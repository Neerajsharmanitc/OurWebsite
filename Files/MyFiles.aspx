 <%@ Page 
     Title="My Files" 
     Language="C#" 
     MasterPageFile="~/Site.Master" 
     AutoEventWireup="true"  
     CodeBehind="MyFiles.aspx.cs" 
     Inherits="OurWebsite.Files.MyFiles" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %></h1>        
    </hgroup>
	<aside>        
        <ul>
            <li><a id="A1" runat="server" href="~/Files/SharedFolders.aspx">Shared Folders</a></li>
        </ul>
    </aside>    
    <style type="text/css">
        #fu
        {
            width: 600px;
        }
        .style1
        {
            width: 110px;
        }
        .style2
        {
            width: 472px;
        }
        .auto-style1 {
            width: 110px;
            height: 23px;
        }
        .auto-style2 {
            width: 472px;
            height: 23px;
        }
        .auto-style3 {
            height: 23px;
        }
    </style>
	
    <div  runat="server">                	
        <div id="form1">    
    <div id="divFileUpload">
         Choose the file you want to upload:
        <br />
        <asp:FileUpload ID="fuChooseFile" runat="server" Width="513px" Height="40px" title="Select the file"/>
        <asp:Button ID="btnUpload" runat="server" Text="Upload" Width="131px" 
            onclick="btnUpload_Click" Height="40px" title="Upload the file"/>
    </div>
                        
    <div id="divNewFolder">
         Input the name of the folder you want to create:
        <br/>
        <asp:TextBox ID="tbNewFolderName" runat="server" Width="500px" Height="28px"></asp:TextBox>
        <asp:Button ID="btnNewFolder" runat="server" Text="Create Folder" Height="40px" 
            Width="131px" onclick="btnNewFolder_Click" />
        <asp:Panel ID="pnlRename" runat="server" Visible = "false">
            <table style="width: 100%;">
            <tr>
                <td colspan= "3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">
                    &nbsp;
                Old Name: 
                </td>
                <td class="auto-style2">
                    &nbsp;<asp:Label ID="lbOldName" runat="server"></asp:Label>
        &nbsp;</td>
                <td class="auto-style3">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;
                New Name:</td>
                <td class="style2">
                    &nbsp;<asp:TextBox ID="tbNewName" runat="server" Width="300px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style2">
        <asp:Button ID="btnCancle" runat="server" Text="Cancel" Width="100px" 
                        onclick="btnCancle_Click" Height="30px" /> 
        &nbsp;&nbsp; 
        <asp:Button ID="btnRename" runat="server" Text="Rename" Width="100px" 
                        onclick="btnRename_Click" Height="30px" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        </asp:Panel>
    </div>
    <div>
        <asp:Label ID="lbMessage" runat="server" ForeColor="Blue"></asp:Label>
    </div>
    <div>
        <table style="width: 100%;">
            <tr>
                <td class="style1">
                    Current Location: 
                </td>
                <td>
                    <asp:Panel ID="pnlCurrentLocation" runat="server" style="margin-left: 0px"></asp:Panel>
                </td>
            </tr>
        </table>        
    </div>                
    <asp:GridView ID="gvFileSystem" runat="server" AutoGenerateColumns="False" DataKeyNames="Type,FullPath,Location,Name"
            Font-Size="Small" onrowcommand="gvFileSystem_RowCommand" 
            onrowdatabound="gvFileSystem_RowDataBound" CellPadding="4" 
        ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:ButtonField DataTextField="Name" CommandName="Open" HeaderText="Name">
                <HeaderStyle HorizontalAlign="Left" Width="300px" />
                </asp:ButtonField>
                
                <asp:BoundField DataField="Size" HeaderText="Size">
                <HeaderStyle HorizontalAlign="Left" Width="90px"/>
                </asp:BoundField>
                
                <asp:BoundField DataField="UploadTime" 
                    HeaderText="Upload Time">
                <HeaderStyle HorizontalAlign="Left" Width="200px" />
                </asp:BoundField>
                
                <asp:BoundField DataField="Type" HeaderText="Type">
                <HeaderStyle HorizontalAlign="Left" Width="70px" />
                </asp:BoundField>
                
                <asp:ButtonField DataTextField="FullPath" DataTextFormatString="Delete" 
                    CommandName="DeleteFileOrFolder" HeaderText="Delete">
                <HeaderStyle Width="50px" HorizontalAlign="Left" />
                <ItemStyle Width="50px" />
                </asp:ButtonField>
                
                <asp:ButtonField CommandName="Rename" DataTextField="FullPath" 
                    DataTextFormatString="Rename" Text="ButtonField" HeaderText="Rename" />
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
        </div>
    </div>    
</asp:Content>
