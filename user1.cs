using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookMS
{
    public partial class user1 : Form
    {
        public user1()
        {
            InitializeComponent();
            label1.Text = "欢迎" + Data.UID + "登陆";
        }

        private void 图书查看和借阅ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //调用图书查看和借阅窗体
            user2 u2 = new user2();
            u2.ShowDialog();

        }

        private void 借出图书和归还ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //调用借出图书和归还窗体
            user3 u3 = new user3();
            u3.ShowDialog();
        }

        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //没啥好帮的
            MessageBox.Show("本系统是一个图书管理系统，主要功能有：\n1.图书查看和借阅\n2.借出图书和归还\n3.帮助\n4.退出");
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 联系管理员ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //联系管理员
            MessageBox.Show("请联系管理员");
        }
    }
}
