using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QLTV_1._0.BusinessLogicLayer;
using QLTV_1._0.DataAccessLayer;
using QLTV_1._0.DataTransferObject;

namespace QLTV_1._0
{
    public partial class Sach_Tra : Form
    {
        string songaymuonsach;
        string maphieumuon;
        string masachcell;
        string tongno;
        public bool Saved = false;
        public Sach_Tra()
        {

            InitializeComponent();
            cbb_madg.Text = "(Nope)";
            DataTable tb = new DataTable();

            tb_tientra.Text = "0";
            tb_tienphat.Text = "0";
            tb_tienno.Text = "0";

            TraSachBLL bll = new TraSachBLL();
            TraSachDAL dal = new TraSachDAL();
            tb = dal.LoadData();
            foreach (TraSachDTO dto in bll.Convert_Type(tb))
            {
                cbb_madg.Items.Add(dto.Madocgia);
                for (int i = 0; i < cbb_madg.Items.Count -1; i++)
                { 
                    if (dto.Madocgia == cbb_madg.Items[i].ToString())
                    {
                        cbb_madg.Items.Remove(cbb_madg.Items[i]);
                    }
                }
            }
        }
       

        private void btn_luu_Click(object sender, EventArgs e)
        {
            if (cbb_madg.Text == "(Nope)")
            {
                MessageBox.Show("Vui lòng điền thông tin độc giả");
            }
            if (dataGridViewX1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Chọn sách cần trả!");
                return;
            }
            TraSachBLL bll = new TraSachBLL();
            bll.Test(Insert());
            dataGridViewX1.DataSource = bll.List_Table_Sach(a);
            ;
        }
        private void dataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {          
            int index = e.RowIndex;
            if (index < 0)
                return;
            if (!this.dataGridViewX1.Rows[index].IsNewRow)
            {
                this.dataGridViewX1.Rows[index].Selected = true;
                masachcell = dataGridViewX1.Rows[index].Cells["MaSach"].Value.ToString();
                tb_tienphat.Text = dataGridViewX1.Rows[index].Cells["Tphat"].Value.ToString();
                songaymuonsach = dataGridViewX1.Rows[index].Cells["songmuon"].Value.ToString();
                maphieumuon = dataGridViewX1.Rows[index].Cells["maphieu"].Value.ToString();
                tb_tienno.Text = tb_tongno.Text = tb_tientra.Text = "0";
            }
        }

        private void tinhtien()
        {
            int tienphatkynay = int.Parse(tb_tienphat.Text);
            int sotientra = int.Parse(tb_tientra.Text);
            if (sotientra > tienphatkynay)
            {
                MessageBox.Show("Số tiền trả phải nhỏ hơn hoặc bằng số tiền phạt kỳ này");
                return;
            }
            else
            {
                int tiennokynay = tienphatkynay - sotientra;
                tb_tienno.Text = tiennokynay.ToString();
                int sum = int.Parse(tongno) + tiennokynay;
                tb_tongno.Text = sum.ToString();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) ||
           char.IsSymbol(e.KeyChar) ||
           char.IsWhiteSpace(e.KeyChar) ||
           char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }
        int a;
        private void cbb_madg_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable tb = new DataTable();
            TraSachBLL bll = new TraSachBLL();
            TraSachDAL dal = new TraSachDAL();
            tb = dal.LoadData();
            if (cbb_madg.Text == "(Nope)")
            {
                tb_hoten.Text = null;
                dataGridViewX1.DataSource = bll.List_Table_Sach(-1);
                return;
            }
            a = int.Parse(cbb_madg.Text);
            foreach (TraSachDTO dto in bll.Convert_Type(tb))
            {
                if (a == int.Parse(dto.Madocgia))
                {
                    dataGridViewX1.DataSource = bll.List_Table_Sach(a);
                    tb_hoten.Text = dto.Tendocgia;
                    tongno = dto.Tongno;
                    return;
                }
                else
                {
                    tb_hoten.Text = null;
                    dataGridViewX1.DataSource = bll.List_Table_Sach(-1);
                }
            } 
        }

        private TraSachDTO Insert()
        {
            TraSachDTO dto = new TraSachDTO();
            TraSachBLL bll = new TraSachBLL();
            TraSachDAL dal = new TraSachDAL();
            dto.Ngaytra = date_ngtra.Text;
            dto.Maphieumuon = maphieumuon;    
            QuyDinhBLL qdinhbll = new QuyDinhBLL();
            QuyDinhDTO qdinhdto = qdinhbll.TestLoad();
            int ngaymuontoida = qdinhdto.Songaymuontoida;
            if (int.Parse(songaymuonsach) > ngaymuontoida)
            {
                dto.Songaytratre = int.Parse(songaymuonsach) - ngaymuontoida;
            }
            else
            {
                dto.Songaytratre = 0;
            }
            dto.Songaymuon = int.Parse(songaymuonsach);
            dto.Tienphat = int.Parse(tb_tienphat.Text);
            dto.Sotientra = tb_tientra.Text;
            dto.Conlai = tb_tienno.Text;
            dto.Tongno = tb_tongno.Text;
            dto.Tinhtrang = "Chưa được mượn";
            dto.Madocgia = cbb_madg.Text;
            dto.Masach = masachcell;
            return dto;
        }

        private void btn_noptien_Click(object sender, EventArgs e)
        {
            this.tinhtien();
        }
    }
}
