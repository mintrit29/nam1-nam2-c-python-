namespace Bai3_chuong3
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.lblA = new System.Windows.Forms.Label();
            this.lblB = new System.Windows.Forms.Label();
            this.lblUcln = new System.Windows.Forms.Label();
            this.lblBcnn = new System.Windows.Forms.Label();
            this.txtBcnn = new System.Windows.Forms.TextBox();
            this.txtA = new System.Windows.Forms.TextBox();
            this.txtUcln = new System.Windows.Forms.TextBox();
            this.txtB = new System.Windows.Forms.TextBox();
            this.btnThuchien = new System.Windows.Forms.Button();
            this.btnTieptuc = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(63, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(422, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "ƯỚC SỐ CHUNG - BỘI SỐ CHUNG";
            // 
            // lblA
            // 
            this.lblA.AutoSize = true;
            this.lblA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblA.Location = new System.Drawing.Point(127, 82);
            this.lblA.Name = "lblA";
            this.lblA.Size = new System.Drawing.Size(85, 20);
            this.lblA.TabIndex = 1;
            this.lblA.Text = "Nhập số a";
            // 
            // lblB
            // 
            this.lblB.AutoSize = true;
            this.lblB.Location = new System.Drawing.Point(127, 130);
            this.lblB.Name = "lblB";
            this.lblB.Size = new System.Drawing.Size(81, 20);
            this.lblB.TabIndex = 2;
            this.lblB.Text = "Nhập số b";
            // 
            // lblUcln
            // 
            this.lblUcln.AutoSize = true;
            this.lblUcln.Location = new System.Drawing.Point(127, 177);
            this.lblUcln.Name = "lblUcln";
            this.lblUcln.Size = new System.Drawing.Size(147, 20);
            this.lblUcln.TabIndex = 3;
            this.lblUcln.Text = "Ước chung lớn nhất";
            // 
            // lblBcnn
            // 
            this.lblBcnn.AutoSize = true;
            this.lblBcnn.Location = new System.Drawing.Point(127, 223);
            this.lblBcnn.Name = "lblBcnn";
            this.lblBcnn.Size = new System.Drawing.Size(147, 20);
            this.lblBcnn.TabIndex = 4;
            this.lblBcnn.Text = "Bội chung nhỏ nhất";
            // 
            // txtBcnn
            // 
            this.txtBcnn.Location = new System.Drawing.Point(293, 220);
            this.txtBcnn.Name = "txtBcnn";
            this.txtBcnn.ReadOnly = true;
            this.txtBcnn.Size = new System.Drawing.Size(121, 26);
            this.txtBcnn.TabIndex = 5;
            // 
            // txtA
            // 
            this.txtA.Location = new System.Drawing.Point(234, 79);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(180, 26);
            this.txtA.TabIndex = 6;
            this.txtA.TextChanged += new System.EventHandler(this.txtA_TextChanged);
            // 
            // txtUcln
            // 
            this.txtUcln.Location = new System.Drawing.Point(293, 174);
            this.txtUcln.Name = "txtUcln";
            this.txtUcln.ReadOnly = true;
            this.txtUcln.Size = new System.Drawing.Size(121, 26);
            this.txtUcln.TabIndex = 7;
            // 
            // txtB
            // 
            this.txtB.Location = new System.Drawing.Point(234, 127);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(180, 26);
            this.txtB.TabIndex = 8;
            this.txtB.TextChanged += new System.EventHandler(this.txtB_TextChanged);
            // 
            // btnThuchien
            // 
            this.btnThuchien.Location = new System.Drawing.Point(112, 272);
            this.btnThuchien.Name = "btnThuchien";
            this.btnThuchien.Size = new System.Drawing.Size(96, 32);
            this.btnThuchien.TabIndex = 9;
            this.btnThuchien.Text = "Thực hiện";
            this.btnThuchien.UseVisualStyleBackColor = true;
            this.btnThuchien.Click += new System.EventHandler(this.btnThuchien_Click);
            // 
            // btnTieptuc
            // 
            this.btnTieptuc.Location = new System.Drawing.Point(234, 272);
            this.btnTieptuc.Name = "btnTieptuc";
            this.btnTieptuc.Size = new System.Drawing.Size(96, 32);
            this.btnTieptuc.TabIndex = 10;
            this.btnTieptuc.Text = "Tiếp tục";
            this.btnTieptuc.UseVisualStyleBackColor = true;
            this.btnTieptuc.Click += new System.EventHandler(this.btnTieptuc_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(354, 272);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(96, 32);
            this.btnThoat.TabIndex = 11;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 322);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnTieptuc);
            this.Controls.Add(this.btnThuchien);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.txtUcln);
            this.Controls.Add(this.txtA);
            this.Controls.Add(this.txtBcnn);
            this.Controls.Add(this.lblBcnn);
            this.Controls.Add(this.lblUcln);
            this.Controls.Add(this.lblB);
            this.Controls.Add(this.lblA);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblA;
        private System.Windows.Forms.Label lblB;
        private System.Windows.Forms.Label lblUcln;
        private System.Windows.Forms.Label lblBcnn;
        private System.Windows.Forms.TextBox txtBcnn;
        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.TextBox txtUcln;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.Button btnThuchien;
        private System.Windows.Forms.Button btnTieptuc;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}

