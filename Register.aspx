<%@ Page
    Language="C#"
    AutoEventWireup="true"
    Title="Register" 
    MasterPageFile="Register.Master"
    CodeBehind="Register.aspx.cs"
    Inherits="OurWebsite.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Create a new account for your institution..</h2>
    </hgroup>
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
    <asp:CreateUserWizard runat="server" ID="RegisterUser" ViewStateMode="Disabled" OnCreatedUser="RegisterUser_CreatedUser">
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
                                <asp:Label runat="server" AssociatedControlID="UserName">User Name</asp:Label>
                                <asp:TextBox runat="server" ID="UserName" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName"
                                    CssClass="field-validation-error" ErrorMessage="The user name field is required." />
                            </li>                            
                            <li>
                                <asp:Label runat="server" AssociatedControlID="Email">Email address</asp:Label>
                                <asp:TextBox runat="server" ID="Email" TextMode="Email" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                    CssClass="field-validation-error" ErrorMessage="The email address field is required." />
                            </li>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="Password">Password</asp:Label>
                                <asp:TextBox runat="server" ID="Password" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                                    CssClass="field-validation-error" ErrorMessage="The password field is required." />
                            </li>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="ConfirmPassword">Confirm password</asp:Label>
                                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                                     CssClass="field-validation-error" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                                     CssClass="field-validation-error" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
                            </li>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="UniversityName">University Name</asp:Label>
                                <asp:TextBox runat="server" ID="UniversityName" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="UniversityName"
                                    CssClass="field-validation-error" ErrorMessage="The university name field is required." />
                            </li>                                                       
                            <li>
                            <asp:Label runat="server">Payment Method</asp:Label>                                
                            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" >
                                <asp:ListItem>Zain</asp:ListItem>
                                <asp:ListItem>MTN</asp:ListItem>
                                <asp:ListItem>Sudani</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="DropDownList1"
                            CssClass="field-validation-error" ErrorMessage="The payment method is required."/>
                            </li>                            
                             <li>
                            <asp:Label ID="LogoLabel" runat="server" Text="Change Logo"></asp:Label>
                            </li>
                            <li>
                                <asp:Label ID="Label7" runat="server"></asp:Label>            
                                <asp:FileUpload ID="FileUpload1" runat="server" Width="424px" />
                            </li>                            
                        </ol>
                        <asp:Button runat="server" CommandName="MoveNext" Text="Register" />
                    </fieldset>
                </ContentTemplate>
                <CustomNavigationTemplate />
            </asp:CreateUserWizardStep>
        </WizardSteps>
    </asp:CreateUserWizard>
</asp:Content>