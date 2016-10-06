using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DealsNDiscount
{
    public partial class LinkGenration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            affilatedLink.NavigateUrl = "#";
            affilatedLinkdisplay.Text = "";
        }

        protected void generateLink_Click(object sender, EventArgs e)
        {
            affilatedLink.NavigateUrl = linkGeneration.Text.Contains("?") ? linkGeneration.Text + "&tag=dealsndisco0c-21" : linkGeneration.Text + "?tag=dealsndisco0c-21";
            affilatedLinkdisplay.Text = affilatedLink.NavigateUrl;
        }
    }
}