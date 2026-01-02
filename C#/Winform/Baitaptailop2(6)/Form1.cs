using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baitaptailop2_6_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem listViewItem in lstv1.Items)
            {
                if (listViewItem.SubItems[0].Text == txtmssv.Text) // Kiểm tra MSSV trùng
                {
                    MessageBox.Show("Mã số sinh viên đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Dừng quá trình thêm sinh viên nếu trùng
                }
            }
            ListViewItem item = new ListViewItem();
            ListViewItem.ListViewSubItem subitem = new
            ListViewItem.ListViewSubItem();
            item.Text = txtmssv.Text;
            subitem.Text = txthoten.Text;
            item.SubItems.Add(subitem);
            lstv1.Items.Add(item);
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem l in lstv1.SelectedItems)
            {
                l.Remove();
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (lstv1.FocusedItem != null && lstv1.FocusedItem.Index >= 0)
            {
                ListViewItem item = lstv1.FocusedItem;
                item.SubItems[0].Text = txtmssv.Text;
                item.SubItems[1].Text = txthoten.Text;
            }
        }
    }
}
