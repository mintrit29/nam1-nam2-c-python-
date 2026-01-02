using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baitaptailop03
{
    public partial class Form1 : Form
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
            return (a * b) / UCLN(a, b);
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy giá trị từ TextBox và kiểm tra dữ liệu nhập
                int a = int.Parse(txtA.Text);
                int b = int.Parse(txtB.Text);

                // Tính UCLN và BCNN
                int ucln = UCLN(a, b);
                int bcnn = BCNN(a, b);

                // Hiển thị kết quả
                textBox3.Text = ucln.ToString();
                textBox4.Text = bcnn.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Vui lòng nhập vào hai số nguyên hợp lệ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            txtA.Clear();
            txtB.Clear();
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
