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
    class MuonSachBLL
    {
        public List<MuonSachDTO> Convert_Type_Sach(DataTable dt1)
        {
            List<MuonSachDTO> list1 = new List<MuonSachDTO>();

            foreach (DataRow dr1 in dt1.Rows)
            {
                MuonSachDTO dg1 = new MuonSachDTO();
                    dg1.Masach = dr1["MaCuonSach"].ToString();
                    dg1.Tensach = dr1["TenDauSach"].ToString();
                    dg1.Theloai = dr1["TenTheLoai"].ToString();
                    dg1.Tacgia = dr1["TenTacGia"].ToString();
                    dg1.Tinhtrang = dr1["TinhTrang"].ToString();
                    list1.Add(dg1);             
            }
            return list1;
        }

        public DataTable List_Table_Sach()
        {
            DataTable dt2 = new DataTable();
            dt2.Columns.Add(new DataColumn("STT"));
            dt2.Columns.Add(new DataColumn("MaCuonSach"));
            dt2.Columns.Add(new DataColumn("TenDauSach"));
            dt2.Columns.Add(new DataColumn("TenTheLoai"));
            dt2.Columns.Add(new DataColumn("TenTacGia"));
            dt2.Columns.Add(new DataColumn("TinhTrang"));
            MuonSachDAL dal = new MuonSachDAL();
            List<MuonSachDTO> list2 = new List<MuonSachDTO>();
            try
            {
                list2 = Convert_Type_Sach(dal.LoadData());
            }
            catch (Exception)
            {
                MessageBox.Show("Loi du lieu!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            for (int i = 0; i < list2.Count; ++i)
            {
                DataRow dr1 = dt2.NewRow();
                dr1.BeginEdit();
                dr1["STT"] = i + 1;
                dr1["MaCuonSach"] = list2[i].Masach;
                dr1["TenDauSach"] = list2[i].Tensach;
                dr1["TenTheLoai"] = list2[i].Theloai;
                dr1["TenTacGia"] = list2[i].Tacgia;
                dr1["TinhTrang"] = list2[i].Tinhtrang;
                dr1.EndEdit();
                dt2.Rows.Add(dr1);
            }
            return dt2;
        }


        public List<MuonSachDTO> Convert_Type_DocGia(DataTable dt1)
        {
            List<MuonSachDTO> list1 = new List<MuonSachDTO>();

            foreach (DataRow dr1 in dt1.Rows)
            {
                MuonSachDTO dg1 = new MuonSachDTO();
                dg1.Madocgia = dr1["MaDocGia"].ToString();
                dg1.Tendocgia = dr1["HoTen"].ToString();
                list1.Add(dg1);
            }
            return list1;
        }
        
        
        public void TestInsert_Docgia(MuonSachDTO dg)
        {
            MuonSachDAL dgdal = new MuonSachDAL();
            try
            {
                dgdal.Insert(dg);
                MessageBox.Show("Lưu dữ liệu thành công!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Không lưu được dữ liệu!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public int Check_Muon(string madg)
        {
            MuonSachDAL dgdal = new MuonSachDAL();
            try
            {
                 return dgdal.Check_Muon(madg);
            }
            catch
            {
                MessageBox.Show("Lỗi Dữ liệu", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return 0;
        }
    }
}
