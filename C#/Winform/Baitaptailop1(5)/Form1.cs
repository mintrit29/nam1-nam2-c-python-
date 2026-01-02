using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baitaptailop1_5_
{
    public partial class frmListBox: Form
    {
        public frmListBox()
        {
            InitializeComponent();
        }

        private void frmListBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
        "Bạn có chắc chắn muốn đóng form?",
        "Xác nhận đóng",
        MessageBoxButtons.YesNo, // Chỉ hiển thị nút Yes và No
        MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                // Nếu người dùng chọn "Không", hủy bỏ việc đóng
                e.Cancel = true;
            }
        }

        private void btnQuaPhai_Click(object sender, EventArgs e)
        {
            if (lst_Trai.SelectedItem != null)
            {
                // Chuyển giá trị chọn bên trái sang phải
                lst_Phai.Items.Add(lst_Trai.SelectedItem);
                // Xóa giá trị chọn bên trái
                lst_Trai.Items.Remove(lst_Trai.SelectedItem);
            }
            else
            {
                // Nếu không có item nào được chọn, hiển thị thông báo lỗi
                MessageBox.Show("Vui lòng chọn một mục từ danh sách bên trái để chuyển.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Chuyển giá trị items bên trái sang phải
            lst_Phai.Items.AddRange(lst_Trai.Items);
            // Xóa giá trị bên trái
            lst_Trai.Items.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (lst_Phai.SelectedItem != null)
            {
                lst_Trai.Items.Add(lst_Phai.SelectedItem);
                lst_Phai.Items.Remove(lst_Phai.SelectedItem);
            }
            else
            {
                // Nếu không có item nào được chọn, hiển thị thông báo lỗi
                MessageBox.Show("Vui lòng chọn một mục từ danh sách bên phải để chuyển.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lst_Trai.Items.AddRange(lst_Phai.Items);
            lst_Phai.Items.Clear();
        }
    }
}
