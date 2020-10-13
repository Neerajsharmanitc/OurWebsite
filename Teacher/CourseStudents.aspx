<%@ Page 
    Title="Class Files" 
    Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="CourseStudents.aspx.cs" 
    Inherits="OurWebsite.Teacher.CourseStudents"
    MasterPageFile="~/Site.Master"  %>

    <%@ PreviousPageType VirtualPath="../Teacher/TeacherHome.aspx" %> 

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %></h1>        
    </hgroup>        
    
    <div id="divFileUpload">
         Choose the file you want to upload:
        <br />
        <asp:FileUpload ID="fuChooseFile" runat="server" Width="513px" Height="40px" title="Select the file"/>
        <asp:Button ID="btnUpload" runat="server" Text="Upload" Width="131px" 
            onclick="btnUpload_Click" Height="40px" title="Upload the file"/> <%--get back to this--%>
         <br />
    </div>
     <div>
        <asp:Label ID="lbMessage" runat="server" ForeColor="Blue"></asp:Label>
    </div>
    <div>
        <br />
        <aside>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"
        Font-Size="Small" onrowcommand="GridView2_RowCommand" DataKeyNames="Type,FName,Name" CellPadding="4" 
        ForeColor="#333333" GridLines="None" Visible="False">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
             <asp:ButtonField DataTextField="Name" CommandName="Open" HeaderText="Name">
                <HeaderStyle HorizontalAlign="Left" Width="300px" />
                </asp:ButtonField>
                
                <asp:BoundField DataField="Size" HeaderText="Size">
                <HeaderStyle HorizontalAlign="Left" Width="100px"/>
                </asp:BoundField>
                
                <asp:BoundField DataField="UploadTime" 
                    HeaderText="Upload Time">
                <HeaderStyle HorizontalAlign="Left" Width="200px" />
                </asp:BoundField>
                
                <asp:BoundField DataField="Type" HeaderText="Type">
                <HeaderStyle HorizontalAlign="Left" Width="70px" />
                </asp:BoundField>                                              
            </Columns>        
        <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Height="18px" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" Height="16px" ForeColor="#333333"/>
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>   
    </aside>    
    <br/>
    <br/>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        onrowcommand="GridView1_RowCommand" DataKeyNames="Name, UserID"
            onrowdatabound="GridView1_RowDataBound" Width="363px">            
        <Columns>
            <asp:ButtonField DataTextField="Name" CommandName="Open" HeaderText="Student Name">
                <HeaderStyle HorizontalAlign="Left" Width="300px"/>
                </asp:ButtonField>                                                        
            </Columns>
    </asp:GridView>
    </div>
    </asp:Content> 
