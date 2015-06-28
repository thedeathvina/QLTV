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
    class BC_SachMuonDAL
    {
        Connect connect1;
        public BC_SachMuonDAL()
        {
            connect1 = new Connect();
        }
        public DataTable DTBTheLoaiSachMuon(int month, int year)
        {
            string sql = "select TenTheLoai, Count(TenTheLoai) as 'SoLuotMuon' "
                        + "from PHIEUMUONSACH,CUONSACH, SACH, DAUSACH ,THELOAISACH "
                        + "where Month(PHIEUMUONSACH.NgayMuon) ="+month+" and Year(PHIEUMUONSACH.NgayMuon) ="+year
                        + " and CUONSACH.MaCuonSach=PHIEUMUONSACH.MaCuonSach "
                        + "and SACH.MaSach = CUONSACH.MaSach "
                        + "and DAUSACH.MaDauSach = SACH.MaDauSach "
                        + "and THELOAISACH.MaTheLoai = DAUSACH.MaTheLoai "
                        + "Group by THELOAISACH.TenTheLoai ";
            SqlDataAdapter da = new SqlDataAdapter(sql, connect1.Con);
            DataTable dt = new DataTable();
            connect1.connect();
            da.Fill(dt);
            connect1.disconnect();
            return dt;
        }

        public void Insert(List<BC_SachMuonDTO> list_dto)
        {
            SqlConnection ct = new SqlConnection();
            ct = connect1.Con;
            connect1.connect();
            for (int i = 0; i < list_dto.Count; ++i)
            {
                string sql2 = "insert into CHITIETBAOCAOMUONSACH(MaTheLoai,SoLuotMuon,Tile)" + "Values(" + int.Parse(list_dto[i].Matheloai) + "," + list_dto[i].Soluotmuon + "," + list_dto[i].Tile + ")";
                SqlCommand dt = new SqlCommand(sql2, connect1.Con);
                dt.ExecuteNonQuery();

               string sql3 = "insert into BAOCAOMUONSACH(MaCTBCMuonSach,Thang,TongSoLuotMuon)" + "Values("+int.Parse(TimMaCTBC())+",'"+list_dto[i].Thang+"',"+list_dto[i].Tongsoluotmuon+")";
                SqlCommand dt1 = new SqlCommand(sql3, connect1.Con);
                dt1.ExecuteNonQuery();
            }
            connect1.disconnect();
        }

        private string TimMaCTBC()
        {
            string sql = "select MaCTBCMuonSach from CHITIETBAOCAOMUONSACH";
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
