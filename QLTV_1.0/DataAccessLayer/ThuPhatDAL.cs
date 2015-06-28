using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using QLTV_1._0.DataTransferObject;
using System.Data;
namespace QLTV_1._0.DataAccessLayer
{
    class ThuPhatDAL
    {
        Connect connect1;
        public ThuPhatDAL()
        {
            connect1 = new Connect();
        }
        public DataTable LoadData()
        {
            string sql = "select MaDocGia,HoTen,TongNo from DOCGIA";
            DataTable dt = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter(sql, connect1.Con);
            connect1.connect();
            adap.Fill(dt);
            connect1.disconnect();
            return dt;
        }

        public void Insert(ThuPhatDTO dto)
        {
            SqlConnection ct = new SqlConnection();
            ct = connect1.Con;
            string sql2 = "insert into PHIEUTHUTIENPHAT(MaDocGia,NgayLap,SoTienThu,ConLai)" + "Values(" + int.Parse(dto.Madocgia) + ",'" + dto.Ngaylap + "'," + dto.Sotienthu + ","+int.Parse(dto.Tongno)+")";
            SqlCommand dt = new SqlCommand(sql2, connect1.Con);
            connect1.connect();
            dt.ExecuteNonQuery();

            string sql1 = "update DOCGIA set TongNo = " + dto.Tongno + " where MaDocGia = " + int.Parse(dto.Madocgia) + "";
            SqlCommand dt1 = new SqlCommand(sql1, connect1.Con);
            dt1.ExecuteNonQuery();
            connect1.disconnect();
        }
    }
}
