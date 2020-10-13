using System;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using Microsoft.AspNet.Membership.OpenAuth;

namespace OurWebsite.Account
{
    public partial class Register : Page
    {
        public static string _UserID;
        public static string _UserName;
        public static int _type;
        public static int _ClassID;
        public static string _UserEmail;
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];

            var db = new CloudAppDbEntities();
            var Facultylist = db.Faculty.ToList();
            var deplist = db.Department.ToList();
            var classlist = db.Class.ToList();
            // DropDownList2.Items.Clear();
            if(DropDownList2.Items.Count<4)
            foreach (var x in Facultylist)
                DropDownList2.Items.Add(x.FacultyName);
            if(DropDownList3.Items.Count<4)
            foreach (var x in deplist)
                DropDownList3.Items.Add(x.DepartmentName);
            if(DropDownList1.Items.Count<4)
            foreach (var x in classlist)
                DropDownList1.Items.Add(x.ClassName);
        }

        protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        {
            FormsAuthentication.SetAuthCookie(RegisterUser.UserName, createPersistentCookie: false);
            
            // SetUserRole Function
            Roles.AddUserToRole(RegisterUser.UserName, "Student");

            // saving user data in database

            var db = new CloudAppDbEntities();

            _UserEmail = RegisterUser.Email;
            _UserID = RegisterUser.UserName;
            _UserName = FirstName.Text + " " + MiddleName.Text + " " + LastName.Text;
            _type = 4;
            _ClassID = db.Class.First(c => c.ClassName == DropDownList1.SelectedValue).ClassID;

            var _User = new User()
            {
                UserID = _UserID,
                UserName = _UserName,
                UserType = _type,
                ClassID = _ClassID
            };

            db.User.Add(_User);
            db.SaveChanges(); 
            
            string continueUrl = RegisterUser.ContinueDestinationPageUrl;
            if (!OpenAuth.IsLocalUrl(continueUrl))
            {
                continueUrl = "~/Student/StudentHome.aspx";
            }
            Response.Redirect(continueUrl);                     
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var db = new CloudAppDbEntities();
         //   int _DepID = db.Department.First(d => d.DepartmentName == DropDownList3.SelectedValue).DepartmentID;
         //   var ClassesList = db.Class.Where(d => d.DepartmentID == _DepID);
         //   DropDownList1.Items.Clear();
         //   foreach (var c in ClassesList)
           //     DropDownList1.Items.Add(c.ClassName);
        }
        
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
           // var db = new CloudAppDbEntities();
         //   int _FacultyID = db.Faculty.First(f => f.FacultyName == DropDownList2.SelectedValue).FacultyID;
         //   var DepList = db.Department.Where(d => d.FacultyID == _FacultyID);
         //   DropDownList3.Items.Clear();
         //   foreach (var d in DepList)
           //     DropDownList3.Items.Add(d.DepartmentName);            
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}