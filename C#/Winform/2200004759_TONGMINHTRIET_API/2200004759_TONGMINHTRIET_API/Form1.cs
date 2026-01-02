using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2200004759_TONGMINHTRIET_API
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn chắc không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Close();
            }
            else
                return;
        }

        private void btnTong_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear(); 

            int n;
            bool isNumeric = int.TryParse(txtNhap.Text, out n);

            if (!isNumeric || n <= 0)
            {
                errorProvider1.SetError(txtNhap, "Vui lòng nhập một số nguyên dương lớn hơn 0.");
                txtKetqua.Text = "";
                return;
            }

            try
            {
          
                TinhTong calculator = new TinhTong(n);

       
                double result = calculator.CalculateSum(); 

                txtKetqua.Text = result.ToString("F5");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi trong quá trình tính toán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtKetqua.Text = "";
            }
        }
    }
}
