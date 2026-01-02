using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

public partial class Form1 : Form
{
    const decimal GIA_PHONG_DON = 300000m;
    const decimal GIA_PHONG_DOI = 500000m;
    const decimal GIA_GIAT_UI = 30000m;
    const decimal GIA_THUE_XE_MAY = 150000m;
    const decimal GIA_BIA_TIGER = 17000m;
    const decimal GIA_NUOC_SUOI = 15000m;

    const decimal VIP_DISCOUNT_RATE = 0.10m;
    const decimal VISA_DISCOUNT_RATE = 0.05m;

    public Form1()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        cmbPhuongThuc.Items.Add("Tiền mặt");
        cmbPhuongThuc.Items.Add("Visa");
        cmbPhuongThuc.Items.Add("Chuyển khoản");
        cmbPhuongThuc.SelectedIndex = 0;

        txtSoNgay.Text = "1";
        ClearResults();
    }

    private void btnTinhTien_Click(object sender, EventArgs e)
    {
        if (!int.TryParse(txtSoNgay.Text, out int soNgay) || soNgay <= 0)
        {
            MessageBox.Show("Số ngày ở phải là một số nguyên dương.", "Lỗi Nhập Liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtSoNgay.Focus();
            txtSoNgay.SelectAll();
            ClearResults();
            return;
        }

        decimal tienPhong = 0;
        decimal tienDichVu = 0;
        decimal tienGiamGia = 0;
        decimal tongTienTruocGiam = 0;
        decimal tongTienPhaiTra = 0;

        if (rbPhongDon.Checked)
        {
            tienPhong = GIA_PHONG_DON * soNgay;
        }
        else if (rbPhongDoi.Checked)
        {
            tienPhong = GIA_PHONG_DOI * soNgay;
        }

        if (chkGiatUi.Checked)
        {
            tienDichVu += GIA_GIAT_UI;
        }
        if (chkThueXeMay.Checked)
        {
            tienDichVu += GIA_THUE_XE_MAY * soNgay;
        }
        if (chkBiaTiger.Checked)
        {
            tienDichVu += GIA_BIA_TIGER;
        }
        if (chkNuocSuoi.Checked)
        {
            tienDichVu += GIA_NUOC_SUOI;
        }

   
        tongTienTruocGiam = tienPhong + tienDichVu;

        decimal giamGiaVIP = 0;
        decimal giamGiaVisa = 0;

        if (chkKhachVIP.Checked)
        {
            giamGiaVIP = tongTienTruocGiam * VIP_DISCOUNT_RATE;
        }

        if (cmbPhuongThuc.SelectedItem != null && cmbPhuongThuc.SelectedItem.ToString() == "Visa")
        {
            giamGiaVisa = tongTienTruocGiam * VISA_DISCOUNT_RATE;
        }

        tienGiamGia = giamGiaVIP + giamGiaVisa;

        tongTienPhaiTra = tongTienTruocGiam - tienGiamGia;

        
        CultureInfo viVNCulture = new CultureInfo("vi-VN"); 
        txtTienPhong.Text = tienPhong.ToString("N0");
        txtTienDichVu.Text = tienDichVu.ToString("N0");
        txtGiamGia.Text = tienGiamGia.ToString("N0");
        txtTongTien.Text = tongTienPhaiTra.ToString("N0") + " đ"; 

    }

    private void btnThoat_Click(object sender, EventArgs e)
    {
        DialogResult result = MessageBox.Show(
            "Bạn có chắc chắn muốn thoát không?",
            "Xác nhận thoát",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            this.Close();
        }
    }

    private void ClearResults()
    {
        txtTienPhong.Text = "0";
        txtTienDichVu.Text = "0";
        txtGiamGia.Text = "0";
        txtTongTien.Text = "0 đ";
    }
    private void rbPhongDon_CheckedChanged(object sender, EventArgs e)
    {
        if (((RadioButton)sender).Checked) 
            ClearResults();
    }
    private void rbPhongDoi_CheckedChanged(object sender, EventArgs e)
    {
        if (((RadioButton)sender).Checked)
            ClearResults();
    }
}