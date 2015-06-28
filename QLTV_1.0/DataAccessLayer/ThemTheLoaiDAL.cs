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
    class ThemTheLoaiDAL
    {
        Connect connect1;
        public ThemTheLoaiDAL()
        {
            connect1 = new Connect();
        }
        public void Insert(string str)
        {
            SqlConnection ct = new SqlConnection();
            ct = connect1.Con;
            connect1.connect();
            string sql2 = "";
            SqlCommand dt = new SqlCommand(sql2, connect1.Con);
            dt.ExecuteNonQuery();   
            connect1.disconnect();
        }

        private string TimMaLoaiDG()
        {
            string sql = "SELECT TOP 1 MaLoaiDocGia FROM LOAIDOCGIA ORDER BY MaLoaiDocGia DESC";
            DataTable dt = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter(sql, connect1.Con);
            adap.Fill(dt);
            DataRow dr = dt.Rows[dt.Rows.Count - 1];
            return dr["MaCTBCMuonSach"].ToString();
        }
      
        public int TongSoLuotMuon(int month, int year)
        {

            string sql = "select Sum(mycount) "
                        + "from( select count(*) as mycount "
                        + "from PHIEUMUONSACH,CUONSACH, SACH, DAUSACH ,THELOAISACH "
                        + "where Month(PHIEUMUONSACH.NgayMuon) =" + month + " and Year(PHIEUMUONSACH.NgayMuon) =" + year
                        + " and CUONSACH.MaCuonSach=PHIEUMUONSACH.MaCuonSach "
                        + "and SACH.MaSach = CUONSACH.MaSach "
                        + "and DAUSACH.MaDauSach = SACH.MaDauSach "
                        + "and THELOAISACH.MaTheLoai = DAUSACH.MaTheLoai "
                        + "Group by THELOAISACH.TenTheLoai)a";
            SqlCommand comm = new SqlCommand(sql, connect1.Con);
            connect1.connect();
            try
            {
                Int32 ms = (Int32)comm.ExecuteScalar();
                connect1.disconnect();
                return ms;
            }
            catch (Exception)
            {
                MessageBox.Show("Tháng " + month + " không cho có sách nào được mượn");
            }
            return 0;
        }
       
        public int ADD_MaBCSM()
        {
            string sql = "select count(*) from BAOCAOMUONSACH";
            SqlCommand comm = new SqlCommand(sql, connect1.Con);
            connect1.connect();
            Int32 ms= (Int32)comm.ExecuteScalar();
            connect1.disconnect();
            return ms+1;
        }
        public int ADD_MaCTBCSM()
        {
            string sql = "select count(*) from CHITIETBAOCAOMUONSACH";
            SqlCommand comm = new SqlCommand(sql, connect1.Con);
            connect1.connect();
            Int32 ms = (Int32)comm.ExecuteScalar();
            connect1.disconnect();
            return ms + 1;
        }
    }
}
