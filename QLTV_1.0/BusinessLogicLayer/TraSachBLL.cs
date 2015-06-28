using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using QLTV_1._0.DataTransferObject;
using QLTV_1._0.DataAccessLayer;
using System.Windows.Forms;

namespace QLTV_1._0.BusinessLogicLayer
{
    class TraSachBLL
    {

        public List<TraSachDTO> Convert_Type(DataTable dt1)
        {
            List<TraSachDTO> list1 = new List<TraSachDTO>();

            foreach (DataRow dr1 in dt1.Rows)
            {
                TraSachDTO dg1 = new TraSachDTO();
                dg1.Tinhtrang = dr1["TinhTrang"].ToString();
                dg1.Masach = dr1["MaCuonSach"].ToString();
                dg1.Ngaymuon = dr1["NgayMuon"].ToString();
                dg1.Madocgia = dr1["MaDocGia"].ToString();
                dg1.Tendocgia = dr1["HoTen"].ToString();
                dg1.Tongno = dr1["TongNo"].ToString();
                dg1.Maphieumuon = dr1["MaPhieuMuon"].ToString();
                list1.Add(dg1);
            }
            return list1;
        }
       

        public DataTable List_Table_Sach(int mdg)
        {
            DataTable dt2 = new DataTable();
            dt2.Columns.Add(new DataColumn("STT"));
            dt2.Columns.Add(new DataColumn("MaCuonSach"));
            dt2.Columns.Add(new DataColumn("NgayMuon"));
            dt2.Columns.Add(new DataColumn("SoNgayMuon"));
            dt2.Columns.Add(new DataColumn("TienPhat"));
            dt2.Columns.Add(new DataColumn("MaPhieuMuon"));
            TraSachDAL dal = new TraSachDAL();
            List<TraSachDTO> list2 = new List<TraSachDTO>();
            try
            {
                list2 = Convert_Type(dal.LoadData());
            }
            catch (Exception)
            {
                MessageBox.Show("Loi du lieu!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            for (int i = 0; i < list2.Count; ++i)
            {
                DataRow dr1 = dt2.NewRow();
                dr1.BeginEdit();
                
                    if (mdg == int.Parse(list2[i].Madocgia))
                    {
                        if (list2[i].Tinhtrang == "Đã được mượn")
                        {
                            dr1["STT"] = i + 1;
                            dr1["MaCuonSach"] = list2[i].Masach;
                            dr1["NgayMuon"] = list2[i].Ngaymuon;
                            DateTime ngmuon = DateTime.Parse(list2[i].Ngaymuon);
                            DateTime snm = DateTime.Now;
                            TimeSpan songay = snm - ngmuon;
                            dr1["SoNgayMuon"] = songay.Days;
                            QuyDinhBLL qdinhbll = new QuyDinhBLL();
                            QuyDinhDTO qdinhdto = qdinhbll.TestLoad();
                            int ngaymuontoida = qdinhdto.Songaymuontoida;
                            int songaytratre = 0;
                            if (songay.Days > ngaymuontoida)
                            {
                                songaytratre = songay.Days - ngaymuontoida;
                            }
                            dr1["TienPhat"] = songaytratre * 1000;
                            dr1["MaPhieuMuon"] = list2[i].Maphieumuon;
                            dr1.EndEdit();
                            dt2.Rows.Add(dr1);
                            for (int j = i+1; j < list2.Count; ++j)
                            {
                                if (int.Parse(list2[i].Masach) == int.Parse(list2[j].Masach))
                                {
                                    dt2.Rows.Remove(dr1);
                                    break;
                                }
                            }
                        }
                    }
            }
            return dt2;
        }
        public void Test(TraSachDTO dto)
        {
            TraSachDAL dgdal = new TraSachDAL();
            try
            {
                dgdal.Insert(dto);
                MessageBox.Show("Lưu dữ liệu thành công!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Không lưu được dữ liệu!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
    }
}
