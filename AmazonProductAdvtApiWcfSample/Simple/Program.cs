using System;
using System.ServiceModel;
using Simple.Amazon.ECS;

namespace Simple {
	class Program {
		// your Amazon ID's
        private const string accessKeyId = "AKIAJMJ32I6O6BN57E5Q";
        private const string secretKey = "5LIKYfK8mYUZhKvGuuUlkLR9MvFmKHUECOhoeBrR";

		// the program starts here
		static void Main(string[] args) {

			// create a WCF Amazon ECS client
			BasicHttpBinding binding		= new BasicHttpBinding(BasicHttpSecurityMode.Transport);
			binding.MaxReceivedMessageSize	= int.MaxValue;
			AWSECommerceServicePortTypeClient client = new AWSECommerceServicePortTypeClient(
				binding,
                new EndpointAddress("https://webservices.amazon.in/onca/soap?Service=AWSECommerceService"));

        

			// add authentication to the ECS client
			client.ChannelFactory.Endpoint.Behaviors.Add(new AmazonSigningEndpointBehavior(accessKeyId, secretKey));

			// prepare an ItemSearch request
			ItemSearchRequest request	= new ItemSearchRequest();
			request.SearchIndex			= "All";
			request.Keywords				= "iphone";
			request.ResponseGroup 		= new string[] { "Images","Small" };

			ItemSearch itemSearch		= new ItemSearch();
			itemSearch.Request			= new ItemSearchRequest[] { request };
			itemSearch.AWSAccessKeyId	= accessKeyId;
            itemSearch.AssociateTag = "wwwdealsndi02-21";

			// issue the ItemSearch request
			ItemSearchResponse response	= client.ItemSearch(itemSearch);

			// write out the results
			foreach (var item in response.Items[0].Item) {
				Console.WriteLine(item.ItemAttributes.Title);
			}
		}
	}
}
