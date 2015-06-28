using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Data.SqlClient;
using QLTV_1._0.BusinessLogicLayer;
using QLTV_1._0.DataAccessLayer;
using QLTV_1._0.DataTransferObject;

namespace QLTV_1._0
{
    public partial class frmMain : DevComponents.DotNetBar.Office2007RibbonForm
    {
        int tab_index = 0;
        int count_add_book=0;
        int count_search_book = 0;
        int count_add_reader = 0;
        int count_search_reader = 0;
        int count_borrow_books = 0;
        int count_return_books = 0;
        int count_fine = 0;
        int count_quydinh = 0;
        public int TuoiToiThieu,
                    TuoiToiDa,
                    ThoiHanThe,
                    ThoiHanXB,
                    SoSachMuonToiDa,
                    NgayMuonToiDa;
        public decimal TienPhatMoiNgay;
        public bool ApDungQDTienThu;
        public frmMain()
        {
            InitializeComponent();
            this.Load_QuiDinh(); 
        }
        private void tabControl1_TabItemClose(object sender, TabStripActionEventArgs e)
        {
            tab_index--;
        }

        private void btn_ThemSach_Click(object sender, EventArgs e)
        {
            tab_index++;
            count_add_book++;
            TabItem newTab = tabControl1.CreateTab("[" + count_add_book + "] Thêm sách");
            TabControlPanel newPanel = (TabControlPanel)newTab.AttachedControl;
            Sach_Them mfrm = new Sach_Them();
            mfrm._main = this;
            mfrm.TopLevel = false;
            newPanel.Controls.Add(mfrm);
            mfrm.Dock = DockStyle.Fill;
            mfrm.Show();
            tabControl1.SelectedTabIndex = tab_index;
        }

        private void btn_TimSach_Click(object sender, EventArgs e)
        {
            tab_index++;
            count_search_book++;
            TabItem newTab = tabControl1.CreateTab("[" + count_search_book + "] Tìm sách");
            TabControlPanel newPanel = (TabControlPanel)newTab.AttachedControl;
            Sach_Tim mfrm = new Sach_Tim();
            mfrm.TopLevel = false;
            newPanel.Controls.Add(mfrm);
            mfrm.Dock = DockStyle.Fill;
            mfrm.Show();
            tabControl1.SelectedTabIndex = tab_index;
        }

        private void btn_LapThe_Click(object sender, EventArgs e)
        {
            tab_index++;
            count_add_reader++;
            TabItem newTab = tabControl1.CreateTab("[" + count_add_reader + "] Lập thẻ");
            TabControlPanel newPanel = (TabControlPanel)newTab.AttachedControl;
            DocGia_Them mfrm = new DocGia_Them();
            mfrm._main = this;
            mfrm.TopLevel = false;
            newPanel.Controls.Add(mfrm);
            mfrm.Dock = DockStyle.Fill;
            mfrm.Show();
            tabControl1.SelectedTabIndex = tab_index;
        }
        //Muon sach
        private void btn_MuonSach_Click(object sender, EventArgs e)
        {
            tab_index++;
            count_borrow_books++;
            TabItem newTab = tabControl1.CreateTab("[" + count_borrow_books + "] Mượn Sách");
            TabControlPanel newPanel = (TabControlPanel)newTab.AttachedControl;
            Sach_Muon mfrm = new Sach_Muon();
            mfrm.TopLevel = false;
            newPanel.Controls.Add(mfrm);
            mfrm.Dock = DockStyle.Fill;
            mfrm.Show();
            tabControl1.SelectedTabIndex = tab_index; 
        }

        //Tra Sach
        private void btn_TraSach_Click(object sender, EventArgs e)
        {
            tab_index++;
            count_return_books++;
            TabItem newTab = tabControl1.CreateTab("[" + count_return_books + "] Trả Sách");
            TabControlPanel newPanel = (TabControlPanel)newTab.AttachedControl;
            Sach_Tra mfrm = new Sach_Tra();
            mfrm.TopLevel = false;
            newPanel.Controls.Add(mfrm);
            mfrm.Dock = DockStyle.Fill;
            mfrm.Show();
            tabControl1.SelectedTabIndex = tab_index; 
        }

        //Thu Phat
        private void btn_ThuPhat_Click(object sender, EventArgs e)
        {
            tab_index++;
            count_fine++;
            TabItem newTab = tabControl1.CreateTab("[" + count_fine + "] Thu Phạt");
            TabControlPanel newPanel = (TabControlPanel)newTab.AttachedControl;
            ThuPhat mfrm = new ThuPhat();
            mfrm.TopLevel = false;
            newPanel.Controls.Add(mfrm);
            mfrm.Dock = DockStyle.Fill;
            mfrm.Show();
            tabControl1.SelectedTabIndex = tab_index; 
        }

        //Quy Dinh
        private void btn_QuyDinh_Click_1(object sender, EventArgs e)
        {
            tab_index++;
            count_quydinh++;
            TabItem newTab = tabControl1.CreateTab("[" + count_quydinh + "] Quy Định Thư Viện");
            TabControlPanel newPanel = (TabControlPanel)newTab.AttachedControl;
            QuyDinh mfrm = new QuyDinh();
            mfrm._main = this;
            mfrm.TopLevel = false;
            newPanel.Controls.Add(mfrm);
            mfrm.Dock = DockStyle.Fill;
            mfrm.Show();
            tabControl1.SelectedTabIndex = tab_index; 
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Info mfrm = new Info();
            mfrm.TopLevel = false;
            this.tabControlPanel3.Controls.Add(mfrm);
            mfrm.Dock = DockStyle.Fill;
            mfrm.Show();
        }
        private void Load_QuiDinh()
        {

            QuyDinhBLL qdinhbll = new QuyDinhBLL();
            QuyDinhDTO qdinhdto = qdinhbll.TestLoad();
            this.TuoiToiThieu = qdinhdto.Tuoitoithieu;
            this.TuoiToiDa = qdinhdto.Tuoitoida;
            this.ThoiHanThe = qdinhdto.Thoihanthe;
            this.ThoiHanXB = qdinhdto.Thoihanxb;
            this.SoSachMuonToiDa = qdinhdto.Sosachmuontoida;
            this.NgayMuonToiDa = qdinhdto.Songaymuontoida;
            this.TienPhatMoiNgay = qdinhdto.Tienphat;
            this.ApDungQDTienThu = qdinhdto.Qd6;

           
        }

        private void buttonItem24_Click(object sender, EventArgs e)
        {
            tab_index++;
            TabItem newTab = tabControl1.CreateTab("Báo Cáo Tình Hình Mượn Sách");
            TabControlPanel newPanel = (TabControlPanel)newTab.AttachedControl;
            BC_SachMuon mfrm = new BC_SachMuon();
            mfrm._main = this;
            mfrm.TopLevel = false;
            newPanel.Controls.Add(mfrm);
            mfrm.Dock = DockStyle.Fill;
            mfrm.Show();
            tabControl1.SelectedTabIndex = tab_index; 
        }

        private void buttonItem25_Click(object sender, EventArgs e)
        {
            tab_index++;
            TabItem newTab = tabControl1.CreateTab("Báo Cáo Sách Trả Trể");
            TabControlPanel newPanel = (TabControlPanel)newTab.AttachedControl;
            BC_SachTre mfrm = new BC_SachTre();
            mfrm._main = this;
            mfrm.TopLevel = false;
            newPanel.Controls.Add(mfrm);
            mfrm.Dock = DockStyle.Fill;
            mfrm.Show();
            tabControl1.SelectedTabIndex = tab_index; 
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {

        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem28_Click(object sender, EventArgs e)
        {
          
            tab_index++;
            TabItem newTab = tabControl1.CreateTab("Thông Tin Phần Mềm");
            TabControlPanel newPanel = (TabControlPanel)newTab.AttachedControl;
            Info mfrm = new Info();
            mfrm._main = this;
            mfrm.TopLevel = false;
            newPanel.Controls.Add(mfrm);
            mfrm.Dock = DockStyle.Fill;
            mfrm.Show();
            tabControl1.SelectedTabIndex = tab_index; 

        }

        private void buttonItem30_Click(object sender, EventArgs e)
        {
            this.btn_QuyDinh_Click_1(sender, e);
        }

        private void btn_huongdan_Click(object sender, EventArgs e)
        {
            tab_index++;
            TabItem newTab = tabControl1.CreateTab("Hướng Dẫn Sử Dụng");
            TabControlPanel newPanel = (TabControlPanel)newTab.AttachedControl;
            HuongDan mfrm = new HuongDan();
            mfrm._main = this;
            mfrm.TopLevel = false;
            newPanel.Controls.Add(mfrm);
            mfrm.Dock = DockStyle.Fill;
            mfrm.Show();
            tabControl1.SelectedTabIndex = tab_index; 
        }

        private void btn_lich_Click(object sender, EventArgs e)
        {
            tab_index++;
            TabItem newTab = tabControl1.CreateTab("Lịch");
            TabControlPanel newPanel = (TabControlPanel)newTab.AttachedControl;
            Lich mfrm = new Lich();
            mfrm._main = this;
            mfrm.TopLevel = false;
            newPanel.Controls.Add(mfrm);
            mfrm.Dock = DockStyle.Fill;
            mfrm.Show();
            tabControl1.SelectedTabIndex = tab_index; 
        }

        private void buttonItem26_Click(object sender, EventArgs e)
        {
            this.btn_lich_Click(sender, e);
        }

        private void btn_giaitri_Click(object sender, EventArgs e)
        {
            tab_index++;
            TabItem newTab = tabControl1.CreateTab("Giải Trí");
            TabControlPanel newPanel = (TabControlPanel)newTab.AttachedControl;
            GiaiTri mfrm = new GiaiTri();
            mfrm._main = this;
            mfrm.TopLevel = false;
            newPanel.Controls.Add(mfrm);
            mfrm.Dock = DockStyle.Fill;
            mfrm.Show();
            tabControl1.SelectedTabIndex = tab_index; 
        }

        private void buttonItem27_Click(object sender, EventArgs e)
        {
            this.btn_giaitri_Click(sender, e);
        }
    }
}
