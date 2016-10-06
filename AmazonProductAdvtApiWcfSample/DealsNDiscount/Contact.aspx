<%@ Page Title="Deals and Discount contact Information" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="DealsNDiscount.Contact" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup>
        <h2>Deals and Discount contact Information</h2>
    </hgroup>

    <section class="contact">
        <header>
            <h3>Phone:</h3>
        </header>
        <p>
            <span class="label">Main:</span>
            <span>+91 8447628878</span>
        </p>
        <p>
            <span class="label">After Hours:</span>
            <span>+91 9767551022</span>
        </p>
    </section>

    <section class="contact">
        <header>
            <h3>Email:</h3>
        </header>
        <p>
            <span class="label">Support:</span>
            <span><a href="mailto:dealsndiscountscare@gmail.com">dealsndiscountscare@gmail.com</a></span>
        </p>
        <p>
            <span class="label">General:</span>
            <span><a href="contactdealsndiscounts@gmail.com">contactdealsndiscounts@gmail.com</a></span>
        </p>
    </section>

    <section class="contact">
        <header>
            <h3>Address:</h3>
        </header>
        <p>
            Delhi, India<br />
            110092
        </p>
    </section>
</asp:Content>