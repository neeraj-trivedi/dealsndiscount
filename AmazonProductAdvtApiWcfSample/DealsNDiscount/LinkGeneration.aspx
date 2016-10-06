<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LinkGeneration.aspx.cs" Inherits="DealsNDiscount.LinkGenration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:TextBox id="linkGeneration" Text="" runat="server"></asp:TextBox>
        <asp:Button ID="generateLink" runat="server" Text="Generate Link" OnClick="generateLink_Click" />

        <div>
            <asp:HyperLink ID="affilatedLink" runat="server">Go for it</asp:HyperLink>
            <asp:Label ID="affilatedLinkdisplay" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>
