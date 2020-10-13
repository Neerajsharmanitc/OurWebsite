using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OurWebsite.Admin
{
    public partial class ManageUniversity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButton0_Click(object sender, EventArgs e)
        {
            PnlFaculty.Visible = true;
            PnlDep.Visible = false;
            PnlClass.Visible = false;
            PnlCourse.Visible = false;

            // fullfill gridview1

            GridView1.DataSource = GetFaculties();
            GridView1.DataBind();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

            PnlFaculty.Visible = false;
            PnlDep.Visible = true;
            PnlClass.Visible = false;
            PnlCourse.Visible = false;

            // fullfill dropdownlist from db
            DropDownList1.Items.Clear();
            var db = new CloudAppDbEntities();
            var Facultylist = db.Faculty.ToList();

            foreach (var x in Facultylist)
                DropDownList1.Items.Add(x.FacultyName);
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {

            PnlFaculty.Visible = false;
            PnlDep.Visible = false;
            PnlClass.Visible = true;
            PnlCourse.Visible = false;
            // fullfill dropdownlists from db

            var db = new CloudAppDbEntities();

            //faculty dropdownlist
            DropDownList4.Items.Clear();
            var FacultyList = db.Faculty.ToList();
            foreach (var x in FacultyList)
                DropDownList4.Items.Add(x.FacultyName);
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            PnlFaculty.Visible = false;
            PnlDep.Visible = false;
            PnlClass.Visible = false;
            PnlCourse.Visible = true;
            // fullfill dropdownlists from db

            var db = new CloudAppDbEntities();

            //faculty dropdownlist
            DropDownList5.Items.Clear();
            var FacultyList = db.Faculty.ToList();

            foreach (var x in FacultyList)
                DropDownList5.Items.Add(x.FacultyName);
        }

        protected void AddFacultyButton_Click(object sender, EventArgs e)
        {
            var db = new CloudAppDbEntities();
            //add faculty code..
            var _faculty = new Faculty()
            {
                FacultyName = TextBox1.Text,
                //FacultyID = int.Parse(TextBox2.Text)
            };

            db.Faculty.Add(_faculty);
            db.SaveChanges();
            //add faculty code end..

            //update gridview1

            GridView1.DataSource = GetFaculties();
            GridView1.DataBind();



        }

        protected void AddDepartmentButton_Click(object sender, EventArgs e)
        { 
            // don't forget to modify autogeneration of departmentid properity in deprtment table, and also or other fields
            var db = new CloudAppDbEntities();

            int _facultyID = db.Faculty.First(f => f.FacultyName == DropDownList1.SelectedValue).FacultyID;
            //add department code ..

            var _department = new Department()
            {
                //DepartmentID = int.Parse(DepartmentID.Text),
                DepartmentName = DepartmentName.Text,
                FacultyID = _facultyID
            };
            db.Department.Add(_department);
            db.SaveChanges();
            //add department code end ..

            // update gridview2

            GridView2.DataSource = GetDepartments(_facultyID);
            GridView2.DataBind();

        }

        protected void AddClassButton_Click(object sender, EventArgs e)
        {
            var db = new CloudAppDbEntities();

            int _departmentID = db.Department.First(d => d.DepartmentName == DropDownList2.SelectedValue).DepartmentID;

            //add class code ..
            var _class = new Class()
            {
                ClassName = TextBox3.Text,
                //ClassID = int.Parse(TextBox4.Text),
                DepartmentID = _departmentID
            };

            db.Class.Add(_class);
            db.SaveChanges();
            //add class code end ..

            //update gridview3
            GridView3.DataSource = GetClasses(_departmentID);
            GridView3.DataBind();


        }

        protected void AddCourseButton_Click(object sender, EventArgs e)
        {
            var db = new CloudAppDbEntities();

            int _ClassID = db.Class.First(c => c.ClassName == DropDownList3.SelectedValue).ClassID;

            //add course code ..                        
            var _course = new Course()
                {
                    CourseName = TextBox5.Text,
                    ClassID = _ClassID,
                    //CourseID = int.Parse(TextBox6.Text),                    
                };

            db.Course.Add(_course);
            db.SaveChanges();
            //add course code ..
            //update gridview4

            GridView4.DataSource = GetCourses(_ClassID);
            GridView4.DataBind();


        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var db = new CloudAppDbEntities();
            var _facultyID = db.Faculty.First(f => f.FacultyName == DropDownList1.SelectedValue).FacultyID;

            //update gridview2

            GridView2.DataSource = GetDepartments(_facultyID);
            GridView2.DataBind();

        }

        protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
        {
            // class div..
            //faculty dropdownlist selected ..
            var db = new CloudAppDbEntities();
            var _facultyID = db.Faculty.First(f => f.FacultyName == DropDownList4.SelectedValue).FacultyID;

            //update departments dropdownlist
            DropDownList2.Items.Clear();
            var DepList = db.Department.Where(d => d.FacultyID == _facultyID).ToList();

            foreach (var x in DepList)
                DropDownList2.Items.Add(x.DepartmentName);


        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //class div..
            //department dropdownlist selected ..
            var db = new CloudAppDbEntities();
            int _departmentID = db.Department.First(d => d.DepartmentName == DropDownList2.SelectedValue).DepartmentID;

            GridView3.DataSource = GetClasses(_departmentID);
            GridView3.DataBind();


        }

        protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
        {
            //course div..
            //faculty dropdownlist selected..
            var db = new CloudAppDbEntities();
            var _facultyID = db.Faculty.First(f => f.FacultyName == DropDownList5.SelectedValue).FacultyID;

            //update departments dropdownlist
            DropDownList6.Items.Clear();
            var DepList = db.Department.Where(d => d.FacultyID == _facultyID).ToList();

            foreach (var x in DepList)
                DropDownList6.Items.Add(x.DepartmentName);
        }

        protected void DropDownList6_SelectedIndexChanged(object sender, EventArgs e)
        {
            //course div..
            //department dropdownlist selected ..
            var db = new CloudAppDbEntities();
            int _departmentID = db.Department.First(d => d.DepartmentName == DropDownList6.SelectedValue).DepartmentID;

            //update class dropdownlist
            DropDownList3.Items.Clear();
            var Classlist = db.Class.Where(c => c.DepartmentID == _departmentID).ToList();

            foreach (var x in Classlist)
                DropDownList3.Items.Add(x.ClassName);
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //course div..
            //class dropdownlist selected..
            var db = new CloudAppDbEntities();

            int _ClassID = db.Class.First(c => c.ClassName == DropDownList3.SelectedValue).ClassID;
            GridView4.DataSource = GetCourses(_ClassID);
            GridView4.DataBind();
        }

        public DataTable GetFaculties()
        {
            var db = new CloudAppDbEntities();

            var facultylist = db.Faculty.ToList();
            // function

            var dtAllItems = new DataTable();

            dtAllItems.Columns.Add("Name");
            dtAllItems.Columns.Add("ID");
            foreach (var f in facultylist) // faculty list
            {
                dtAllItems.Rows.Add(f.FacultyName, f.FacultyID);
            }
            return dtAllItems;
        }

        public DataTable GetDepartments(int _facultyID)
        {

            var db = new CloudAppDbEntities();
            //var _facultyID = db.Faculty.First(f => f.FacultyName == DropDownList1.SelectedValue).FacultyID;

            var DepList = db.Department.Where(d => d.FacultyID == _facultyID).ToList();
            // function

            var dtAllItems = new DataTable();

            dtAllItems.Columns.Add("Name");
            dtAllItems.Columns.Add("ID");
            foreach (var d in DepList) // faculty list
            {
                dtAllItems.Rows.Add(d.DepartmentName, d.DepartmentID);
            }
            return dtAllItems;
        }

        public DataTable GetClasses(int _departmentID)
        {
            var db = new CloudAppDbEntities();

            //var _departmentID = db.Department.First(d => d.DepartmentName == DropDownList2.SelectedValue).DepartmentID;

            var ClassList = db.Class.Where(d => d.DepartmentID == _departmentID).ToList();


            var dtAllItems = new DataTable();

            dtAllItems.Columns.Add("Name");
            dtAllItems.Columns.Add("ID");
            foreach (var c in ClassList)
            {
                dtAllItems.Rows.Add(c.ClassName, c.ClassID);
            }

            return dtAllItems;
        }

        public DataTable GetCourses(int _classID)
        {
            var db = new CloudAppDbEntities();

            //var _ClassID = db.Class.First(c => c.ClassName == DropDownList3.SelectedValue).ClassID;

            var CourseList = db.Course.Where(c => c.ClassID == _classID).ToList();


            var dtAllItems = new DataTable();

            dtAllItems.Columns.Add("Name");
            dtAllItems.Columns.Add("ID");
            foreach (var c in CourseList)
            {
                dtAllItems.Rows.Add(c.CourseName, c.CourseID);
            }

            return dtAllItems;
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {            
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                var db = new CloudAppDbEntities();
                var faculty = new Faculty();
                faculty = db.Faculty.Find(GridView1.DataKeys[rowIndex].Values[1].ToString());
                db.Faculty.Remove(faculty);
                db.SaveChanges();
                GridView1.DataSource = GetFaculties();
                GridView1.DataBind();
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            var db = new CloudAppDbEntities();
            var department = new Department();
            department = db.Department.Find(GridView2.DataKeys[rowIndex].Values[1].ToString());
            db.Department.Remove(department);
            db.SaveChanges();
            var _facultyID = db.Faculty.First(f => f.FacultyName == DropDownList1.SelectedValue).FacultyID;

            GridView2.DataSource = GetDepartments(_facultyID);
            GridView2.DataBind();
        }

        protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            var db = new CloudAppDbEntities();
            var _class = new Class();
            _class = db.Class.Find(GridView3.DataKeys[rowIndex].Values[1].ToString());
            db.Class.Remove(_class);
            db.SaveChanges();
            int _departmentID = db.Department.First(d => d.DepartmentName == DropDownList2.SelectedValue).DepartmentID;

            GridView3.DataSource = GetClasses(_departmentID);
            GridView3.DataBind();
        }

        protected void GridView4_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            var db = new CloudAppDbEntities();
            var course = new Course();
            course = db.Course.Find(GridView3.DataKeys[rowIndex].Values[1].ToString());
            db.Course.Remove(course);
            db.SaveChanges();
            int _ClassID = db.Class.First(c => c.ClassName == DropDownList3.SelectedValue).ClassID;

            GridView4.DataSource = GetCourses(_ClassID);
            GridView4.DataBind();
        }

        //how to delete element from gridview?





    }
}