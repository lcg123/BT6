using Gecko;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BT6
{
    public partial class Form1 : Form
    {

        private readonly string xulrunnerPath = Application.StartupPath + "/xulrunner";
        private const string testUrl = "https://www.alipay.com/";
        private GeckoWebBrowser Browser;

        private Boolean xsgb = false;
        private Boolean xsck = false;
        
        public static Form1 frm1;              //定义一个静态变量

        public Form1()
        {
            InitializeComponent();
            frm1 = this;                       //引用this，可以供其他窗口调用
            Xpcom.Initialize(xulrunnerPath);
        }



        private void button1_Click(object sender, EventArgs e)
        {
            geckoWebBrowser1.Navigate("https://www.okex.com/account/login");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
            Browser = new GeckoWebBrowser();
            Browser.Parent = this;
            Browser.Dock = DockStyle.Fill;
            Browser.Navigate(testUrl);
            */
            geckoWebBrowser1.Navigate("https://www.okex.com/");

            geckoWebBrowser1.Dock = DockStyle.Fill;
        }

        internal void button6_Click()
        {
            throw new NotImplementedException();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            geckoWebBrowser1.Navigate("https://www.okex.com/spot/full/btc-usdt");
        }

        


        private void pictureBox1_Click(object sender, EventArgs e)
        {




            if (!xsck)
            {
                //geckoWebBrowser1.Location = new Point(int.Parse(textBox2.Text), int.Parse(textBox3.Text));
                geckoWebBrowser1.Location = new Point(-55, -83);
                this.Size = new Size(760, 308);
                this.BackColor = Color.White;
                this.TransparencyKey = Color.White;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                //this.ShowInTaskbar = false;
                geckoWebBrowser1.Dock = DockStyle.None;
                xsck = true;
            }
            else
            {
                geckoWebBrowser1.Location = new Point(1, 1);
                this.Size = new Size(1380, 750);
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                this.BackColor = Color.FromKnownColor(System.Drawing.KnownColor.Control);
                this.TransparencyKey = Color.White;
                //this.ShowInTaskbar = true;
                geckoWebBrowser1.Dock = DockStyle.Fill;
                xsck = false;
            }


        }

        public string Gethb()
        {

            string hhbb = "";


            try
            {

                string Title = geckoWebBrowser1.DocumentTitle;
                int kk = Title.IndexOf("| OKEx");
                if (kk > 1) {
                    hhbb = Title + " " + geckoWebBrowser1.Document.GetElementsByClassName("change")[0].TextContent;
                    //textBox2.Text =geckoWebBrowser1.Document.GetElementById("depth-ticker").TextContent;
                }

            }
            catch (OverflowException)
            {
                return "错误";
            }

            return hhbb;

        }

   

        //自定义类的代码
        class Helper
        {
            private static Form2 forChange = new Form2();
            public static Form2 GetForm()
            {
                return forChange;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (!xsgb)
            {
                Helper.GetForm().Show();
                xsgb = true;
            }
            else {
                Helper.GetForm().Hide();
                xsgb = false;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal; //还原窗体
            }



        }
    }
}

