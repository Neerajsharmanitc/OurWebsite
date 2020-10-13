<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="OurWebsite.Contact" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Your contact page.</h2>
    </hgroup>

    <section class="contact">
        <header>
            <h3>Phone:</h3>
        </header>
        <p>
            <span class="label">Main:</span>
            <span>9400850286</span>
        </p>
        <p>
            <span class="label">After Hours:</span>
            <span>0123456789</span>
        </p>
    </section>

    <section class="contact">
        <header>
            <h3>Email:</h3>
        </header>
        <p>
            <span class="label">Support:</span>
            <span><a href="mailto:omer@google.com">neeraj_m170571ca@nitc.ac.in</a></span>
        </p>
        <p>
            <span class="label">Marketing:</span>
            <span><a href="mailto:Awab@government.gov">Awab@government.gov</a></span>
        </p>
        <p>
            <span class="label">General:</span>
            <span><a href="mailto:Alntheer@Apple.com">Alntheer@Apple.com</a></span>
        </p>
    </section>

    <section class="contact">
        <header>
            <h3>Address:</h3>
        </header>
        <p>
           National Institue Of Technology Calicut
           Kerla India.
        </p>
    </section>
</asp:Content>