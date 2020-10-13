using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using OurWebsite.Files;

namespace OurWebsite.Teacher
{
    public partial class CourseStudents : System.Web.UI.Page
    {
        public static string CurrentLocation;
        public static int _courseID;
        public static string currentUserID;
        public static int rowIndex;
        protected void Page_Load(object sender, EventArgs e)
        {
            _courseID = PreviousPage._courseID;
            currentUserID = User.Identity.Name;

            GridView1.DataSource = GetCourseStudents();
            GridView1.DataBind();

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            rowIndex = Convert.ToInt32(e.CommandArgument);    
            GridView2.DataSource = GetCourseStudents();
            GridView2.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex2 = Convert.ToInt32(e.CommandArgument);

            FilesObject.DownloadFile(
                GridView2.DataKeys[rowIndex2].Values[1].ToString());

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            CurrentLocation = ConfigurationManager.AppSettings["RootPath"];
            // The file Extension
            string fileExtension = string.Empty;

            // The choosed file name
            string fileName = string.Empty;

            // The new file name in the server
            string newFileName = string.Empty;

            // Check if choosed a file
            if (!fuChooseFile.HasFile)
            {
                lbMessage.Text = "Please choose the file you want to upload. " +
                                 "Note: The file size cannot be zero.";
                return;
            }


            fileExtension = Path.GetExtension(fuChooseFile.FileName);
            fileName = string.Format("{0}\\{1}", CurrentLocation,
                (string.IsNullOrEmpty(fileExtension) ? fuChooseFile.FileName :
                fuChooseFile.FileName.Replace(fileExtension, "")));

            if (fileExtension.ToLower() == ".exe" || fileExtension.ToLower() == ".msi")
            {
                lbMessage.Text =
                    "The file you want to upload cannot be a .exe or .msi file.";
                return;
            }

            newFileName = fileName;

            // Check file size
            //if (fuChooseFile.PostedFile.ContentLength >= 1024*1024*40)
            //{
            //    lbMessage.Text =
            //        "The file you want to upload cannot be larger than 40 MB.";
            //    return;
            //}

            try
            {
                // If there is already a file with the same name in the system,rename 
                // and then upload the file .
                int i = 0;
                while (System.IO.File.Exists(newFileName + fileExtension))
                {
                    i++;
                    newFileName = string.Format(fileName + "({0})", i);
                }

                fuChooseFile.SaveAs(Utilities.FixRoot(newFileName + fileExtension));

                lbMessage.Text =
                    string.Format("The file \"{0}\" was uploaded successfully!",
                    Path.GetFileName(fileName));

                ShowFolderItems();
            }
            catch (HttpException he)
            {
                lbMessage.Text =
                    string.Format("File {0} upload failed because of the following error:{1}.",
                    fuChooseFile.PostedFile.FileName, he.Message);
            }

            //the file id
            var _file2 = new FileInfo(newFileName);
            var db = new CloudAppDbEntities();
            var _file = new UserFile()
            {
                FName = Path.GetFileName(newFileName),
                FileName = Path.GetFileName(fileName),
                UploaderID = currentUserID,
                // don't forget to find currentuserID
                //FileSize = CommonUse.FormatFileSize((long)fuChooseFile.PostedFile.ContentLength) ,
                FileSize = CommonUse.FormatFileSize((long)fuChooseFile.PostedFile.ContentLength),
                FileType = fileExtension,
                UploadTime = _file2.CreationTime,
                CourseID = _courseID,
                ClassID = null
            };

            db.UserFile.Add(_file);
            db.SaveChanges();

        }

        private void ShowFolderItems()
        {

            var location = Utilities.FixRoot(CurrentLocation);

            GridView1.AutoGenerateColumns = false;
            GridView1.DataSource = GetStudentFiles();
                    //FilesObject.GetAllItemsInTheDirectory(location);

            GridView1.DataBind();
        }

        private DataTable GetCourseStudents()
        {
            var db = new CloudAppDbEntities();
            int _classID = db.CourseClass.First(c => c.CourseID == _courseID).ClassID;
            var StudentList = db.User.Where(u => u.ClassID == _classID);

            // function
            var dtAllItems = new DataTable();

            dtAllItems.Columns.Add("StudentName");
            dtAllItems.Columns.Add("UserID");
            foreach (var f in StudentList)
            {

                dtAllItems.Rows.Add(f.UserName, f.UserID);

            }
            //  function
            return dtAllItems;
        }

        private DataTable GetStudentFiles()
        {
            var db = new CloudAppDbEntities();
            string _uploaderID = GridView1.DataKeys[rowIndex].Values[1].ToString();
            var filesList = db.UserFile.Where(f => f.UploaderID == _uploaderID && f.CourseID == _courseID);

            // function
            var dtAllItems = new DataTable();

            dtAllItems.Columns.Add("Name");
            dtAllItems.Columns.Add("Size");
            dtAllItems.Columns.Add("UploadTime");
            dtAllItems.Columns.Add("Type");
            dtAllItems.Columns.Add("FName");
            foreach (var f in filesList)
            {
                //var fuploader = db.User.Find(f.UploaderID).UserName;
                dtAllItems.Rows.Add(f.FileName, f.FileSize, f.UploadTime, f.FileType, string.Format("{0}{1}", f.FName, f.FileType));
            }
            //  function

            return dtAllItems;
        }
    }
}