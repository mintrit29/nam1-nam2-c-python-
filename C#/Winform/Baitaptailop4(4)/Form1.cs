using System;
using System.Windows.Forms;

namespace HotelPayment
{
    public partial class Form1 : Form
    {
        // Biến lưu trữ tổng số lượt khách và tổng tiền thu được trong ngày
        private int totalGuests = 0;
        private decimal totalRevenue = 0;

        // Các hằng số giá
        private const decimal SINGLE_ROOM_RATE = 300000m;
        private const decimal DOUBLE_ROOM_RATE = 350000m;
        private const decimal TRIPLE_ROOM_RATE = 400000m;
        private const decimal AMENITY_RATE = 10000m;
        private const decimal KARAOKE_RATE = 50000m;
        private const decimal BREAKFAST_RATE_PER_DAY = 15000m;

        public Form1()
        {
            InitializeComponent();
        }

        // --- XỬ LÝ SỰ KIỆN LOAD FORM ---
        private void Form1_Load(object sender, EventArgs e)
        {
            // Đặt con trỏ vào ô Tên khách hàng
            txtName.Focus();

            // Mờ các button không cần thiết ban đầu
            btnThanhToan.Enabled = false;
            btnNhapMoi.Enabled = false;
            btnTongKet.Enabled = false;

            // Khởi tạo trạng thái ban đầu
            ResetFormControls();
        }

        // --- KIỂM TRA TÍNH HỢP LỆ CỦA INPUT ---
        private bool IsInputValid()
        {
            // Kiểm tra tên không được trống
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                return false;
            }

            // Kiểm tra địa chỉ không được trống
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                return false;
            }

            // Kiểm tra số ngày ở phải lớn hơn 0 (NumericUpDown đã có Min=1)
            if (numDays.Value <= 0)
            {
                return false;
            }

            // Kiểm tra đã chọn loại phòng chưa (RadioButton trong GroupBox đảm bảo luôn có 1 cái được chọn nếu có Checked=true ban đầu)
            if (!radSingle.Checked && !radDouble.Checked && !radTriple.Checked)
            {
                return false; // Trường hợp không có default checked
            }

            return true;
        }

        // --- SỰ KIỆN KHI INPUT THAY ĐỔI (ĐỂ ENABLE/DISABLE btnThanhToan) ---
        private void Input_Changed(object sender, EventArgs e)
        {
            btnThanhToan.Enabled = IsInputValid();
        }


        // --- XỬ LÝ SỰ KIỆN CLICK BUTTON THANH TOÁN ---
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (!IsInputValid()) // Kiểm tra lại lần nữa cho chắc chắn
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng (Tên, Địa chỉ, Số ngày > 0).", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy số ngày ở
            int days = (int)numDays.Value;

            // Tính tiền phòng
            decimal roomCost = 0;
            if (radSingle.Checked)
                roomCost = SINGLE_ROOM_RATE * days;
            else if (radDouble.Checked)
                roomCost = DOUBLE_ROOM_RATE * days;
            else if (radTriple.Checked)
                roomCost = TRIPLE_ROOM_RATE * days;

            // Tính tiền tiện nghi
            decimal amenityCost = 0;
            if (chkTV.Checked) amenityCost += AMENITY_RATE;
            if (chkInternet.Checked) amenityCost += AMENITY_RATE;
            if (chkMayGiat.Checked) amenityCost += AMENITY_RATE;
            // Thêm các checkbox tiện nghi khác nếu có

            // Tính tiền dịch vụ
            decimal serviceCost = 0;
            if (chkKaraoke.Checked) serviceCost += KARAOKE_RATE;
            if (chkBreakfast.Checked) serviceCost += BREAKFAST_RATE_PER_DAY * days;

            // Tính tổng tiền thanh toán cho khách này
            decimal currentBill = roomCost + amenityCost + serviceCost;

            // Hiển thị thành tiền
            lblThanhTien.Text = currentBill.ToString("N0") + " đ"; // Định dạng số có dấu phẩy ngăn cách hàng nghìn

            // Cập nhật tổng số lượt khách và tổng doanh thu
            totalGuests++;
            totalRevenue += currentBill;

            // Cập nhật trạng thái các button
            btnNhapMoi.Enabled = true;
            btnTongKet.Enabled = true;
            btnThanhToan.Enabled = false; // Mờ đi sau khi đã thanh toán, chờ nhập mới
        }

        // --- XỬ LÝ SỰ KIỆN CLICK BUTTON NHẬP MỚI ---
        private void btnNhapMoi_Click(object sender, EventArgs e)
        {
            ResetFormControls();
        }

        // --- HÀM KHỞI TẠO LẠI TRẠNG THÁI FORM ---
        private void ResetFormControls()
        {
            // Xóa/Reset các ô nhập liệu
            txtName.Clear();
            txtAddress.Clear();
            numDays.Value = 1; // Giá trị mặc định hợp lệ

            // Đặt lại loại phòng (chọn phòng đơn làm mặc định)
            radSingle.Checked = true;

            // Bỏ chọn tất cả tiện nghi và dịch vụ
            chkTV.Checked = false;
            chkInternet.Checked = false;
            chkMayGiat.Checked = false;
            chkKaraoke.Checked = false;
            chkBreakfast.Checked = false;

            // Reset label Thành tiền
            lblThanhTien.Text = "0 đ";

            // Đặt lại focus
            txtName.Focus();

            // Mờ các button không cần thiết
            // btnTongKet giữ nguyên trạng thái Enabled/Disabled từ lần ThanhToan trước
            // hoặc bị Disabled nếu vừa nhấn Tổng kết
            btnNhapMoi.Enabled = false;
            btnThanhToan.Enabled = false; // Vì txtName và txtAddress trống
        }


        // --- XỬ LÝ SỰ KIỆN CLICK BUTTON TỔNG KẾT ---
        private void btnTongKet_Click(object sender, EventArgs e)
        {
            // Hiển thị tổng kết ra các label tương ứng
            lblTotalGuests.Text = totalGuests.ToString();
            lblTotalRevenue.Text = totalRevenue.ToString("N0") + " đ";

            // Reset lại biến đếm và tổng tiền cho ngày mới (hoặc ca mới)
            totalGuests = 0;
            totalRevenue = 0;

            // Mờ button Tổng kết sau khi đã thực hiện
            btnTongKet.Enabled = false;

            // Có thể tùy chọn reset cả form nhập liệu hiện tại sau khi tổng kết
            // ResetFormControls(); // Bỏ comment nếu muốn reset cả form nhập liệu
        }

        // --- XỬ LÝ SỰ KIỆN CLICK BUTTON THOÁT ---
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát khỏi chương trình?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit(); // Hoặc this.Close(); nếu chỉ muốn đóng form này
            }
            // Nếu chọn No thì không làm gì cả
        }

        private void chkTV_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkBreakfast_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void grpAmenities_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
    }
}