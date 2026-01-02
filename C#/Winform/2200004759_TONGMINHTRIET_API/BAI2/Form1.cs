using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; 
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArrayCalculatorApp 
{
    public partial class Form1 : Form
    {
        
        private List<int> numberList = new List<int>();

        public Form1()
        {
            InitializeComponent();
        }

   
        private void UpdateDisplayArray()
        {
            txtDisplayArray.Text = string.Join(", ", numberList);
        }

        private void btnNhapSo_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtInputNumber.Text, out int number))
            {

                numberList.Add(number);

        
                UpdateDisplayArray();
                txtInputNumber.Clear();

                txtInputNumber.Focus();
            }
            else
            {
  
                MessageBox.Show("Vui lòng nhập một số nguyên hợp lệ.", "Lỗi Nhập Liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtInputNumber.SelectAll(); 
                txtInputNumber.Focus();
            }
        }

        private void btnThucHien_Click(object sender, EventArgs e)
        {
            if (numberList.Count == 0)
            {
                txtTongMang.Text = "0";
                txtSoChan.Text = "0";
                MessageBox.Show("Mảng đang rỗng. Vui lòng nhập số trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return; 
            }


            long sum = numberList.Sum(x => (long)x); 
            txtTongMang.Text = sum.ToString();


            int evenCount = numberList.Count(n => n % 2 == 0);
            txtSoChan.Text = evenCount.ToString();
        }

 
        private void btnSapXepGiam_Click(object sender, EventArgs e)
        {
            if (numberList.Count == 0)
            {
                MessageBox.Show("Mảng đang rỗng, không có gì để sắp xếp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return; 
            }


        
            numberList = numberList.OrderByDescending(n => n).ToList();


            UpdateDisplayArray();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     
        private void txtInputNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnNhapSo_Click(sender, e);
            }
        }
    }
}