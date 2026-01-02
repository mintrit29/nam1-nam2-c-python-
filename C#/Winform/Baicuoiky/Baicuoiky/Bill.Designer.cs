namespace Baicuoiky
{
    partial class Bill
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bill));
            this.cuiCalendarDatePicker1 = new CuoreUI.Controls.cuiCalendarDatePicker();
            this.btnPrintBill = new CuoreUI.Controls.cuiButton();
            this.cuiDataGridView1 = new CuoreUI.Controls.cuiDataGridView();
            this.pbBack = new System.Windows.Forms.PictureBox();
            this.btnRefresh = new CuoreUI.Controls.cuiButton();
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).BeginInit();
            this.SuspendLayout();
            // 
            // cuiCalendarDatePicker1
            // 
            this.cuiCalendarDatePicker1.EnableThemeChangeButton = true;
            this.cuiCalendarDatePicker1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuiCalendarDatePicker1.ForeColor = System.Drawing.Color.Gray;
            this.cuiCalendarDatePicker1.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.cuiCalendarDatePicker1.HoverOutline = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.cuiCalendarDatePicker1.Icon = null;
            this.cuiCalendarDatePicker1.IconTint = System.Drawing.Color.Gray;
            this.cuiCalendarDatePicker1.Location = new System.Drawing.Point(268, 12);
            this.cuiCalendarDatePicker1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cuiCalendarDatePicker1.Name = "cuiCalendarDatePicker1";
            this.cuiCalendarDatePicker1.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.cuiCalendarDatePicker1.NormalOutline = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.cuiCalendarDatePicker1.OutlineThickness = 1.5F;
            this.cuiCalendarDatePicker1.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.cuiCalendarDatePicker1.PressedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.cuiCalendarDatePicker1.Rounding = 8;
            this.cuiCalendarDatePicker1.ShowIcon = true;
            this.cuiCalendarDatePicker1.Size = new System.Drawing.Size(360, 45);
            this.cuiCalendarDatePicker1.TabIndex = 0;
            this.cuiCalendarDatePicker1.Theme = CuoreUI.Controls.Forms.DatePicker.Themes.Light;
            this.cuiCalendarDatePicker1.Value = new System.DateTime(2025, 4, 26, 0, 0, 0, 0);
            // 
            // btnPrintBill
            // 
            this.btnPrintBill.BackColor = System.Drawing.Color.Transparent;
            this.btnPrintBill.CheckButton = false;
            this.btnPrintBill.Checked = false;
            this.btnPrintBill.CheckedBackground = System.Drawing.Color.DarkKhaki;
            this.btnPrintBill.CheckedForeColor = System.Drawing.Color.White;
            this.btnPrintBill.CheckedImageTint = System.Drawing.Color.White;
            this.btnPrintBill.CheckedOutline = System.Drawing.Color.DarkKhaki;
            this.btnPrintBill.Content = "Print bill";
            this.btnPrintBill.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrintBill.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPrintBill.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintBill.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnPrintBill.HoverBackground = System.Drawing.Color.Cornsilk;
            this.btnPrintBill.HoveredImageTint = System.Drawing.Color.MidnightBlue;
            this.btnPrintBill.HoverForeColor = System.Drawing.Color.Black;
            this.btnPrintBill.HoverOutline = System.Drawing.Color.Cornsilk;
            this.btnPrintBill.Image = null;
            this.btnPrintBill.ImageAutoCenter = true;
            this.btnPrintBill.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnPrintBill.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnPrintBill.Location = new System.Drawing.Point(670, 12);
            this.btnPrintBill.Name = "btnPrintBill";
            this.btnPrintBill.NormalBackground = System.Drawing.Color.Cornsilk;
            this.btnPrintBill.NormalForeColor = System.Drawing.Color.MidnightBlue;
            this.btnPrintBill.NormalImageTint = System.Drawing.Color.White;
            this.btnPrintBill.NormalOutline = System.Drawing.Color.Black;
            this.btnPrintBill.OutlineThickness = 1F;
            this.btnPrintBill.PressedBackground = System.Drawing.Color.DarkKhaki;
            this.btnPrintBill.PressedForeColor = System.Drawing.Color.White;
            this.btnPrintBill.PressedImageTint = System.Drawing.Color.White;
            this.btnPrintBill.PressedOutline = System.Drawing.Color.DarkKhaki;
            this.btnPrintBill.Rounding = new System.Windows.Forms.Padding(8);
            this.btnPrintBill.Size = new System.Drawing.Size(144, 45);
            this.btnPrintBill.TabIndex = 5;
            this.btnPrintBill.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnPrintBill.TextOffset = new System.Drawing.Point(0, 0);
            // 
            // cuiDataGridView1
            // 
            this.cuiDataGridView1.AutoScroll = true;
            this.cuiDataGridView1.Cell = System.Drawing.Color.White;
            this.cuiDataGridView1.Cell2 = System.Drawing.Color.DarkKhaki;
            this.cuiDataGridView1.CellBorder = System.Drawing.Color.Black;
            this.cuiDataGridView1.CellHover = System.Drawing.Color.Silver;
            this.cuiDataGridView1.CellSelect = System.Drawing.Color.OliveDrab;
            this.cuiDataGridView1.DataSource = null;
            this.cuiDataGridView1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuiDataGridView1.HeaderColor = System.Drawing.Color.DarkOliveGreen;
            this.cuiDataGridView1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.cuiDataGridView1.Location = new System.Drawing.Point(24, 90);
            this.cuiDataGridView1.Name = "cuiDataGridView1";
            this.cuiDataGridView1.Rounding = 8;
            this.cuiDataGridView1.Size = new System.Drawing.Size(1217, 588);
            this.cuiDataGridView1.TabIndex = 8;
            this.cuiDataGridView1.Text = "cuiDataGridView1";
            // 
            // pbBack
            // 
            this.pbBack.BackColor = System.Drawing.Color.Transparent;
            this.pbBack.ErrorImage = null;
            this.pbBack.Image = ((System.Drawing.Image)(resources.GetObject("pbBack.Image")));
            this.pbBack.InitialImage = null;
            this.pbBack.Location = new System.Drawing.Point(1173, 12);
            this.pbBack.Name = "pbBack";
            this.pbBack.Size = new System.Drawing.Size(78, 59);
            this.pbBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBack.TabIndex = 18;
            this.pbBack.TabStop = false;
            this.pbBack.Click += new System.EventHandler(this.pbBack_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Transparent;
            this.btnRefresh.CheckButton = false;
            this.btnRefresh.Checked = false;
            this.btnRefresh.CheckedBackground = System.Drawing.Color.DarkKhaki;
            this.btnRefresh.CheckedForeColor = System.Drawing.Color.White;
            this.btnRefresh.CheckedImageTint = System.Drawing.Color.White;
            this.btnRefresh.CheckedOutline = System.Drawing.Color.DarkKhaki;
            this.btnRefresh.Content = "Refresh";
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnRefresh.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnRefresh.HoverBackground = System.Drawing.Color.Cornsilk;
            this.btnRefresh.HoveredImageTint = System.Drawing.Color.MidnightBlue;
            this.btnRefresh.HoverForeColor = System.Drawing.Color.Black;
            this.btnRefresh.HoverOutline = System.Drawing.Color.Cornsilk;
            this.btnRefresh.Image = null;
            this.btnRefresh.ImageAutoCenter = true;
            this.btnRefresh.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnRefresh.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnRefresh.Location = new System.Drawing.Point(841, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.NormalBackground = System.Drawing.Color.Cornsilk;
            this.btnRefresh.NormalForeColor = System.Drawing.Color.MidnightBlue;
            this.btnRefresh.NormalImageTint = System.Drawing.Color.White;
            this.btnRefresh.NormalOutline = System.Drawing.Color.Black;
            this.btnRefresh.OutlineThickness = 1F;
            this.btnRefresh.PressedBackground = System.Drawing.Color.DarkKhaki;
            this.btnRefresh.PressedForeColor = System.Drawing.Color.White;
            this.btnRefresh.PressedImageTint = System.Drawing.Color.White;
            this.btnRefresh.PressedOutline = System.Drawing.Color.DarkKhaki;
            this.btnRefresh.Rounding = new System.Windows.Forms.Padding(8);
            this.btnRefresh.Size = new System.Drawing.Size(144, 45);
            this.btnRefresh.TabIndex = 19;
            this.btnRefresh.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnRefresh.TextOffset = new System.Drawing.Point(0, 0);
            // 
            // Bill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1267, 703);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.pbBack);
            this.Controls.Add(this.cuiDataGridView1);
            this.Controls.Add(this.btnPrintBill);
            this.Controls.Add(this.cuiCalendarDatePicker1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Bill";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giao diện quản lý hóa đơn";
            this.Load += new System.EventHandler(this.Bill_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CuoreUI.Controls.cuiCalendarDatePicker cuiCalendarDatePicker1;
        private CuoreUI.Controls.cuiButton btnPrintBill;
        private CuoreUI.Controls.cuiDataGridView cuiDataGridView1;
        private System.Windows.Forms.PictureBox pbBack;
        private CuoreUI.Controls.cuiButton btnRefresh;
    }
}