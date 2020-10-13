using System;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;

namespace OurWebsite.Student
{
    public partial class StudentHome : System.Web.UI.Page
    {
        public static int _classID ;
        public int SelectedCourse;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.AutoGenerateColumns = false;
            GridView1.DataSource = GetData();
            GridView1.DataBind();
            var db = new CloudAppDbEntities();
            _classID = db.User.Find(User.Identity.Name).ClassID ?? 0;
        }
        private DataTable GetData()
        {
            var dt = new DataTable();
            dt.Columns.Add("Courses");
            dt.Columns.Add("ID");
            var db = new CloudAppDbEntities();
            var courseList = db.CourseClass.Where(c=>c.ClassID == _classID);
            foreach (var cc in courseList)
            {
                var _coursename = db.Course.Find(cc.CourseID).CourseName;
                dt.Rows.Add(_coursename, cc.CourseID);
            }
            return dt;
        }
        public void GoToStudentCourse(object sender, GridViewCommandEventArgs e)
        {            
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            SelectedCourse = int.Parse(GridView1.DataKeys[rowIndex].Values[1].ToString());
            Response.Redirect("StudentCourse.aspx");
        }        
    }
}