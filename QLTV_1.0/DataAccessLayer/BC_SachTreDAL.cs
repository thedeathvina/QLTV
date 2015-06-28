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
    class BC_SachTreDAL
    {
         Connect connect1;
         public BC_SachTreDAL()
        {
            connect1 = new Connect();
        }
        public DataTable DTBTheLoaiSachTre(DateTime dat, int days)
        {
            string sql = "select CUONSACH.MaCuonSach, DAUSACH.TenDauSach, PHIEUMUONSACH.NgayMuon, DATEDIFF(DAY, PHIEUMUONSACH.NgayMuon,'" + dat.Date + "')-4 as 'NgayTre' "
                       + "from CUONSACH, PHIEUMUONSACH, SACH, DAUSACH "
                       + "where PHIEUMUONSACH.MaPhieuMuon in( "
                       + "select MaPhieuMuon "
                       + "from PHIEUMUONSACH "
                       + "where MaPhieuMuon not in( "
                                           + "select MaPhieuMuon "
                                           + "from PHIEUTRASACH)) "
                       + "and CUONSACH.MaCuonSach = PHIEUMUONSACH.MaCuonSach "
                       + "and PHIEUMUONSACH.MaCuonSach=CUONSACH.MaCuonSach "
                       + "and SACH.MaSach = CUONSACH.MaSach "
                       + "and DAUSACH.MaDauSach = SACH.MaDauSach "
                       + "and DATEDIFF(DAY,PHIEUMUONSACH.NgayMuon,'" + dat.Date + "') >" + days;
            SqlDataAdapter da = new SqlDataAdapter(sql, connect1.Con);
            DataTable dt = new DataTable();
            connect1.connect();
            da.Fill(dt);
            connect1.disconnect();
            return dt;
        }

        

        public void Insert(List<BC_SachTreDTO> list_dto)
        {
            SqlConnection ct = new SqlConnection();
            ct = connect1.Con;
            connect1.connect();
            for (int i = 0; i < list_dto.Count; ++i)
            {
                string sql2 = "insert into BAOCAOSACHTRATRE(Ngay,MaCuonSach,NgayMuon,SoNgayTraTre)" + "Values('" + list_dto[i].Ngay+ "'," + int.Parse(list_dto[i].Macuonsach) + ",'" + list_dto[i].Ngaymuon + "'," + int.Parse(list_dto[i].Songaytre) + ")";
                SqlCommand dt = new SqlCommand(sql2, connect1.Con);
                dt.ExecuteNonQuery();
            }
            connect1.disconnect();
        }
    }
}
