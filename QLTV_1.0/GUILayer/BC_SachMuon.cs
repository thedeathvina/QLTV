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
using System.IO;

namespace QLTV_1._0
{
    public partial class BC_SachMuon : Form
    {
        public frmMain _main = new frmMain();
        Boolean month_choosed = false;
        public BC_SachMuon()
        {
            InitializeComponent();
            int max_year = this._main.ThoiHanXB;
            while (max_year-- > 0)
            {
                this.cbb_nam.Items.Add(DateTime.Now.Year - max_year);
            }
        }
        
        private void btn_luu_Click(object sender, EventArgs e)
        {
            BC_SachMuonBLL bll = new BC_SachMuonBLL();
            if (isFullInfo())
            { 
                        
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
                return;
            }
            bll.TestInsert(list_insert());
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
        private List<BC_SachMuonDTO> list_insert()
        {
            List<BC_SachMuonDTO> list1 = new List<BC_SachMuonDTO>();
            for (int i = 0; i < ((DataTable)dataGridViewX1.DataSource).Rows.Count; i++)
            {
                BC_SachMuonDTO dto = new BC_SachMuonDTO();
                dto.Thang = cbb_thang.Text;
                dto.Tongsoluotmuon = int.Parse(lb_tsl.Text);
                dto.Soluotmuon = int.Parse(dataGridViewX1.Rows[i].Cells["SoLuotMuon"].Value.ToString());
                if (dataGridViewX1.Rows[i].Cells["TenTheLoai"].Value.ToString() == "A")
                {
                    dto.Matheloai="1";
                }
                else
                {
                    if (dataGridViewX1.Rows[i].Cells["TenTheLoai"].Value.ToString() == "B")
                    {
                        dto.Matheloai="2";
                    }
                    else
                    {
                        dto.Matheloai="3";
                    }
                }
                dto.Tile = float.Parse(dataGridViewX1.Rows[i].Cells["TiLe"].Value.ToString());
                list1.Add(dto);
            }
            return list1;
        }

        private void cbb_nam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbb_thang.SelectedIndex>-1)
            {
                int month = int.Parse(this.cbb_thang.Text.ToString());
                int year = int.Parse(this.cbb_nam.Text.ToString());
                BC_SachMuonBLL bll = new BC_SachMuonBLL();
                this.lb_tsl.Text = bll.Load_TongSoLuotMuon(month, year).ToString();
                DataTable dt = bll.LoadData(month, year);
                if (dt.Rows.Count > 0)
                {
                    dataGridViewX1.DataSource = dt;
                    this.buttonX1.Enabled = true;
                }
                else
                {
                    DataTable DT = (DataTable)dataGridViewX1.DataSource;
                    if (DT != null)
                        DT.Clear();
                    this.buttonX1.Enabled = false;
                }
            }
        }
        private void InsertData()
        {
            int month = int.Parse(this.cbb_thang.Text.ToString());
            int tsl = int.Parse(this.lb_tsl.Text.ToString());
            BC_SachMuonBLL bll = new BC_SachMuonBLL();
            BC_SachMuonDAL dal = new BC_SachMuonDAL();

            BC_SachMuonDTO bc1 = new BC_SachMuonDTO();
            bc1.Mabcmuonsach = dal.ADD_MaBCSM().ToString();
            bc1.Mactbcmuonsach = dal.ADD_MaCTBCSM().ToString();
            bc1.Thang = month.ToString();
            bc1.Tongsoluotmuon = tsl;

            List<BC_SachMuonDTO> list1 = new List<BC_SachMuonDTO>();
            //insert chitietbaocao
            foreach(DataRow dtr in dataGridViewX1.Rows)
            {
              
            }
        }

        private void btn_xuatfile_Click(object sender, EventArgs e)
        {
            var dia = new System.Windows.Forms.SaveFileDialog();
            dia.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dia.Filter = "Excel Worksheets (*.xlsx)|*.xlsx|xls file (*.xls)|*.xls|All files (*.*)|*.*";
            dia.FileName = "BC_TILESACHMUON_" + cbb_thang.Text+"_"+cbb_nam.Text;
            if (dia.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                DataTable dtLocalC = new DataTable();
                dtLocalC.Columns.Add("STT");
                dtLocalC.Columns.Add("TenTheLoai");
                dtLocalC.Columns.Add("SoLuotMuon");
                dtLocalC.Columns.Add("TiLe");

                DataRow drLocal = null;
                foreach (DataGridViewRow dr in this.dataGridViewX1.Rows)
                {
                    drLocal = dtLocalC.NewRow();
                    drLocal["STT"] = dr.Cells["STT"].Value;
                    drLocal["TenTheLoai"] = dr.Cells["TenTheLoai"].Value;
                    drLocal["SoLuotMuon"] = dr.Cells["SoLuotMuon"].Value;
                    drLocal["TiLe"] = dr.Cells["TiLe"].Value;
                    dtLocalC.Rows.Add(drLocal);
                }
                var excel = new OfficeOpenXml.ExcelPackage();
                var ws = excel.Workbook.Worksheets.Add("worksheet-name");
                // you can also use LoadFromCollection with an `IEnumerable<SomeType>`
                ws.Cells["A3"].LoadFromDataTable(dtLocalC, true, OfficeOpenXml.Table.TableStyles.Light1);
                ws.Cells[ws.Dimension.Address.ToString()].AutoFitColumns();
                ws.Cells["A1"].Value = "BÁO CÁO THỐNG KÊ TỈ LỆ MƯỢN SÁCH THÁNG "+this.cbb_thang.Text;
                ws.Cells["A1:D1"].Merge = true;
                using (var file = File.Create(dia.FileName))
                    excel.SaveAs(file);
            }
        }
    }
}
