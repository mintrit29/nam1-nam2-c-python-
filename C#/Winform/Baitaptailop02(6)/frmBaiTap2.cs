using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization; // Required for number formatting

namespace WinFormsAppAccountManager // Change this namespace if needed
{
    public partial class frmBaiTap2 : Form
    {
        private bool isAdding = false; // Flag to track if we are in "Add" mode

        public frmBaiTap2()
        {
            InitializeComponent();
        }

        private void frmBaiTap2_Load(object sender, EventArgs e)
        {
            SetupListView();
            LoadInitialData();
            UpdateTotalAmount();
            UpdateButtonStates();

            // Select the last item and display its details as per the initial image
            if (lvTaiKhoan.Items.Count > 0)
            {
                lvTaiKhoan.Items[lvTaiKhoan.Items.Count - 1].Selected = true;
                lvTaiKhoan.Select(); // Ensure selection event fires
                // The lvTaiKhoan_SelectedIndexChanged event will handle populating textboxes
            }
            else
            {
                // If no initial data, ensure delete button is disabled
                btnXoa.Enabled = false;
            }
        }

        private void SetupListView()
        {
            lvTaiKhoan.View = View.Details;
            lvTaiKhoan.FullRowSelect = true;
            lvTaiKhoan.GridLines = true;
            lvTaiKhoan.MultiSelect = false;

            // Add columns only if they don't exist (good practice if designer might add them)
            if (lvTaiKhoan.Columns.Count == 0)
            {
                lvTaiKhoan.Columns.Add("STT", 40, HorizontalAlignment.Center);
                lvTaiKhoan.Columns.Add("Số tài khoản", 100, HorizontalAlignment.Left);
                lvTaiKhoan.Columns.Add("Tên khách hàng", 150, HorizontalAlignment.Left);
                lvTaiKhoan.Columns.Add("Địa chỉ", 100, HorizontalAlignment.Left);
                lvTaiKhoan.Columns.Add("Số tiền", 100, HorizontalAlignment.Right);
            }
        }

        private void LoadInitialData()
        {
            // Add sample data as shown in the image
            AddAccountToListView("0160901609", "Nguyễn Văn An", "TPHCM", 5200000);
            AddAccountToListView("0160901610", "Trần Văn Anh", "Tây Ninh", 1200000);
            UpdateRowNumbers(); // Update STT after adding initial data
        }

        // Helper to add account data to ListView
        private void AddAccountToListView(string accountNumber, string customerName, string address, decimal amount)
        {
            ListViewItem item = new ListViewItem(""); // STT will be updated later
            item.SubItems.Add(accountNumber);
            item.SubItems.Add(customerName);
            item.SubItems.Add(address);
            item.SubItems.Add(amount.ToString("N0", CultureInfo.InvariantCulture)); // Format with commas, no decimals
            item.Tag = amount; // Store the raw decimal amount in Tag for calculation
            lvTaiKhoan.Items.Add(item);
        }

        private void UpdateRowNumbers()
        {
            for (int i = 0; i < lvTaiKhoan.Items.Count; i++)
            {
                lvTaiKhoan.Items[i].SubItems[0].Text = (i + 1).ToString();
            }
        }

        private void UpdateTotalAmount()
        {
            decimal total = 0;
            foreach (ListViewItem item in lvTaiKhoan.Items)
            {
                // Retrieve the amount stored in the Tag
                if (item.Tag is decimal amount)
                {
                    total += amount;
                }
                // Fallback: Try parsing from text if Tag is missing (less robust)
                // else if (decimal.TryParse(item.SubItems[4].Text.Replace(",", ""), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal parsedAmount))
                // {
                //     total += parsedAmount;
                // }
            }
            // Display total formatted with commas, no decimals
            txtTongTien.Text = total.ToString("N0", CultureInfo.InvariantCulture);
        }

        private void UpdateButtonStates()
        {
            if (isAdding)
            {
                btnThem.Text = "Hủy";
                btnLuu.Enabled = true;
                btnXoa.Enabled = false; // Cannot delete while adding
                lvTaiKhoan.Enabled = false; // Disable list interaction during add
            }
            else
            {
                btnThem.Text = "Thêm";
                btnLuu.Enabled = false;
                // Enable Xoa only if an item is selected
                btnXoa.Enabled = (lvTaiKhoan.SelectedItems.Count > 0);
                lvTaiKhoan.Enabled = true; // Enable list interaction
            }
        }

        private void ClearInputFields()
        {
            txtSoTaiKhoan.Clear();
            txtTenKhachHang.Clear();
            txtDiaChi.Clear();
            txtSoTien.Clear();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isAdding = !isAdding; // Toggle the adding state

            if (isAdding)
            {
                // Entering Add mode
                ClearInputFields();
                lvTaiKhoan.SelectedItems.Clear(); // Deselect any item
                txtSoTaiKhoan.Focus();
            }
            else
            {
                // Cancelling Add mode
                // Optionally, re-select the last selected item or clear fields
                ClearInputFields();
                if (lvTaiKhoan.Items.Count > 0) // Reselect last item if available
                {
                    // Re-enable selection event temporarily if needed
                    lvTaiKhoan.Enabled = true;
                    lvTaiKhoan.Items[lvTaiKhoan.Items.Count - 1].Selected = true;
                    lvTaiKhoan.Select();
                }
            }
            UpdateButtonStates(); // Update buttons based on the new state
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Basic Validation
            if (string.IsNullOrWhiteSpace(txtSoTaiKhoan.Text) ||
                string.IsNullOrWhiteSpace(txtTenKhachHang.Text) ||
                string.IsNullOrWhiteSpace(txtDiaChi.Text) ||
                string.IsNullOrWhiteSpace(txtSoTien.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtSoTien.Text.Replace(",", ""), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal amount))
            {
                MessageBox.Show("Số tiền không hợp lệ.", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoTien.Focus();
                txtSoTien.SelectAll();
                return;
            }

            // Add data to ListView
            AddAccountToListView(txtSoTaiKhoan.Text, txtTenKhachHang.Text, txtDiaChi.Text, amount);

            // Update UI
            UpdateRowNumbers();
            UpdateTotalAmount();
            ClearInputFields();

            // Exit Add mode
            isAdding = false;
            UpdateButtonStates();

            // Select the newly added item
            lvTaiKhoan.Items[lvTaiKhoan.Items.Count - 1].Selected = true;
            lvTaiKhoan.Select();
            lvTaiKhoan.EnsureVisible(lvTaiKhoan.Items.Count - 1); // Scroll to new item
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvTaiKhoan.SelectedItems.Count > 0)
            {
                // Optional: Confirmation dialog
                var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản này?",
                                     "Xác nhận xóa",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    lvTaiKhoan.SelectedItems[0].Remove();
                    UpdateRowNumbers();
                    UpdateTotalAmount();
                    ClearInputFields(); // Clear textboxes after deleting
                    btnXoa.Enabled = false; // Disable delete as nothing is selected now
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một tài khoản để xóa.", "Chưa chọn tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the form
        }

        private void lvTaiKhoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Only process if not in Add mode and an item is actually selected
            if (!isAdding && lvTaiKhoan.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvTaiKhoan.SelectedItems[0];

                txtSoTaiKhoan.Text = selectedItem.SubItems[1].Text;
                txtTenKhachHang.Text = selectedItem.SubItems[2].Text;
                txtDiaChi.Text = selectedItem.SubItems[3].Text;
                // Display amount without commas in the textbox for easier editing potentially
                // Retrieve from Tag for accuracy
                if (selectedItem.Tag is decimal amount)
                {
                    txtSoTien.Text = amount.ToString(CultureInfo.InvariantCulture); // Use InvariantCulture to avoid locale issues with decimal point
                }
                else
                {
                    // Fallback if Tag is missing
                    txtSoTien.Text = selectedItem.SubItems[4].Text.Replace(",", "");
                }


                btnXoa.Enabled = true; // Enable delete button when an item is selected
            }
            else if (!isAdding)
            {
                // If selection is cleared (and not in Add mode), disable delete
                // Optionally clear textboxes when selection is lost outside of add mode
                // ClearInputFields(); // Uncomment if you want fields cleared when nothing is selected
                btnXoa.Enabled = false;
            }
            // If in Add mode, changing selection shouldn't happen (list is disabled)
            // but adding this check prevents accidental state changes.
            else
            {
                btnXoa.Enabled = false;
            }
        }

        // Optional: Handle Enter key in SoTien textbox like clicking Save if in Add mode
        private void txtSoTien_KeyDown(object sender, KeyEventArgs e)
        {
            if (isAdding && e.KeyCode == Keys.Enter)
            {
                btnLuu_Click(sender, e); // Trigger the Save button click event
                e.Handled = true; // Prevent the 'ding' sound
                e.SuppressKeyPress = true; // Prevent the Enter key from being processed further
            }
        }
    }
}