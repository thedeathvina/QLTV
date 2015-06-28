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
    public partial class Sach_Tim : Form
    {
        public bool found = false;
        public frmMain _main = new frmMain();
        public Sach_Tim()
        {
            InitializeComponent();
            int max_year = this._main.ThoiHanXB;
            while(max_year-->0)
                this.cbb_nxb.Items.Add(DateTime.Now.Year - max_year);
            ThemTL_BLL bll2 = new ThemTL_BLL();
            foreach (string st in bll2.load_TheLoaiSach())
            {
                this.cbb_theloai.Items.Add(st);
            }

        }
        private Boolean isFullInfo()
        {
            foreach (Control c in this.groupPanel1.Controls)
            {
                if (c is TextBox && c.Text != "")
                    return true;
                if (c is ComboBox && ((ComboBox)c).SelectedIndex > 0)
                    return true;
            }
            return false;
        }
        private void btn_tim_Click(object sender, EventArgs e)
        {
            if(!isFullInfo())
            {
                MessageBox.Show("Nhập thông tin để tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            TimSachBLL bll = new TimSachBLL();
            dataGridViewX1.DataSource = bll.List_Table(tb_masach.Text, tb_tensach.Text, tb_tacgia.Text, tb_nhaxb.Text, cbb_theloai.Text, cbb_nxb.Text);
            if (dataGridViewX1.Rows.Count == 0 )
            {
                MessageBox.Show("Dữ liệu không tìm thấy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void tb_masach_TextChanged(object sender, EventArgs e)
        {
            if (tb_masach.Text != "")
            {
                tb_nhaxb.Enabled = false;
                tb_tacgia.Enabled = false;
                tb_tensach.Enabled = false;
                tb_trigia.Enabled = false;
                cbb_nxb.Enabled = false;
                cbb_theloai.Enabled = false;
            }
            else
            {
                tb_nhaxb.Enabled = true;
                tb_tacgia.Enabled = true;
                tb_tensach.Enabled = true;
                tb_trigia.Enabled = true;
                cbb_nxb.Enabled = true;
                cbb_theloai.Enabled = true;
            }
        }

        private void tb_tensach_TextChanged_1(object sender, EventArgs e)
        {
            if (tb_tensach.Text != "")
            {
                tb_masach.Enabled = false;
            }
            else
            {
                tb_masach.Enabled = true;
            }
        }

        private void tb_tacgia_TextChanged_1(object sender, EventArgs e)
        {
            if (tb_tacgia.Text != "")
            {
                tb_masach.Enabled = false;
            }
            else
            {
                tb_masach.Enabled = true;
            }
        }

        private void tb_nhaxb_TextChanged_1(object sender, EventArgs e)
        {
            if (tb_nhaxb.Text != "")
            {
                tb_masach.Enabled = false;
            }
            else
            {
                tb_masach.Enabled = true;
            }
        }

        private void cbb_theloai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_theloai.Text != "")
            {
                tb_masach.Enabled = false;
            }
            else
            {
                tb_masach.Enabled = true;
            }
        }

        private void cbb_nxb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_nxb.Text != "")
            {
                tb_masach.Enabled = false;
            }
            else
            {
                tb_masach.Enabled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) ||
           char.IsSymbol(e.KeyChar) ||
           char.IsWhiteSpace(e.KeyChar) ||
           char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }
    }
}
