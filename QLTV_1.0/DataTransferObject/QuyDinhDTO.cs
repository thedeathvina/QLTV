using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLTV_1._0.DataTransferObject
{
    class QuyDinhDTO
    {
        private int tuoitoithieu;

        public int Tuoitoithieu
        {
            get { return tuoitoithieu; }
            set { tuoitoithieu = value; }
        }
        private int tuoitoida;

        public int Tuoitoida
        {
            get { return tuoitoida; }
            set { tuoitoida = value; }
        }
        private int thoihanthe;

        public int Thoihanthe
        {
            get { return thoihanthe; }
            set { thoihanthe = value; }
        }
        private int thoihanxb;

        public int Thoihanxb
        {
            get { return thoihanxb; }
            set { thoihanxb = value; }
        }
        private int sosachmuontoida;

        public int Sosachmuontoida
        {
            get { return sosachmuontoida; }
            set { sosachmuontoida = value; }
        }
        private int songaymuontoida;

        public int Songaymuontoida
        {
            get { return songaymuontoida; }
            set { songaymuontoida = value; }
        }

        private decimal tienphat;

        public decimal Tienphat
        {
            get { return tienphat; }
            set { tienphat = value; }
        }

        private Boolean qd6;

        public Boolean Qd6
        {
            get { return qd6; }
            set { qd6 = value; }
        }
    }
}
