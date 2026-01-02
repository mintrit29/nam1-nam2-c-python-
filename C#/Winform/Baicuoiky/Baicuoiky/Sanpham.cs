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
    public partial class Sanpham: Form
    {
        public Sanpham()
        {
            InitializeComponent();

            DataTable table = new DataTable();

            table.Columns.Add("Pro ID", typeof(string));
            table.Columns.Add("Pro Img", typeof(string));  // Cột "Pro Img" chứa chữ "img"
            table.Columns.Add("Pro name", typeof(string));
            table.Columns.Add("Pro quantity", typeof(int));
            table.Columns.Add("Pro price", typeof(int));

            // Thêm dữ liệu giả vào DataTable
            table.Rows.Add("P001", "img", "Sản phẩm A", 10, 50000);
            table.Rows.Add("P002", "img", "Sản phẩm B", 5, 120000);
            table.Rows.Add("P003", "img", "Sản phẩm C", 3, 30000);
            table.Rows.Add("P004", "img", "Sản phẩm D", 7, 45000);
            table.Rows.Add("P005", "img", "Sản phẩm E", 2, 15000);


            cuiDataGridView1.DataSource = table;
        }

        private void pbBack_Click(object sender, EventArgs e)
        {
            this.Close();
            Nhanvien nhanvien = new Nhanvien();
            nhanvien.Show();
        }

        private void btnAddPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Chọn ảnh";
            ofd.Filter = "Image Files(*.gif; *.jpg; *.jpeg; *.bmp; *.wmf; *.png) | *.gif; *.jpg; *.jpeg; *.bmp; *.wmf; *.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pbPicture.ImageLocation = ofd.FileName;
            }
        }
    }
}
