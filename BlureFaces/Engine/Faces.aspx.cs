using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BlureFaces.Engine
{
    public partial class Faces : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DirectoryInfo info = new DirectoryInfo(Server.MapPath("~/Images/"));
                string[] filePaths = info.GetFiles().OrderByDescending(p => p.CreationTimeUtc).Select(x=>x.Name).ToArray();
                List<ListItem> files = new List<ListItem>();
                foreach (string filePath in filePaths)
                {
                    if (Array.IndexOf(filePaths, filePath) < 5)
                    {
                        string fileName = Path.GetFileName(filePath);
                        files.Add(new ListItem(fileName, "~/Images/" + fileName));
                    }
                    else
                    {
                        File.Delete(filePath);
                    }
                }

                GridView1.DataSource = files;
                GridView1.DataBind();
            }
        }
        protected void Upload(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                string sSavedFileName = Server.MapPath("~/Images/") + fileName;
                FileUpload1.PostedFile.SaveAs(sSavedFileName);

                HandleImage(sSavedFileName, 1, int.Parse(TextBoxStrenght.Text));

                Response.Redirect(Request.Url.AbsoluteUri);
            }
        }
        private void HandleImage(string fileName, int effect, int strength)
        {
            Image<Bgr, byte> image1 = new Image<Bgr, byte>(fileName);
            var facesCascade = HttpContext.Current.Server.MapPath("~/haarcascade_frontalface_default.xml");
            List<Rectangle> list = FaceDetection.Detect(image1, facesCascade);
            //this.bkgdWorker.ReportProgress(list.Count, (object)item);
            Bitmap image2 = image1.ToBitmap();

            if (effect != 2)
            {
                bool usePixelate = (effect == 1) ? true : false;

                foreach (Rectangle rectangle in list)
                {
                    image2 = usePixelate ? ImageProcessor.Pixelate(image2, rectangle, strength) : ImageProcessor.Blur(image2, rectangle, strength);
                }
            }

            string sBluredFileName = "blrd-" + Path.GetFileName(fileName);
            //string str1 = ".png";
            //string str2 = dir + "\\" + text.Substring(0, text.LastIndexOf("."));
            //bool flag = true;
            //int num = 0;
            //string str3 = "";
            //while (flag)
            //{
            //    if (File.Exists(str2 + str3 + str1))
            //    {
            //        ++num;
            //        str3 = "(" + num.ToString() + ")";
            //    }
            //    else
            //        flag = false;
            //}
            image2.Save(Path.GetDirectoryName(fileName) + "\\"+ sBluredFileName);
            image2.Dispose();
            image1.Dispose();
            File.Delete(fileName);
            
            //this.bkgdWorker.ReportProgress(-1, (object)item);
        }
    }
}