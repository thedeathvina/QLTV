using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using QLTV_1._0.DataTransferObject;

namespace QLTV_1._0.DataAccessLayer
{
    class MuonSachDAL
    {
        Connect connect1;
        public MuonSachDAL()
        {
            connect1 = new Connect();
        }

        public DataTable LoadData()
        {
            string sql = "select MaCuonSach,TenDauSach,TenTheLoai,TenTacGia,TinhTrang from DAUSACH, SACH, CUONSACH,TACGIA,CHITIETTACGIA, THELOAISACH where CUONSACH.MaSach = SACH.MaSach and DAUSACH.MaDauSach = SACH.MaDauSach and THELOAISACH.MaTheLoai = DAUSACH.MaTheLoai and TACGIA.MaTacGia = CHITIETTACGIA.MaTacGia and CHITIETTACGIA.MaDauSach = DAUSACH.MaDauSach";
            DataTable dt = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter(sql, connect1.Con);
            connect1.connect();
            adap.Fill(dt);
            connect1.disconnect();
            return dt;
        }
        public DataTable LoadDataDocGia()
        {
            DataTable dt = new DataTable();
            string sql1 = "select MaDocGia, HoTen, NgayLapThe from DOCGIA ";
            SqlDataAdapter adap1 = new SqlDataAdapter(sql1, connect1.Con);
            connect1.connect();
            adap1.Fill(dt);
            connect1.disconnect();
            return dt;
        }

        public void Insert(MuonSachDTO dto)
        {
            SqlConnection ct = new SqlConnection();
            ct = connect1.Con;
            string sql2 = "insert into PHIEUMUONSACH(NgayMuon,MaDocGia,MaCuonSach)" + "Values('" + dto.Ngaymuon + "'," + int.Parse(dto.Madocgia) + "," + int.Parse(dto.Masach) + ")";
            SqlCommand dt = new SqlCommand(sql2, connect1.Con);
            connect1.connect();
            dt.ExecuteNonQuery();

            string sql1 = "update CUONSACH set TinhTrang = N'" + dto.Tinhtrang + "' where MaCuonSach = " + int.Parse(dto.Masach) + "";
            SqlCommand dt1 = new SqlCommand(sql1, connect1.Con);
            dt1.ExecuteNonQuery();
            connect1.disconnect();
        }
        public int Check_Muon(string madg)
        {
            string sql = "select count(MaDocGia) "
                        + "from PHIEUMUONSACH "
                        + "where MaPhieuMuon in( "
                        + "select MaPhieuMuon "
                        + "from PHIEUMUONSACH "
                        + "where MaPhieuMuon not in( "
                        + "select MaPhieuMuon "
                        + "from PHIEUTRASACH)) "
                        + "and MaDocGia=" + madg;
            SqlCommand comm = new SqlCommand(sql, connect1.Con);
            connect1.connect();
            Int32 count = (Int32)comm.ExecuteScalar();
            connect1.disconnect();
            return count;
        }
    }
}
