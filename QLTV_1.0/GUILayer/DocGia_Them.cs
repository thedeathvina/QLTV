using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QLTV_1._0.BLL;
using QLTV_1._0.DTO;
using QLTV_1._0.DataAccessLayer;
using QLTV_1._0.DataTransferObject;
using QLTV_1._0.BusinessLogicLayer;

namespace QLTV_1._0
{
    public partial class DocGia_Them : Form
    {
        public frmMain _main = new frmMain();
       
        public DocGia_Them()
        {
            InitializeComponent();
            Load_DocGia();
        }
        private void NewData()
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

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            NewData();
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            //save to DTB
            int age = DateTime.Now.Year - this.date_ngsinh.Value.Year;
            int Youngest = this._main.TuoiToiThieu;
            int Oldest = this._main.TuoiToiDa;
            if (age < Youngest || age > Oldest || this.date_ngsinh.Value> DateTime.Now)
            {
                MessageBox.Show("Số tuổi không phù hợp, Vui lòng nhập lại");
                return;
            }
            char at = '@';
            bool hadAt = tb_email.Text.IndexOf(at) >= 0;
           
            if (!hadAt)
            {
                MessageBox.Show("Email không phù hợp, Vui lòng nhập lại");
                return;
            }
            if (this.date_nglapthe.Value > DateTime.Now)
            {
                MessageBox.Show("Ngày lập thẻ nhỏ hơn hoặc bằng ngày hiện tại");
                return;
            }
            DocGiaBLL dll = new DocGiaBLL();
            dll.TestInsert(Insert_DocGia());
            Load_DocGia();
            NewData();
        }
        private void Load_DocGia()
        {
            DocGiaBLL bll = new DocGiaBLL();
            dataGridViewX1.DataSource = bll.List_Table();
            ThemTL_BLL bll2 = new ThemTL_BLL();
            foreach (string st in bll2.load_loaiDG())
            {
                this.cbb_loaiDG.Items.Add(st);
            }
            
        }
        private DocGia Insert_DocGia()
        {
            DocGia dg1 = new DocGia();
            dg1.Hoten = tb_hoten.Text;
            dg1.Diachi = tb_dchi.Text;
            dg1.Email = tb_email.Text;

            if (cbb_loaiDG.Text == "X")
            {
                dg1.Loaidocgia = "1";
            }
            else
            {
                dg1.Loaidocgia = "2";
            }
            DateTime ngaylap = date_nglapthe.Value;
            dg1.Ngaysinh = date_ngsinh.Value.ToString();
            dg1.Ngaylapthe = ngaylap.ToString();
            dg1.Ngayhethan = ngaylap.AddMonths(6).ToString();
            dg1.Tongno = "0";
            return dg1;
        }

        //private void buttonX1_Click(object sender, EventArgs e)
        //{
        //    foreach (DataGridViewRow dr in dataGridViewX1.Rows)
        //    {
        //        if (!dr.IsNewRow)
        //        {
        //            string ma = dr.Cells[1].Value.ToString();
        //            DocGiaBLL bll = new DocGiaBLL();
        //            bll.TestUpdate(ma);
        //            dataGridViewX1.Refresh();
        //        }
        //    }
        //}
    }
}
