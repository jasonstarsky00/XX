using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace Admin.XXCommon
{
    /// <summary>
    /// 项目帮助类
    /// </summary>
    public class XXHelper
    {
        /// <summary>
        /// 获取webconfig中自定义加密 key
        /// </summary>
        /// <returns></returns>
        public static string GetUserEncryptKey()
        {
            return "xx";
        }
        /// <summary>
        /// 验证注册的账号合法性
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static string UserName(string userName)
        {
            string str = "";
            if (!StringHelper.Stra_zA_Z0_9(userName))
            {
                return str = "账号必须是以字母或数字或下划线组成";
            }
            if (!StringHelper.Stra_zA_Z0_96_16(userName))
            {
                return str = "账号必须是6到16位字母或数字或下划线组成";
            }
            return str;
        }
        /// <summary>
        /// 验证注册的密码合法性
        /// </summary>
        /// <param name="passWord"></param>
        /// <returns></returns>
        public static string PassWord(string passWord)
        {
            string str = "";
            if (!StringHelper.Str0_9(passWord))
            {
                return str = "密码必须包含数字";
            }
            if (!StringHelper.Stra_zA_Z2More(passWord))
            {
                return str = "密码必须包含两位大写字母或小写字母或下划线字符";
            }
            return str;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="passWord">输入的密码</param>
        /// <param name="randNum">18位随机码</param>
        /// <param name="encryptPassWord">加密后的密码</param>
        /// <returns></returns>
        public static bool PassWordIsRight(string passWord, string randNum, string encryptPassWord)
        {
            //获取自定义配置的加密key
            string encryptKey = GetUserEncryptKey();
            //密码 + 随机码 +key
            string encryptingStr = RsaHelper.MD5(passWord + randNum + encryptKey);
            //验证
            return string.Equals(encryptPassWord, encryptingStr);
        }
        /// <summary>
        /// 随机生成用户头像路径
        /// </summary>
        /// <returns></returns>
        public static string CreateUserAvatarSrc()
        {
            //默认路径
            string path = AppDomain.CurrentDomain.BaseDirectory.ToString() + @"Images\Avatar";
            string src = "";
            //如果目录存在
            if (Directory.Exists(path))
            {
                List<string> fileNames = new List<string>();
                DirectoryInfo folder = new DirectoryInfo(path);//目录信息
                foreach (FileInfo file in folder.GetFiles())
                {
                    fileNames.Add(file.Name);
                }
                Random r = new Random();
                int index = r.Next(0, fileNames.Count - 1);
                src = fileNames[index];
            }
            return src;
        }
        /// <summary>
        /// 随机生成昵称
        /// </summary>
        /// <returns></returns>
        public static string CreateName()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory.ToString() + @"Files\User";
            string name = "";
            if (Directory.Exists(path))
            {
                if (File.Exists(path + @"\name.txt"))
                {
                    string nameTxt = File.ReadAllText(path+ @"\name.txt");                    
                    List<string> names = nameTxt.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    Random r = new Random();
                    int index = r.Next(0, names.Count - 1);
                    name = names[index];
                   
                }
            }
            return name;
        }
        /// <summary>
        /// 生成token
        /// </summary>
        /// <param name="randCode"></param>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static string CreateToken(string randCode,string guid)
        {
            return RsaHelper.MD5(randCode + guid);
        }






        /// <summary>
        /// 生成随机的字符串
        /// </summary>
        /// <param name="codeCount"></param>
        /// <returns></returns>
        public static string CreateRandomCode(int codeCount)
        {
            string allChar = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,a,b,c,d,e,f,g,h,i,g,k,l,m,n,o,p,q,r,F,G,H,I,G,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,s,t,u,v,w,x,y,z";
            string[] allCharArray = allChar.Split(',');
            string randomCode = "";
            int temp = -1;
            Random rand = new Random();
            for (int i = 0; i < codeCount; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(i * temp * ((int)DateTime.Now.Ticks));
                }
                int t = rand.Next(35);
                if (temp == t)
                {
                    return CreateRandomCode(codeCount);
                }
                temp = t;
                randomCode += allCharArray[t];
            }
            return randomCode;
        }
        /// <summary>
        /// 创建验证码图片
        /// </summary>
        /// <param name="validateCode"></param>
        /// <returns></returns>
        public static byte[] CreateValidateGraphic(string validateCode)
        {
            Bitmap image = new Bitmap((int)Math.Ceiling(validateCode.Length * 16.0), 27);
            Graphics g = Graphics.FromImage(image);
            try
            {
                //生成随机生成器
                Random random = new Random();
                //清空图片背景色
                g.Clear(Color.White);
                //画图片的干扰线
                for (int i = 0; i < 25; i++)
                {
                    int x1 = random.Next(image.Width);
                    int x2 = random.Next(image.Width);
                    int y1 = random.Next(image.Height);
                    int y2 = random.Next(image.Height);
                    g.DrawLine(new Pen(Color.Silver), x1, x2, y1, y2);
                }
                Font font = new Font("Arial", 13, (FontStyle.Bold | FontStyle.Italic));
                LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.DarkRed, 1.2f, true);
                g.DrawString(validateCode, font, brush, 3, 2);

                //画图片的前景干扰线
                for (int i = 0; i < 100; i++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);
                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }
                //画图片的边框线
                g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);

                //保存图片数据
                MemoryStream stream = new MemoryStream();
                image.Save(stream, ImageFormat.Jpeg);

                //输出图片流
                return stream.ToArray();
            }
            finally
            {
                g.Dispose();
                image.Dispose();
            }
        }
        /// <summary>
        /// 下载图片
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="savePath"></param>
        public static string DownloadImage(string requestUrl,string savePath)
        {
            WebRequest imgRequest = WebRequest.Create(requestUrl);
            HttpWebResponse res;
            string fileName = "";
            try
            {
                res = (HttpWebResponse)imgRequest.GetResponse();

            }
            catch (WebException ex)
            {

                res = (HttpWebResponse)ex.Response;
            }
            if (res.StatusCode.ToString() == "OK")
            {
                //文件后缀名
                string fileType = res.ContentType;
                int index = fileType.IndexOf('/')+1;
                fileType = fileType.Substring(index);
                Image downImage = Image.FromStream(imgRequest.GetResponse().GetResponseStream());
                if (!Directory.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);
                }
                //生成文件名
                string guidName = Guid.NewGuid().ToString("N");  
                downImage.Save(savePath+@"\" + guidName + "." + fileType);
                downImage.Dispose();
                fileName = guidName + "." + fileType;
            }

            return fileName;
         }
    }
}