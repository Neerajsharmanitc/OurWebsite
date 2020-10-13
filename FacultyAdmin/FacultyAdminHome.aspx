<%@ Page 
    Title="Home" 
    Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="FacultyAdminHome.aspx.cs" 
    Inherits="OurWebsite.FacultyAdmin.FacultyAdminHome"
    MasterPageFile="~/Site.Master"  %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %></h1>        

    </hgroup>
    <h2>Hello Admin...</h2>   
    <br/>     
    <h3>  <a href="../FacultyAdmin/ManageFaculty.aspx"> Manage Faculty from here</a></h3>    
    <br/>     
    <h4>  <a href="../FacultyAdmin/ManageFacultyUsers.aspx"> Manage Faculty Users (Students and Teachers ) from here</a></h4>

    </asp:Content>