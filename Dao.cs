using System.Data.SqlClient;

namespace BookMS
{
    class Dao
    {
        SqlConnection sc;
        public SqlConnection connect()
        {
            string str = "Data Source = 山川不念旧\\SHANCHUAN;Initial Catalog=BookMS;Integrated Security=True"; //数据库连接字符串
            sc = new SqlConnection(str); //创建连接对象
            sc.Open();
            return sc;
        }
        public SqlCommand command(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, connect());
            return cmd;
        }
        public int Execute(string sql) //更新
        {
            return command(sql).ExecuteNonQuery();
        }
        public SqlDataReader read(string sql) //读取
        {
            return command(sql).ExecuteReader();
        }
        public void DaoClose() //关闭连接
        {
            sc.Close();
        }
    }
}
