using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLTV_1._0.DataTransferObject;
using System.Data;
using System.Data.SqlClient;

namespace QLTV_1._0.DataAccessLayer
{
    class TraSachDAL
    {
        Connect connect1;
        public TraSachDAL()
        {
            connect1 = new Connect();
        }

        public DataTable LoadData()
        {
            string sql = "select * from PHIEUMUONSACH,DOCGIA,CUONSACH where PHIEUMUONSACH.MaDocGia = DOCGIA.MaDocGia and PHIEUMUONSACH.MaCuonSach = CUONSACH.MaCuonSach";
            DataTable dt = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter(sql, connect1.Con);
            connect1.connect();
            adap.Fill(dt);

            connect1.disconnect();
            return dt;
        }

        public void Insert(TraSachDTO dto)
        {
            string sql1 = "insert into PHIEUTRASACH(NgayTra,MaPhieuMuon,SoNgayMuon,SoNgayTraTre,TienPhat,NoConLai)" + "Values('"+dto.Ngaytra+"',"+int.Parse(dto.Maphieumuon)+","+dto.Songaymuon+","+dto.Songaytratre+","+dto.Tienphat+","+int.Parse(dto.Conlai)+")";
            SqlCommand dt1 = new SqlCommand(sql1, connect1.Con);
            connect1.connect();
            dt1.ExecuteNonQuery();

            string sql2 = "update DOCGIA set TongNo = " + int.Parse(dto.Tongno) + " where MaDocGia = " + int.Parse(dto.Madocgia) + "";
            SqlCommand dt2 = new SqlCommand(sql2, connect1.Con);
            dt2.ExecuteNonQuery();

            string sql3 = "update CUONSACH set TinhTrang = N'"+dto.Tinhtrang+"' where MaCuonSach = " + int.Parse(dto.Masach) + "";
            SqlCommand dt3 = new SqlCommand(sql3, connect1.Con);
            dt3.ExecuteNonQuery();
            connect1.disconnect();
        }
        public void Del(TraSachDTO dto)
        {
            string sql1 = "delete from ";
            SqlCommand dt1 = new SqlCommand(sql1, connect1.Con);
            connect1.connect();
            dt1.ExecuteNonQuery();
            connect1.disconnect();
        }
    }
}
