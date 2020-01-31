using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace Polypack.Helpers
{
    public class FileManager
    {
        public static string Upload(HttpPostedFileBase File)
        {
            var postFile = File.FileName.Split('.');
            string filename = Guid.NewGuid().ToString() + "." + postFile[postFile.Length - 1];
            string path = Path.Combine(HttpContext.Current.Server.MapPath("/Uploads"), filename);
            File.SaveAs(path);

            return filename;
        }

        public static void Delete(string File)
        {
            string path = Path.Combine(HttpContext.Current.Server.MapPath("/Uploads"), File);

            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
        }
    }
}