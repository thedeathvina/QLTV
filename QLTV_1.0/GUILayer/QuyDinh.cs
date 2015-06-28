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
    public partial class QuyDinh : Form
    {
        public bool Saved = false;
        public frmMain _main = new frmMain();
        public QuyDinh()
        {
            InitializeComponent();
            tb_tienphat.ReadOnly = true;
            cb_apdungQD.Enabled = false;
        }
        private void btn_refresh_Click(object sender, EventArgs e)
        {
                tb_maxngay.Text = ""; tb_mintuoi.Text = ""; tb_hanthe.Text = ""; tb_hanxb.Text = ""; tb_maxsach.Text = ""; tb_maxtuoi.Text = "";
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            try
            {
                Saved = true;
                if (tb_maxngay.Text == "" || tb_mintuoi.Text == "" || tb_hanthe.Text == "" || tb_hanxb.Text == "" || tb_maxsach.Text == "" || tb_maxtuoi.Text == "")
                {
                    MessageBox.Show("Dữ liệu không thể để trống!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (int.Parse(tb_mintuoi.Text) > int.Parse(tb_maxtuoi.Text))
                {
                    MessageBox.Show("Quy định về tuổi sai. Vui lòng nhập lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                QuyDinhBLL dll = new QuyDinhBLL();
                dll.TestUpdate(Data_Update());
            }
            catch
            {
                MessageBox.Show("Dữ liệu sai!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private QuyDinhDTO Data_Update()
        {  
            QuyDinhDTO dto = new QuyDinhDTO();
            dto.Tuoitoithieu     = this._main.TuoiToiThieu    = int.Parse(tb_mintuoi.Text);
            dto.Tuoitoida        = this._main.TuoiToiDa       = int.Parse(tb_maxtuoi.Text);
            dto.Thoihanthe       = this._main.ThoiHanThe      = int.Parse(tb_hanthe.Text);
            dto.Thoihanxb        = this._main.ThoiHanXB       = int.Parse(tb_hanxb.Text);
            dto.Sosachmuontoida  = this._main.SoSachMuonToiDa = int.Parse(tb_maxsach.Text);
            dto.Songaymuontoida  = this._main.NgayMuonToiDa   = int.Parse(tb_maxngay.Text);
            dto.Tienphat         = this._main.TienPhatMoiNgay = decimal.Parse(tb_tienphat.Text);
            dto.Qd6              = this._main.ApDungQDTienThu = this.cb_apdungQD.Checked;
            return dto;
        }

        private void tb_MouseClick(object sender, MouseEventArgs e)
        {
            Saved = false;
        }
        public void Loaddata()
        {
            tb_mintuoi.Text = this._main.TuoiToiThieu.ToString();
            tb_maxtuoi.Text = this._main.TuoiToiDa.ToString();
            tb_hanthe.Text = this._main.ThoiHanThe.ToString();
            tb_hanxb.Text = this._main.ThoiHanXB.ToString();
            tb_maxsach.Text = this._main.SoSachMuonToiDa.ToString();
            tb_maxngay.Text = this._main.NgayMuonToiDa.ToString();
            tb_tienphat.Text = this._main.TienPhatMoiNgay.ToString();
            if (this._main.ApDungQDTienThu)
                cb_apdungQD.Checked = true;
            else
            {
                cb_apdungQD.Checked = false;
                this.tb_tienphat.Enabled = false;
            }
        }

        private void tb_mintuoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) ||
           char.IsSymbol(e.KeyChar) ||
           char.IsWhiteSpace(e.KeyChar) ||
           char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }

        private void tb_maxtuoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) ||
           char.IsSymbol(e.KeyChar) ||
           char.IsWhiteSpace(e.KeyChar) ||
           char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }

        private void tb_hanthe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) ||
           char.IsSymbol(e.KeyChar) ||
           char.IsWhiteSpace(e.KeyChar) ||
           char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }

        private void tb_hanxb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) ||
           char.IsSymbol(e.KeyChar) ||
           char.IsWhiteSpace(e.KeyChar) ||
           char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }

        private void tb_maxsach_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) ||
           char.IsSymbol(e.KeyChar) ||
           char.IsWhiteSpace(e.KeyChar) ||
           char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }

        private void tb_maxngay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) ||
           char.IsSymbol(e.KeyChar) ||
           char.IsWhiteSpace(e.KeyChar) ||
           char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }

        private void QuyDinh_Load(object sender, EventArgs e)
        {
            this.Loaddata();
        }

        private void cb_apdungQD_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cb_apdungQD.Checked)
                this.tb_tienphat.Enabled = true;
            else
                this.tb_tienphat.Enabled = false;
        }

        private void tb_tenloaisach_TextChanged(object sender, EventArgs e)
        {
            if (this.tb_tenloaisach.Text != "")
                this.btn_add.Enabled = true;
        }

        private void tb_tenloaidg_TextChanged(object sender, EventArgs e)
        {
            if (this.tb_tenloaidg.Text != "")
                this.btn_add2.Enabled = true;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            string str = this.tb_tenloaisach.Text;
            ThemTL_BLL bll = new ThemTL_BLL();
            bll.TestInsert_SACH(str);
        }

        private void btn_add2_Click(object sender, EventArgs e)
        {
            string str = this.tb_tenloaidg.Text;
            ThemTL_BLL bll = new ThemTL_BLL();
            bll.TestInsert_DG(str);
        }
    }
}
