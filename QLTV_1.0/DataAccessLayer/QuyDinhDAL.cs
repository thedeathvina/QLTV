using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using QLTV_1._0.DataTransferObject;
namespace QLTV_1._0.DataAccessLayer
{
    class QuyDinhDAL
    {
        Connect connect2;
        public QuyDinhDAL()
        {
            connect2 = new Connect();
        }

        public DataTable LoadData()
        {
            string sql = "select * from THAMSO";
            SqlDataAdapter adap = new SqlDataAdapter(sql,connect2.Con);
            DataTable dt = new DataTable();
            connect2.connect();
            adap.Fill(dt);
            connect2.disconnect();
            return dt;
        }

        public void Update(QuyDinhDTO dto)
        {
            string sql = "update THAMSO set TuoiToiThieu = " + dto.Tuoitoithieu + ", TuoiToiDa = "+dto.Tuoitoida+", ThoiHanSuDung = "+dto.Thoihanthe+",KhoangCachNamXuatBan = "+dto.Thoihanxb+",SoSachMuonToiDa = "+dto.Sosachmuontoida+", ThoiGianMuonToiDa = "+dto.Songaymuontoida+"";
            SqlCommand com = new SqlCommand(sql,connect2.Con);
            DataTable dt = new DataTable();
            connect2.connect();
            com.ExecuteNonQuery();
            connect2.disconnect();
        }
    }
}
