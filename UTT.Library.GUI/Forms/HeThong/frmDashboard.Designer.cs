namespace UTT.Library.GUI.Forms.HeThong
{
    partial class frmDashboard
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTongSach = new System.Windows.Forms.Label();
            this.lblTongSachValue = new System.Windows.Forms.Label();
            this.lblDocGia = new System.Windows.Forms.Label();
            this.lblDocGiaValue = new System.Windows.Forms.Label();
            this.lblDangMuon = new System.Windows.Forms.Label();
            this.lblDangMuonValue = new System.Windows.Forms.Label();
            this.lblQuaHan = new System.Windows.Forms.Label();
            this.lblQuaHanValue = new System.Windows.Forms.Label();
            this.dgvPhieuMuon = new System.Windows.Forms.DataGridView();
            this.lblPhieuMuon = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuMuon)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(168, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Thống kê tổng hợp";
            // 
            // lblTongSach
            // 
            this.lblTongSach.AutoSize = true;
            this.lblTongSach.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.lblTongSach.Location = new System.Drawing.Point(30, 70);
            this.lblTongSach.Name = "lblTongSach";
            this.lblTongSach.Size = new System.Drawing.Size(82, 20);
            this.lblTongSach.TabIndex = 1;
            this.lblTongSach.Text = "Tổng sách:";
            // 
            // lblTongSachValue
            // 
            this.lblTongSachValue.AutoSize = true;
            this.lblTongSachValue.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblTongSachValue.Location = new System.Drawing.Point(150, 70);
            this.lblTongSachValue.Name = "lblTongSachValue";
            this.lblTongSachValue.Size = new System.Drawing.Size(17, 20);
            this.lblTongSachValue.TabIndex = 2;
            this.lblTongSachValue.Text = "0";
            // 
            // lblDocGia
            // 
            this.lblDocGia.AutoSize = true;
            this.lblDocGia.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.lblDocGia.Location = new System.Drawing.Point(250, 70);
            this.lblDocGia.Name = "lblDocGia";
            this.lblDocGia.Size = new System.Drawing.Size(92, 20);
            this.lblDocGia.TabIndex = 3;
            this.lblDocGia.Text = "Tổng độc giả:";
            // 
            // lblDocGiaValue
            // 
            this.lblDocGiaValue.AutoSize = true;
            this.lblDocGiaValue.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblDocGiaValue.Location = new System.Drawing.Point(380, 70);
            this.lblDocGiaValue.Name = "lblDocGiaValue";
            this.lblDocGiaValue.Size = new System.Drawing.Size(17, 20);
            this.lblDocGiaValue.TabIndex = 4;
            this.lblDocGiaValue.Text = "0";
            // 
            // lblDangMuon
            // 
            this.lblDangMuon.AutoSize = true;
            this.lblDangMuon.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.lblDangMuon.Location = new System.Drawing.Point(470, 70);
            this.lblDangMuon.Name = "lblDangMuon";
            this.lblDangMuon.Size = new System.Drawing.Size(92, 20);
            this.lblDangMuon.TabIndex = 5;
            this.lblDangMuon.Text = "Đang mượn:";
            // 
            // lblDangMuonValue
            // 
            this.lblDangMuonValue.AutoSize = true;
            this.lblDangMuonValue.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblDangMuonValue.Location = new System.Drawing.Point(600, 70);
            this.lblDangMuonValue.Name = "lblDangMuonValue";
            this.lblDangMuonValue.Size = new System.Drawing.Size(17, 20);
            this.lblDangMuonValue.TabIndex = 6;
            this.lblDangMuonValue.Text = "0";
            // 
            // lblQuaHan
            // 
            this.lblQuaHan.AutoSize = true;
            this.lblQuaHan.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.lblQuaHan.ForeColor = System.Drawing.Color.Red;
            this.lblQuaHan.Location = new System.Drawing.Point(690, 70);
            this.lblQuaHan.Name = "lblQuaHan";
            this.lblQuaHan.Size = new System.Drawing.Size(67, 20);
            this.lblQuaHan.TabIndex = 7;
            this.lblQuaHan.Text = "Quá hạn:";
            // 
            // lblQuaHanValue
            // 
            this.lblQuaHanValue.AutoSize = true;
            this.lblQuaHanValue.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblQuaHanValue.ForeColor = System.Drawing.Color.Red;
            this.lblQuaHanValue.Location = new System.Drawing.Point(800, 70);
            this.lblQuaHanValue.Name = "lblQuaHanValue";
            this.lblQuaHanValue.Size = new System.Drawing.Size(17, 20);
            this.lblQuaHanValue.TabIndex = 8;
            this.lblQuaHanValue.Text = "0";
            // 
            // lblPhieuMuon
            // 
            this.lblPhieuMuon.AutoSize = true;
            this.lblPhieuMuon.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.lblPhieuMuon.Location = new System.Drawing.Point(30, 120);
            this.lblPhieuMuon.Name = "lblPhieuMuon";
            this.lblPhieuMuon.Size = new System.Drawing.Size(137, 20);
            this.lblPhieuMuon.TabIndex = 9;
            this.lblPhieuMuon.Text = "Phiếu mượn gần đây:";
            // 
            // dgvPhieuMuon
            // 
            this.dgvPhieuMuon.AllowUserToAddRows = false;
            this.dgvPhieuMuon.AllowUserToDeleteRows = false;
            this.dgvPhieuMuon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPhieuMuon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhieuMuon.BackgroundColor = System.Drawing.Color.White;
            this.dgvPhieuMuon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhieuMuon.Location = new System.Drawing.Point(30, 150);
            this.dgvPhieuMuon.Name = "dgvPhieuMuon";
            this.dgvPhieuMuon.ReadOnly = true;
            this.dgvPhieuMuon.RowTemplate.Height = 28;
            this.dgvPhieuMuon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhieuMuon.Size = new System.Drawing.Size(900, 450);
            this.dgvPhieuMuon.TabIndex = 10;
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1175, 650);
            this.Controls.Add(this.dgvPhieuMuon);
            this.Controls.Add(this.lblPhieuMuon);
            this.Controls.Add(this.lblQuaHanValue);
            this.Controls.Add(this.lblQuaHan);
            this.Controls.Add(this.lblDangMuonValue);
            this.Controls.Add(this.lblDangMuon);
            this.Controls.Add(this.lblDocGiaValue);
            this.Controls.Add(this.lblDocGia);
            this.Controls.Add(this.lblTongSachValue);
            this.Controls.Add(this.lblTongSach);
            this.Controls.Add(this.lblTitle);
            this.Name = "frmDashboard";
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.frmDashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuMuon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTongSach;
        private System.Windows.Forms.Label lblTongSachValue;
        private System.Windows.Forms.Label lblDocGia;
        private System.Windows.Forms.Label lblDocGiaValue;
        private System.Windows.Forms.Label lblDangMuon;
        private System.Windows.Forms.Label lblDangMuonValue;
        private System.Windows.Forms.Label lblQuaHan;
        private System.Windows.Forms.Label lblQuaHanValue;
        private System.Windows.Forms.Label lblPhieuMuon;
        private System.Windows.Forms.DataGridView dgvPhieuMuon;
    }
}