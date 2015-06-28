using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
namespace QLTV_1._0
{
    class Connect
    {
        
        private SqlConnection con = new SqlConnection("Data Source=(local);Initial Catalog=QUANLYTHUVIEN;Integrated Security=True");
        public SqlConnection Con
        {            get { return con; }
            set { con = value; }
        }

        public void connect()
        {
            try
            {    
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }  
     
        public void disconnect()
        {
            con.Close();
            con.Dispose();
            con = null;
        }
    }
}
