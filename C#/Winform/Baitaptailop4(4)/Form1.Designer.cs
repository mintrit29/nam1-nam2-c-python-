namespace HotelPayment
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.numDays = new System.Windows.Forms.NumericUpDown();
            this.grpRoomType = new System.Windows.Forms.GroupBox();
            this.radTriple = new System.Windows.Forms.RadioButton();
            this.radDouble = new System.Windows.Forms.RadioButton();
            this.radSingle = new System.Windows.Forms.RadioButton();
            this.grpAmenities = new System.Windows.Forms.GroupBox();
            this.chkMayGiat = new System.Windows.Forms.CheckBox();
            this.chkInternet = new System.Windows.Forms.CheckBox();
            this.chkTV = new System.Windows.Forms.CheckBox();
            this.grpServices = new System.Windows.Forms.GroupBox();
            this.chkBreakfast = new System.Windows.Forms.CheckBox();
            this.chkKaraoke = new System.Windows.Forms.CheckBox();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.btnNhapMoi = new System.Windows.Forms.Button();
            this.btnTongKet = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblThanhTien = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblTotalRevenue = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTotalGuests = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numDays)).BeginInit();
            this.grpRoomType.SuspendLayout();
            this.grpAmenities.SuspendLayout();
            this.grpServices.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(56, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(741, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ THANH TOÁN KHÁCH SẠN THANH THANH";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 67);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên khách hàng:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 117);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Địa chỉ:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 166);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Số ngày ở";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(166, 63);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(182, 26);
            this.txtName.TabIndex = 0;
            this.txtName.TextChanged += new System.EventHandler(this.Input_Changed);
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(166, 112);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(120, 26);
            this.txtAddress.TabIndex = 1;
            this.txtAddress.TextChanged += new System.EventHandler(this.Input_Changed);
            // 
            // numDays
            // 
            this.numDays.Location = new System.Drawing.Point(166, 163);
            this.numDays.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numDays.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.numDays.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDays.Name = "numDays";
            this.numDays.Size = new System.Drawing.Size(83, 26);
            this.numDays.TabIndex = 2;
            this.numDays.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDays.ValueChanged += new System.EventHandler(this.Input_Changed);
            // 
            // grpRoomType
            // 
            this.grpRoomType.Controls.Add(this.radTriple);
            this.grpRoomType.Controls.Add(this.radDouble);
            this.grpRoomType.Controls.Add(this.radSingle);
            this.grpRoomType.Location = new System.Drawing.Point(13, 226);
            this.grpRoomType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpRoomType.Name = "grpRoomType";
            this.grpRoomType.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpRoomType.Size = new System.Drawing.Size(168, 169);
            this.grpRoomType.TabIndex = 3;
            this.grpRoomType.TabStop = false;
            this.grpRoomType.Text = "Loại phòng";
            // 
            // radTriple
            // 
            this.radTriple.AutoSize = true;
            this.radTriple.Location = new System.Drawing.Point(28, 106);
            this.radTriple.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radTriple.Name = "radTriple";
            this.radTriple.Size = new System.Drawing.Size(102, 24);
            this.radTriple.TabIndex = 2;
            this.radTriple.Text = "Phòng ba";
            this.radTriple.UseVisualStyleBackColor = true;
            this.radTriple.CheckedChanged += new System.EventHandler(this.Input_Changed);
            // 
            // radDouble
            // 
            this.radDouble.AutoSize = true;
            this.radDouble.Location = new System.Drawing.Point(28, 72);
            this.radDouble.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radDouble.Name = "radDouble";
            this.radDouble.Size = new System.Drawing.Size(105, 24);
            this.radDouble.TabIndex = 1;
            this.radDouble.Text = "Phòng đôi";
            this.radDouble.UseVisualStyleBackColor = true;
            this.radDouble.CheckedChanged += new System.EventHandler(this.Input_Changed);
            // 
            // radSingle
            // 
            this.radSingle.AutoSize = true;
            this.radSingle.Checked = true;
            this.radSingle.Location = new System.Drawing.Point(28, 38);
            this.radSingle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radSingle.Name = "radSingle";
            this.radSingle.Size = new System.Drawing.Size(111, 24);
            this.radSingle.TabIndex = 0;
            this.radSingle.TabStop = true;
            this.radSingle.Text = "Phòng đơn";
            this.radSingle.UseVisualStyleBackColor = true;
            this.radSingle.CheckedChanged += new System.EventHandler(this.Input_Changed);
            // 
            // grpAmenities
            // 
            this.grpAmenities.Controls.Add(this.chkMayGiat);
            this.grpAmenities.Controls.Add(this.chkInternet);
            this.grpAmenities.Controls.Add(this.chkTV);
            this.grpAmenities.Location = new System.Drawing.Point(189, 226);
            this.grpAmenities.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpAmenities.Name = "grpAmenities";
            this.grpAmenities.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpAmenities.Size = new System.Drawing.Size(142, 169);
            this.grpAmenities.TabIndex = 4;
            this.grpAmenities.TabStop = false;
            this.grpAmenities.Text = "Tiện nghi";
            this.grpAmenities.Enter += new System.EventHandler(this.grpAmenities_Enter);
            // 
            // chkMayGiat
            // 
            this.chkMayGiat.AutoSize = true;
            this.chkMayGiat.Location = new System.Drawing.Point(28, 101);
            this.chkMayGiat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkMayGiat.Name = "chkMayGiat";
            this.chkMayGiat.Size = new System.Drawing.Size(94, 24);
            this.chkMayGiat.TabIndex = 2;
            this.chkMayGiat.Text = "Máy giặt";
            this.chkMayGiat.UseVisualStyleBackColor = true;
            // 
            // chkInternet
            // 
            this.chkInternet.AutoSize = true;
            this.chkInternet.Location = new System.Drawing.Point(28, 67);
            this.chkInternet.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkInternet.Name = "chkInternet";
            this.chkInternet.Size = new System.Drawing.Size(91, 24);
            this.chkInternet.TabIndex = 1;
            this.chkInternet.Text = "Internet";
            this.chkInternet.UseVisualStyleBackColor = true;
            // 
            // chkTV
            // 
            this.chkTV.AutoSize = true;
            this.chkTV.Location = new System.Drawing.Point(28, 33);
            this.chkTV.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkTV.Name = "chkTV";
            this.chkTV.Size = new System.Drawing.Size(55, 24);
            this.chkTV.TabIndex = 0;
            this.chkTV.Text = "TV";
            this.chkTV.UseVisualStyleBackColor = true;
            this.chkTV.CheckedChanged += new System.EventHandler(this.chkTV_CheckedChanged);
            // 
            // grpServices
            // 
            this.grpServices.Controls.Add(this.chkBreakfast);
            this.grpServices.Controls.Add(this.chkKaraoke);
            this.grpServices.Location = new System.Drawing.Point(339, 226);
            this.grpServices.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpServices.Name = "grpServices";
            this.grpServices.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpServices.Size = new System.Drawing.Size(140, 169);
            this.grpServices.TabIndex = 5;
            this.grpServices.TabStop = false;
            this.grpServices.Text = "Dịch vụ";
            // 
            // chkBreakfast
            // 
            this.chkBreakfast.AutoSize = true;
            this.chkBreakfast.Location = new System.Drawing.Point(13, 72);
            this.chkBreakfast.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkBreakfast.Name = "chkBreakfast";
            this.chkBreakfast.Size = new System.Drawing.Size(94, 24);
            this.chkBreakfast.TabIndex = 1;
            this.chkBreakfast.Text = "Ăn sáng";
            this.chkBreakfast.UseVisualStyleBackColor = true;
            this.chkBreakfast.CheckedChanged += new System.EventHandler(this.chkBreakfast_CheckedChanged);
            // 
            // chkKaraoke
            // 
            this.chkKaraoke.AutoSize = true;
            this.chkKaraoke.Location = new System.Drawing.Point(13, 33);
            this.chkKaraoke.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkKaraoke.Name = "chkKaraoke";
            this.chkKaraoke.Size = new System.Drawing.Size(94, 24);
            this.chkKaraoke.TabIndex = 0;
            this.chkKaraoke.Text = "Karaoke";
            this.chkKaraoke.UseVisualStyleBackColor = true;
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Location = new System.Drawing.Point(492, 46);
            this.btnThanhToan.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(135, 54);
            this.btnThanhToan.TabIndex = 6;
            this.btnThanhToan.Text = "Thanh Toán";
            this.btnThanhToan.UseVisualStyleBackColor = true;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // btnNhapMoi
            // 
            this.btnNhapMoi.Location = new System.Drawing.Point(643, 46);
            this.btnNhapMoi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnNhapMoi.Name = "btnNhapMoi";
            this.btnNhapMoi.Size = new System.Drawing.Size(135, 54);
            this.btnNhapMoi.TabIndex = 7;
            this.btnNhapMoi.Text = "Nhập Mới";
            this.btnNhapMoi.UseVisualStyleBackColor = true;
            this.btnNhapMoi.Click += new System.EventHandler(this.btnNhapMoi_Click);
            // 
            // btnTongKet
            // 
            this.btnTongKet.Location = new System.Drawing.Point(492, 150);
            this.btnTongKet.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTongKet.Name = "btnTongKet";
            this.btnTongKet.Size = new System.Drawing.Size(135, 54);
            this.btnTongKet.TabIndex = 8;
            this.btnTongKet.Text = "Tổng Kết";
            this.btnTongKet.UseVisualStyleBackColor = true;
            this.btnTongKet.Click += new System.EventHandler(this.btnTongKet_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(492, 418);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(135, 54);
            this.btnThoat.TabIndex = 9;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(488, 112);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Thành Tiền:";
            // 
            // lblThanhTien
            // 
            this.lblThanhTien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblThanhTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThanhTien.ForeColor = System.Drawing.Color.Red;
            this.lblThanhTien.Location = new System.Drawing.Point(588, 105);
            this.lblThanhTien.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblThanhTien.Name = "lblThanhTien";
            this.lblThanhTien.Size = new System.Drawing.Size(167, 36);
            this.lblThanhTien.TabIndex = 11;
            this.lblThanhTien.Text = "0 đ";
            this.lblThanhTien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblTotalRevenue);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.lblTotalGuests);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Location = new System.Drawing.Point(492, 214);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox4.Size = new System.Drawing.Size(349, 194);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Thống kê trong ngày";
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // lblTotalRevenue
            // 
            this.lblTotalRevenue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalRevenue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRevenue.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblTotalRevenue.Location = new System.Drawing.Point(110, 105);
            this.lblTotalRevenue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalRevenue.Name = "lblTotalRevenue";
            this.lblTotalRevenue.Size = new System.Drawing.Size(215, 34);
            this.lblTotalRevenue.TabIndex = 3;
            this.lblTotalRevenue.Text = "0 đ";
            this.lblTotalRevenue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 112);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 20);
            this.label8.TabIndex = 2;
            this.label8.Text = "Tổng tiền:";
            // 
            // lblTotalGuests
            // 
            this.lblTotalGuests.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalGuests.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalGuests.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblTotalGuests.Location = new System.Drawing.Point(153, 51);
            this.lblTotalGuests.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalGuests.Name = "lblTotalGuests";
            this.lblTotalGuests.Size = new System.Drawing.Size(149, 34);
            this.lblTotalGuests.TabIndex = 1;
            this.lblTotalGuests.Text = "0";
            this.lblTotalGuests.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 58);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Tổng số khách:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 483);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.lblThanhTien);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.grpServices);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnTongKet);
            this.Controls.Add(this.btnNhapMoi);
            this.Controls.Add(this.btnThanhToan);
            this.Controls.Add(this.grpAmenities);
            this.Controls.Add(this.grpRoomType);
            this.Controls.Add(this.numDays);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thanh Toán Tiền Phòng - Khách Sạn Thanh Thanh";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numDays)).EndInit();
            this.grpRoomType.ResumeLayout(false);
            this.grpRoomType.PerformLayout();
            this.grpAmenities.ResumeLayout(false);
            this.grpAmenities.PerformLayout();
            this.grpServices.ResumeLayout(false);
            this.grpServices.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.NumericUpDown numDays;
        private System.Windows.Forms.GroupBox grpRoomType;
        private System.Windows.Forms.RadioButton radTriple;
        private System.Windows.Forms.RadioButton radDouble;
        private System.Windows.Forms.RadioButton radSingle;
        private System.Windows.Forms.GroupBox grpAmenities;
        private System.Windows.Forms.CheckBox chkMayGiat;
        private System.Windows.Forms.CheckBox chkInternet;
        private System.Windows.Forms.CheckBox chkTV;
        private System.Windows.Forms.GroupBox grpServices;
        private System.Windows.Forms.CheckBox chkBreakfast;
        private System.Windows.Forms.CheckBox chkKaraoke;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Button btnNhapMoi;
        private System.Windows.Forms.Button btnTongKet;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblThanhTien;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblTotalRevenue;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTotalGuests;
        private System.Windows.Forms.Label label6;
    }
}