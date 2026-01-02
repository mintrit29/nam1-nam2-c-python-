using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai3_chuong3
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int UCLN(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        private int BCNN(int a, int b)
        {
            return Math.Abs(a * b) / UCLN(a, b);
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
                errorProvider1.SetError(txtA, "Vui lòng nhập số");
            }    
        }

        private void txtB_TextChanged(object sender, EventArgs e)
        {
            int Songuyen;
            if (int.TryParse(txtA.Text, out Songuyen))
            {
                errorProvider1.SetError(txtB, string.Empty);
            }
            else
            {
                errorProvider1.SetError(txtB, "Vui lòng nhập số");
            }
        }

        private void btnThuchien_Click(object sender, EventArgs e)
        {
            int a, b;
            if (int.TryParse(txtA.Text, out a) && int.TryParse(txtB.Text, out b))
            {
                int ucln = UCLN(Convert.ToInt32(txtA.Text), Convert.ToInt32(txtB.Text));
                int bcnn = BCNN(Convert.ToInt32(txtA.Text), Convert.ToInt32(txtB.Text));

                txtUcln.Text = ucln.ToString();
                txtBcnn.Text = bcnn.ToString();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đúng theo yêu cầu");
            }    
        }

        private void btnTieptuc_Click(object sender, EventArgs e)
        {
            txtA.Clear();
            txtB.Clear();
            txtBcnn.Clear();
            txtUcln.Clear();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
