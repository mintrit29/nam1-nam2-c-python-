using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai1_chuong3
{
    public partial class frmBaiTap1: Form
    {
        public frmBaiTap1()
        {
            InitializeComponent();
        }

        private void frmBaiTap1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Cảm ơn bạn!");
        }

        private void txtYourName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtYourName.Text))
            {
                errorProvider1.SetError(txtYourName, "Vui lòng nhập tên");
            }
            else
            {
                errorProvider1.SetError(txtYourName, string.Empty);
            }    
        }

        private void txtYear_TextChanged(object sender, EventArgs e)
        {
            int yearOfBirth;
            if (int.TryParse(txtYear.Text, out yearOfBirth))
            { 
                if (yearOfBirth < 1900 || yearOfBirth > DateTime.Now.Year)
                {
                    errorProvider1.SetError(txtYear, "Bạn xuyên không à ???");
                }
                else
                {
                    errorProvider1.SetError(txtYear, string.Empty);
                }    
            }
            else
            {
                errorProvider1.SetError(txtYear, "Vui lòng nhập số");
            }    
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            MessageBox.Show("My name is:" + txtYourName.Text + Environment.NewLine + "Age:" + (2025 - int.Parse(txtYear.Text)));
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtYourName.Clear();
            txtYear.Clear();
            txtYourName.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn chắc chắn chứ?",
                "Vui lòng xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Close();
            }
            else if (result == DialogResult.No)
            {
                return;
            }
        }
    }
}
