<%@ Page 
    Title="Home" 
    Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="TeacherHome.aspx.cs" 
    Inherits="OurWebsite.Teacher.TeacherHome"
    MasterPageFile="~/Site.Master"  %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %></h1>        
    </hgroup>
    <h2>Hello Teacher...</h2>
    <p>Click on one of the courses to see the students' uploaded files.</p>
    <p>Click on My Files to start uploading files for students to see.</p>
    
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="Course, CourseID" OnRowCommand="GridView1_RowCommand">                                
        <Columns>
            <asp:ButtonField DataTextField="Course" CommandName="Open" HeaderText="Courses">
                <HeaderStyle HorizontalAlign="Left" Width="300px"/>
                </asp:ButtonField>
            </Columns>
    </asp:GridView>
    </asp:Content> 
