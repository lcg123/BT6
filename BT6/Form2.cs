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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.ControlBox = false;   // 设置不出现关闭按钮
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = Form1.frm1.Gethb().Replace("/USDT | OKEx.com", "");
        }

        private void Form2_DoubleClick(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            this.BackColor = Color.White;
            this.TransparencyKey = Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void Form2_Click(object sender, EventArgs e)
        {
            label1.Text = Form1.frm1.Gethb().Replace("/USDT | OKEx.com", "");
        }
    
    }
}
