using accessPsychology.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace accessPsychology.Handlers
{
    /// <summary>
    /// Captcha 的摘要说明
    /// </summary>
    public class Captcha : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Clear();
            using (Bitmap b = new Bitmap(95, 40, PixelFormat.Format32bppArgb))
            {
                using (Graphics g = Graphics.FromImage(b))
                {
                    Rectangle rect = new Rectangle(0, 0, 94, 39);
                    g.FillRectangle(Brushes.White, rect);

                    String drawCaptchaString = CharacterUtility.GenerateRandomString();
                    HttpContext.Current.Session["CAPTCHA_Contact"] = drawCaptchaString;

                    Font drawFont = new Font("Arial", 16, FontStyle.Italic | FontStyle.Strikeout);
                    using (SolidBrush drawBrush = new SolidBrush(Color.Black))
                    {
                        PointF drawPoint = new PointF(15, 10);

                        g.DrawRectangle(new Pen(Color.Red, 0), rect);
                        g.DrawString(drawCaptchaString, drawFont, drawBrush, drawPoint);
                    }
                    b.Save(context.Response.OutputStream, ImageFormat.Jpeg);
                    context.Response.ContentType = "image/jpeg";
                    context.Response.End();
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}