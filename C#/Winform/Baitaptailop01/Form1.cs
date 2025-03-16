using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baitaptailop01
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private bool ValidateInput()
        {
            errorProvider1.Clear();
            double a, b;
            bool isValid = true;

            if (!double.TryParse(textBox1.Text, out a))
            {
                MessageBox.Show("Giá trị nhập vào ô A không hợp lệ. Vui lòng nhập số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isValid = false;
            }

            if (!double.TryParse(textBox2.Text, out b))
            {
                MessageBox.Show("Giá trị nhập vào ô B không hợp lệ. Vui lòng nhập số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isValid = false;
            }

            return isValid;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                double a = double.Parse(textBox1.Text);
                double b = double.Parse(textBox2.Text);
                textBox3.Text = (a + b).ToString();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có muốn thoát?", "Thoát",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
                e.Cancel = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                double a = double.Parse(textBox1.Text);
                double b = double.Parse(textBox2.Text);
                textBox3.Text = (a - b).ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                double a = double.Parse(textBox1.Text);
                double b = double.Parse(textBox2.Text);
                textBox3.Text = (a * b).ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                double a = double.Parse(textBox1.Text);
                double b = double.Parse(textBox2.Text);
                if (b == 0)
                {
                    MessageBox.Show("Không thể chia cho 0", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                textBox3.Text = (a / b).ToString();
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            double a;
            if (!double.TryParse(textBox1.Text, out a))
            {
                errorProvider1.SetError(textBox1, "Giá trị không hợp lệ");
            }
            else
            {
                errorProvider1.Clear();
            }    
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            double b;
            if (!double.TryParse(textBox2.Text, out b))
            {
                errorProvider1.SetError(textBox2, "Giá trị không hợp lệ");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true; // Chặn ký tự không hợp lệ
            }

            // Chỉ cho phép một dấu phẩy
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
