
namespace OurWebsite.Files
{
    internal class CommonUse
    {
        /// <summary>
        /// Format the file size
        /// </summary>
        /// <param name="fileLength">The file size</param>
        /// <returns>Formated file size</returns>
        public static string FormatFileSize(long fileLength)
        {

            if (fileLength / 1024 < 1)
            {
                return string.Format("{0} (bytes)",fileLength);
            }
            else
            {
                fileLength = fileLength / 1024;
            }

            if (fileLength / 1024 < 1)
            {
                return string.Format("{0} KB", fileLength);
            }
            else
            {
                fileLength = fileLength / 1024;
            }

            if (fileLength / 1024 < 1)
            {
                return string.Format("{0} MB", fileLength);
            }
            else
            {
                fileLength = fileLength / 1024;
            }

            if (fileLength / 1024 < 1)
            {
                return string.Format("{0} GB", fileLength);
            }
            else
            {
                fileLength = fileLength / 1024;
            }

            return string.Format("{0} TB", fileLength);

        }
    }
}