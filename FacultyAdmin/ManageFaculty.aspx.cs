using System;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;

namespace OurWebsite.FacultyAdmin
{
    public partial class ManageFaculty : System.Web.UI.Page
    {
        public static int _facultyID;
        protected void Page_Load(object sender, EventArgs e)
        {
            var db = new CloudAppDbEntities();
            _facultyID = db.User.Find(User.Identity.Name).FacultyID ?? 0;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            PnlDep.Visible = true;
            PnlClass.Visible = false;
            PnlCourse.Visible = false;
            //update Gridview2
            GridView2.DataSource = GetDepartments();
            GridView2.DataBind();

        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {


            PnlDep.Visible = false;
            PnlClass.Visible = true;
            PnlCourse.Visible = false;
            // fullfill dropdownlists from db
            DropDownList2.Items.Clear();
            var db = new CloudAppDbEntities();
            var DepList = db.Department.Where(d => d.FacultyID == _facultyID).ToList();

            foreach (var x in DepList)
                DropDownList2.Items.Add(x.DepartmentName);
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {

            PnlDep.Visible = false;
            PnlClass.Visible = false;
            PnlCourse.Visible = true;

            var db = new CloudAppDbEntities();
            //departments dropdownlist
            DropDownList6.Items.Clear();
            var DepList = db.Department.Where(d => d.FacultyID == _facultyID).ToList();

            foreach (var x in DepList)
                DropDownList6.Items.Add(x.DepartmentName);
        }

        protected void AddDepartmentButton_Click(object sender, EventArgs e)
        {
            var db = new CloudAppDbEntities();
            //add department code ..
            var _department = new Department()
            {
                DepartmentName = DepartmentName.Text,
                FacultyID = _facultyID

            };
            db.Department.Add(_department);
            db.SaveChanges();
            //add department code end ..

            // update gridview2

            GridView2.DataSource = GetDepartments();
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
                    ClassID = _ClassID
                };

            db.Course.Add(_course);
            db.SaveChanges();
            //add course code ..
            //update gridview4

            GridView4.DataSource = GetCourses(_ClassID);
            GridView4.DataBind();


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

        public DataTable GetDepartments()
        {

            var db = new CloudAppDbEntities();
            var DepList = db.Department.Where(d => d.FacultyID == _facultyID).ToList();
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

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            var db = new CloudAppDbEntities();
            var department = new Department();
            department = db.Department.Find(GridView2.DataKeys[rowIndex].Values[1].ToString());
            db.Department.Remove(department);
            db.SaveChanges();

            GridView2.DataSource = GetDepartments();
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
    }
}