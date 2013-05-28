using System;
using System.Drawing;

namespace DPXS.Web.Admin
{
    public partial class ValidCode : WebCrm.Web.Facade.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GenImg(GenCode(4));
            Response.End();
        }
        //产生随机字符串
        private string GenCode(int num)
        {
            string[] source = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            //string[] source ={"0","1","2","3","4","5","6","7","8","9",
            //"a","b","c","d","e","f","g","h","i","j","k","l","m","n",
            //"o","p","q","r","s","t","u","v","w","x","y","z"};
            string code = "";
            Random rd = new Random();
            for (int i = 0; i < num; i++)
            {
                code += source[rd.Next(0, source.Length)];
            }
            return code;
        }

        //生成图片
        private void GenImg(string code)
        {
            Bitmap myPalette = new Bitmap(35, 18);//定义一个画板

            Graphics gh = Graphics.FromImage(myPalette);//在画板上定义绘图的实例

            Rectangle rc = new Rectangle(0, 0, 35, 18);//定义一个矩形

            gh.FillRectangle(new SolidBrush(Color.White), rc);//填充矩形 Color.Black
            gh.DrawString(code, new Font("Arial", 10), new SolidBrush(Color.Red), rc);//在矩形内画出字符串 Color.White

            myPalette.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);//将图片显示出来

            Session["ValidCode"] = code;//将字符串保存到Session中，以便需要时进行验证

            gh.Dispose();
            myPalette.Dispose();
        }
    }
}