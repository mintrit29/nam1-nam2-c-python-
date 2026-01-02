namespace ArrayCalculatorApp // Use your actual project namespace
{
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelNhapSo = new System.Windows.Forms.Label();
            this.txtInputNumber = new System.Windows.Forms.TextBox();
            this.btnNhapSo = new System.Windows.Forms.Button();
            this.labelDayVuaNhap = new System.Windows.Forms.Label();
            this.txtDisplayArray = new System.Windows.Forms.TextBox();
            this.btnSapXepGiam = new System.Windows.Forms.Button();
            this.labelTongMang = new System.Windows.Forms.Label();
            this.txtTongMang = new System.Windows.Forms.TextBox();
            this.labelSoChan = new System.Windows.Forms.Label();
            this.txtSoChan = new System.Windows.Forms.TextBox();
            this.btnThucHien = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.labelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.Blue;
            this.labelTitle.Location = new System.Drawing.Point(12, 20);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(660, 29);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "TÍNH TOÁN TRÊN MẢNG SỐ NGUYÊN";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.labelNhapSo.AutoSize = true;
            this.labelNhapSo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNhapSo.Location = new System.Drawing.Point(40, 80);
            this.labelNhapSo.Name = "labelNhapSo";
            this.labelNhapSo.Size = new System.Drawing.Size(65, 18);
            this.labelNhapSo.TabIndex = 1;
            this.labelNhapSo.Text = "Nhập số";

            this.txtInputNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInputNumber.Location = new System.Drawing.Point(150, 77);
            this.txtInputNumber.Name = "txtInputNumber";
            this.txtInputNumber.Size = new System.Drawing.Size(250, 24);
            this.txtInputNumber.TabIndex = 2;
            this.txtInputNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInputNumber_KeyDown);
  
            this.btnNhapSo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhapSo.Location = new System.Drawing.Point(420, 74);
            this.btnNhapSo.Name = "btnNhapSo";
            this.btnNhapSo.Size = new System.Drawing.Size(100, 30);
            this.btnNhapSo.TabIndex = 3;
            this.btnNhapSo.Text = "Nhập số";
            this.btnNhapSo.UseVisualStyleBackColor = true;
            this.btnNhapSo.Click += new System.EventHandler(this.btnNhapSo_Click);

            this.labelDayVuaNhap.AutoSize = true;
            this.labelDayVuaNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDayVuaNhap.Location = new System.Drawing.Point(40, 120);
            this.labelDayVuaNhap.Name = "labelDayVuaNhap";
            this.labelDayVuaNhap.Size = new System.Drawing.Size(98, 18);
            this.labelDayVuaNhap.TabIndex = 4;
            this.labelDayVuaNhap.Text = "Dãy vừa nhập";

            this.txtDisplayArray.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDisplayArray.Location = new System.Drawing.Point(150, 117);
            this.txtDisplayArray.Name = "txtDisplayArray";
            this.txtDisplayArray.ReadOnly = true;
            this.txtDisplayArray.Size = new System.Drawing.Size(370, 24);
            this.txtDisplayArray.TabIndex = 5;
     
            this.btnSapXepGiam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSapXepGiam.Location = new System.Drawing.Point(540, 114);
            this.btnSapXepGiam.Name = "btnSapXepGiam";
            this.btnSapXepGiam.Size = new System.Drawing.Size(130, 30);
            this.btnSapXepGiam.TabIndex = 6;
            this.btnSapXepGiam.Text = "Sắp xếp giảm";
            this.btnSapXepGiam.UseVisualStyleBackColor = true;
            this.btnSapXepGiam.Click += new System.EventHandler(this.btnSapXepGiam_Click);
   
            this.labelTongMang.AutoSize = true;
            this.labelTongMang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTongMang.Location = new System.Drawing.Point(280, 170);
            this.labelTongMang.Name = "labelTongMang";
            this.labelTongMang.Size = new System.Drawing.Size(83, 18);
            this.labelTongMang.TabIndex = 7;
            this.labelTongMang.Text = "Tổng mảng";
        
            this.txtTongMang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongMang.Location = new System.Drawing.Point(420, 167);
            this.txtTongMang.Name = "txtTongMang";
            this.txtTongMang.ReadOnly = true;
            this.txtTongMang.Size = new System.Drawing.Size(150, 24);
            this.txtTongMang.TabIndex = 8;
      
            this.labelSoChan.AutoSize = true;
            this.labelSoChan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSoChan.Location = new System.Drawing.Point(280, 210);
            this.labelSoChan.Name = "labelSoChan";
            this.labelSoChan.Size = new System.Drawing.Size(117, 18);
            this.labelSoChan.TabIndex = 9;
            this.labelSoChan.Text = "Số phần tử chẵn";
       
            this.txtSoChan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoChan.Location = new System.Drawing.Point(420, 207);
            this.txtSoChan.Name = "txtSoChan";
            this.txtSoChan.ReadOnly = true;
            this.txtSoChan.Size = new System.Drawing.Size(150, 24);
            this.txtSoChan.TabIndex = 10;
      
            this.btnThucHien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThucHien.Location = new System.Drawing.Point(180, 260);
            this.btnThucHien.Name = "btnThucHien";
            this.btnThucHien.Size = new System.Drawing.Size(120, 40);
            this.btnThucHien.TabIndex = 11;
            this.btnThucHien.Text = "Thực hiện";
            this.btnThucHien.UseVisualStyleBackColor = true;
            this.btnThucHien.Click += new System.EventHandler(this.btnThucHien_Click);

            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(380, 260);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(120, 40);
            this.btnThoat.TabIndex = 12;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
     
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 321); 
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnThucHien);
            this.Controls.Add(this.txtSoChan);
            this.Controls.Add(this.labelSoChan);
            this.Controls.Add(this.txtTongMang);
            this.Controls.Add(this.labelTongMang);
            this.Controls.Add(this.btnSapXepGiam);
            this.Controls.Add(this.txtDisplayArray);
            this.Controls.Add(this.labelDayVuaNhap);
            this.Controls.Add(this.btnNhapSo);
            this.Controls.Add(this.txtInputNumber);
            this.Controls.Add(this.labelNhapSo);
            this.Controls.Add(this.labelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle; 
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen; 
            this.Text = "Câu 2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelNhapSo;
        private System.Windows.Forms.TextBox txtInputNumber;
        private System.Windows.Forms.Button btnNhapSo;
        private System.Windows.Forms.Label labelDayVuaNhap;
        private System.Windows.Forms.TextBox txtDisplayArray;
        private System.Windows.Forms.Button btnSapXepGiam;
        private System.Windows.Forms.Label labelTongMang;
        private System.Windows.Forms.TextBox txtTongMang;
        private System.Windows.Forms.Label labelSoChan;
        private System.Windows.Forms.TextBox txtSoChan;
        private System.Windows.Forms.Button btnThucHien;
        private System.Windows.Forms.Button btnThoat;
    }
}