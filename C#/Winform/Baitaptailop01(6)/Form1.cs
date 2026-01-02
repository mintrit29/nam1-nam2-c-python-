using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baitaptailop01_6_
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbDanToc.Items.Add("Kinh");
            cmbDanToc.Items.Add("Tày");
            cmbDanToc.Items.Add("Mường");
            cmbDanToc.Items.Add("H'mong");

            // Tạo ContextMenuStrip
            contextMenuStrip1 = new ContextMenuStrip();

            // Tạo mục "Xóa"
            ToolStripMenuItem deleteItem = new ToolStripMenuItem("Xóa");
            contextMenuStrip1.Items.Add(deleteItem);

            // Đăng ký sự kiện khi nhấp vào mục "Xóa"
            contextMenuStrip1.ItemClicked += contextMenuStrip1_ItemClicked;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn đóng không?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Xóa")  // Kiểm tra xem mục người dùng đã chọn là "Xóa" không
            {
                // Xóa mục đã chọn trong ListView
                foreach (ListViewItem item in lvSinhVien.SelectedItems)
                {
                    item.Remove();  // Xóa mục khỏi ListView
                }
            }
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            string mssv = txtmssv.Text;
            // Lấy giá trị từ các điều khiển
            var gender = rbtnNam.Checked ? "Nam" : "Nữ";
            var languages = "";
            if (chkAnh.Checked) languages += "Anh ";
            if (chkPhap.Checked) languages += "Pháp ";
            if (chkHoa.Checked) languages += "Hoa ";

            foreach (ListViewItem lvItem in lvSinhVien.Items)  // Đổi tên 'item' thành 'lvItem'
            {
                if (lvItem.SubItems[0].Text == mssv)  // Kiểm tra mã sinh viên trùng
                {
                    MessageBox.Show("Mã sinh viên này đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;  // Dừng thêm nếu có mã trùng
                }
            }

            // Tạo một ListViewItem mới
            ListViewItem item = new ListViewItem(txtmssv.Text);

            // Thêm các SubItems vào ListViewItem
            item.SubItems.Add(txthoten.Text);
            item.SubItems.Add(gender);
            item.SubItems.Add(languages);
            item.SubItems.Add(cmbDanToc.SelectedItem.ToString());

            // Thêm ListViewItem vào ListView
            lvSinhVien.Items.Add(item);
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem l in lvSinhVien.SelectedItems)
            {
                l.Remove();
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu có mục nào được chọn trong ListView
            if (lvSinhVien.FocusedItem != null && lvSinhVien.FocusedItem.Index >= 0)
            {
                ListViewItem item = lvSinhVien.FocusedItem;

                // Không thay đổi Mã sinh viên, chỉ lấy giá trị của Mã sinh viên hiện tại
                string mssv = item.SubItems[0].Text; // Mã sinh viên không được sửa

                // Lấy các thông tin còn lại từ các trường nhập
                var gender = rbtnNam.Checked ? "Nam" : "Nữ";
                var languages = "";
                if (chkAnh.Checked) languages += "Anh ";
                if (chkPhap.Checked) languages += "Pháp ";
                if (chkHoa.Checked) languages += "Hoa ";

                // Cập nhật các thông tin khác vào ListViewItem
                item.SubItems[1].Text = txthoten.Text;   // Cập nhật tên
                item.SubItems[2].Text = gender;          // Cập nhật giới tính
                item.SubItems[3].Text = languages;       // Cập nhật ngôn ngữ
                item.SubItems[4].Text = cmbDanToc.SelectedItem.ToString(); // Cập nhật dân tộc

                // Thông báo cho người dùng rằng thông tin đã được cập nhật
                MessageBox.Show("Thông tin sinh viên đã được cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lvSinhVien_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Xác định mục được nhấp chuột phải
                var hit = lvSinhVien.HitTest(e.Location);
                if (hit.Item != null)
                {
                    // Chọn mục đã nhấp chuột
                    lvSinhVien.SelectedItems.Clear();
                    hit.Item.Selected = true;

                    // Thêm một khoảng cách offset (ví dụ: 10px) cho vị trí của menu ngữ cảnh
                    Point menuLocation = new Point(e.X + 10, e.Y + 10); // Thêm 10px vào tọa độ X và Y

                    // Hiển thị menu ngữ cảnh tại vị trí đã điều chỉnh
                    contextMenuStrip1.Show(lvSinhVien, menuLocation);
                }
            }
        }
    }
}
