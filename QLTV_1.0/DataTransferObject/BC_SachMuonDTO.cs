using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLTV_1._0.DataTransferObject
{
    class BC_SachMuonDTO
    {
        string mabcmuonsach;
        public string Mabcmuonsach
        {
            get { return mabcmuonsach; }
            set { mabcmuonsach = value; }
        }
        string mactbcmuonsach;
        public string Mactbcmuonsach
        {
            get { return mactbcmuonsach; }
            set { mactbcmuonsach = value; }
        }
        string thang;
        public string Thang
        {
            get { return thang; }
            set { thang = value; }
        }
        int tongsoluotmuon;
        public int Tongsoluotmuon
        {
            get { return tongsoluotmuon; }
            set { tongsoluotmuon = value; }
        }
    
      
        string matheloai;
        public string Matheloai
        {
            get { return matheloai; }
            set { matheloai = value; }
        }
        int soluotmuon;
        public int Soluotmuon
        {
            get { return soluotmuon; }
            set { soluotmuon = value; }
        }
        float tile;
        public float Tile
        {
            get { return tile; }
            set { tile = value; }
        }
    }
}
