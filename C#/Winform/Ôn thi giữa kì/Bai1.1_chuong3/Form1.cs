using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai1._1_chuong3
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtA_TextChanged(object sender, EventArgs e)
        {
            int Songuyen;
            if (int.TryParse(txtA.Text, out Songuyen))
            {
                errorProvider1.SetError(txtA, string.Empty);
            }
            else
            {
                errorProvider1.SetError(txtA, "Vui lòng nhập số!");
            }    
        }

        private void txtB_TextChanged(object sender, EventArgs e)
        {
            int Songuyen;
            if (int.TryParse(txtB.Text, out Songuyen))
            {
                errorProvider1.SetError(txtB, string.Empty);
            }
            else
            {
                errorProvider1.SetError(txtB, "Vui lòng nhập số!");
            }
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }    
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtA.KeyPress += txt_KeyPress;
            txtB.KeyPress += txt_KeyPress;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn chắc chứ?", 
                "Xác nhận", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void btnCong_Click(object sender, EventArgs e)
        {
            //txtKetqua.Text = (Convert.ToInt32(txtA.Text) + Convert.ToInt32(txtB.Text)).ToString();
            txtKetqua.Text = (int.Parse(txtA.Text) + int.Parse(txtB.Text)).ToString();
        }

        private void btnTru_Click(object sender, EventArgs e)
        {
            txtKetqua.Text = (int.Parse(txtA.Text) - int.Parse(txtB.Text)).ToString();
        }

        private void btnNhan_Click(object sender, EventArgs e)
        {
            txtKetqua.Text = (int.Parse(txtA.Text) * int.Parse(txtB.Text)).ToString();
        }

        private void btnChia_Click(object sender, EventArgs e)
        {
            txtKetqua.Text = (int.Parse(txtA.Text) / int.Parse(txtB.Text)).ToString();
        }
    }
}
