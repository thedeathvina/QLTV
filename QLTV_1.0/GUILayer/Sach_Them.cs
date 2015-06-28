using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QLTV_1._0.DataAccessLayer;
using QLTV_1._0.DataTransferObject;
using QLTV_1._0.BusinessLogicLayer;


namespace QLTV_1._0
{
    public partial class Sach_Them : Form
    {
        public frmMain _main = new frmMain();
        public Sach_Them()
        {
            InitializeComponent();
            //maximum within 8 years
            int max_year = this._main.ThoiHanXB;
            while (max_year-- > 0)
            {
                this.cbb_nxb.Items.Add(DateTime.Now.Year - max_year);
            }
        }
        private void btn_refresh_Click(object sender, EventArgs e)
        {
            reload();
        }
        private void reload()
        {
            foreach (Control c in this.groupPanel1.Controls)
            {
                if (c is TextBox)
                    c.ResetText();
                if (c is ComboBox)
                    ((ComboBox)c).SelectedIndex = -1;
                if (c is DateTimePicker)
                    ((DateTimePicker)c).Value = DateTime.Now;

            }
        }
        private void btn_luu_Click(object sender, EventArgs e)
        {
            if (isFullInfo())
            {
                if (this.date_ngnhap.Value > DateTime.Now)
                {
                    MessageBox.Show("Ngày nhập phải nhỏ hơn ngày hiện tại");
                    return;
                }
                //save to DTB
                ThemSachBLL dll = new ThemSachBLL();
                dll.TestInsert(InsertData());
                LoadData();
                reload();
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
                return;
            }
           
        }
        private Boolean isFullInfo()
        {
            foreach (Control c in this.groupPanel1.Controls)
            {
                if (c is TextBox && c.Text == "")
                    return false;
                if(c is ComboBox && ((ComboBox)c).SelectedIndex<0)
                    return false;
            }
            return true;
        }

        private void tb_trigia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) ||
           char.IsSymbol(e.KeyChar) ||
           char.IsWhiteSpace(e.KeyChar) ||
           char.IsPunctuation(e.KeyChar))
                e.Handled = true;
            
        }

        private void Sach_Them_Load(object sender, EventArgs e)
        {
           LoadData();
        }

        private void LoadData()
        {
            ThemSachBLL bll = new ThemSachBLL();
            dataGridViewX1.DataSource = bll.List_Table();
            ThemTL_BLL bll2 = new ThemTL_BLL();
            foreach (string st in bll2.load_TheLoaiSach())
            {
                this.cbb_theloai.Items.Add(st);
            }
        }
        private ThemSachDTO InsertData()
        {
            ThemSachDTO dto = new ThemSachDTO();
            dto.Tensach = tb_tensach.Text;
            if (cbb_theloai.Text == "A")
            {
                dto.Theloai = "1";
            }
            else
            {
                if (cbb_theloai.Text == "B")
                {
                    dto.Theloai = "2";
                }
                else
                    dto.Theloai = "3";
            }
            dto.Namxb = cbb_nxb.Text;
            dto.Ngaynhap = date_ngnhap.Text;
            dto.Nhaxb = tb_nhaxb.Text;
            dto.Tacgia = tb_tacgia.Text;
            dto.Trigia = tb_trigia.Text;
            dto.Tinhtrang = "Chưa được mượn";
            return dto;
        }

        private void date_ngnhap_ValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}
