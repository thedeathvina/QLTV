using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLTV_1._0.DTO;
using QLTV_1._0.DataAccessLayer;
using System.Data;
using System.Windows.Forms;
using System.Globalization;

namespace QLTV_1._0.BusinessLogicLayer
{
    class ThemTL_BLL
    {
       public void TestInsert_SACH(string tentl_sach)
       {
           themTL_DAL dal = new themTL_DAL();
           try
           {
               dal.Insert_Sach(tentl_sach);
               MessageBox.Show(tentl_sach+" đã được thêm vào!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
           }
           catch
           {
                MessageBox.Show("Không thêm được!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
       }
       public void TestInsert_DG(string tenloaidg)
       {
           themTL_DAL dal = new themTL_DAL();
           try
           {
               dal.Insert_DG(tenloaidg);
               MessageBox.Show(tenloaidg + " đã được thêm vào!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
           }
           catch
           {
               MessageBox.Show("Không thêm được!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
       }
       public List<string> load_TheLoaiSach()
       {
           List<string> list_tls = new List<string>();
           themTL_DAL dal = new themTL_DAL();
           DataTable dt1 = dal.load_TLS();
           foreach (DataRow dr1 in dt1.Rows)
           {
               list_tls.Add(dr1["TenTheLoai"].ToString());
           }
           return list_tls;
       }
       public List<string> load_loaiDG()
       {
           List<string> list_tls = new List<string>();
           themTL_DAL dal = new themTL_DAL();
           DataTable dt1 = dal.load_TLDG();
           foreach (DataRow dr1 in dt1.Rows)
           {
               list_tls.Add(dr1["TenLoaiDocGia"].ToString());
           }
           return list_tls;
       }
    }
   
}
