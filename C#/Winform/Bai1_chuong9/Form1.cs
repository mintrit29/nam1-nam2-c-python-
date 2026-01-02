using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Bai1_chuong9
{
    public partial class Form1 : Form
    {
        string connectionString = "Data Source=VINCENT\\SQLEXPRESS;Initial Catalog=QLSINHVIEN;Integrated Security=True";
        SqlConnection cn;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(connectionString);
            try
            {
                cn.Open(); // Thử mở kết nối
                           // Nếu kết nối thành công, gọi hàm tải dữ liệu Khoa
                Load_ComboBox_Khoa();
                cn.Close(); // Đóng lại ngay sau khi kiểm tra và tải xong ComboBox
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message);
                // Có thể vô hiệu hóa các nút nếu không kết nối được
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
                btnSua.Enabled = false;
            }
        }

    void Load_ComboBox_Khoa()
        {
            DataSet ds = new DataSet();
            string strSelect = "SELECT MaKhoa, TenKhoa FROM Khoa";

            SqlDataAdapter da = new SqlDataAdapter(strSelect, cn);

            try
            {
                da.Fill(ds, "Khoa");

                cboKhoa.DataSource = ds.Tables["Khoa"];

                cboKhoa.DisplayMember = "TenKhoa";

                cboKhoa.ValueMember = "MaKhoa";

                cboKhoa.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách Khoa: " + ex.Message);
            }
        }

        bool KiemTraMaLopTonTai(string maLop)
        {
            bool exists = false;
            string sql = "SELECT COUNT(*) FROM Lop WHERE MaLop = @MaLop";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@MaLop", maLop);

            try
            {
                if (cn.State != ConnectionState.Open) // Mở kết nối nếu nó đang đóng
                    cn.Open();

                int count = (int)cmd.ExecuteScalar(); // ExecuteScalar trả về giá trị ô đầu tiên, dòng đầu tiên
                if (count > 0)
                {
                    exists = true; // Nếu count > 0 nghĩa là mã lớp đã tồn tại
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kiểm tra mã lớp: " + ex.Message);
                // Có thể xem xét trả về true để ngăn chặn thao tác nếu có lỗi
            }
            finally
            {
                if (cn.State == ConnectionState.Open) // Đóng kết nối nếu đã mở
                    cn.Close();
            }
            return exists;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // 1. Lấy dữ liệu từ Form
            string maLop = txtMaLop.Text.Trim();
            string tenLop = txtTenLop.Text.Trim();
            object selectedKhoaValue = cboKhoa.SelectedValue; // Lấy giá trị MaKhoa

            // 2. Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(maLop))
            {
                MessageBox.Show("Vui lòng nhập Mã lớp.");
                txtMaLop.Focus();
                return;
            }
            if (string.IsNullOrEmpty(tenLop))
            {
                MessageBox.Show("Vui lòng nhập Tên lớp.");
                txtTenLop.Focus();
                return;
            }
            if (selectedKhoaValue == null) // Kiểm tra xem đã chọn Khoa chưa
            {
                MessageBox.Show("Vui lòng chọn Khoa.");
                cboKhoa.Focus();
                return;
            }
            string maKhoa = selectedKhoaValue.ToString();

            // 3. Kiểm tra Mã lớp đã tồn tại chưa?
            if (KiemTraMaLopTonTai(maLop))
            {
                MessageBox.Show("Mã lớp [" + maLop + "] đã tồn tại. Vui lòng nhập mã khác.");
                txtMaLop.Focus();
                txtMaLop.SelectAll();
                return;
            }

            // 4. Thực hiện INSERT vào CSDL
            string sqlInsert = "INSERT INTO Lop (MaLop, TenLop, MaKhoa) VALUES (@MaLop, @TenLop, @MaKhoa)";
            SqlCommand cmd = new SqlCommand(sqlInsert, cn);
            cmd.Parameters.AddWithValue("@MaLop", maLop);
            cmd.Parameters.AddWithValue("@TenLop", tenLop);
            cmd.Parameters.AddWithValue("@MaKhoa", maKhoa);

            try
            {
                if (cn.State != ConnectionState.Open)
                    cn.Open();

                int rowsAffected = cmd.ExecuteNonQuery(); // ExecuteNonQuery trả về số dòng bị ảnh hưởng

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Thêm lớp thành công!");
                    // (Tùy chọn) Xóa trống các ô nhập liệu sau khi thêm
                    txtMaLop.Clear();
                    txtTenLop.Clear();
                    cboKhoa.SelectedIndex = -1;
                    // (Tùy chọn) Cập nhật lại một danh sách lớp nếu có (ví dụ: DataGridView)
                    // LoadDanhSachLop();
                }
                else
                {
                    MessageBox.Show("Thêm lớp thất bại.");
                }
            }
            catch (SqlException sqlex) // Bắt lỗi SQL cụ thể (như khóa ngoại, kiểu dữ liệu...)
            {
                MessageBox.Show("Lỗi SQL khi thêm lớp: " + sqlex.Message);
            }
            catch (Exception ex) // Bắt lỗi chung khác
            {
                MessageBox.Show("Lỗi khi thêm lớp: " + ex.Message);
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // 1. Lấy Mã lớp cần xóa
            string maLop = txtMaLop.Text.Trim();

            // 2. Kiểm tra xem Mã lớp có được nhập không
            if (string.IsNullOrEmpty(maLop))
            {
                MessageBox.Show("Vui lòng nhập hoặc chọn Mã lớp cần xóa.");
                txtMaLop.Focus();
                return;
            }

            // 3. Hỏi xác nhận trước khi xóa
            DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa lớp có mã [{maLop}] không?",
                                                   "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                // 4. Thực hiện DELETE khỏi CSDL
                string sqlDelete = "DELETE FROM Lop WHERE MaLop = @MaLop";
                SqlCommand cmd = new SqlCommand(sqlDelete, cn);
                cmd.Parameters.AddWithValue("@MaLop", maLop);

                try
                {
                    if (cn.State != ConnectionState.Open)
                        cn.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Xóa lớp thành công!");
                        // (Tùy chọn) Xóa trống các ô nhập liệu
                        txtMaLop.Clear();
                        txtTenLop.Clear();
                        cboKhoa.SelectedIndex = -1;
                        // (Tùy chọn) Cập nhật lại danh sách lớp
                        // LoadDanhSachLop();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy lớp có mã [" + maLop + "] để xóa.");
                    }
                }
                catch (SqlException sqlex) // Bắt lỗi SQL, ví dụ: lớp này đang được tham chiếu ở bảng khác
                {
                    MessageBox.Show("Lỗi SQL khi xóa lớp: " + sqlex.Message + "\nCó thể lớp này đang chứa sinh viên hoặc dữ liệu liên quan khác.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa lớp: " + ex.Message);
                }
                finally
                {
                    if (cn.State == ConnectionState.Open)
                        cn.Close();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // 1. Lấy dữ liệu từ Form
            string maLop = txtMaLop.Text.Trim();
            string tenLop = txtTenLop.Text.Trim();
            object selectedKhoaValue = cboKhoa.SelectedValue;

            // 2. Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(maLop))
            {
                MessageBox.Show("Vui lòng nhập hoặc chọn Mã lớp cần sửa.");
                txtMaLop.Focus();
                return;
            }
            if (string.IsNullOrEmpty(tenLop))
            {
                MessageBox.Show("Vui lòng nhập Tên lớp.");
                txtTenLop.Focus();
                return;
            }
            if (selectedKhoaValue == null)
            {
                MessageBox.Show("Vui lòng chọn Khoa.");
                cboKhoa.Focus();
                return;
            }
            string maKhoa = selectedKhoaValue.ToString();

            // 3. Thực hiện UPDATE trong CSDL
            // Lưu ý: Không cần kiểm tra mã lớp tồn tại vì nếu không tồn tại thì UPDATE sẽ không ảnh hưởng dòng nào.
            string sqlUpdate = "UPDATE Lop SET TenLop = @TenLop, MaKhoa = @MaKhoa WHERE MaLop = @MaLop";
            SqlCommand cmd = new SqlCommand(sqlUpdate, cn);
            cmd.Parameters.AddWithValue("@TenLop", tenLop);
            cmd.Parameters.AddWithValue("@MaKhoa", maKhoa);
            cmd.Parameters.AddWithValue("@MaLop", maLop); // Điều kiện WHERE

            try
            {
                if (cn.State != ConnectionState.Open)
                    cn.Open();

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Cập nhật thông tin lớp thành công!");
                    // (Tùy chọn) Xóa trống các ô nhập liệu
                    txtMaLop.Clear();
                    txtTenLop.Clear();
                    cboKhoa.SelectedIndex = -1;
                    // (Tùy chọn) Cập nhật lại danh sách lớp
                    // LoadDanhSachLop();
                }
                else
                {
                    // Có thể mã lớp nhập vào không tồn tại trong CSDL
                    MessageBox.Show("Cập nhật lớp thất bại. Không tìm thấy mã lớp [" + maLop + "] hoặc thông tin không thay đổi.");
                }
            }
            catch (SqlException sqlex) // Bắt lỗi SQL
            {
                MessageBox.Show("Lỗi SQL khi cập nhật lớp: " + sqlex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật lớp: " + ex.Message);
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
            }
        }
    }
}
