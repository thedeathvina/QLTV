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
    public partial class BC_SachTre : Form
    {
     
        public frmMain _main = new frmMain();
        public BC_SachTre()
        {
            InitializeComponent();
        }
        
        private void btn_luu_Click(object sender, EventArgs e)
        {
            BC_SachTreBLL bll = new BC_SachTreBLL();
            int a = dataGridViewX1.RowCount;
            if (a==0)
            {
                MessageBox.Show("Không có dữ liệu để lưu!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                
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

        private void date_ngay_ValueChanged(object sender, EventArgs e)
        {
            BC_SachTreBLL bll = new BC_SachTreBLL();
            dataGridViewX1.DataSource= bll.LoadData(date_ngay.Value.Date,this._main.NgayMuonToiDa);
        }


        private List<BC_SachTreDTO> list_insert()
        {
            List<BC_SachTreDTO> list1 = new List<BC_SachTreDTO>();
            for (int i = 0; i < ((DataTable)dataGridViewX1.DataSource).Rows.Count; i++)
            {
                BC_SachTreDTO dto = new BC_SachTreDTO();
                dto.Ngay = date_ngay.Text;
                dto.Macuonsach = dataGridViewX1.Rows[i].Cells["MaCuonSach"].Value.ToString();
                dto.Ngaymuon = dataGridViewX1.Rows[i].Cells["NgayMuon"].Value.ToString();
                dto.Songaytre = dataGridViewX1.Rows[i].Cells["NgayTre"].Value.ToString();
                list1.Add(dto);
            }
            return list1;
        }

        private void btn_luu_Click_1(object sender, EventArgs e)
        {
            var dia = new System.Windows.Forms.SaveFileDialog();
            dia.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dia.Filter = "Excel Worksheets (*.xlsx)|*.xlsx|xls file (*.xls)|*.xls|All files (*.*)|*.*";
            dia.FileName = "BC_SACHTRE_" + date_ngay.Value.Day + "_" + date_ngay.Value.Month + "_" + date_ngay.Value.Year;
            if (dia.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                DataTable dtLocalC = new DataTable();
                dtLocalC.Columns.Add("STT");
                dtLocalC.Columns.Add("MaCuonSach");
                dtLocalC.Columns.Add("TenDauSach");
                dtLocalC.Columns.Add("NgayMuon");
                dtLocalC.Columns.Add("NgayTre");

                DataRow drLocal = null;
                foreach (DataGridViewRow dr in this.dataGridViewX1.Rows)
                {
                    drLocal = dtLocalC.NewRow();
                    drLocal["STT"] = dr.Cells["STT"].Value;
                    drLocal["MaCuonSach"] = dr.Cells["MaCuonSach"].Value;
                    drLocal["TenDauSach"] = dr.Cells["TenDauSach"].Value;
                    drLocal["NgayMuon"] = dr.Cells["NgayMuon"].Value;
                    drLocal["NgayTre"] = dr.Cells["NgayTre"].Value;
                    dtLocalC.Rows.Add(drLocal);
                }
                var excel = new OfficeOpenXml.ExcelPackage();
                var ws = excel.Workbook.Worksheets.Add("worksheet-name");
                // you can also use LoadFromCollection with an `IEnumerable<SomeType>`
                ws.Cells["A3"].LoadFromDataTable(dtLocalC, true, OfficeOpenXml.Table.TableStyles.Light1);
                ws.Cells[ws.Dimension.Address.ToString()].AutoFitColumns();
                ws.Cells["A1"].Value = "BÁO CÁO SÁCH TRẢ TRỂ NGÀY " + this.date_ngay.Value.ToString();
                ws.Cells["A1:E1"].Merge = true;
                using (var file = File.Create(dia.FileName))
                    excel.SaveAs(file);
            }
        }

    }
}
