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
    class TimSachBLL
    {
        public List<TimSachDTO> Convert_Type(DataTable dt1)
        {
            List<TimSachDTO> list1 = new List<TimSachDTO>();

            foreach (DataRow dr1 in dt1.Rows)
            {
                TimSachDTO dg1 = new TimSachDTO();
                dg1.Masach = dr1["MaCuonSach"].ToString();
                dg1.Tensach = dr1["TenDauSach"].ToString();
                dg1.Theloai = dr1["TenTheLoai"].ToString();
                dg1.Namxuatban = dr1["NamXuatBan"].ToString();
                dg1.Tacgia = dr1["TenTacGia"].ToString();
                dg1.Ngaynhap = dr1["NgayNhap"].ToString();
                dg1.Tinhtrang = dr1["TinhTrang"].ToString();
                list1.Add(dg1);
            }
            return list1;
        }
        public DataTable List_Table(string masach, string tensach, string tacgia, string nhaxb, string theloai, string namxb)
        {
            DataTable dt2 = new DataTable();
            dt2.Columns.Add(new DataColumn("STT"));
            dt2.Columns.Add(new DataColumn("MaCuonSach"));
            dt2.Columns.Add(new DataColumn("TenDauSach"));
            dt2.Columns.Add(new DataColumn("TenTheLoai"));
            dt2.Columns.Add(new DataColumn("NamXuatBan"));
            dt2.Columns.Add(new DataColumn("TenTacGia"));
            dt2.Columns.Add(new DataColumn("NgayNhap"));
            dt2.Columns.Add(new DataColumn("TinhTrang"));
            TimSachDAL dal = new TimSachDAL();
            List<TimSachDTO> list2 = new List<TimSachDTO>();
            try
            {
                list2 = Convert_Type(dal.LoadData(masach,tensach,tacgia,nhaxb,theloai,namxb));
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi dữ liệu!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            for (int i = 0; i < list2.Count; ++i)
            {
                DataRow dr1 = dt2.NewRow();
                dr1.BeginEdit();
                dr1["STT"] = i + 1;
                dr1["MaCuonSach"] = list2[i].Masach;
                dr1["TenDauSach"] = list2[i].Tensach;
                dr1["TenTheLoai"] = list2[i].Theloai;
                dr1["NamXuatBan"] = list2[i].Tensach;
                dr1["TenTacGia"] = list2[i].Tacgia;
                dr1["NgayNhap"] = list2[i].Ngaynhap;
                dr1["TinhTrang"] = list2[i].Tinhtrang; 
                dr1.EndEdit();
                dt2.Rows.Add(dr1);
            }
            return dt2;
        }
    }
}
