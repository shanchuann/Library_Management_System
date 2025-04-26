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
    public partial class admin1 : Form
    {
        public admin1()
        {
            InitializeComponent();
        }

        private void 图书管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            admin2 admin = new admin2();
            admin.ShowDialog();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Text = "本系统是一个图书管理系统，主要功能有：\n1.图书管理\n2.用户管理\n3.借阅管理\n4.帮助\n5.退出");
        }
    }
}
