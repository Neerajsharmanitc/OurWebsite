
<%@ Page Language="C#" Title="Shared Files" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="SharedFolders.aspx.cs" Inherits="OurWebsite.Files.SharedFolders" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>
            <br />
        </h1>        
    </hgroup>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        onrowcommand="GridView1_RowCommand" DataKeyNames="Type,FullPath,Location,Name"
            onrowdatabound="GridView1_RowDataBound" DataSourceID="SqlDataSource1">
            
        <Columns>
            <asp:ButtonField DataTextField="Name" CommandName="Open" HeaderText="Name">
                <HeaderStyle HorizontalAlign="Left" Width="300px"/>
                </asp:ButtonField>

            <asp:BoundField DataField="Type" HeaderText="Type">
                <HeaderStyle HorizontalAlign="Left" Width="70px"/>
                </asp:BoundField>                                               
            </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
    <br />
    <br />
    <div>
        <table style="width: 100%;">
            <tr>
                <td class="auto-style1">
                    Current Location: 
                </td>
                <td>
                    <asp:Panel ID="pnlCurrentLocation" runat="server" style="margin-left: 0px"></asp:Panel>
                </td>
            </tr>
        </table>
        
    </div>   
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"
        Font-Size="Small" onrowcommand="GridView2_RowCommand" DataKeyNames="Type,FullPath,Location,Name"
            onrowdatabound="GridView2_RowDataBound"  CellPadding="4" 
        ForeColor="#333333" GridLines="None" >
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
    </asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .auto-style1 {
            width: 118px;
            direction: ltr;
        }
    </style>
</asp:Content>

