using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace DealsNDiscount.Models
{
    public class Product
    {
        private string title;
        private string detailPageUrl;
        private string thumbnailUrl;
        private string price;

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }

        public string DetailPageUrl
        {
            get
            {
                return detailPageUrl;
            }

            set
            {
                detailPageUrl = value;
            }
        }

        public string ThumbnailUrl
        {
            get
            {
                return thumbnailUrl;
            }

            set
            {
                thumbnailUrl = value;
            }
        }

        public string Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }
    }
}