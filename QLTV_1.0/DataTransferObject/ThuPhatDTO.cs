using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLTV_1._0.DataTransferObject
{
    class ThuPhatDTO
    {
        private string madocgia;

        public string Madocgia
        {
            get { return madocgia; }
            set { madocgia = value; }
        }
        private string hoten;

        public string Hoten
        {
            get { return hoten; }
            set { hoten = value; }
        }
        private string tongno;

        public string Tongno
        {
            get { return tongno; }
            set { tongno = value; }
        }
        private string ngaylap;

        public string Ngaylap
        {
            get { return ngaylap; }
            set { ngaylap = value; }
        }
        private int sotienthu;

        public int Sotienthu
        {
            get { return sotienthu; }
            set { sotienthu = value; }
        }
        private int conlai;

        public int Conlai
        {
            get { return conlai; }
            set { conlai = value; }
        }
    }
}
