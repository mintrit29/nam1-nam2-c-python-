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
    public partial class Khachhang : Form
    {
        public Khachhang()
        {
            InitializeComponent();

            // Tạo DataTable
            DataTable table = new DataTable();
            table.Columns.Add("Customer ID", typeof(int));
            table.Columns.Add("Customer Name", typeof(string));
            table.Columns.Add("Address", typeof(string));
            table.Columns.Add("Phone number", typeof(int));

            // Thêm dữ liệu giả vào DataTable
            table.Rows.Add(1, "Nguyễn Văn A", "Hà Nội", 123456789);
            table.Rows.Add(2, "Trần Thị B", "Hồ Chí Minh", 987654321);
            table.Rows.Add(3, "Lê Minh C", "Đà Nẵng", 564738291);
            table.Rows.Add(4, "Phạm Thị D", "Hải Phòng", 876543210);
            table.Rows.Add(5, "Hoàng Văn E", "Cần Thơ", 112233445);

            cuiDataGridView1.DataSource = table;
        }

        private void cuiDataGridView1_Click(object sender, EventArgs e)
        {

        }

        private void pbBack_Click(object sender, EventArgs e)
        {
            this.Close();
            Nhanvien nhanvien = new Nhanvien();
            nhanvien.Show();
        }
    }
}
