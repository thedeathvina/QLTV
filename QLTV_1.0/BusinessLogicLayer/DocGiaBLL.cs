using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLTV_1._0.DTO;
using QLTV_1._0.DataAccessLayer;
using System.Data;
using System.Windows.Forms;
using System.Globalization;

namespace QLTV_1._0.BLL
{
    class DocGiaBLL
    {
       
       public List<DocGia> Convert_Type(DataTable dt1)
        {
              List<DocGia> list1 = new List<DocGia>();

             foreach (DataRow dr1 in dt1.Rows)
             {
                    DocGia dg1 = new DocGia();
                    dg1.Madocgia = dr1["MaDocGia"].ToString();
                    dg1.Hoten = dr1["HoTen"].ToString();
                    dg1.Loaidocgia = dr1["TenLoaiDocGia"].ToString();
                    dg1.Ngaysinh = dr1["NgaySinh"].ToString();
                    dg1.Ngaylapthe = dr1["NgayLapThe"].ToString();
                    dg1.Email = dr1["Email"].ToString();
                    dg1.Diachi = dr1["DiaChi"].ToString();
                    dg1.Ngayhethan = dr1["NgayHetHan"].ToString();
                    list1.Add(dg1);
             }
        return list1;
        }

       public DataTable List_Table()
       {
           DataTable dt2 = new DataTable();
           dt2.Columns.Add(new DataColumn("STT"));
           dt2.Columns.Add(new DataColumn("MaDocGia"));
           dt2.Columns.Add(new DataColumn("HoTen"));
           dt2.Columns.Add(new DataColumn("TenLoaiDocGia"));
           dt2.Columns.Add(new DataColumn("DiaChi"));
           dt2.Columns.Add(new DataColumn("NgaySinh")); 
           dt2.Columns.Add(new DataColumn("Email"));
           dt2.Columns.Add(new DataColumn("NgayLapThe"));
           dt2.Columns.Add(new DataColumn("NgayHetHan"));
           DocGiaDAL dtdal = new DocGiaDAL();
           List<DocGia> list2 = new List<DocGia>();
           try
           {
               list2 = Convert_Type(dtdal.DanhSachDocGia());
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
               dr1["MaDocGia"] = list2[i].Madocgia;
               dr1["HoTen"] = list2[i].Hoten;
               dr1["TenLoaiDocGia"] = list2[i].Loaidocgia;
               dr1["DiaChi"]= list2[i].Diachi;
               dr1["NgaySinh"] = list2[i].Ngaysinh;
               dr1["Email"] = list2[i].Email;
               dr1["NgayLapThe"] = list2[i].Ngaylapthe;
               dr1["NgayHetHan"] = list2[i].Ngayhethan ;
               dr1.EndEdit();
               dt2.Rows.Add(dr1);
           }
           return dt2;
       }

       public void TestInsert(DocGia dg)
       {
           DocGiaDAL dgdal = new DocGiaDAL();
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
       //public void TestUpdate(string ma)
       //{
       //    DocGiaDAL dgdal = new DocGiaDAL();
       //    dgdal.Update(ma);
           
       //}
       public DateTime Ktra_Hanthe(string mdg)
       { 
            DocGiaDAL dgdal = new DocGiaDAL();
            try
            {
                return dgdal.Kiemtra_The(mdg);
            }
            catch (Exception)
            {
                MessageBox.Show("Không có dữ liệu");
            }
            return new DateTime();
       }
    }
   
}
