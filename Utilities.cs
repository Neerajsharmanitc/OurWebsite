using System.Configuration;
using System.Web.Security;


namespace OurWebsite
{
    public static class Utilities
    {
        public static string GetRootPath()
        {            
            var user = Membership.GetUser();
            string userName = user==null ? "" : user.UserName;
            return string.Format("{0}\\{1}",
                ConfigurationManager.AppSettings["RootPath"],userName);
        }

        public static string FixRoot(string webpath)
        {
            return webpath.Replace("File Server Root", GetRootPath());
        }                     
    }
}

