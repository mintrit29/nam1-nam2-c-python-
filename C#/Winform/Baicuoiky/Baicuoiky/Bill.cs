using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace Baicuoiky
{
    public partial class Bill: Form
    {
        public Bill()
        {
            InitializeComponent();

            DataTable table = new DataTable();

            // Thêm các cột vào DataTable
            table.Columns.Add("Bill ID", typeof(int));
            table.Columns.Add("Pro ID", typeof(string));
            table.Columns.Add("Pro name", typeof(string));  // Chỉnh sửa kiểu dữ liệu từ int thành string cho tên sản phẩm
            table.Columns.Add("Pro quantity", typeof(int));
            table.Columns.Add("Pro price", typeof(int));
            table.Columns.Add("Total price", typeof(int));
            table.Columns.Add("Customer ID", typeof(int));
            table.Columns.Add("Employee ID", typeof(int));
            table.Columns.Add("Create date", typeof(DateTime)); // Chỉnh sửa kiểu dữ liệu từ int thành DateTime cho ngày tạo

            // Thêm dữ liệu giả vào DataTable
            table.Rows.Add(1, "P001", "Sản phẩm 1", 2, 50000, 100000, 101, 201, new DateTime(2025, 4, 27));
            table.Rows.Add(2, "P002", "Sản phẩm 2", 1, 120000, 120000, 102, 202, new DateTime(2025, 4, 26));
            table.Rows.Add(3, "P003", "Sản phẩm 3", 3, 30000, 90000, 103, 203, new DateTime(2025, 4, 25));
            table.Rows.Add(4, "P004", "Sản phẩm 4", 5, 45000, 225000, 104, 204, new DateTime(2025, 4, 24));
            table.Rows.Add(5, "P005", "Sản phẩm 5", 10, 15000, 150000, 105, 205, new DateTime(2025, 4, 23));

            cuiDataGridView1.DataSource = table;
        }

        private void Bill_Load(object sender, EventArgs e)
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
