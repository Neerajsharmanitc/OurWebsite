using System;
using System.Data;
using System.Linq;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace OurWebsite.FacultyAdmin
{
    public partial class ManageFacultyUsers : System.Web.UI.Page
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
            var db = new CloudAppDbEntities();
            _facultyID = db.User.Find(User.Identity.Name).FacultyID?? 0;            
            var DepList = db.Department.Where(d=>d.FacultyID == _facultyID);
            
            // fullfill dropdownlist of departmwnts
            DropDownList3.Items.Clear();
            foreach (var d in DepList)
            {
                DropDownList3.Items.Add(d.DepartmentName);
            }
            //...
            GridView1.DataSource = GetFacultyUsers(_facultyID);
            GridView1.DataBind();

            
            
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

            if (DropDownList1.SelectedValue == "Faculty Admin")
            {
                _type = 2;
                Roles.AddUserToRole(RegisterUser.UserName, "Faculty Admin");
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
                _User.FacultyID = _facultyID;
            }

            db.User.Add(_User);
            db.SaveChanges();
        }
        
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue.Equals("Student"))
            {
                StudentPanel.Visible = true;
            }
            else
            {
                StudentPanel.Visible = false;
            }
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
                RadioButtonList1.Visible = false;
                changePassword.Visible = false;
                //delete user from membership
                Membership.DeleteUser(GridView1.DataKeys[rowIndex].Values[1].ToString());
                // delete user from database
                var db = new CloudAppDbEntities();
                var _User = db.User.Find(GridView1.DataKeys[rowIndex].Values[1].ToString());
                db.User.Remove(_User);
                db.SaveChanges();
                //update GridView1
                GridView1.DataSource = GetFacultyUsers(_facultyID);
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
                
                case "Faculty Admin" :
                    _type2 = 2;
                    Roles.AddUserToRole(GridView1.DataKeys[rowIndex].Values[1].ToString(), "FacultyAdmin");
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
                _EditedUser.FacultyID = _facultyID;
            }
            else if (_type2 == 4)
            {
                _EditedUser.ClassID = db.Class.First(c=>c.ClassName == DropDownList4.SelectedValue).ClassID;
                _EditedUser.UserType = _type2;
            }
            
            db.Entry(_EditedUser).State = EntityState.Modified;
            db.SaveChanges();                                   
            
            
            //..
            // update GridView1
            GridView1.DataSource = GetFacultyUsers(_facultyID);
            GridView1.DataBind();
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedValue == "Student")
            
                StudentPanel.Visible = true;
            
                       else
            
                StudentPanel.Visible = false;                        
        }        
    // changing password!!!    
        public DataTable GetFacultyUsers(int facultyID)
        {
            var db = new CloudAppDbEntities();
            var UsersList = db.User.Where(u => u.Class.Department.FacultyID == facultyID || u.FacultyID == facultyID).ToList();
            //var DepList = db.Department.Where(d => d.FacultyID == facultyID);
            var dtAllItems = new DataTable();

            dtAllItems.Columns.Add("Name");
            dtAllItems.Columns.Add("UserID");
            //foreach (var d in DepList)
            //foreach (var u in studentlist)
            //{
                //var classlist = db.Class.Where(c => c.DepartmentID == d.DepartmentID).ToList();
                //foreach (var c in classlist)
                //{
                    //var UsersList = db.User.Where(u => u.ClassID == c.ClassID).ToList();
                    foreach (var u in UsersList)
                    {
                        string _type2 = null;
                        switch (u.UserType)
                        {
                            case 2:
                                _type2 = "FacultyAdmin";
                                break;
                            case 4:
                                _type2 = "Student";
                                break;
                        }
                        dtAllItems.Rows.Add(u.UserName, u.UserID, _type2);
                    }
            return dtAllItems;

        }
    }

}

