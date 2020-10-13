using System;
using System.Web.Security;
using System.Web.UI;

namespace OurWebsite.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            RegisterHyperLink.NavigateUrl = "Register";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];

            //var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);


            if (Roles.IsUserInRole(User.Identity.Name, "Admin"))
                Response.Redirect("../Admin/AdminHome.aspx");
            else if (Roles.IsUserInRole(User.Identity.Name, "Teacher"))
                Response.Redirect("../Teacher/TeacherHome.aspx");
            else if (Roles.IsUserInRole(User.Identity.Name, "FacultyAdmin"))
                Response.Redirect("../FacultyAdmin/FacultyAdminHome.aspx");
            else if (Roles.IsUserInRole(User.Identity.Name, "Student"))
                Response.Redirect("../Student/StudentHome.aspx");            
            //if (!String.IsNullOrEmpty(returnUrl))
            //{
            //    RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            //}
        }
        protected void Unnamed6_Click(object sender, EventArgs e)
        {     
            if (Roles.IsUserInRole(User.Identity.Name, "Admin"))
                Response.Redirect("../Admin/AdminHome.aspx");
            else if (Roles.IsUserInRole(User.Identity.Name, "Teacher"))
                Response.Redirect("../Teacher/TeacherHome.aspx");
            else if (Roles.IsUserInRole(User.Identity.Name, "FacultyAdmin"))
                Response.Redirect("../FacultyAdmin/FacultyAdminHome.aspx");
            else if (Roles.IsUserInRole(User.Identity.Name, "Student"))
                Response.Redirect("../Student/StudentHome.aspx");  
        }
    }
}