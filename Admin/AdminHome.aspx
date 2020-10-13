<%@ Page 
    Title="Home" 
    Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="AdminHome.aspx.cs" 
    Inherits="OurWebsite.Admin.AdminHome"
    MasterPageFile="~/Site.Master"  %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %></h1>        

    </hgroup>
    <h2>Hello Admin...</h2>   
    <br/>     
    <h3><a href="../Admin/ManageUsers.aspx"> Manage Users from here</a></h3>
    <br/>
    <br/>
    <h4><a href="../Admin/ManageUniversity.aspx"> Manage University from here</a></h4>
    </asp:Content>