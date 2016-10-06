using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ServiceModel;
using DealsNDiscount.Amazon.ECS;
using DealsNDiscount.Models;

namespace DealsNDiscount
{

    public partial class _Default : Page
    {
        private const string accessKeyId = "AKIAJMJ32I6O6BN57E5Q";
        private const string secretKey = "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";

        protected void Page_Load(object sender, EventArgs e)
        {
            // create a WCF Amazon ECS client
            BasicHttpBinding binding = new BasicHttpBinding(BasicHttpSecurityMode.Transport);
            binding.MaxReceivedMessageSize = int.MaxValue;
            AWSECommerceServicePortTypeClient client = new AWSECommerceServicePortTypeClient(
                binding,
                new EndpointAddress("https://webservices.amazon.in/onca/soap?Service=AWSECommerceService"));



            // add authentication to the ECS client
            client.ChannelFactory.Endpoint.Behaviors.Add(new Simple.AmazonSigningEndpointBehavior(accessKeyId, secretKey));

            // prepare an ItemSearch request
            ItemSearchRequest request = new ItemSearchRequest();
            request.SearchIndex = "Electronics";
            request.Keywords = "laptop";
            request.ItemPage = "1";
            request.ResponseGroup = new string[] { "Large" };

            ItemSearchRequest request2 = new ItemSearchRequest();
            request2.SearchIndex = "Electronics";
            request2.Keywords = "smartphone";
            request2.ItemPage = "2";
            request2.ResponseGroup = new string[] { "Large" };

            // batch the two requests together
            ItemSearch itemSearch = new ItemSearch();
            itemSearch.Request = new ItemSearchRequest[] { request, request2 };
            itemSearch.AWSAccessKeyId = accessKeyId;
            itemSearch.AssociateTag = "dealsndisco0c-21";


            // issue the ItemSearch request
            ItemSearchResponse response = client.ItemSearch(itemSearch);

            List<Product> products = new List<Product>();
            List<Product> products1 = new List<Product>();

            // write out the results
            foreach (var item in response.Items[0].Item)
            {
                products.Add(new Product()
                {
                    Title = item.ItemAttributes.Title,
                    DetailPageUrl = item.DetailPageURL,
                    ThumbnailUrl = item.ImageSets[0].MediumImage.URL
                    //Price = item.OfferSummary.LowestNewPrice.FormattedPrice
                });
            }
            foreach (var item in response.Items[1].Item)
            {
                products1.Add(new Product()
                {
                    Title = item.ItemAttributes.Title,
                    DetailPageUrl = item.DetailPageURL,
                    ThumbnailUrl = item.ImageSets[0].MediumImage.URL
                    //Price = item.OfferSummary.LowestNewPrice.FormattedPrice
                });
            }

            listview1.DataSource = products;
            listview1.DataBind();
            listview2.DataSource = products1;
            listview2.DataBind();
        }
    }
}