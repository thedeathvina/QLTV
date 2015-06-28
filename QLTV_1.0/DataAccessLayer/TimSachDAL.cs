using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using QLTV_1._0.DataTransferObject;

namespace QLTV_1._0.DataAccessLayer
{
    class TimSachDAL
    {
        Connect connect1;
        public TimSachDAL()
        {
            connect1 = new Connect();
        }
        public DataTable LoadData(string masach, string tensach, string tacgia,string nhaxb, string theloai,string namxb)
        {
            string sql = "";
            sql += "select MaCuonSach, TenDauSach,TenTheLoai,TenTacGia,NamXuatBan, NhaXuatBan,NgayNhap,TinhTrang from DAUSACH, SACH, CUONSACH,TACGIA,CHITIETTACGIA, THELOAISACH where CUONSACH.MaSach = SACH.MaSach and DAUSACH.MaDauSach = SACH.MaDauSach and THELOAISACH.MaTheLoai = DAUSACH.MaTheLoai and TACGIA.MaTacGia = CHITIETTACGIA.MaTacGia and CHITIETTACGIA.MaDauSach = DAUSACH.MaDauSach  ";
            
            if (masach != "")
                sql += "and MaCuonSach = "+ int.Parse(masach)+"";
            if (tensach !="")
                sql += "and TenDauSach = N'"+ tensach+"'";
            if (tacgia !="")
                sql += "and TenTacGia = N'"+ tacgia+"'";
            if (nhaxb !="")
                sql += "and NhaXuatBan = N'"+ nhaxb+"'";
            if (theloai != "" && theloai != "(Nope)")
                sql += "and TenTheLoai = '"+ theloai+"'";
            if (namxb !="" && namxb != "(Nope)")
                sql += "and NamXuatBan = " + int.Parse(namxb) + "";
            DataTable dt = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter(sql, connect1.Con);
            connect1.connect();
            adap.Fill(dt);
            connect1.disconnect();
            return dt;
        }

        
    }
}
