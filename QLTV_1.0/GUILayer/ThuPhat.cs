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
    public partial class ThuPhat : Form
    {
        
        public bool Saved = false;
        int conlai;
        public ThuPhat()
        {
            InitializeComponent();
            tb_tienthu.ReadOnly = true;
            DataTable tb = new DataTable();
            ThuPhatBLL bll = new ThuPhatBLL();
            ThuPhatDAL dal = new ThuPhatDAL();
            tb = dal.LoadData();
            foreach (ThuPhatDTO dto in bll.Convert_Type(tb))
            {
                if (int.Parse(dto.Tongno) != 0)
                {
                    comboBox1.Items.Add(dto.Madocgia);
                }
            }
        }
        private void btn_refresh_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.groupPanel1.Controls)
            {
                if (c is TextBox )
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
            { }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
                return;
            }
            Saved = true;
            //save to DTB
            ThuPhatBLL bll = new ThuPhatBLL();
            bll.TestInsert(Insert_DG());
            comboBox1.Text = "(Nope)";
        }

        private void tb_MouseClick(object sender, MouseEventArgs e)
        {
            Saved = false;
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
        private void Fill_textbox()
        {
            
            
        }
        private void tb_madg_TextChanged(object sender, EventArgs e)
        {
            this.Fill_textbox();
        }
        private void tb_hoten_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.Fill_textbox();
               
        }

        private void tb_tienthu_Leave(object sender, EventArgs e)
        {
            if (tb_tienthu.Text == "")
            {
                return;
            }
            else
            {
                conlai = int.Parse(tb_tongno.Text) - int.Parse(tb_tienthu.Text);
                tb_conlai.Text = conlai.ToString();
            }
        }

        private void tb_tienthu_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void tb_tienthu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) ||
            char.IsSymbol(e.KeyChar) ||
            char.IsWhiteSpace(e.KeyChar) ||
            char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }

        private void tb_madg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) ||
           char.IsSymbol(e.KeyChar) ||
           char.IsWhiteSpace(e.KeyChar) ||
           char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }

        private void tb_conlai_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable tb = new DataTable();
            ThuPhatBLL bll = new ThuPhatBLL();
            ThuPhatDAL dal = new ThuPhatDAL();
            tb = dal.LoadData();
            if (comboBox1.Text == "(Nope)")
            {
                tb_tienthu.ReadOnly = true;
                tb_hoten.Text = null;
                tb_tongno.Text = null;
                tb_tienthu.Text = null;
                tb_conlai.Text = null;
                return;
            }
            int a = int.Parse(comboBox1.Text);
            foreach (ThuPhatDTO dto in bll.Convert_Type(tb))
            {
                if (a == int.Parse(dto.Madocgia))
                {
                    tb_hoten.Text = dto.Hoten;
                    tb_tongno.Text = dto.Tongno;
                    tb_tienthu.ReadOnly = false;
                    return;
                }
            } 
        }

        private ThuPhatDTO Insert_DG()
        {
            ThuPhatDTO dto = new ThuPhatDTO();
            dto.Madocgia = comboBox1.Text;
            dto.Ngaylap = date_ngtra.Text;
            dto.Sotienthu = int.Parse(tb_tienthu.Text);
            dto.Tongno = tb_conlai.Text;
            return dto;
        }

        private void ThuPhat_Load(object sender, EventArgs e)
        {

        }

        private void groupPanel1_Click(object sender, EventArgs e)
        {

        }

    }
}
