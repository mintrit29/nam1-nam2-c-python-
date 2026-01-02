using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cau1
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Close();
            }
            else
            {
                return;
            }    
        }

        private int tinhTiendien (int a, int b)
        {
            int chiSo;
            int ketQua=0;
            chiSo = Convert.ToInt32(txtSomoi.Text) - Convert.ToInt32(txtSocu.Text);
            if (chiSo >=0 && chiSo <=50)
            {
                ketQua = (chiSo * 1680);
            }
            else if (chiSo >= 51 && chiSo <= 100)
            {
                ketQua = chiSo*1734;
            }
            else if(chiSo >= 100)
            {
                ketQua = chiSo*2014;
            }
            return ketQua;
        }

        private void btnTinhtien_Click(object sender, EventArgs e)
        {
            int a, b;
            if (int.TryParse(txtSocu.Text, out a) && int.TryParse(txtSomoi.Text, out b))
            {
                if (!(txtSonha.Text == ""))
                {
                    if (!(b < a))
                    {
                        MessageBox.Show("Số nhà: " + txtSonha.Text + " Tổng tiền: " + tinhTiendien(a, b));
                    }
                    else
                    {
                        MessageBox.Show("Số mới phải lớn hơn số cũ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    errorProvider1.SetError(txtSonha, "Vui lòng nhập số nhà");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số hợp lệ cho số cũ và số mới.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
