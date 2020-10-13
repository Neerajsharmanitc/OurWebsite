<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="OurWebsite.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Use the form below to create a new account.</h2>
    </hgroup>
     
    
    <br />
    <table>
   <tr>
       <td>
           &nbsp;Select Faculty:
       </td>
            <td>
                 &nbsp;<asp:DropDownList runat="server" AutoPostBack="True" ID="DropDownList2" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                     <asp:ListItem>Select</asp:ListItem>
        </asp:DropDownList>
            </td>
        </tr>  
    <tr >
       <td>
           &nbsp;Select Department:
       </td>
            <td>
                 &nbsp;<asp:DropDownList runat="server" AutoPostBack="True" ID="DropDownList3" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
                     <asp:ListItem>Select</asp:ListItem>
            
        </asp:DropDownList>
            </td>
        </tr>  
    
   <tr>
       <td >
           &nbsp;Select Class:
       </td>
            <td>
                 &nbsp;<asp:DropDownList runat="server" ID="DropDownList1" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                     <asp:ListItem>Select</asp:ListItem>
        </asp:DropDownList>
            </td>
        </tr>  
    </table>
   
     <li>
         <asp:Label ID="Label1" runat="server" AssociatedControlID="FirstName">First name</asp:Label>
         <asp:TextBox runat="server" ID="FirstName" />
         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FirstName"
             CssClass="field-validation-error" ErrorMessage="The First name field is required." />
         
         <asp:Label ID="Label2" runat="server" AssociatedControlID="MiddleName">Middle name</asp:Label>
         <asp:TextBox runat="server" ID="MiddleName" />
         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="MiddleName"
             CssClass="field-validation-error" ErrorMessage="The Middle name field is required." />
         
         <asp:Label ID="Label3" runat="server" AssociatedControlID="LastName">Last name</asp:Label>
         <asp:TextBox runat="server" ID="LastName" />
         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="LastName"
             CssClass="field-validation-error" ErrorMessage="The Last name field is required." />

     </li>
   
    
     <asp:CreateUserWizard runat="server" ID="RegisterUser" ViewStateMode="Disabled" OnCreatedUser="RegisterUser_CreatedUser" OnDataBinding="RegisterUser_CreatedUser">
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
                                <asp:Label ID="Label4" runat="server" AssociatedControlID="UserName">User name</asp:Label>
                                <asp:TextBox runat="server" ID="UserName" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="UserName"
                                    CssClass="field-validation-error" ErrorMessage="The user name field is required." />
                            </li>
                           
                            <li>
                                <asp:Label ID="Label5" runat="server" AssociatedControlID="Email">Email address</asp:Label>
                                <asp:TextBox runat="server" ID="Email" TextMode="Email" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="Email"
                                    CssClass="field-validation-error" ErrorMessage="The email address field is required." />
                            </li>
                            <li>
                                <asp:Label ID="Label6" runat="server" AssociatedControlID="Password">Password</asp:Label>
                                <asp:TextBox runat="server" ID="Password" TextMode="Password" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="Password"
                                    CssClass="field-validation-error" ErrorMessage="The password field is required." />
                            </li>
                            <li>
                                <asp:Label ID="Label7" runat="server" AssociatedControlID="ConfirmPassword">Confirm password</asp:Label>
                                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ConfirmPassword"
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
</asp:Content>