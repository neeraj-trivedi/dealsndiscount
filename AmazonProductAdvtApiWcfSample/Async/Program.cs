using System;
using System.ServiceModel;
using Async.Amazon.ECS;

namespace Async {
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

			// prepare an ItemSearch request
			ItemSearchRequest request	= new ItemSearchRequest();
			request.SearchIndex			= "Books";
			request.Title				= "WCF";
			request.ResponseGroup 		= new string[] { "Small" };

			ItemSearch itemSearch		= new ItemSearch();
			itemSearch.Request			= new ItemSearchRequest[] { request };
			itemSearch.AWSAccessKeyId	= accessKeyId;

			// prepare to handle the results, once the async request is completed
			client.ItemSearchCompleted += (source, e) => {
				// write out the results
				foreach (var item in e.Result.Items[0].Item) {
					Console.WriteLine(item.ItemAttributes.Title);
				}
			};

			// issue the ItemSearch request
			client.ItemSearchAsync(itemSearch);
			Console.WriteLine("Waiting for results...");

			// wait for results
			Console.ReadKey();
		}
	}
}
