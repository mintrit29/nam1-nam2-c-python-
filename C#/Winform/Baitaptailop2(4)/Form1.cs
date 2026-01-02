using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baitaptailop1_4_
{
    public partial class Form1: Form
    {
        private PhuongTrinhBacHai ptBacHai;
        public Form1()
        {
            InitializeComponent();
            ptBacHai = new PhuongTrinhBacHai();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ptBacHai.A = double.Parse(txtA.Text);
                ptBacHai.B = double.Parse(txtB.Text);
                ptBacHai.C = rbtnBacHai.Checked ? double.Parse(txtC.Text) : 0;

                string ketQua;
                if (rbtnBacNhat.Checked)
                {
                    ketQua = $"Nghiệm phương trình bậc nhất: x = {ptBacHai.GiaiPhuongTrinhBacNhat()}";
                }
                else
                {
                    ketQua = ptBacHai.GiaiPhuongTrinhBacHai();
                }
                txtKetQua.Text = ketQua;

                btnGiai.Enabled = false;
            }
            catch (FormatException)
            {
                MessageBox.Show("Dữ liệu nhập vào không hợp lệ. Vui lòng kiểm tra lại.");
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public class PhuongTrinhBacHai
        {
            public double A { get; set; }
            public double B { get; set; }
            public double C { get; set; }
            public double GiaiPhuongTrinhBacNhat()
            {
                if (A == 0)
                {
                    throw new InvalidOperationException("Phương trình bậc nhất không hợp lệ!");
                }
                return -B / A;
            }

            public string GiaiPhuongTrinhBacHai()
            {
                if (A == 0)
                {
                    throw new InvalidOperationException("Phương trình không phải bậc hai!");
                }

                double delta = B * B - 4 * A * C;
                if (delta < 0)
                {
                    return "Phương trình vô nghiệm.";
                }
                else if (delta == 0)
                {
                    double x = -B / (2 * A);
                    return $"Phương trình có nghiệm kép: x = {x}";
                }
                else
                {
                    double x1 = (-B + Math.Sqrt(delta)) / (2 * A);
                    double x2 = (-B - Math.Sqrt(delta)) / (2 * A);
                    return $"Phương trình có 2 nghiệm phân biệt: x1 = {x1}, x2 = {x2}";
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnBacNhat.Checked)
            {
                txtC.Enabled = false;
                txtA.Enabled = true;
                txtB.Enabled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void rbtnBacHai_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnBacHai.Checked)
            {
                txtC.Enabled = true;
                txtA.Enabled = true;
                txtB.Enabled = true;
            }
        }

        private void txtA_TextChanged(object sender, EventArgs e)
        {
            ValidateInput();
        }

        private void txtB_TextChanged(object sender, EventArgs e)
        {
            ValidateInput();
        }

        private void txtC_TextChanged(object sender, EventArgs e)
        {
            ValidateInput();
        }

        private void ValidateInput()
        {
            if (rbtnBacNhat.Checked)
            {
                btnGiai.Enabled = !string.IsNullOrWhiteSpace(txtA.Text) && !string.IsNullOrWhiteSpace(txtB.Text);
            }
            else if (rbtnBacHai.Checked)
            {
                btnGiai.Enabled = !string.IsNullOrWhiteSpace(txtA.Text) && !string.IsNullOrWhiteSpace(txtB.Text) && !string.IsNullOrWhiteSpace(txtC.Text);
            }
        }

      
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn đóng form?", "Xác nhận", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
