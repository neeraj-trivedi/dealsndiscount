<%@ Page Title="Deals N Discounts" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DealsNDiscount._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
           <%-- <hgroup class="title">
            </hgroup>
            <div style="width: 300px; height: 250px; border-width: 0px; display: inline-block;">
                <div data-wrid="WRID-147565127446756151" data-widgettype="Push Content" data-class="affiliateAdsByFlipkart" isloaded="y" style="width: 300px; height: 250px;">
                    <iframe src="http://affiliate.flipkart.com/widget/displayWidget?wrid=WRID-147565127446756151&amp;environment={}" style="width: 300px; height: 250px; border-width: 0px;"></iframe>
                </div>
                <script async="" src="//affiliate.flipkart.com/affiliate/widgets/FKAffiliateWidgets.js"></script>
            </div>

            <div style="width: 300px; height: 250px; border-width: 0px; display: inline-block;">
                <div data-sdid="46489592" data-identifier="SnapdealAffiliateAds" data-height="250" data-width="300" isloaded="true" style="width: 300px; height: 250px; border-width: 0px;">
                    <iframe src="http://affiliate-ads.snapdeal.com/affiliate/bannerdata/46489592" style="width: 300px; height: 250px; border-width: 0px;"></iframe>
                </div>
                <script async="" id="snap_zxcvbnhg" src="//affiliate-ads.snapdeal.com/affiliate/js/snapdealAffiliate.js"></script>
            </div>
            <div style="width: 300px; height: 250px; border-width: 0px; display: inline-block;">
                <script type="text/javascript" language="javascript">
                    var aax_size = '300x250';
                    var aax_pubname = 'doozydeals-21';
                    var aax_src = '302';
                </script>
                <script type="text/javascript" language="javascript" src="//c.amazon-adsystem.com/aax2/assoc.js"></script>
            </div>--%>
            <script charset="utf-8" type="text/javascript">
                amzn_assoc_ad_type = "responsive_search_widget";
                amzn_assoc_tracking_id = "dealsndisco0c-21";
                amzn_assoc_marketplace = "amazon";
                amzn_assoc_region = "IN";
                amzn_assoc_placement = "";
                amzn_assoc_search_type = "search_widget";
                amzn_assoc_width = "auto";
                amzn_assoc_height = "auto";
                amzn_assoc_default_search_category = "";
                amzn_assoc_default_search_key = "Mobile";
                amzn_assoc_theme = "light";
                amzn_assoc_bg_color = "FFFFFF";
</script>
<script src="//z-in.amazon-adsystem.com/widgets/q?ServiceVersion=20070822&Operation=GetScript&ID=OneJS&WS=1&MarketPlace=IN"></script>

          <%--  --%>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>We suggest the following: laptops</h3>
    <div style="overflow-x:auto;width:100%">
    <asp:ListView ID="listview1" runat="server">
        <LayoutTemplate>
            <table>
                <tr>
                    
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server">
                        
                    </asp:PlaceHolder>
                       
                </tr>
            </table>
        </LayoutTemplate>
        <ItemTemplate>

            <td>
               
                    <asp:HyperLink ID="HyperLink1" NavigateUrl="<%#Bind('DetailPageUrl')%>" runat="server">

                        <asp:Label ID="Label1" runat="server" Text="<%#Bind('Title')%>" Width="200px" CssClass="title" />

                        <asp:Image ID="Image1" runat="server" ImageUrl="<%#Bind('ThumbnailUrl')%>" Width="200px" Height="200px" ImageAlign="Top" CssClass="title" />
                    </asp:HyperLink></td></ItemTemplate></asp:ListView></div><br />
    <h3>We suggest the following: Smartphones</h3><div style="overflow-x:auto;width:100%">
    <asp:ListView ID="listview2" runat="server">
        <LayoutTemplate>
            <table>
                <tr>
                    
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server">
                        
                    </asp:PlaceHolder>
                       
                </tr>
            </table>
        </LayoutTemplate>
        <ItemTemplate>

            <td>
               
                    <asp:HyperLink ID="HyperLink1" NavigateUrl="<%#Bind('DetailPageUrl')%>" runat="server">

                        <asp:Label ID="Label1" runat="server" Text="<%#Bind('Title')%>" Width="200px" CssClass="title" />

                        <asp:Image ID="Image1" runat="server" ImageUrl="<%#Bind('ThumbnailUrl')%>" Width="200px" Height="200px" ImageAlign="Top" CssClass="title" />
                    </asp:HyperLink></td></ItemTemplate></asp:ListView></div></asp:Content>