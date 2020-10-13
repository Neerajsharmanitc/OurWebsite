<%@ Page 
    Title="Home" 
    Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="StudentHome.aspx.cs" 
    Inherits="OurWebsite.Student.StudentHome"
    MasterPageFile="~/Site.Master"  %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %></h1>        
    </hgroup>    
            <h2> Hello Student... </h2>
    <p>
        Click on My Files to start uploading your own files.    
    </p>
    <br/>     
    <h3><a href="../Student/Class.aspx"> Go to your shared class files from here</a></h3>
    <br/>
    
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GoToStudentCourse" 
        DataKeyNames="Name,ID">                                
        <Columns>
            <asp:ButtonField DataTextField="Name" CommandName="Open" HeaderText="Courses">
                <HeaderStyle HorizontalAlign="Left" Width="300px"/>
                </asp:ButtonField>
            </Columns>
    </asp:GridView>
   

    </asp:Content> 
