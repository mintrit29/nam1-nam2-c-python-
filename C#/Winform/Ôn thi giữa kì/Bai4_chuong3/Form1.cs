using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai4_chuong3
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<int> numbers = new List<int>();

        private void txtNhap_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnTieptuc_Click(object sender, EventArgs e)
        {
            txtDayso.Clear();
            txtTongchan.Clear();
            txtTongle.Clear();
            txtTong.Clear();
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtNhap.Text, out int Songuyen))
            {
                numbers.Add(Songuyen);
                txtDayso.Text = string.Join(", ", numbers);
                TinhTong();
                txtNhap.Clear();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập một số nguyên hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void TinhTong()
        {
            int tong = 0, tongChan = 0, tongLe = 0;
            foreach (int num in numbers)
            {
                tong += num;
                if (num % 2 == 0)
                {
                    tongChan += num;
                }
                else
                {
                    tongLe += num;
                }
            }

            txtTong.Text = tong.ToString();
            txtTongchan.Text = tongChan.ToString();
            txtTongle.Text = tongLe.ToString();
        }
    }
}
