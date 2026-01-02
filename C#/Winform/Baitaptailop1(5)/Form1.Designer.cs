namespace Baitaptailop1_5_
{
    partial class frmListBox
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
            this.lst_Trai = new System.Windows.Forms.ListBox();
            this.lst_Phai = new System.Windows.Forms.ListBox();
            this.btnQuaPhai = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lst_Trai
            // 
            this.lst_Trai.FormattingEnabled = true;
            this.lst_Trai.ItemHeight = 27;
            this.lst_Trai.Items.AddRange(new object[] {
            "Cốc",
            "Ổi",
            "Xoài",
            "Me",
            "Bưởi",
            "Cam"});
            this.lst_Trai.Location = new System.Drawing.Point(37, 22);
            this.lst_Trai.Name = "lst_Trai";
            this.lst_Trai.Size = new System.Drawing.Size(357, 409);
            this.lst_Trai.TabIndex = 0;
            // 
            // lst_Phai
            // 
            this.lst_Phai.FormattingEnabled = true;
            this.lst_Phai.ItemHeight = 27;
            this.lst_Phai.Location = new System.Drawing.Point(487, 22);
            this.lst_Phai.Name = "lst_Phai";
            this.lst_Phai.Size = new System.Drawing.Size(357, 409);
            this.lst_Phai.TabIndex = 2;
            // 
            // btnQuaPhai
            // 
            this.btnQuaPhai.Location = new System.Drawing.Point(400, 63);
            this.btnQuaPhai.Name = "btnQuaPhai";
            this.btnQuaPhai.Size = new System.Drawing.Size(81, 69);
            this.btnQuaPhai.TabIndex = 3;
            this.btnQuaPhai.Text = ">";
            this.btnQuaPhai.UseVisualStyleBackColor = true;
            this.btnQuaPhai.Click += new System.EventHandler(this.btnQuaPhai_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(400, 151);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 69);
            this.button1.TabIndex = 4;
            this.button1.Text = ">>";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(400, 240);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(81, 69);
            this.button2.TabIndex = 5;
            this.button2.Text = "<";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(400, 328);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(81, 69);
            this.button3.TabIndex = 6;
            this.button3.Text = "<<";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // frmListBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 608);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnQuaPhai);
            this.Controls.Add(this.lst_Phai);
            this.Controls.Add(this.lst_Trai);
            this.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmListBox";
            this.Text = "Sử dụng Listbox";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmListBox_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lst_Trai;
        private System.Windows.Forms.ListBox lst_Phai;
        private System.Windows.Forms.Button btnQuaPhai;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

