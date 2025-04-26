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
    public partial class user3 : Form
    {
        public user3()
        {
            InitializeComponent();
            Table();
            //当前选中的图书名
            if (dataGridView1.SelectedRows.Count > 0)
            {
                label2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            }
            else
            {
                label2.Text = "无";
            }
        }
        public void Table()
        {
            dataGridView1.Rows.Clear(); //清空表格
            Dao dao = new Dao();
            //SELECT no,bid,name,datetime FROM t_lend,t_book WHERE uid = '1001';
            string sql = "SELECT no,bid,name,datetime FROM t_lend,t_book WHERE uid = '" + Data.UID + "' and t_lend.bid = t_book.id";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString());
            }
            dc.Close();
            dao.DaoClose();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //DELETE FROM t_lend WHERE no = 3;UPDATE t_book SET number = number + 1 WHERE id = 'ISBN978-7-123-45678-0';
            string no = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            string id = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            string sql = "DELETE FROM t_lend WHERE no = " + no + ";UPDATE t_book SET number = number + 1 WHERE id = '" + id + "'";
            Dao dao = new Dao();
            int n = dao.Execute(sql);
            if (n > 1)
            {
                MessageBox.Show("归还成功");
                Table();
            }
            else
            {
                MessageBox.Show("归还失败");
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            label2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        }
    }
}
