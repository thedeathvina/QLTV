using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLTV_1._0.DataTransferObject
{
    class ThemSachDTO
    {
        private string masach;

        private int stt;

        public int Stt
        {
            get { return stt; }
            set { stt = value; }
        }
        public string Masach
        {
            get { return masach; }
            set { masach = value; }
        }
     
        private string tensach;

        public string Tensach
        {
            get { return tensach; }
            set { tensach = value; }
        }
        private string theloai;

        public string Theloai
        {
            get { return theloai; }
            set { theloai = value; }
        }
        private string tacgia;

        public string Tacgia
        {
            get { return tacgia; }
            set { tacgia = value; }
        }
        private string namxb;

        public string Namxb
        {
            get { return namxb; }
            set { namxb = value; }
        }
        private string nhaxb;

        public string Nhaxb
        {
            get { return nhaxb; }
            set { nhaxb = value; }
        }
        private string ngaynhap;

        public string Ngaynhap
        {
            get { return ngaynhap; }
            set { ngaynhap = value; }
        }
        private string trigia;

        public string Trigia
        {
            get { return trigia; }
            set { trigia = value; }
        }
        private string tinhtrang;

        public string Tinhtrang
        {
            get { return tinhtrang; }
            set { tinhtrang = value; }
        }
    }
}
