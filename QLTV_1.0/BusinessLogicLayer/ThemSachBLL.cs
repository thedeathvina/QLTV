using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLTV_1._0.DataTransferObject;
using QLTV_1._0.DataAccessLayer;
using System.Data;
using System.Windows.Forms;

namespace QLTV_1._0.BusinessLogicLayer
{
    class ThemSachBLL
    {
        public List<ThemSachDTO> Convert_Type(DataTable dt1)
        {
            List<ThemSachDTO> list1 = new List<ThemSachDTO>();

            foreach (DataRow dr1 in dt1.Rows)
            {
                ThemSachDTO dg1 = new ThemSachDTO();
                dg1.Masach = dr1["MaCuonSach"].ToString();
                dg1.Tensach = dr1["TenDauSach"].ToString();
                dg1.Theloai = dr1["TenTheLoai"].ToString();
                dg1.Tacgia = dr1["TenTacGia"].ToString();
                dg1.Namxb = dr1["NamXuatBan"].ToString();
                dg1.Nhaxb = dr1["NhaXuatBan"].ToString();
                dg1.Ngaynhap = dr1["NgayNhap"].ToString();
                dg1.Trigia = dr1["TriGia"].ToString();
                list1.Add(dg1);
            }
            return list1;
        }
        public DataTable List_Table()
        {
            DataTable dt2 = new DataTable();
            dt2.Columns.Add(new DataColumn("STT"));
            dt2.Columns.Add(new DataColumn("MaCuonSach"));
            dt2.Columns.Add(new DataColumn("TenDauSach"));
            dt2.Columns.Add(new DataColumn("TenTheLoai"));
            dt2.Columns.Add(new DataColumn("TenTacGia"));
            dt2.Columns.Add(new DataColumn("NamXuatBan"));
            dt2.Columns.Add(new DataColumn("NhaXuatBan"));
            dt2.Columns.Add(new DataColumn("NgayNhap"));
            dt2.Columns.Add(new DataColumn("TriGia"));
            ThemSachDAL dal = new ThemSachDAL();
            List<ThemSachDTO> list2 = new List<ThemSachDTO>();
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
                dr1["STT"] = i + 1;
                dr1["MaCuonSach"] = list2[i].Masach;
                dr1["TenDauSach"] = list2[i].Tensach;
                dr1["TenTheLoai"] = list2[i].Theloai;
                dr1["TenTacGia"] = list2[i].Tacgia;
                dr1["NamXuatBan"] = list2[i].Namxb;
                dr1["NhaXuatBan"] = list2[i].Nhaxb;
                dr1["NgayNhap"] = list2[i].Ngaynhap;
                dr1["TriGia"] = list2[i].Trigia;
                dr1.EndEdit();
                dt2.Rows.Add(dr1);
            }
            return dt2;
        }

        public void TestInsert(ThemSachDTO dg)
       {
           ThemSachDAL dgdal = new ThemSachDAL();
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
    }
}
