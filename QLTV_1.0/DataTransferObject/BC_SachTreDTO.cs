using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace QLTV_1._0.DataTransferObject
{
    class BC_SachTreDTO
    {
        private string tensach;

        public string Tensach
        {
            get { return tensach; }
            set { tensach = value; }
        }
        private string ngay;
        public string Ngay
        {
             get { return ngay; }
            set { ngay = value; }
        }
	    string macuonsach;
        public string Macuonsach
        {
            get { return macuonsach; }
            set { macuonsach = value; }
        }
        private string ngaymuon;
        public string Ngaymuon
        {
             get { return ngaymuon; }
            set { ngaymuon = value; }
        }
        string songaytre;
        public string Songaytre
        {
            get { return songaytre; }
            set { songaytre= value; }
        }
	
    }
}
