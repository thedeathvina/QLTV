using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using QLTV_1._0.DataTransferObject;


namespace QLTV_1._0.DataAccessLayer
{
    class ThemSachDAL
    {
        Connect connect1;
        public ThemSachDAL()
        {
            connect1 = new Connect();
        }

        public DataTable LoadData()
        {
            string sql = "select MaCuonSach, TenDauSach,TenTheLoai,TenTacGia,NamXuatBan, NhaXuatBan,NgayNhap,TriGia from DAUSACH, SACH, CUONSACH,TACGIA,CHITIETTACGIA, THELOAISACH where CUONSACH.MaSach = SACH.MaSach and DAUSACH.MaDauSach = SACH.MaDauSach and THELOAISACH.MaTheLoai = DAUSACH.MaTheLoai and TACGIA.MaTacGia = CHITIETTACGIA.MaTacGia and CHITIETTACGIA.MaDauSach = DAUSACH.MaDauSach";
            DataTable dt = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter(sql, connect1.Con);
            connect1.connect();
            adap.Fill(dt);
            connect1.disconnect();
            return dt;
        }
        public void Insert(ThemSachDTO themsach)
        {
            SqlConnection ct = new SqlConnection();
            ct = connect1.Con;
            string sql = "insert into TACGIA(TenTacGia)"+" Values(N'" + themsach.Tacgia + "')";
            SqlCommand com = new SqlCommand(sql, ct);
            connect1.connect();
            com.ExecuteNonQuery();

            string sql1 = "insert into DAUSACH(TenDauSach, MaTheLoai)" + "Values(N'"+themsach.Tensach+"',"+int.Parse(themsach.Theloai)+")";
            SqlCommand com1 = new SqlCommand(sql1, ct);
            com1.ExecuteNonQuery();

            string sql2 = "insert into SACH(MaDauSach, NamXuatBan, NhaXuatBan,NgayNhap,TriGia)" + "Values("+int.Parse(TimMaDauSach())+","+int.Parse(themsach.Namxb)+",N'"+themsach.Nhaxb+"','"+themsach.Ngaynhap+"',"+int.Parse(themsach.Trigia)+") ";
            SqlCommand com2 = new SqlCommand(sql2, ct);
            com2.ExecuteNonQuery();

            string sql3 = "insert into CUONSACH( MaSach,TinhTrang)" + "Values("+int.Parse(TimMaSach())+",N'" + themsach.Tinhtrang + "')";
            SqlCommand com3 = new SqlCommand(sql3, ct);
            com3.ExecuteNonQuery();

            string sql4 = "insert into CHITIETTACGIA( MaTacGia, MaDauSach)" + "Values("+int.Parse(TimMaTacGia())+","+int.Parse(TimMaDauSach())+")";
            SqlCommand com4 = new SqlCommand(sql4, ct);
            com4.ExecuteNonQuery();

            connect1.disconnect();
        }
        private string TimMaDauSach()
        {
            string sql = "select MaDauSach from DAUSACH";
            DataTable dt = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter(sql, connect1.Con);
            adap.Fill(dt);
            DataRow dr = dt.Rows[dt.Rows.Count - 1];
            return dr["MaDauSach"].ToString();
        }
        private string TimMaSach()
        {
            string sql = "select MaSach from SACH";
            DataTable dt = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter(sql, connect1.Con);
            adap.Fill(dt);
            DataRow dr = dt.Rows[dt.Rows.Count - 1];
            return dr["MaSach"].ToString();
        }
        private string TimMaTacGia()
        {
            string sql = "select MaTacGia from TACGIA";
            DataTable dt = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter(sql, connect1.Con);
            adap.Fill(dt);
            DataRow dr = dt.Rows[dt.Rows.Count - 1];
            return dr["MaTacGia"].ToString();
        }
    }
}
