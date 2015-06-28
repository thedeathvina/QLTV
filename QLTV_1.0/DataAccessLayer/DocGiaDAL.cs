using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using QLTV_1._0.DTO;

namespace QLTV_1._0.DataAccessLayer
{
    class DocGiaDAL
    {
        Connect connect1;
        public DocGiaDAL()
        {
            connect1 = new Connect();
        }
        public DataTable DanhSachDocGia()
        {
            string sql = "select * from DOCGIA,LOAIDOCGIA where DOCGIA.MaLoaiDocGia = LOAIDOCGIA.MaLoaiDocGia";
            SqlDataAdapter da = new SqlDataAdapter(sql, connect1.Con);
            DataTable dt = new DataTable();
            connect1.connect();
            da.Fill(dt);
            connect1.disconnect();
            return dt;
        }
        //public void Update(string ma)
        //{
        //    string sql = "update DOCGIA set NgayHethan=DATEADD(month,6,NgayLapThe) where MaDocGia="+ma;
        //    SqlCommand com = new SqlCommand(sql, connect1.Con);
        //    connect1.connect();
        //    com.ExecuteNonQuery();
        //    connect1.disconnect();
        //}
        public void Insert(DocGia dg)
        {
            string sql = "insert into DOCGIA(HoTen,MaLoaiDocGia,NgaySinh,DiaChi,Email,NgayLapThe,NgayHetHan,TongNo)" + "Values(N'" + dg.Hoten + "','" + int.Parse(dg.Loaidocgia) + "','" + dg.Ngaysinh + "',N'" + dg.Diachi + "','" + dg.Email + "','" + dg.Ngaylapthe + "','" + "','" + dg.Ngayhethan + "','" + dg.Tongno + "')";
            SqlCommand com = new SqlCommand(sql,connect1.Con);
            connect1.connect();
            com.ExecuteNonQuery();
            connect1.disconnect();
        }
        public DateTime Kiemtra_The(string mdg)
        {
            string sql = "select NgayLapThe from DOCGIA where DOCGIA.MaDocGia =" + mdg;
            SqlCommand comm = new SqlCommand(sql, connect1.Con);
            connect1.connect();
            DateTime dti = (DateTime)comm.ExecuteScalar();
            connect1.disconnect();
            return dti;
        }
    }
}
