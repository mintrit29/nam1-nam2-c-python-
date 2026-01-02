using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baicuoiky
{
    public partial class Nhanvien : Form
    {
        public Nhanvien()
        {
            InitializeComponent();
        }

        private void btnSignout_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Signin signin = new Signin();
            signin.Show();
        }

        private void btnSales_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Banhang banhang = new Banhang();
            banhang.Show();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            this.Close();
            Khachhang khachhang = new Khachhang();
            khachhang.Show();
        }

        private void cuiButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            Bill bill = new Bill();
            bill.Show();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            this.Close();
            Sanpham sanpham = new Sanpham();
            sanpham.Show();
        }
    }
}
