using System;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Simple {
	public class AmazonSigningEndpointBehavior : IEndpointBehavior {
        private string accessKeyId = "AKIAJMJ32I6O6BN57E5Q";
        private string secretKey = "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";

		public AmazonSigningEndpointBehavior(string accessKeyId, string secretKey) {
			this.accessKeyId	= accessKeyId;
			this.secretKey		= secretKey;
		}

		public void ApplyClientBehavior(ServiceEndpoint serviceEndpoint, ClientRuntime clientRuntime) {
			clientRuntime.MessageInspectors.Add(new AmazonSigningMessageInspector(accessKeyId, secretKey));
		}

		public void ApplyDispatchBehavior(ServiceEndpoint serviceEndpoint, EndpointDispatcher endpointDispatcher) { return; }
		public void Validate(ServiceEndpoint serviceEndpoint) { return; }
		public void AddBindingParameters(ServiceEndpoint serviceEndpoint, BindingParameterCollection bindingParameters) { return; }
	}
}
