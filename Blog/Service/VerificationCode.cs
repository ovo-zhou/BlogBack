using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Service
{
    public class VerificationCode : IVerificationCode
    {
        private Dictionary<string, string> codeList = new Dictionary<string, string>();
        public bool CheckCode(string UUID, string code)
        {
            if (codeList.ContainsKey(UUID)&&code==codeList[UUID]) 
            {
                codeList.Remove(UUID);
                return true;
            }
            return false;
        }

        public string GetVerificationCode(string UUID)
        {
            //生成四位数字验证码
            string code = string.Empty;
            Random r = new Random();
            for (int i = 0; i < 4; i++)
            {
                int num = r.Next(0, 10);
                code += num.ToString();
            }
            if (!codeList.ContainsKey(UUID))
            {
                codeList.Add(UUID, code);
            }
            else {
                return "UUID重复";
            }
            //绘图
            Bitmap bmp = new Bitmap(80, 20);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            for (int i = 0; i < 4; i++)
            {
                Point p = new Point(i * 20, 0);
                string[] fonts = { "微软雅黑", "宋体", "黑体", "隶书", "仿宋" };
                Color[] colors = { Color.Blue, Color.Black, Color.Red, Color.Green };
                g.DrawString(code[i].ToString(), new Font(fonts[r.Next(0, 5)], 15, FontStyle.Bold), new SolidBrush(colors[r.Next(0, 4)]), p);
            }
            //转为base64
            MemoryStream ms = new MemoryStream();
            bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] arr = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(arr, 0, (int)ms.Length);
            ms.Close();
            return "data:image/png;base64,"+Convert.ToBase64String(arr);
        }
    }
}
