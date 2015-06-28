using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using QLTV_1._0.DataTransferObject;
using System.Windows.Forms;

namespace QLTV_1._0.DataAccessLayer
{
    class themTL_DAL
    {
         Connect connect1;
         public themTL_DAL()
        {
            connect1 = new Connect();
        } 
       private int Set_MaTheLoaiDG()
        {
            string sql = "select MaLoaiDocGia from LOAIDOCGIA";
            DataTable dt = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter(sql, connect1.Con);
            adap.Fill(dt);
            DataRow dr = dt.Rows[dt.Rows.Count - 1];
            return int.Parse(dr["MaLoaiDocGia"].ToString()) + 1;
        }
        private int Set_MaTheLoaiSach()
        {
            string sql = "select MaTheLoai from THELOAISACH";
            DataTable dt = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter(sql, connect1.Con);
            adap.Fill(dt);
            DataRow dr = dt.Rows[dt.Rows.Count - 1];
            return int.Parse(dr["MaTheLoai"].ToString())+1;
        }
        public void Insert_DG(string tenloaidg)
        {
            int n = this.Set_MaTheLoaiDG();
            SqlConnection ct = new SqlConnection();
            ct = connect1.Con;
            string sql = "SET IDENTITY_INSERT LOAIDOCGIA ON insert into LOAIDOCGIA(MaLoaiDocGia,TenLoaiDocGia)" + "Values(N'" + n + "','" + tenloaidg + "')";
            SqlCommand com = new SqlCommand(sql, ct);
            connect1.connect();
            com.ExecuteNonQuery();
            connect1.disconnect();
        }
        public void Insert_Sach(string tenloais)
        {
            int n = this.Set_MaTheLoaiSach();
            SqlConnection ct = new SqlConnection();
            ct = connect1.Con;
            string sql = "SET IDENTITY_INSERT THELOAISACH ON insert into THELOAISACH(MaTheLoai,TenTheLoai)" + "Values(N'" + n + "','" + tenloais + "')";
            SqlCommand com = new SqlCommand(sql, ct);
            connect1.connect();
            com.ExecuteNonQuery();
            connect1.disconnect();
        }
        public DataTable load_TLS()
        {
            string sql = "Select TenTheLoai from THELOAISACH";
            DataTable dt = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter(sql, connect1.Con);
            connect1.connect();
            adap.Fill(dt);
            connect1.disconnect();
            return dt;
        }
        public DataTable load_TLDG()
        {
            string sql = "Select TenLoaiDocGia from LOAIDOCGIA";
            DataTable dt = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter(sql, connect1.Con);
            connect1.connect();
            adap.Fill(dt);
            connect1.disconnect();
            return dt;
        }
    }
}
