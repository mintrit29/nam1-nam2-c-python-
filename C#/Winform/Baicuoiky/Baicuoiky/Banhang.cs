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
    public partial class Banhang : Form
    {
        public Banhang()
        {
            InitializeComponent();


            // Create a DataTable and add columns
            DataTable table = new DataTable();

            // Thêm các cột thông tin sản phẩm, bao gồm Product ID
            table.Columns.Add("Product ID", typeof(int));
            table.Columns.Add("Product name", typeof(string));
            table.Columns.Add("Quantity", typeof(int));
            table.Columns.Add("Price", typeof(int));
            table.Columns.Add("Total price", typeof(int));

            // Thêm dữ liệu giả cho các sản phẩm
            table.Rows.Add(1, "Sản phẩm 1", 2, 50000, 100000); // Tổng = Quantity * Price
            table.Rows.Add(2, "Sản phẩm 2", 1, 120000, 120000);
            table.Rows.Add(3, "Sản phẩm 3", 3, 30000, 90000);
            table.Rows.Add(4, "Sản phẩm 4", 5, 45000, 225000);
            table.Rows.Add(5, "Sản phẩm 5", 10, 15000, 150000);

            cuiDataGridView1.DataSource = table;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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
