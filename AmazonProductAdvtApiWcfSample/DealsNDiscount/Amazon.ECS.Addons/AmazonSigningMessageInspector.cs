﻿using System;
using System.Security.Cryptography;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Text.RegularExpressions;

namespace Simple {
	public class AmazonSigningMessageInspector : IClientMessageInspector {
        private string accessKeyId = "AKIAJMJ32I6O6BN57E5Q";
        private string secretKey = "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";

		public AmazonSigningMessageInspector(string accessKeyId, string secretKey) {
			this.accessKeyId	= accessKeyId;
			this.secretKey		= secretKey;
		}

		public object BeforeSendRequest(ref Message request, IClientChannel channel) {
			// prepare the data to sign
			string		operation		= Regex.Match(request.Headers.Action, "[^/]+$").ToString();
			DateTime	now				= DateTime.UtcNow;
			string		timestamp		= now.ToString("yyyy-MM-ddTHH:mm:ssZ");
			string		signMe			= operation + timestamp;
			byte[]		bytesToSign		= Encoding.UTF8.GetBytes(signMe);

			// sign the data
			byte[]		secretKeyBytes	= Encoding.UTF8.GetBytes(secretKey);
			HMAC		hmacSha256		= new HMACSHA256(secretKeyBytes);
			byte[]		hashBytes		= hmacSha256.ComputeHash(bytesToSign);
			string		signature		= Convert.ToBase64String(hashBytes);

			// add the signature information to the request headers
			request.Headers.Add(new AmazonHeader("AWSAccessKeyId", accessKeyId));
			request.Headers.Add(new AmazonHeader("Timestamp", timestamp));
			request.Headers.Add(new AmazonHeader("Signature", signature));

			return null;
		}

		public void AfterReceiveReply(ref Message reply, object correlationState) { }
	}
}
