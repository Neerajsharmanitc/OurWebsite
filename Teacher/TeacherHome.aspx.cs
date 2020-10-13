using System;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;

namespace OurWebsite.Teacher
{
    public partial class TeacherHome : System.Web.UI.Page
    {
        public int _courseID;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.AutoGenerateColumns = false;
            GridView1.DataSource = GetData();
            GridView1.DataBind();
        }

        private DataTable GetData()
        {            
            var dt = new DataTable();
            dt.Columns.Add("Course");
            dt.Columns.Add("CourseID");
            var db = new CloudAppDbEntities();
            var courseList = db.TeacherCourse.Where(t => t.TeacherID == User.Identity.Name);
            foreach (var tc in courseList)
            {
                dt.Rows.Add(tc.Course.CourseName, tc.CourseID);
            }
            return dt;
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            _courseID = int.Parse(GridView1.DataKeys[rowIndex].Values[1].ToString());
            Response.Redirect("CourseStudents.aspx");
        }

    }
}