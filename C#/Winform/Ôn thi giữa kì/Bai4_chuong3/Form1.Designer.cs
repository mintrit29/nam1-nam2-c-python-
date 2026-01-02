namespace Bai4_chuong3
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
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNhap = new System.Windows.Forms.TextBox();
            this.txtDayso = new System.Windows.Forms.TextBox();
            this.btnNhap = new System.Windows.Forms.Button();
            this.txtTong = new System.Windows.Forms.TextBox();
            this.txtTongle = new System.Windows.Forms.TextBox();
            this.txtTongchan = new System.Windows.Forms.TextBox();
            this.btnTieptuc = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(94, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(329, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập Dãy Số Và Tính Tổng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(80, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nhập số";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(80, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Dãy vừa nhập";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(80, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(202, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tống các phần từ trong dãy";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(80, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tổng chẳn";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(255, 188);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Tống lẻ";
            // 
            // txtNhap
            // 
            this.txtNhap.Location = new System.Drawing.Point(199, 62);
            this.txtNhap.Name = "txtNhap";
            this.txtNhap.Size = new System.Drawing.Size(83, 26);
            this.txtNhap.TabIndex = 6;
            this.txtNhap.TextChanged += new System.EventHandler(this.txtNhap_TextChanged);
            // 
            // txtDayso
            // 
            this.txtDayso.Location = new System.Drawing.Point(199, 101);
            this.txtDayso.Name = "txtDayso";
            this.txtDayso.Size = new System.Drawing.Size(198, 26);
            this.txtDayso.TabIndex = 7;
            // 
            // btnNhap
            // 
            this.btnNhap.Location = new System.Drawing.Point(299, 58);
            this.btnNhap.Name = "btnNhap";
            this.btnNhap.Size = new System.Drawing.Size(98, 35);
            this.btnNhap.TabIndex = 8;
            this.btnNhap.Text = "Nhập";
            this.btnNhap.UseVisualStyleBackColor = true;
            this.btnNhap.Click += new System.EventHandler(this.btnNhap_Click);
            // 
            // txtTong
            // 
            this.txtTong.Location = new System.Drawing.Point(299, 140);
            this.txtTong.Name = "txtTong";
            this.txtTong.Size = new System.Drawing.Size(98, 26);
            this.txtTong.TabIndex = 9;
            // 
            // txtTongle
            // 
            this.txtTongle.Location = new System.Drawing.Point(322, 182);
            this.txtTongle.Name = "txtTongle";
            this.txtTongle.Size = new System.Drawing.Size(75, 26);
            this.txtTongle.TabIndex = 10;
            // 
            // txtTongchan
            // 
            this.txtTongchan.Location = new System.Drawing.Point(170, 182);
            this.txtTongchan.Name = "txtTongchan";
            this.txtTongchan.Size = new System.Drawing.Size(75, 26);
            this.txtTongchan.TabIndex = 12;
            // 
            // btnTieptuc
            // 
            this.btnTieptuc.Location = new System.Drawing.Point(134, 229);
            this.btnTieptuc.Name = "btnTieptuc";
            this.btnTieptuc.Size = new System.Drawing.Size(98, 35);
            this.btnTieptuc.TabIndex = 13;
            this.btnTieptuc.Text = "Tiếp tục";
            this.btnTieptuc.UseVisualStyleBackColor = true;
            this.btnTieptuc.Click += new System.EventHandler(this.btnTieptuc_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(268, 229);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(98, 35);
            this.btnThoat.TabIndex = 14;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 285);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnTieptuc);
            this.Controls.Add(this.txtTongchan);
            this.Controls.Add(this.txtTongle);
            this.Controls.Add(this.txtTong);
            this.Controls.Add(this.btnNhap);
            this.Controls.Add(this.txtDayso);
            this.Controls.Add(this.txtNhap);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNhap;
        private System.Windows.Forms.TextBox txtDayso;
        private System.Windows.Forms.Button btnNhap;
        private System.Windows.Forms.TextBox txtTong;
        private System.Windows.Forms.TextBox txtTongle;
        private System.Windows.Forms.TextBox txtTongchan;
        private System.Windows.Forms.Button btnTieptuc;
        private System.Windows.Forms.Button btnThoat;
    }
}

