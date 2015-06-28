using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using QLTV_1._0.DataTransferObject;
using QLTV_1._0.DataAccessLayer;
using System.Windows.Forms;
using System.Data;
namespace QLTV_1._0.BusinessLogicLayer
{
    class ThuPhatBLL
    {
        public List<ThuPhatDTO> Convert_Type(DataTable dt1)
        {
            List<ThuPhatDTO> list1 = new List<ThuPhatDTO>();

            foreach (DataRow dr1 in dt1.Rows)
            {
                ThuPhatDTO dg1 = new ThuPhatDTO();
                dg1.Madocgia = dr1["MaDocGia"].ToString();
                dg1.Hoten = dr1["HoTen"].ToString();
                dg1.Tongno = dr1["TongNo"].ToString();
                list1.Add(dg1);
            }
            return list1;
        }


        public void TestInsert(ThuPhatDTO dg)
        {
            ThuPhatDAL dgdal = new ThuPhatDAL();
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
