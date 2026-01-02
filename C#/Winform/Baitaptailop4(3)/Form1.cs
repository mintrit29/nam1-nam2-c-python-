using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Baitaptailop4
{
    public partial class Form1: Form
    {
        private int[] dãySố;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;

            // Kiểm tra và xử lý chuỗi nhập vào
            if (!string.IsNullOrWhiteSpace(input))
            {
                try
                {
                    dãySố = input.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                  .Select(s => int.Parse(s)).ToArray();

                    // Hiển thị dãy số vào TextBox
                    textBox2.Text = string.Join(", ", dãySố);

                    // Tính tổng, tổng chẵn, tổng lẻ
                    textBox3.Text = dãySố.Sum().ToString();
                    textBox4.Text = dãySố.Where(n => n % 2 == 0).Sum().ToString();
                    textBox5.Text = dãySố.Where(n => n % 2 != 0).Sum().ToString();
                }
                catch (FormatException)
                {
                    // Nếu người dùng nhập dữ liệu không hợp lệ, xóa các TextBox kết quả
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox2.Clear();
                }
            }
            else
            {
                // Nếu không có dữ liệu, xóa kết quả
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox2.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            dãySố = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thoát", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
