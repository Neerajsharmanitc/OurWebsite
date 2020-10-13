using System;
using System.Web.UI;
using System.IO;
namespace OurWebsite
{
    public partial class Default : Page
    {
        private string _rootPath;
        protected void Page_Load(object sender, EventArgs e)
        {                        
                //RootPath = ConfigurationManager.AppSettings["RootPath"];
                _rootPath = Utilities.GetRootPath();                
                Directory.CreateDirectory(string.Format("{0}\\{1}", _rootPath,"Shared"));
            
            //Response.Redirect("");
        }
    }
}