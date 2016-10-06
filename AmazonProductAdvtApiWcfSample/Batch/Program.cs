using System;
using System.ServiceModel;
using Batch.Amazon.ECS;

namespace Batch {
	class Program {
		// your Amazon ID's
		private const string accessKeyId	= "XXXXXXXXXXXXXXXXXXXX";
		private const string secretKey		= "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";

		// the program starts here
		static void Main(string[] args) {

			// create a WCF Amazon ECS client
			BasicHttpBinding binding		= new BasicHttpBinding(BasicHttpSecurityMode.Transport);
			binding.MaxReceivedMessageSize	= int.MaxValue;
			AWSECommerceServicePortTypeClient client = new AWSECommerceServicePortTypeClient(
				binding,
				new EndpointAddress("https://webservices.amazon.com/onca/soap?Service=AWSECommerceService"));

			// add authentication to the ECS client
			client.ChannelFactory.Endpoint.Behaviors.Add(new AmazonSigningEndpointBehavior(accessKeyId, secretKey));

			// prepare the first ItemSearchRequest
			ItemSearchRequest request1	= new ItemSearchRequest();
			request1.SearchIndex		= "Books";
			request1.Keywords			= "WCF";
			request1.ItemPage			= "1";
			request1.ResponseGroup 		= new string[] { "Small" };

			// prepare a second ItemSearchRequest
			ItemSearchRequest request2	= new ItemSearchRequest();
			request2.SearchIndex		= "Books";
			request2.Keywords			= "WCF";
			request2.ItemPage			= "2";
			request2.ResponseGroup		= new string[] { "Small" };

			// batch the two requests together
			ItemSearch itemSearch		= new ItemSearch();
			itemSearch.Request			= new ItemSearchRequest[] { request1, request2 };
			itemSearch.AWSAccessKeyId	= accessKeyId;

			// issue the ItemSearch request
			ItemSearchResponse response	= client.ItemSearch(itemSearch);

			// write out the results
			foreach (var item in response.Items[0].Item) {
				Console.WriteLine(item.ItemAttributes.Title);
			}
			foreach (var item in response.Items[1].Item) {
				Console.WriteLine(item.ItemAttributes.Title);
			}
		}
	}
}
