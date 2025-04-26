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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                Login();
            }
            else
            {
                MessageBox.Show("请保证输入不为空");
            }
        }
        //是否允许登录
        public void Login()
        {
            if (radioButtonUser.Checked)
            {
                Dao dao = new Dao();
                string sql = "select * from t_user where id ='" + textBox1.Text + "' and psw='" + textBox2.Text + "'";
                IDataReader dc = dao.read(sql);
                if(dc.Read())
                {
                    Data.UID = dc["id"].ToString();
                    Data.UName = dc["name"].ToString();
                    MessageBox.Show("登录成功");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    user1 user = new user1();
                    this.Hide();
                    user.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("用户名或密码错误");
                }
                dao.DaoClose();
            }
            if (radioButtonAdmin.Checked)
            {
                Dao dao = new Dao();
                string sql = "select * from t_admin where id ='" + textBox1.Text + "' and psw='" + textBox2.Text + "'";
                IDataReader dc = dao.read(sql);
                if (dc.Read())
                {
                    MessageBox.Show("登录成功");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    admin1 admin = new admin1();
                    this.Hide();
                    admin.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("用户名或密码错误");
                }
                dao.DaoClose();
            }
        }
    }
}