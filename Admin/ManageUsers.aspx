<%@ Page 
    Title="Manage Users" 
    Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="ManageUsers.aspx.cs" 
    Inherits="OurWebsite.Admin.ManageUsers"
    MasterPageFile="~/Site.Master"  %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %></h1>        
    </hgroup>    
        <br/>
        <br/>
    <h2>Hello Admin...</h2>         
        <br/>
        <br/>
    <div>
    <table>
       <tr>
            <td class="auto-style1">
                &nbsp;<asp:LinkButton ID="LinkButton0" runat="server" OnClick="LinkButton0_Click">Create Users</asp:LinkButton> 
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                &nbsp;<asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Manage Users</asp:LinkButton>
            </td>
        </tr>              
    </table>        
    </div>
    
    
    <div id="divCreate">
        <asp:Panel runat="server" ID ="StudentPanel" Visible="False">
    <table>
                <tr>
                    <td>&nbsp;Select Faculty: </td>
                    <td>&nbsp;<asp:DropDownList ID="DropDownList2" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;Select Department: </td>
                    <td>&nbsp;<asp:DropDownList ID="DropDownList3" runat="server" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;Select Class: </td>
                    <td>&nbsp;<asp:DropDownList ID="DropDownList4" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
   </asp:panel>


            <asp:Panel runat="server" ID ="FacultyAdminPanel" Visible="False">

    <table>
                <tr>
                    <td>&nbsp;Select Faculty: </td>
                    <td>&nbsp;<asp:DropDownList ID="DropDownList5" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                </tr>
               
            </table>
   </asp:panel>
             
        <asp:Panel runat="server" ID ="PnlCreate" Visible="False">
            <br/>
    <table>
   <tr>
       <td>
           &nbsp;Select Role:
       </td>
            <td>
                 &nbsp;<asp:DropDownList runat="server" ID="DropDownList1" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
            <asp:ListItem>Student</asp:ListItem>
            <asp:ListItem>Teacher</asp:ListItem>
            <asp:ListItem>Faculty Admin</asp:ListItem>
            <asp:ListItem>Admin</asp:ListItem>
        </asp:DropDownList>
            </td>
        </tr>  
    </table>
   
            <br />
   
            
   
    <br/>

        <br/>

            <li>
         <asp:Label ID="Label1" runat="server" AssociatedControlID="FirstName">First name</asp:Label>
         <asp:TextBox runat="server" ID="FirstName" />
         <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="FirstName"
             CssClass="field-validation-error" ErrorMessage="The First name field is required." />
         
         <asp:Label ID="Label2" runat="server" AssociatedControlID="MiddleName">Middle name</asp:Label>
         <asp:TextBox runat="server" ID="MiddleName" />
         <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="MiddleName"
             CssClass="field-validation-error" ErrorMessage="The Middle name field is required." />
         
         <asp:Label ID="Label3" runat="server" AssociatedControlID="LastName">Last name</asp:Label>
         <asp:TextBox runat="server" ID="LastName" />
         <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="LastName"
             CssClass="field-validation-error" ErrorMessage="The Last name field is required." />

     </li>
   
    <asp:CreateUserWizard LoginCreatedUser="False" runat="server" ID="RegisterUser" ViewStateMode="Disabled" OnCreatedUser="RegisterUser_CreatedUser">
        <LayoutTemplate>
            <asp:PlaceHolder runat="server" ID="wizardStepPlaceholder" />
            <asp:PlaceHolder runat="server" ID="navigationPlaceholder" />
        </LayoutTemplate>
        <WizardSteps>
            <asp:CreateUserWizardStep runat="server" ID="RegisterUserWizardStep">
                <ContentTemplate>
                    <p class="message-info">
                        Passwords are required to be a minimum of <%: Membership.MinRequiredPasswordLength %> characters in length.
                    </p>

                    <p class="validation-summary-errors">
                        <asp:Literal runat="server" ID="ErrorMessage" />
                    </p>

                    <fieldset>
                        <legend>Registration Form</legend>
                        <ol>
                            <li>
                                <asp:Label ID="Label1" runat="server" AssociatedControlID="UserName">User name</asp:Label>
                                <asp:TextBox runat="server" ID="UserName" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="UserName"
                                    CssClass="field-validation-error" ErrorMessage="The user name field is required." />
                            </li>
                            <li>
                                <asp:Label ID="Label2" runat="server" AssociatedControlID="Email">Email address</asp:Label>
                                <asp:TextBox runat="server" ID="Email" TextMode="Email" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Email"
                                    CssClass="field-validation-error" ErrorMessage="The email address field is required." />
                            </li>
                            <li>
                                <asp:Label ID="Label3" runat="server" AssociatedControlID="Password">Password</asp:Label>
                                <asp:TextBox runat="server" ID="Password" TextMode="Password" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Password"
                                    CssClass="field-validation-error" ErrorMessage="The password field is required." />
                            </li>
                            <li>
                                <asp:Label ID="Label4" runat="server" AssociatedControlID="ConfirmPassword">Confirm password</asp:Label>
                                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ConfirmPassword"
                                     CssClass="field-validation-error" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                                     CssClass="field-validation-error" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
                            </li>
                        </ol>
                        <asp:Button ID="Button1" runat="server" CommandName="MoveNext" Text="Register" />
                    </fieldset>
                </ContentTemplate>
                <CustomNavigationTemplate />
            </asp:CreateUserWizardStep>
        </WizardSteps>
    </asp:CreateUserWizard>
    </asp:panel>

        </div>

        


    <div>
<asp:Panel runat="server" ID="PnlManage" Visible="False">

        
        
        <asp:GridView runat="server" ID="GridView1" 
            AutoGenerateColumns="False" 
            DataKeyNames="Name,UserID"
            OnRowCommand="GridView1_RowCommand">
            <Columns>
                <asp:ButtonField DataTextField="Name" HeaderText="Name">
                <HeaderStyle HorizontalAlign="Left" Width="300px"/>
                </asp:ButtonField>

            <asp:BoundField DataField="UserID" HeaderText="User ID">
                <HeaderStyle HorizontalAlign="Left" Width="70px"/>
                </asp:BoundField>     
                 
                <asp:BoundField DataField="Type" HeaderText="Type">
                <HeaderStyle HorizontalAlign="Left" Width="80px"/>
                </asp:BoundField>                                          
            
            <asp:ButtonField DataTextField="UserID" DataTextFormatString="Delete" 
                    CommandName="DeleteUser" HeaderText="Delete">
                <HeaderStyle Width="50px" HorizontalAlign="Left" />
                <ItemStyle Width="50px" />
                </asp:ButtonField>
                <asp:ButtonField DataTextField="UserID" DataTextFormatString="Edit" 
                    CommandName="EditRole" HeaderText="Edit Roles">
                <HeaderStyle Width="100px" HorizontalAlign="Left" />
                <ItemStyle Width="50px" />
                </asp:ButtonField>
                
                <asp:ButtonField DataTextField="UserID" DataTextFormatString="Edit" 
                    CommandName="EditPassword" HeaderText="Edit Passwords">
                <HeaderStyle Width="200px" HorizontalAlign="Left"/>
                <ItemStyle Width="50px" />
                </asp:ButtonField>
                
            </Columns>
        </asp:GridView>

<aside>
    <asp:Panel runat="server" ID="RoleEditPnl" Visible="False">

            <asp:RadioButtonList ID="RadioButtonList1" runat="server" Visible="true" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                <asp:ListItem>Student</asp:ListItem>
                <asp:ListItem>Teacher</asp:ListItem>
                <asp:ListItem>Faculty Admin</asp:ListItem>
                <asp:ListItem>Admin</asp:ListItem>
        </asp:RadioButtonList>
            <br />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Confirm" />
        </asp:Panel>
        </aside>
        
            <asp:PlaceHolder runat="server" ID="changePassword" Visible="false">
            <h3>Change password</h3>
            <asp:ChangePassword ID="ChangePassword1" runat="server" CancelDestinationPageUrl="~/" ViewStateMode="Disabled" RenderOuterTable="false" SuccessPageUrl="Manage?m=ChangePwdSuccess">
                <ChangePasswordTemplate>
                    <p class="validation-summary-errors">
                        <asp:Literal runat="server" ID="FailureText" />
                    </p>
                    <fieldset class="changePassword">
                        <legend>Change password details</legend>
                        <ol>
                            <li>
                                <asp:Label runat="server" ID="CurrentPasswordLabel" AssociatedControlID="CurrentPassword">Current password</asp:Label>
                                <asp:TextBox runat="server" ID="CurrentPassword" CssClass="passwordEntry" TextMode="Password" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="CurrentPassword"
                                    CssClass="field-validation-error" ErrorMessage="The current password field is required."
                                    ValidationGroup="ChangePassword" />
                            </li>
                            <li>
                                <asp:Label runat="server" ID="NewPasswordLabel" AssociatedControlID="NewPassword">New password</asp:Label>
                                <asp:TextBox runat="server" ID="NewPassword" CssClass="passwordEntry" TextMode="Password" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="NewPassword"
                                    CssClass="field-validation-error" ErrorMessage="The new password is required."
                                    ValidationGroup="ChangePassword" />
                            </li>
                            <li>
                                <asp:Label runat="server" ID="ConfirmNewPasswordLabel" AssociatedControlID="ConfirmNewPassword">Confirm new password</asp:Label>
                                <asp:TextBox runat="server" ID="ConfirmNewPassword" CssClass="passwordEntry" TextMode="Password" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ConfirmNewPassword"
                                    CssClass="field-validation-error" Display="Dynamic" ErrorMessage="Confirm new password is required."
                                    ValidationGroup="ChangePassword" />
                                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword"
                                    CssClass="field-validation-error" Display="Dynamic" ErrorMessage="The new password and confirmation password do not match."
                                    ValidationGroup="ChangePassword" />
                            </li>
                        </ol>
                        <asp:Button ID="Button2" runat="server" CommandName="ChangePassword" Text="Change password" ValidationGroup="ChangePassword" />
                    </fieldset>
                </ChangePasswordTemplate>
            </asp:ChangePassword>
        </asp:PlaceHolder>

</asp:Panel>
    </div>
    </asp:Content>