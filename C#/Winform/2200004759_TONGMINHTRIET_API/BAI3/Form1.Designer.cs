partial class Form1
{
    private System.ComponentModel.IContainer components = null;
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code
    private void InitializeComponent()
    {
        this.label1 = new System.Windows.Forms.Label();
        this.label2 = new System.Windows.Forms.Label();
        this.txtHoTen = new System.Windows.Forms.TextBox();
        this.groupBox1 = new System.Windows.Forms.GroupBox();
        this.rbPhongDoi = new System.Windows.Forms.RadioButton();
        this.rbPhongDon = new System.Windows.Forms.RadioButton();
        this.groupBox2 = new System.Windows.Forms.GroupBox();
        this.chkNuocSuoi = new System.Windows.Forms.CheckBox();
        this.chkThueXeMay = new System.Windows.Forms.CheckBox();
        this.chkBiaTiger = new System.Windows.Forms.CheckBox();
        this.chkGiatUi = new System.Windows.Forms.CheckBox();
        this.label3 = new System.Windows.Forms.Label();
        this.txtSoNgay = new System.Windows.Forms.TextBox();
        this.chkKhachVIP = new System.Windows.Forms.CheckBox();
        this.label4 = new System.Windows.Forms.Label();
        this.txtTienPhong = new System.Windows.Forms.TextBox();
        this.label5 = new System.Windows.Forms.Label();
        this.txtTienDichVu = new System.Windows.Forms.TextBox();
        this.label6 = new System.Windows.Forms.Label();
        this.txtGiamGia = new System.Windows.Forms.TextBox();
        this.label7 = new System.Windows.Forms.Label();
        this.txtTongTien = new System.Windows.Forms.TextBox();
        this.label8 = new System.Windows.Forms.Label();
        this.cmbPhuongThuc = new System.Windows.Forms.ComboBox();
        this.btnTinhTien = new System.Windows.Forms.Button();
        this.btnThoat = new System.Windows.Forms.Button();
        this.groupBox1.SuspendLayout();
        this.groupBox2.SuspendLayout();
        this.SuspendLayout();

        this.label1.AutoSize = true;
        this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label1.ForeColor = System.Drawing.Color.Blue;
        this.label1.Location = new System.Drawing.Point(211, 25);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(245, 24);
        this.label1.TabIndex = 0;
        this.label1.Text = "QUẢN LÝ KHÁCH SẠN";

        this.label2.AutoSize = true;
        this.label2.Location = new System.Drawing.Point(41, 78);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(111, 13);
        this.label2.TabIndex = 1;
        this.label2.Text = "Họ và tên khách hàng";
 
        this.txtHoTen.Location = new System.Drawing.Point(169, 75);
        this.txtHoTen.Name = "txtHoTen";
        this.txtHoTen.Size = new System.Drawing.Size(395, 20);
        this.txtHoTen.TabIndex = 0;

        this.groupBox1.Controls.Add(this.rbPhongDoi);
        this.groupBox1.Controls.Add(this.rbPhongDon);
        this.groupBox1.Location = new System.Drawing.Point(44, 118);
        this.groupBox1.Name = "groupBox1";
        this.groupBox1.Size = new System.Drawing.Size(228, 100);
        this.groupBox1.TabIndex = 1;
        this.groupBox1.TabStop = false;
        this.groupBox1.Text = "Loại phòng";

        this.rbPhongDoi.AutoSize = true;
        this.rbPhongDoi.Location = new System.Drawing.Point(36, 61);
        this.rbPhongDoi.Name = "rbPhongDoi";
        this.rbPhongDoi.Size = new System.Drawing.Size(74, 17);
        this.rbPhongDoi.TabIndex = 1;
        this.rbPhongDoi.Text = "Phòng đôi";
        this.rbPhongDoi.UseVisualStyleBackColor = true;

        this.rbPhongDon.AutoSize = true;
        this.rbPhongDon.Checked = true;
        this.rbPhongDon.Location = new System.Drawing.Point(36, 29);
        this.rbPhongDon.Name = "rbPhongDon";
        this.rbPhongDon.Size = new System.Drawing.Size(78, 17);
        this.rbPhongDon.TabIndex = 0;
        this.rbPhongDon.TabStop = true;
        this.rbPhongDon.Text = "Phòng đơn";
        this.rbPhongDon.UseVisualStyleBackColor = true;

        this.groupBox2.Controls.Add(this.chkNuocSuoi);
        this.groupBox2.Controls.Add(this.chkThueXeMay);
        this.groupBox2.Controls.Add(this.chkBiaTiger);
        this.groupBox2.Controls.Add(this.chkGiatUi);
        this.groupBox2.Location = new System.Drawing.Point(310, 118);
        this.groupBox2.Name = "groupBox2";
        this.groupBox2.Size = new System.Drawing.Size(254, 100);
        this.groupBox2.TabIndex = 2;
        this.groupBox2.TabStop = false;
        this.groupBox2.Text = "Dịch vụ";
 
        this.chkNuocSuoi.AutoSize = true;
        this.chkNuocSuoi.Location = new System.Drawing.Point(142, 61);
        this.chkNuocSuoi.Name = "chkNuocSuoi";
        this.chkNuocSuoi.Size = new System.Drawing.Size(74, 17);
        this.chkNuocSuoi.TabIndex = 3;
        this.chkNuocSuoi.Text = "Nước suối";
        this.chkNuocSuoi.UseVisualStyleBackColor = true;
     
        this.chkThueXeMay.AutoSize = true;
        this.chkThueXeMay.Location = new System.Drawing.Point(23, 61);
        this.chkThueXeMay.Name = "chkThueXeMay";
        this.chkThueXeMay.Size = new System.Drawing.Size(89, 17);
        this.chkThueXeMay.TabIndex = 1;
        this.chkThueXeMay.Text = "Thuê xe máy";
        this.chkThueXeMay.UseVisualStyleBackColor = true;

        this.chkBiaTiger.AutoSize = true;
        this.chkBiaTiger.Location = new System.Drawing.Point(142, 30);
        this.chkBiaTiger.Name = "chkBiaTiger";
        this.chkBiaTiger.Size = new System.Drawing.Size(70, 17);
        this.chkBiaTiger.TabIndex = 2;
        this.chkBiaTiger.Text = "Bia Tiger";
        this.chkBiaTiger.UseVisualStyleBackColor = true;
 
        this.chkGiatUi.AutoSize = true;
        this.chkGiatUi.Location = new System.Drawing.Point(23, 30);
        this.chkGiatUi.Name = "chkGiatUi";
        this.chkGiatUi.Size = new System.Drawing.Size(57, 17);
        this.chkGiatUi.TabIndex = 0;
        this.chkGiatUi.Text = "Giặt ủi";
        this.chkGiatUi.UseVisualStyleBackColor = true;

        this.label3.AutoSize = true;
        this.label3.Location = new System.Drawing.Point(77, 268);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(55, 13);
        this.label3.TabIndex = 5;
        this.label3.Text = "Số ngày ở";
        
        this.txtSoNgay.Location = new System.Drawing.Point(155, 265);
        this.txtSoNgay.Name = "txtSoNgay";
        this.txtSoNgay.Size = new System.Drawing.Size(117, 20);
        this.txtSoNgay.TabIndex = 3;
        
        this.chkKhachVIP.AutoSize = true;
        this.chkKhachVIP.Location = new System.Drawing.Point(405, 267);
        this.chkKhachVIP.Name = "chkKhachVIP";
        this.chkKhachVIP.Size = new System.Drawing.Size(101, 17);
        this.chkKhachVIP.TabIndex = 4;
        this.chkKhachVIP.Text = "Khách hàng VIP";
        this.chkKhachVIP.UseVisualStyleBackColor = true;
     
        this.label4.AutoSize = true;
        this.label4.Location = new System.Drawing.Point(77, 306);
        this.label4.Name = "label4";
        this.label4.Size = new System.Drawing.Size(60, 13);
        this.label4.TabIndex = 8;
        this.label4.Text = "Tiền phòng";
  
        this.txtTienPhong.Location = new System.Drawing.Point(155, 303);
        this.txtTienPhong.Name = "txtTienPhong";
        this.txtTienPhong.ReadOnly = true;
        this.txtTienPhong.Size = new System.Drawing.Size(117, 20);
        this.txtTienPhong.TabIndex = 9;
        this.txtTienPhong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

        this.label5.AutoSize = true;
        this.label5.Location = new System.Drawing.Point(297, 306);
        this.label5.Name = "label5";
        this.label5.Size = new System.Drawing.Size(65, 13);
        this.label5.TabIndex = 10;
        this.label5.Text = "Tiền dịch vụ";
   
        this.txtTienDichVu.Location = new System.Drawing.Point(368, 303);
        this.txtTienDichVu.Name = "txtTienDichVu";
        this.txtTienDichVu.ReadOnly = true;
        this.txtTienDichVu.Size = new System.Drawing.Size(117, 20);
        this.txtTienDichVu.TabIndex = 11;
        this.txtTienDichVu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
   
        this.label6.AutoSize = true;
        this.label6.Location = new System.Drawing.Point(505, 306);
        this.label6.Name = "label6";
        this.label6.Size = new System.Drawing.Size(48, 13);
        this.label6.TabIndex = 12;
        this.label6.Text = "Giảm giá";

        this.txtGiamGia.Location = new System.Drawing.Point(559, 303);
        this.txtGiamGia.Name = "txtGiamGia";
        this.txtGiamGia.ReadOnly = true;
        this.txtGiamGia.Size = new System.Drawing.Size(117, 20);
        this.txtGiamGia.TabIndex = 13;
        this.txtGiamGia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
  
        this.label7.AutoSize = true;
        this.label7.Location = new System.Drawing.Point(77, 354);
        this.label7.Name = "label7";
        this.label7.Size = new System.Drawing.Size(132, 13);
        this.label7.TabIndex = 14;
        this.label7.Text = "Tổng tiền khách phải trả";

        this.txtTongTien.BackColor = System.Drawing.Color.Yellow;
        this.txtTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.txtTongTien.Location = new System.Drawing.Point(226, 351);
        this.txtTongTien.Name = "txtTongTien";
        this.txtTongTien.ReadOnly = true;
        this.txtTongTien.Size = new System.Drawing.Size(450, 20);
        this.txtTongTien.TabIndex = 15;
        this.txtTongTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
   
        this.label8.AutoSize = true;
        this.label8.Location = new System.Drawing.Point(77, 391);
        this.label8.Name = "label8";
        this.label8.Size = new System.Drawing.Size(123, 13);
        this.label8.TabIndex = 16;
        this.label8.Text = "Phương thức thanh toán";

        this.cmbPhuongThuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cmbPhuongThuc.FormattingEnabled = true;
        this.cmbPhuongThuc.Location = new System.Drawing.Point(226, 388);
        this.cmbPhuongThuc.Name = "cmbPhuongThuc";
        this.cmbPhuongThuc.Size = new System.Drawing.Size(259, 21);
        this.cmbPhuongThuc.TabIndex = 5;
   
        this.btnTinhTien.Location = new System.Drawing.Point(226, 436);
        this.btnTinhTien.Name = "btnTinhTien";
        this.btnTinhTien.Size = new System.Drawing.Size(104, 32);
        this.btnTinhTien.TabIndex = 6;
        this.btnTinhTien.Text = "Tính tiền";
        this.btnTinhTien.UseVisualStyleBackColor = true;
        this.btnTinhTien.Click += new System.EventHandler(this.btnTinhTien_Click);
  
        this.btnThoat.Location = new System.Drawing.Point(381, 436);
        this.btnThoat.Name = "btnThoat";
        this.btnThoat.Size = new System.Drawing.Size(104, 32);
        this.btnThoat.TabIndex = 7;
        this.btnThoat.Text = "Thoát";
        this.btnThoat.UseVisualStyleBackColor = true;
        this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(714, 497);
        this.Controls.Add(this.btnThoat);
        this.Controls.Add(this.btnTinhTien);
        this.Controls.Add(this.cmbPhuongThuc);
        this.Controls.Add(this.label8);
        this.Controls.Add(this.txtTongTien);
        this.Controls.Add(this.label7);
        this.Controls.Add(this.txtGiamGia);
        this.Controls.Add(this.label6);
        this.Controls.Add(this.txtTienDichVu);
        this.Controls.Add(this.label5);
        this.Controls.Add(this.txtTienPhong);
        this.Controls.Add(this.label4);
        this.Controls.Add(this.chkKhachVIP);
        this.Controls.Add(this.txtSoNgay);
        this.Controls.Add(this.label3);
        this.Controls.Add(this.groupBox2);
        this.Controls.Add(this.groupBox1);
        this.Controls.Add(this.txtHoTen);
        this.Controls.Add(this.label2);
        this.Controls.Add(this.label1);
        this.Name = "Form1";
        this.Text = "Câu 3 - Quản lý khách sạn";
        this.Load += new System.EventHandler(this.Form1_Load);
        this.groupBox1.ResumeLayout(false);
        this.groupBox1.PerformLayout();
        this.groupBox2.ResumeLayout(false);
        this.groupBox2.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtHoTen;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.RadioButton rbPhongDoi;
    private System.Windows.Forms.RadioButton rbPhongDon;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.CheckBox chkNuocSuoi;
    private System.Windows.Forms.CheckBox chkThueXeMay;
    private System.Windows.Forms.CheckBox chkBiaTiger;
    private System.Windows.Forms.CheckBox chkGiatUi;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txtSoNgay;
    private System.Windows.Forms.CheckBox chkKhachVIP;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox txtTienPhong;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox txtTienDichVu;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox txtGiamGia;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.TextBox txtTongTien;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.ComboBox cmbPhuongThuc;
    private System.Windows.Forms.Button btnTinhTien;
    private System.Windows.Forms.Button btnThoat;
}