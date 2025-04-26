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
    public partial class admin2 : Form
    {
        public admin2()
        {
            InitializeComponent();
        }

        private void admin2_Load(object sender, EventArgs e)
        {
            Table();
            label2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        }
        public void Table()
        {
            dataGridView1.Rows.Clear(); //清空表格
            Dao dao = new Dao();
            string sql = "select * from t_book";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString());
            }
            dc.Close();
            dao.DaoClose();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                DialogResult dr = MessageBox.Show("是否删除" + id + "号图书", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    Dao dao = new Dao();
                    string sql = "delete from t_book where id='" + id + "'";
                    int n = dao.Execute(sql);
                    if (n > 0)
                    {
                        MessageBox.Show("删除成功");
                        Table();
                    }
                    else
                    {
                        MessageBox.Show("删除失败");
                    }
                }
            }
            catch
            {
                MessageBox.Show("请选中一行");
                return;
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            label2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            admin21 f = new admin21();
            f.ShowDialog();
            Table();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string name = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                string author = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                string press = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                string number = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                admin22 admin = new admin22(id,name,author,press,number);
                admin.ShowDialog();
                Table();
            }
            catch
            {
                MessageBox.Show("请选中一行");
                return;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Table();
        }
        public void TableID()
        {
            dataGridView1.Rows.Clear(); //清空表格
            Dao dao = new Dao();
            string sql = "select * from t_book WHERE id = '" + textBox1.Text + "'";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString());
            }
            dc.Close();
            dao.DaoClose();
        }
        public void TableName()
        {
            dataGridView1.Rows.Clear(); //清空表格
            Dao dao = new Dao();
            //select * from t_book WHERE name LIKE '%算法%';
            string sql = "select * from t_book WHERE name LIKE '%" + textBox2.Text + "%'";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString());
            }
            dc.Close();
            dao.DaoClose();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            TableID();
            //清空文本框
            textBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TableName();
            //清空文本框
            textBox2.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
