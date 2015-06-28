using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QLTV_1._0.DataTransferObject;
using QLTV_1._0.DataAccessLayer;
using System.Windows.Forms;

namespace QLTV_1._0.BusinessLogicLayer
{
    class BC_SachTreBLL
    {
        public DataTable LoadData(DateTime dat, int days)
        {

            BC_SachTreDAL dal = new BC_SachTreDAL();
            try
            {
                DataTable dtb1 = new DataTable();
                dtb1 = dal.DTBTheLoaiSachTre(dat, days);
                DataColumn col = dtb1.Columns.Add("STT", Type.GetType("System.Int16"));
                col.SetOrdinal(0);
                int i = 0;
                foreach (DataRow dr in dtb1.Rows)
                {
                    dr["STT"] = ++i;
                }
                return dtb1;
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi Dữ Liệu", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return new DataTable();
        }

        public void TestInsert(List<BC_SachTreDTO> dto)
        {
            BC_SachTreDAL dgdal = new BC_SachTreDAL();
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
