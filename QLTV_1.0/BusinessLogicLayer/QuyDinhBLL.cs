using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLTV_1._0.DataAccessLayer;
using QLTV_1._0.BusinessLogicLayer;
using QLTV_1._0.DataTransferObject;
using System.Data;
using System.Windows.Forms;

namespace QLTV_1._0.BusinessLogicLayer
{
    class QuyDinhBLL
    {
        public QuyDinhDTO Convert_Type(DataTable dt)
        {
            QuyDinhDTO qd = new QuyDinhDTO();
            DataRow dr1 = dt.Rows[0];
            qd.Tuoitoithieu = int.Parse(dr1["TuoiToiThieu"].ToString());
            qd.Tuoitoida = int.Parse(dr1["TuoiToiDa"].ToString());
            qd.Thoihanthe = int.Parse(dr1["ThoiHanSuDung"].ToString());
            qd.Thoihanxb = int.Parse(dr1["KhoangCachNamXuatBan"].ToString());
            qd.Sosachmuontoida = int.Parse(dr1["SoSachMuonToiDa"].ToString());
            qd.Songaymuontoida = int.Parse(dr1["ThoiGianMuonToiDa"].ToString());
            qd.Tienphat = decimal.Parse(double.Parse(dr1["TienPhatMoiNgay"].ToString()).ToString());
            qd.Qd6 = bool.Parse(dr1["ApDungQD6"].ToString());
            return qd;
        }

        public QuyDinhDTO TestLoad()
        {
            QuyDinhDTO qd = new QuyDinhDTO();
            QuyDinhDAL dal = new QuyDinhDAL();
            try
            {
                qd = Convert_Type(dal.LoadData());
            }
            catch
            {
                MessageBox.Show("Lỗi dữ liệu!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return qd;
        }
        public void TestUpdate(QuyDinhDTO dto)
        {
            QuyDinhDAL dal = new QuyDinhDAL();
            try
            {
                dal.Update(dto);
                MessageBox.Show("Update dữ liệu thành công!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Update dữ liệu không thành công", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
