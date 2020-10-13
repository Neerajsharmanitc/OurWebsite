using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Membership.OpenAuth;

namespace OurWebsite.Admin
{
    public partial class ManageUsers : System.Web.UI.Page
    {
        public static string _UserID;
        public static string _UserName;
        public static int _type;
        public static int _ClassID;
        public static string _UserEmail;
        public static int _facultyID;
        public static int rowIndex; // used in edit users gridview

        protected void Page_Load(object sender, EventArgs e)
        {
            DropDownList2.Items.Clear();
            // to fullfill faculty dropdownlist
            var db = new CloudAppDbEntities();
            var Facultylist = db.Faculty.ToList();

            foreach (var x in Facultylist)
                DropDownList2.Items.Add(x.FacultyName);

            
            //...
            // fullfill gridview1
            GridView1.DataSource = GetAllUsers();
            GridView1.DataBind();
            //...
        }

        protected void LinkButton0_Click(object sender, EventArgs e)
        {
            PnlCreate.Visible = true;
            PnlManage.Visible = false;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            PnlCreate.Visible = false;
            PnlManage.Visible = true;
        }

        protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        {
            RegisterUser.LoginCreatedUser = false;
            if (DropDownList1.SelectedValue == "Admin")
            {
                _type = 1;
                Roles.AddUserToRole(RegisterUser.UserName, "Admin");
            }
            if (DropDownList1.SelectedValue == "Faculty Admin")
            { 
                _type = 2;
                Roles.AddUserToRole(RegisterUser.UserName, "FacultyAdmin");
            }
            if (DropDownList1.SelectedValue == "Teacher")
            {
                _type = 3;
                Roles.AddUserToRole(RegisterUser.UserName, "Teacher");
            }
            if (DropDownList1.SelectedValue == "Student")
            {
                _type = 4;
                Roles.AddUserToRole(RegisterUser.UserName, "Student");
            }
            
            // saving user data in database
            var db = new CloudAppDbEntities();
            _UserEmail = RegisterUser.Email;
            _UserID = User.Identity.Name;
            _UserName = FirstName.Text + " " + MiddleName.Text + " " + LastName.Text;
            
            var _User = new User();
            
            _User.UserID = _UserID;
            _User.UserName = _UserName;
            _User.UserType = _type;
            _User.UserEmail = _UserEmail;
            if (_type == 4)
            {
                _ClassID = db.Class.First(c => c.ClassName == DropDownList4.SelectedValue).ClassID;
                _User.ClassID = _ClassID;
                
            }
            else if (_type == 2)
            {
                _facultyID = db.Faculty.First(f => f.FacultyName == DropDownList5.SelectedValue).FacultyID;
                _User.FacultyID = _facultyID;
            }

            db.User.Add(_User);
            db.SaveChanges();

            GridView1.DataSource = GetAllUsers();
            GridView1.DataBind();

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue.Equals("Student"))
            {
                StudentPanel.Visible = true;
                FacultyAdminPanel.Visible = false;
            }
            else if (DropDownList1.SelectedValue.Equals("Faculty Admin"))
            {
                FacultyAdminPanel.Visible = true;
                StudentPanel.Visible = false;
            }
            else
            {
                StudentPanel.Visible = false;
                FacultyAdminPanel.Visible = false;
            }            
        }
        
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList3.Items.Clear();
            var db = new CloudAppDbEntities();
            int _FacultyID = db.Faculty.First(f => f.FacultyName == DropDownList2.SelectedValue).FacultyID;
            var DepList = db.Department.Where(d => d.FacultyID == _FacultyID);
            foreach (var d in DepList)
                DropDownList3.Items.Add(d.DepartmentName);
        }
          
        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList4.Items.Clear();
            var db = new CloudAppDbEntities();
            int _DepID = db.Department.First(d => d.DepartmentName == DropDownList3.SelectedValue).DepartmentID;
            var ClassesList = db.Class.Where(d => d.DepartmentID == _DepID);
            foreach (var c in ClassesList)
                DropDownList4.Items.Add(c.ClassName);
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            rowIndex = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "DeleteUser")
            {
                RoleEditPnl.Visible = false;
                changePassword.Visible = false;

                //delete user from membership
                
                Membership.DeleteUser(GridView1.DataKeys[rowIndex].Values[1].ToString());

                //delete user data from database

                var db = new CloudAppDbEntities();
                var _User = db.User.Find(GridView1.DataKeys[rowIndex].Values[1].ToString());
                db.User.Remove(_User);
                db.SaveChanges();
                //update gridview1
                GridView1.DataSource = GetAllUsers();
                GridView1.DataBind();


            }
            if (e.CommandName == "EditRole")
            {
                RoleEditPnl.Visible = true;
                changePassword.Visible = false;
            }
            if (e.CommandName == "EditPassword")
            {
                RoleEditPnl.Visible = false;
                changePassword.Visible = true;
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            var db = new CloudAppDbEntities();

            var _EditedUser = db.User.Find(GridView1.DataKeys[rowIndex].Values[1].ToString());

            int _type2 = 0;
            switch (RadioButtonList1.SelectedValue)
            {

                case "Admin":
                    _type2 = 1;
                    Roles.AddUserToRole(GridView1.DataKeys[rowIndex].Values[1].ToString(), "Admin");
                    break;
                case "Faculty Admin" :
                    _type2 = 2;
                    Roles.AddUserToRole(GridView1.DataKeys[rowIndex].Values[1].ToString(), "Faculty Admin");
                    break;
                case "Teacher":
                    _type2 = 3;
                    Roles.AddUserToRole(GridView1.DataKeys[rowIndex].Values[1].ToString(), "Teacher");
                    break;
                case "Student":
                    _type2 = 4;
                    Roles.AddUserToRole(GridView1.DataKeys[rowIndex].Values[1].ToString(), "Student");
                    break;
            }

            //editing data in database
            
            _EditedUser.UserType = _type2;
            
            if (_type2 == 2)
            {
                int _facultyID = db.Faculty.First(f=>f.FacultyName == DropDownList5.SelectedValue).FacultyID;
                _EditedUser.FacultyID = _facultyID;
            }
            
            else if (_type2 == 4)
            {
                int _classID = db.Class.First(c=>c.ClassName == DropDownList4.SelectedValue).ClassID;
                _EditedUser.ClassID = _classID;
            }

            db.Entry(_EditedUser).State = EntityState.Modified;
            db.SaveChanges();

            //..
            // update GridView1
            GridView1.DataSource = GetAllUsers();
            GridView1.DataBind();


        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedValue == "Student")
            {
                StudentPanel.Visible = true;
                FacultyAdminPanel.Visible = false;
            }
            else if (RadioButtonList1.SelectedValue == "FacultyAdmin")
            {
                FacultyAdminPanel.Visible = true;
                StudentPanel.Visible = false;
            }
            else
            {
                StudentPanel.Visible = false;
                FacultyAdminPanel.Visible = false;
            }
        }

        public DataTable GetAllUsers()
        {
            var db = new CloudAppDbEntities();

            var UsersList = db.User.ToList();
            // function
            var dtAllItems = new DataTable();

            dtAllItems.Columns.Add("Name");
            dtAllItems.Columns.Add("UserID");
            dtAllItems.Columns.Add("Type");

            foreach (var u in UsersList)
            {
                string _type2 = null;
                switch (u.UserType)
                {
                    case 1:
                        _type2 = "Admin";
                        break;
                    case 2:
                        _type2 = "FacultyAdmin";
                        break;
                    case 3:
                        _type2 = "Teacher";
                        break;
                    case 4:
                        _type2 = "Student";
                        break;
                }
                dtAllItems.Rows.Add(u.UserName, u.UserID, _type2);
            }
            //  function...

            return dtAllItems;
        }

        // changing password!!!  code is with omer ..  
        

    }
  }