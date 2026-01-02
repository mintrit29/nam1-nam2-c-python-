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

namespace Bai1_chuong7
{
    public partial class Form1: Form
    {
        SqlConnection connsql;
        public Form1()
        {
            InitializeComponent();
            connsql = new SqlConnection("Data source=VINCENT\\SQLEXPRESS;Initial Catalog = QLSINHVIEN;Integrated Security = True");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Kiem tra ket noi truoc khi mo 
                if (connsql.State == ConnectionState.Closed)
                {
                    connsql.Open();
                }
                //Xac dinh chuoi truy van
                string insertString;
                insertString = "insert into MonHoc values('" + txtMaMH.Text + "',N'" + txtTenMH.Text + "')";
                //Khai bao commamnd moi 
                SqlCommand cmd = new SqlCommand(insertString, connsql);
                //Goi ExecuteNonQuery de gui command
                cmd.ExecuteNonQuery();
                //Kiem tra ket noi truoc khi dong 
                if (connsql.State == ConnectionState.Open)
                {
                    connsql.Close();
                }
                //Hien thi thong bao 
                MessageBox.Show("Thanh cong");
            }
            catch (Exception ex)
            {
                MessageBox.Show("That bai");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //Kiem tra ket noi truoc khi mo 
                if (connsql.State == ConnectionState.Closed)
                {
                    connsql.Open();
                }
                //Xac dinh chuoi truy van
                string deleteString = "delete Khoa where MaMonHoc='" + txtMaMH.Text + "'";
                //Khai bao commamnd moi 
                SqlCommand cmd = new SqlCommand(deleteString, connsql);
                //Goi ExecuteNonQuery de gui command
                cmd.ExecuteNonQuery();
                //Kiem tra ket noi truoc khi dong 
                if (connsql.State == ConnectionState.Open)
                {
                    connsql.Close();
                }
                //Hien thi thong bao 
                MessageBox.Show("Thanh cong");
            }
            catch (Exception ex)
            {
                MessageBox.Show("That bai");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //Kiem tra ket noi truoc khi mo 
                if (connsql.State == ConnectionState.Closed)
                {
                    connsql.Open();
                }
                //Xac dinh chuoi truy van
                string updateString = "update MonHoc set TenMonHoc='" + txtTenMH.Text + "' where MaMonHoc='" + txtMaMH.Text + "'";
                //Khai bao commamnd moi 
                SqlCommand cmd = new SqlCommand(updateString, connsql);
                //Goi ExecuteNonQuery de gui command
                cmd.ExecuteNonQuery();
                //Kiem tra ket noi truoc khi dong 
                if (connsql.State == ConnectionState.Open)
                {
                    connsql.Close();
                }
                //Hien thi thong bao 
                MessageBox.Show("Thanh cong");
            }
            catch (Exception ex)
            {
                MessageBox.Show("That bai");
            }
        }
    }
}
