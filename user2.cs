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
    public partial class user2 : Form
    {
        public user2()
        {
            InitializeComponent();
        }

        private void user2_Load(object sender, EventArgs e)
        {
            Table(); //加载表格
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
        private void button1_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            int number = int.Parse(dataGridView1.SelectedRows[0].Cells[4].Value.ToString());
            if (number > 0)
            {
                DialogResult dr = MessageBox.Show("是否借阅" + id + "号图书", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    Dao dao = new Dao();
                    //INSERT INTO t_lend values('1001','ISBN978-7-123-45678-3',getdate());update t_book set number = 2 where id = '3';
                    string sql = "INSERT INTO t_lend values('" + Data.UID + "','" + id + "',getdate());update t_book set number = " + (number - 1) + " where id = '" + id + "'";
                    int n = dao.Execute(sql);
                    if (n > 1)
                    {
                        string user_lend = "用户" + Data.UID + "借阅了图书" + id;
                        MessageBox.Show(user_lend);
                        Table();
                    }
                    else
                    {
                        MessageBox.Show("借阅失败");
                    }
                }
            }
            else
            {
                MessageBox.Show("库存不足");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            label2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        }
    }
}
