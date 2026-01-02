using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baitaptailop02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            if (!IsValidEmail(email))
            {
                errorProvider1.SetError(txtEmail, "Email không đúng định dạng.");
            }
            else
            {
                errorProvider1.SetError(txtEmail, "");
            }
        }

        private bool IsValidEmail(string email)
        {
            string pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            return Regex.IsMatch(email, pattern);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (!IsValidEmail(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, "Email không đúng định dạng.");
                return; // Dừng xử lý nếu email không hợp lệ
            }
            else
            {
                errorProvider1.SetError(txtEmail, "");
            }
            // Kiểm tra các trường bắt buộc
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                errorProvider1.SetError(txtUsername, "Tên đăng nhập không được để trống.");
                return;
            }
            else
            {
                errorProvider1.SetError(txtUsername, "");
            }

            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, "Email không được để trống.");
                return;
            }
            else
            {
                errorProvider1.SetError(txtEmail, "");
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                errorProvider1.SetError(txtPassword, "Mật khẩu không được để trống.");
                return;
            }
            else
            {
                errorProvider1.SetError(txtPassword, "");
            }

            if (string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                errorProvider1.SetError(txtConfirmPassword, "Xác nhận mật khẩu không được để trống.");
                return;
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, "");
            }

            // Kiểm tra mật khẩu và xác nhận mật khẩu
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                errorProvider1.SetError(txtConfirmPassword, "Mật khẩu không khớp.");
                return;
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, "");
            }

            // Hiển thị thông tin
            string message = $"Tên đăng nhập: {txtUsername.Text}\n" +
                             $"Email: {txtEmail.Text}";
            MessageBox.Show(message, "Thông tin đăng ký");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đóng form?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                errorProvider1.SetError(txtUsername, "Tên đăng nhập không được để trống.");
            }
            else
            {
                errorProvider1.SetError(txtUsername, "");
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, "Email không được để trống.");
            }
            else
            {
                errorProvider1.SetError(txtEmail, "");
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errorProvider1.SetError(txtPassword, "Mật khẩu không được để trống.");
            }
            else
            {
                errorProvider1.SetError(txtPassword, "");
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                errorProvider1.SetError(txtUsername, "Tên đăng nhập không được để trống.");
            }
            else
            {
                errorProvider1.SetError(txtUsername, "");
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errorProvider1.SetError(txtPassword, "Mật khẩu không được để trống.");
            }
            else
            {
                errorProvider1.SetError(txtPassword, "");
            }
        }

        private void txtConfirmPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnRegister_Click(sender, e); // Gọi sự kiện click của nút Đăng ký
            }
        }
    }
}
