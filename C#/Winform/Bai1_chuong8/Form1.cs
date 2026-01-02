using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai1_chuong8
{
    public partial class Form1: Form
    {
        string connectionString = "Data Source=VINCENT\\SQLEXPRESS;Initial Catalog=QLSINHVIEN;Integrated Security=True;";
        public Form1()
        {
            InitializeComponent();
        }
        private void btnHienThiDuLieu_Click(object sender, EventArgs e)
        {
            listViewLop.Items.Clear();

            string query = "SELECT MaLop, TenLop, MaKhoa FROM Lop ORDER BY MaLop";

            int stt = 1;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    ListViewItem item = new ListViewItem(stt.ToString());
                                    item.SubItems.Add(reader["MaLop"].ToString());
                                    item.SubItems.Add(reader["TenLop"].ToString());
                                    item.SubItems.Add(reader["MaKhoa"].ToString());
                                    listViewLop.Items.Add(item);
                                    stt++;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy dữ liệu lớp học.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    catch (SqlException sqlEx)
                    {
                        MessageBox.Show($"Lỗi SQL: {sqlEx.Message}", "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn chắc chứ?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

            }    
        }
    }
}
