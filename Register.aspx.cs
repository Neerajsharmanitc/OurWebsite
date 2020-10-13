using System;
using System.Web.Security;
using System.Web.UI;

namespace OurWebsite
{
    public partial class Register : Page
    {
        public static string _UserID;
        public static string _UserName;
        public static int _type;
        public static string _UserEmail;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
        }

        protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        {
            FormsAuthentication.SetAuthCookie(RegisterUser.UserName, createPersistentCookie: false);
            Roles.AddUserToRole(RegisterUser.UserName, "Admin");
            var db = new CloudAppDbEntities();

            _UserEmail = RegisterUser.Email;
            // is it important to add emails to our database?
            _UserID = RegisterUser.UserName;
            _UserName = FirstName.Text + " " + MiddleName.Text + " " + LastName.Text;
            _type = 1;

            var _User = new User()
            {
                UserID = _UserID,
                UserName = _UserName,
                UserType = _type,
                UserEmail =  _UserEmail
            };

            db.User.Add(_User);
            db.SaveChanges();

            string continueUrl = RegisterUser.ContinueDestinationPageUrl;
            //if (!OpenAuth.IsLocalUrl(continueUrl))
            //{
                continueUrl = "~/Admin/AdminHome.aspx";
            //}
            Response.Redirect(continueUrl);

            // saving user data in database

            
        }
    }
}