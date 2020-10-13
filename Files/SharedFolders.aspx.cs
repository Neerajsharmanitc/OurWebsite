using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;
using System.Configuration;

namespace OurWebsite.Files
{
    public partial class SharedFolders : System.Web.UI.Page
    {        
        private static string _currentLocation;
        private static string _currentLocation2;
        private static string virtualRootPath;
        private static int rowIndex1 = 0;
        private static int rowIndex2 = 0;        
        protected void Page_Load(object sender, EventArgs e)
        {            
            _currentLocation =
                ConfigurationManager.AppSettings["RootPath"];
            
            GridView1.AutoGenerateColumns = false;
            GridView1.DataSource = ShowSharedUsers(ConfigurationManager.AppSettings["RootPath"]);
            GridView1.DataBind();

            var dataKey = GridView1.DataKeys[rowIndex1];
            if (dataKey != null)
                virtualRootPath = ConfigurationManager.AppSettings["RootPath"] + 
                    dataKey.Values[3].ToString() + 
                    "\\" +
                    "Shared";
            else
                virtualRootPath = ConfigurationManager.AppSettings["RootPath"];
        }


        private static DataTable ShowSharedUsers(string path)
        {            
            var sharedTable = new DataTable();

            sharedTable.Columns.Add("Name");
            sharedTable.Columns.Add("Type");
            sharedTable.Columns.Add("Size");
            sharedTable.Columns.Add("UploadTime");
            sharedTable.Columns.Add("Location");
            sharedTable.Columns.Add("FullPath");

            //Get All Shared Users Name            
            var sharedResult = Directory.GetDirectories(
                ConfigurationManager.AppSettings["RootPath"],
                "Shared",
                SearchOption.AllDirectories);                
                       
            foreach (string checkUser in sharedResult)
            {
                var sharedUser = new DirectoryInfo(checkUser);
                sharedTable.Rows.Add(
                    Directory.GetParent(checkUser).Name.Split('\\').Last(),
                    "Folder",
                    "",
                    sharedUser.CreationTime.ToString(CultureInfo.InvariantCulture),
                    sharedUser.Parent.FullName,
                    sharedUser.FullName);
                
                if (sharedUser.Parent.Name.Equals("UploadFolder"))
                {
                    sharedTable.Rows.RemoveAt(0);
                }
            }            
            return sharedTable;
        }

        private static DataTable ShowSharedFolders(string userName)
        {
            var sharedFolders = new DataTable();

            sharedFolders.Columns.Add("Name");
            sharedFolders.Columns.Add("Type");
            sharedFolders.Columns.Add("Size");
            sharedFolders.Columns.Add("UploadTime");
            sharedFolders.Columns.Add("Location");
            sharedFolders.Columns.Add("FullPath");

            string[] subFolders = Directory.GetDirectories(userName);
            foreach (string subFolderPath in subFolders)
            {
                var subFolder = new DirectoryInfo(subFolderPath);
                sharedFolders.Rows.Add(subFolder.Name,
                                       "Folder",
                                       "",
                                       subFolder.CreationTime.ToString(CultureInfo.InvariantCulture),
                                       subFolder.Parent.FullName,
                                       subFolder.FullName);
            }

            string[] files = Directory.GetFiles(userName);
            foreach (string filePath in files)
            {
                var file = new FileInfo(filePath);
                sharedFolders.Rows.Add(file.Name,
                                       file.Name.LastIndexOf('.') < 0
                                           ? ""
                                           : file.Name.Substring(file.Name.LastIndexOf('.')).ToUpper(),
                                       CommonUse.FormatFileSize((long) file.Length),
                                       file.CreationTime.ToString(CultureInfo.InvariantCulture),
                                       file.DirectoryName,
                                       file.FullName);
                if (file.Name.Equals("readme.html"))
                {
                    FilesObject.DownloadFile(filePath);
                }
            }
            return sharedFolders;
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {            
            rowIndex1 = Convert.ToInt32(e.CommandArgument);
            
            if (e.CommandName == "Open")
            {
                _currentLocation = _currentLocation + "\\" + GridView1.DataKeys[rowIndex1].Values[3].ToString() + "\\" + "Shared";
                               
                _currentLocation2 = _currentLocation;

                virtualRootPath = ConfigurationManager.AppSettings["RootPath"] + "\\" +
                                  GridView1.DataKeys[rowIndex1].Values[3].ToString() + "\\" + "Shared";

                ShowCurrentLocation();                               
                GridView2.DataSource = ShowSharedFolders(_currentLocation);
                GridView2.Visible = true;
                GridView2.DataBind();                                
            }
        }
        
        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {            
            rowIndex2 = Convert.ToInt32(e.CommandArgument);

            _currentLocation = _currentLocation2 + "\\" + GridView2.DataKeys[rowIndex2].Values[3].ToString();
            
            if (e.CommandName == "Open")
            {
                if (GridView2.DataKeys[rowIndex2].Values[0].ToString() == "Folder")
                {                                       
                    _currentLocation = Path.Combine(_currentLocation2, GridView2.DataKeys[rowIndex2].Values[3].ToString());                    
                    ShowFolderItems();                                       
                }
                else
                {
                    FilesObject.DownloadFile(
                        GridView2.DataKeys[rowIndex2].Values[1].ToString());
                }                
                
                _currentLocation2 = _currentLocation;
                ShowCurrentLocation();                                        
            }
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }
        
        private void ShowFolderItems()
        {
            GridView2.AutoGenerateColumns = false;
            GridView2.DataSource = ShowSharedFolders(_currentLocation);                
            GridView2.DataBind();
        }

        private void ShowCurrentLocation()
        {
            var strArrayLocation =
                    _currentLocation2.Replace(_currentLocation2, "File Server Root").Split('\\');

            var panelCurrentLocation = pnlCurrentLocation;
            panelCurrentLocation.Controls.Clear();
            for (int i = 0; i < strArrayLocation.Length; i++)
            {
                var lbtnFolder = new LinkButton();
                lbtnFolder.Text = strArrayLocation[i];
                lbtnFolder.ID = string.Format("lbtnFolder{0}", i);
                lbtnFolder.Click += new EventHandler(Folder_Click);
                //string path = strArrayLocation[0];
                string path = virtualRootPath;

                for (int j = 1; j <= i; j++)
                {
                    path = Path.Combine(path,strArrayLocation[j]);
                }
                lbtnFolder.ToolTip = path;
                panelCurrentLocation.Controls.Add(lbtnFolder);

                var lbFolder = new Label();
                lbFolder.Text = " \\ ";
                panelCurrentLocation.Controls.Add(lbFolder);
            }
        }

        private void Folder_Click(object sender, EventArgs e)
        {
            _currentLocation =
               ((LinkButton)sender).ToolTip.Replace("File Server Root", _currentLocation);

            Init += Folder_Click;

            ShowFolderItems();
            ShowCurrentLocation();          
        }              
    }
}