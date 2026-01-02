using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baitaptailop5
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNumber.Text))
            {
                MessageBox.Show("Vui lòng nhập một số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int number = int.Parse(txtNumber.Text);
                if (number < 1 || number > 999)
                {
                    MessageBox.Show("Số phải nằm trong khoảng từ 1 đến 999!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                lblResult.Text = NumberToWords(number);
            }
            catch (FormatException)
            {
                MessageBox.Show("Vui lòng nhập một số nguyên hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string NumberToWords(int number)
        {
            string[] ones = { "", "Một", "Hai", "Ba", "Bốn", "Năm", "Sáu", "Bảy", "Tám", "Chín" };
            string[] tens = { "", "Mười", "Hai Mươi", "Ba Mươi", "Bốn Mươi", "Năm Mươi", "Sáu Mươi", "Bảy Mươi", "Tám Mươi", "Chín Mươi" };
            string[] hundreds = { "", "Một Trăm", "Hai Trăm", "Ba Trăm", "Bốn Trăm", "Năm Trăm", "Sáu Trăm", "Bảy Trăm", "Tám Trăm", "Chín Trăm" };

            if (number == 0)
                return "Không";

            string words = "";
            int hundred = number / 100;
            int ten = (number % 100) / 10;
            int one = number % 10;

            if (hundred > 0)
            {
                words += hundreds[hundred] + " ";
            }

            if (ten > 0)
            {
                words += tens[ten] + " ";
            }
            else if (ten == 0 && one > 0 && hundred > 0)
            {
                words += "Lẻ ";
            }

            if (one > 0)
            {
                words += ones[one];
            }

            return words.Trim();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Bạn có chắc muốn thoát?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtNumber.Clear();
            lblResult.Text = string.Empty;
        }
    }
}
