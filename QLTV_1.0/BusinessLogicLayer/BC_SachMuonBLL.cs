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
    class BC_SachMuonBLL
    {
        public DataTable LoadData(int month, int year)
        {

            BC_SachMuonDAL dal = new BC_SachMuonDAL();
            try
            {
                DataTable dtb1= new DataTable();
                dtb1= dal.DTBTheLoaiSachMuon(month, year);
                DataColumn col = dtb1.Columns.Add("STT", Type.GetType("System.Int16"));
                col.SetOrdinal(0);
                col = dtb1.Columns.Add("TiLe", Type.GetType("System.Int16"));
                col.SetOrdinal(3);
                int i = 0;
                float percent= 100/Load_TongSoLuotMuon(month, year);
                foreach (DataRow dr in dtb1.Rows)
                {
                    dr["STT"] = ++i;
                    dr["Tile"] = (float.Parse(dr["SoLuotMuon"].ToString()) *percent).ToString();
                }
                return dtb1;
            }
            catch (Exception)
            {
                MessageBox.Show("Loi du lieu!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return new DataTable();
        }
        public int Load_TongSoLuotMuon(int month, int year)
        {
            BC_SachMuonDAL dal = new BC_SachMuonDAL();
            return dal.TongSoLuotMuon(month, year);
        }
        
        public void TestInsert(List<BC_SachMuonDTO> dg)
        {
            BC_SachMuonDAL dgdal = new BC_SachMuonDAL();
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
     
        //public BC_SachMuonDTO Convert_toInsert(DataRow dtr, int month, int tongsoluot)
        //{
        //    BC_SachMuonDAL dal = new BC_SachMuonDAL();
        //    BC_SachMuonDTO bc = new BC_SachMuonDTO();
        //    bc.Mabcmuonsach = dal.ADD_MaBCSM().ToString();
        //    bc.Mactbcmuonsach = dal.ADD_MaCTBCSM().ToString();
        //    bc.Soluotmuon = int.Parse(dtr["SoLuotMuon"].ToString());
        //    bc.Tile = float.Parse(dtr["TiLe"].ToString());
        //    bc.Thang = month;
        //    bc.Tongsoluotmuon = tongsoluot;
        //    string type = dtr["TenTheLoai"].ToString();
        //    if (type == "A")
        //        bc.Matheloai = "1";
        //    else if (type == "B")
        //        bc.Matheloai = "2";
        //    else
        //        bc.Matheloai = "3";
        //    return bc;
        //}
    }
}
