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
    public partial class Signin : Form
    {
        public Signin()
        {
            InitializeComponent();
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lblCreate_Click(object sender, EventArgs e)
        {
            Dangki dangki = new Dangki(); // tạo Form2
            dangki.Show();              // mở Form2
            this.Hide();               // ẩn Form1 (không tắt hẳn)

            // Nếu muốn đóng luôn Form1 thì dùng this.Close() thay vì this.Hide()
        }

        private void lblForgot_Click(object sender, EventArgs e)
        {
            Quenmk quenmk = new Quenmk();
            quenmk.Show();             
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Nhanvien nhanvien = new Nhanvien();
            nhanvien.Show();
            this.Hide();
        }
    }
}
