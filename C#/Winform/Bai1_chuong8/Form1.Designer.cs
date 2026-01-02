namespace Bai1_chuong8
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
            this.btnHienThiDuLieu = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.listViewLop = new System.Windows.Forms.ListView();
            this.STT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MALOP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TENLOP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MAKHOA = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btnHienThiDuLieu
            // 
            this.btnHienThiDuLieu.Location = new System.Drawing.Point(37, 26);
            this.btnHienThiDuLieu.Name = "btnHienThiDuLieu";
            this.btnHienThiDuLieu.Size = new System.Drawing.Size(141, 36);
            this.btnHienThiDuLieu.TabIndex = 0;
            this.btnHienThiDuLieu.Text = "Hiển thị dữ liệu";
            this.btnHienThiDuLieu.UseVisualStyleBackColor = true;
            this.btnHienThiDuLieu.Click += new System.EventHandler(this.btnHienThiDuLieu_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(592, 381);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(147, 57);
            this.btnThoat.TabIndex = 0;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // listViewLop
            // 
            this.listViewLop.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.STT,
            this.MALOP,
            this.TENLOP,
            this.MAKHOA});
            this.listViewLop.FullRowSelect = true;
            this.listViewLop.GridLines = true;
            this.listViewLop.HideSelection = false;
            this.listViewLop.Location = new System.Drawing.Point(37, 68);
            this.listViewLop.Name = "listViewLop";
            this.listViewLop.Size = new System.Drawing.Size(702, 307);
            this.listViewLop.TabIndex = 2;
            this.listViewLop.UseCompatibleStateImageBehavior = false;
            this.listViewLop.View = System.Windows.Forms.View.Details;
            // 
            // STT
            // 
            this.STT.Text = "STT";
            this.STT.Width = 50;
            // 
            // MALOP
            // 
            this.MALOP.Text = "Mã lớp";
            this.MALOP.Width = 100;
            // 
            // TENLOP
            // 
            this.TENLOP.Text = "Tên lớp";
            this.TENLOP.Width = 250;
            // 
            // MAKHOA
            // 
            this.MAKHOA.Text = "Mã khoa";
            this.MAKHOA.Width = 80;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listViewLop);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnHienThiDuLieu);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnHienThiDuLieu;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.ListView listViewLop;
        private System.Windows.Forms.ColumnHeader STT;
        private System.Windows.Forms.ColumnHeader MALOP;
        private System.Windows.Forms.ColumnHeader TENLOP;
        private System.Windows.Forms.ColumnHeader MAKHOA;
    }
}

