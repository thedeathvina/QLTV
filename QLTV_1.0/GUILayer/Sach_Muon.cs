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
using QLTV_1._0.BLL;

namespace QLTV_1._0
{
    public partial class Sach_Muon : Form
    {
        string nghethan;
        int sachmuontoida = 0;
        int ngaymuontoida = 0;
        int row_selected=0;
        int masachcell;
        string status_book;
        public bool Saved = false;
        public frmMain _main = new frmMain();
        public Sach_Muon()
        {
            InitializeComponent();
            cbb_madg.Text = "(Nope)";
            DataTable tb = new DataTable();
            MuonSachBLL bll = new MuonSachBLL();
            MuonSachDAL dal = new MuonSachDAL();
            tb = dal.LoadDataDocGia();
            foreach (MuonSachDTO dto in bll.Convert_Type_DocGia(tb))
            {
                cbb_madg.Items.Add(dto.Madocgia);
            }
            QuyDinhBLL qdinhbll = new QuyDinhBLL();
            QuyDinhDTO qdinhdto = qdinhbll.TestLoad();
            sachmuontoida = qdinhdto.Sosachmuontoida;
            ngaymuontoida = qdinhdto.Songaymuontoida;
        }
        private void btn_refresh_Click(object sender, EventArgs e)
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

            if (!isFullInfo())
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
                return;
            }
            if (dataGridViewX1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Chọn sách cần mượn");
                return;
            }
            if (this.date_ngmuon.Value > DateTime.Now)
            {
                MessageBox.Show("Ngày mượn phải nhỏ hơn hoặc bằng ngày hiện tại");
                return;
            }
            //Kiem tra the het han
            DateTime ngaylap = new DateTime();
            DocGiaBLL dgbll = new DocGiaBLL();
            ngaylap = dgbll.Ktra_Hanthe(cbb_madg.Text.ToString());

            if ((DateTime.Now - ngaylap).Days > this._main.ThoiHanThe * 30)
            {
                MessageBox.Show("Thẻ đã hết hạn. Vui lòng đăng ký mới!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (Check_Muon(this.cbb_madg.Text))
            {
                MessageBox.Show("Không mượn được! \nĐã mượn đủ tối đa " + this._main.SoSachMuonToiDa + " cuốn sách. \nVui lòng trả để mượn tiếp!","", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //Kiem tra tinh trang sach
            DataTable tb = new DataTable();
            MuonSachBLL bll = new MuonSachBLL();

            if (status_book=="Đã được mượn")
            {
                MessageBox.Show("Sách này đã được mượn!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            bll.TestInsert_Docgia(Insert_DG());
            dataGridViewX1.DataSource = bll.List_Table_Sach();
        }
        private MuonSachDTO Insert_DG()
        {
            MuonSachDTO dto = new MuonSachDTO();
            dto.Madocgia = cbb_madg.Text;
            dto.Masach = masachcell.ToString();
            dto.Ngaymuon = date_ngmuon.Text;
            dto.Tinhtrang = "Đã được mượn";
            return dto;
        }
        private Boolean isFullInfo()
        {
            foreach (Control c in this.groupPanel1.Controls)
            {
                if (c is TextBox && c.Text == "")
                    return false;
                if (c is ComboBox && ((ComboBox)c).SelectedIndex < 0)
                    return false;
            }
            return true;
        }

        private void tb_trigia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar == '.'))
                e.Handled = true;

        }
        private void Sach_Muon_Load(object sender, EventArgs e)
        {
            MuonSachBLL bll = new MuonSachBLL();
            dataGridViewX1.DataSource = bll.List_Table_Sach();
            tb_hoten.ReadOnly = true;
        }
        private void tb_madg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) ||
           char.IsSymbol(e.KeyChar) ||
           char.IsWhiteSpace(e.KeyChar) ||
           char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }
        private Boolean Check_Muon(string madg)
        {
            MuonSachBLL bll = new MuonSachBLL();
            if (bll.Check_Muon(madg) == this._main.SoSachMuonToiDa)
                return true;
            return false;
        }

        private void cbb_madg_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable tb = new DataTable();
            MuonSachBLL bll = new MuonSachBLL();
            MuonSachDAL dal = new MuonSachDAL();
            tb = dal.LoadDataDocGia();
            if (cbb_madg.Text == "(Nope)")
            {
                tb_hoten.Text = null;
                return;
            }
            int a = int.Parse(cbb_madg.Text);
            foreach (MuonSachDTO dto in bll.Convert_Type_DocGia(tb))
            {
                if (a == int.Parse(dto.Madocgia))
                {
                    tb_hoten.Text = dto.Tendocgia;
                    nghethan = dto.Ngayhethan;
                    return;
                }
            }
        }

        private void dataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r < 0)
                return;
            if (!this.dataGridViewX1.Rows[r].IsNewRow)
            {
                this.dataGridViewX1.Rows[r].Selected = true;
                masachcell = int.Parse(this.dataGridViewX1.Rows[r].Cells[1].Value.ToString());
                status_book = this.dataGridViewX1.Rows[r].Cells[5].Value.ToString();
            }
        }
    }
}
