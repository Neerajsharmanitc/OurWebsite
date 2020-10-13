<%@ Page Language="C#" 
    AutoEventWireup="true" 
    Title="Manage Faculty"
    CodeBehind="ManageFaculty.aspx.cs" 
    MasterPageFile="../Site.Master"
    Inherits="OurWebsite.FacultyAdmin.ManageFaculty" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %></h1>        

    </hgroup>
    <h2>Hello Admin...</h2>   
    <br/>    
    <br/>
    <br/>              
    
    <aside>
       <div>
    <table>
        <tr>
            <td class="auto-style1">
                &nbsp;<asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click"> Manage Departments</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click"> Manage Classes</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                &nbsp;<asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click"> Manage Courses</asp:LinkButton>
            </td>
        </tr>
    </table>

       </div>
           </aside>
    
    
    
    <div id="DivDepartment">
           <asp:Panel runat="server" ID="PnlDep" Visible="False">
        <table>
            
            <tr>
        <td class="auto-style1">
                    &nbsp;
                Department Name: 
                </td>
                <td class="auto-style2">
                    &nbsp;<asp:TextBox ID="DepartmentName" runat="server"></asp:TextBox>
        &nbsp;</td>
                <td class="auto-style3">
                    &nbsp;
                </td>
            </tr>
            <%--<tr>
                <td class="style1">
                    &nbsp;
                Department ID:</td>
                <td class="style2">
                    &nbsp;<asp:TextBox ID="DepartmentID" runat="server" Width="300px"></asp:TextBox>
                </td>
                </tr>--%>
            <tr>
            <td></td>
            <td>
                <asp:Button runat="server" ID="AddDepartmentButton" Text="Add" Width="100px" OnClick="AddDepartmentButton_Click"/>
            </td>
        </tr>
    </table>
    
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
         DataKeyNames="Name,ID,Record" OnRowCommand="GridView2_RowCommand"
            >            
        <Columns>
            <asp:ButtonField DataTextField="Name" HeaderText="Name">
                <HeaderStyle HorizontalAlign="Left" Width="300px"/>
                </asp:ButtonField>

            <asp:BoundField DataField="ID" HeaderText="ID">
                <HeaderStyle HorizontalAlign="Left" Width="70px"/>
                </asp:BoundField>                                               
            
            <asp:ButtonField DataTextField="ID" DataTextFormatString="Delete" 
                    CommandName="Delete" HeaderText="Delete">
                <HeaderStyle Width="50px" HorizontalAlign="Left" />
                <ItemStyle Width="50px" />
                </asp:ButtonField>
            </Columns>                    
    </asp:GridView>
        </asp:Panel>
               </div>
 
    
    
    
    
       <div id="DivClass">
        <asp:Panel runat="server" ID="PnlClass" Visible="False">   
        <table>
           
            <tr>
                <td class ="auto-style1">
                    &nbsp;
                    Select Department:
                </td>
                <td class="auto-style2">
                    &nbsp;<asp:DropDownList ID="DropDownList2" runat="server" Width="300px" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                </td>
            </tr>
            <tr>
        <td class="auto-style1">
                    &nbsp;
                Class Name: 
                </td>
                <td class="auto-style2">
                    &nbsp;<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        &nbsp;</td>
                <td class="auto-style3">
                    &nbsp;
                </td>
            </tr>
            <%--<tr>
                <td class="style1">
                    &nbsp;
                Class ID:</td>
                <td class="style2">
                    &nbsp;<asp:TextBox ID="TextBox4" runat="server" Width="300px"></asp:TextBox>
                </td>
                </tr>--%>
            <tr>
            <td></td>
            <td>
                <asp:Button runat="server" ID="AddClassButton" Text="Add" Width="100px" OnClick="AddClassButton_Click"/>
            </td>
        </tr>
    </table>
    
    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
         DataKeyNames="Name,ID,Record" OnRowCommand="GridView3_RowCommand"
            >            
        <Columns>
            <asp:ButtonField DataTextField="Name" HeaderText="Name">
                <HeaderStyle HorizontalAlign="Left" Width="300px"/>
                </asp:ButtonField>

            <asp:BoundField DataField="ID" HeaderText="ID">
                <HeaderStyle HorizontalAlign="Left" Width="70px"/>
                </asp:BoundField>                                               
            
            <asp:ButtonField DataTextField="ID" DataTextFormatString="Delete" 
                    CommandName="Delete" HeaderText="Delete">
                <HeaderStyle Width="50px" HorizontalAlign="Left" />
                <ItemStyle Width="50px" />
                </asp:ButtonField>
            </Columns>                    
    </asp:GridView>
        </asp:Panel>
            </div>
 
    
    
       <div id="DivCourse">
           <asp:Panel runat="server"  ID="PnlCourse" Visible="False">
        <table>
            <tr>
                <td class ="auto-style1">
                    &nbsp;
                    Select Department:
                </td>
                <td class="auto-style2">
                    &nbsp;<asp:DropDownList ID="DropDownList6" runat="server" Width="300px" OnSelectedIndexChanged="DropDownList6_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class ="auto-style1">
                    &nbsp;
                    Select Class:
                </td>
                <td class="auto-style2">
                    &nbsp;<asp:DropDownList ID="DropDownList3" runat="server" Width="300px" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                </td>
            </tr>
            <tr>
        <td class="auto-style1">
                    &nbsp;
                Course Name: 
                </td>
                <td class="auto-style2">
                    &nbsp;<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        &nbsp;</td>
                <td class="auto-style3">
                    &nbsp;
                </td>
            </tr>
            <%--<tr>
                <td class="style1">
                    &nbsp;
                Course ID:</td>
                <td class="style2">
                    &nbsp;<asp:TextBox ID="TextBox6" runat="server" Width="300px"></asp:TextBox>
                </td>
                </tr>--%>
            <tr>
            <td></td>
            <td>
                <asp:Button runat="server" ID="AddCourseButton" Text="Add" Width="100px" OnClick="AddCourseButton_Click"/>
            </td>
        </tr>
    </table>
    
    <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" 
         DataKeyNames="Name,ID,Record" OnRowCommand="GridView4_RowCommand"
            >            
        <Columns>
            <asp:ButtonField DataTextField="Name" HeaderText="Name">
                <HeaderStyle HorizontalAlign="Left" Width="300px"/>
                </asp:ButtonField>

            <asp:BoundField DataField="ID" HeaderText="ID">
                <HeaderStyle HorizontalAlign="Left" Width="70px"/>
                </asp:BoundField>                                               
            
            <asp:ButtonField DataTextField="ID" DataTextFormatString="Delete" 
                    CommandName="Delete" HeaderText="Delete">
                <HeaderStyle Width="50px" HorizontalAlign="Left" />
                <ItemStyle Width="50px" />
                </asp:ButtonField>
            </Columns>                    
    </asp:GridView>
        </asp:Panel>
               </div>
 

    </asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .auto-style1 {
            width: 163px;
        }
    </style>
</asp:Content>