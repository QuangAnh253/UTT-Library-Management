namespace UTT.Library.GUI.Forms.NghiepVu
{
    partial class frmQuanLyDatTruoc
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
            this.panelLeft = new System.Windows.Forms.Panel();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.dtpNgayHetHan = new System.Windows.Forms.DateTimePicker();
            this.lblNgayHetHan = new System.Windows.Forms.Label();
            this.cboSach = new System.Windows.Forms.ComboBox();
            this.lblSach = new System.Windows.Forms.Label();
            this.cboSinhVien = new System.Windows.Forms.ComboBox();
            this.lblSinhVien = new System.Windows.Forms.Label();
            this.txtMaPhieu = new System.Windows.Forms.TextBox();
            this.lblMaPhieu = new System.Windows.Forms.Label();
            this.panelRight = new System.Windows.Forms.Panel();
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblHeadTitle = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.panelLeft.SuspendLayout();
            this.panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelLeft.BackColor = System.Drawing.Color.White;
            this.panelLeft.Controls.Add(this.btnLamMoi);
            this.panelLeft.Controls.Add(this.btnXoa);
            this.panelLeft.Controls.Add(this.btnCapNhat);
            this.panelLeft.Controls.Add(this.btnThem);
            this.panelLeft.Controls.Add(this.cboTrangThai);
            this.panelLeft.Controls.Add(this.lblTrangThai);
            this.panelLeft.Controls.Add(this.dtpNgayHetHan);
            this.panelLeft.Controls.Add(this.lblNgayHetHan);
            this.panelLeft.Controls.Add(this.cboSach);
            this.panelLeft.Controls.Add(this.lblSach);
            this.panelLeft.Controls.Add(this.cboSinhVien);
            this.panelLeft.Controls.Add(this.lblSinhVien);
            this.panelLeft.Controls.Add(this.txtMaPhieu);
            this.panelLeft.Controls.Add(this.lblMaPhieu);
            this.panelLeft.ForeColor = System.Drawing.Color.Black;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(600, 761);
            this.panelLeft.TabIndex = 0;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(124)))), ((int)(((byte)(191)))));
            this.btnLamMoi.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(378, 538);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(85, 32);
            this.btnLamMoi.TabIndex = 13;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnXoa.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(266, 538);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 32);
            this.btnXoa.TabIndex = 12;
            this.btnXoa.Text = "Hủy";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(124)))), ((int)(((byte)(191)))));
            this.btnCapNhat.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnCapNhat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapNhat.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnCapNhat.ForeColor = System.Drawing.Color.White;
            this.btnCapNhat.Location = new System.Drawing.Point(148, 538);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(85, 32);
            this.btnCapNhat.TabIndex = 11;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.UseVisualStyleBackColor = false;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(148)))), ((int)(((byte)(33)))));
            this.btnThem.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(30, 538);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(85, 32);
            this.btnThem.TabIndex = 10;
            this.btnThem.Text = "Đặt trước";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThai.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.cboTrangThai.FormattingEnabled = true;
            this.cboTrangThai.Items.AddRange(new object[] { "Đang chờ", "Đã có sách", "Đã hủy" });
            this.cboTrangThai.Location = new System.Drawing.Point(30, 475);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(433, 28);
            this.cboTrangThai.TabIndex = 9;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.lblTrangThai.Location = new System.Drawing.Point(30, 445);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(80, 20);
            this.lblTrangThai.TabIndex = 8;
            this.lblTrangThai.Text = "Trạng thái:";
            // 
            // dtpNgayHetHan
            // 
            this.dtpNgayHetHan.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.dtpNgayHetHan.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayHetHan.Location = new System.Drawing.Point(30, 395);
            this.dtpNgayHetHan.Name = "dtpNgayHetHan";
            this.dtpNgayHetHan.Size = new System.Drawing.Size(433, 27);
            this.dtpNgayHetHan.TabIndex = 7;
            // 
            // lblNgayHetHan
            // 
            this.lblNgayHetHan.AutoSize = true;
            this.lblNgayHetHan.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.lblNgayHetHan.Location = new System.Drawing.Point(30, 365);
            this.lblNgayHetHan.Name = "lblNgayHetHan";
            this.lblNgayHetHan.Size = new System.Drawing.Size(102, 20);
            this.lblNgayHetHan.TabIndex = 6;
            this.lblNgayHetHan.Text = "Ngày hết hạn:";
            // 
            // cboSach
            // 
            this.cboSach.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSach.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.cboSach.FormattingEnabled = true;
            this.cboSach.Location = new System.Drawing.Point(30, 315);
            this.cboSach.Name = "cboSach";
            this.cboSach.Size = new System.Drawing.Size(433, 28);
            this.cboSach.TabIndex = 5;
            // 
            // lblSach
            // 
            this.lblSach.AutoSize = true;
            this.lblSach.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.lblSach.Location = new System.Drawing.Point(30, 285);
            this.lblSach.Name = "lblSach";
            this.lblSach.Size = new System.Drawing.Size(44, 20);
            this.lblSach.TabIndex = 4;
            this.lblSach.Text = "Sách:";
            // 
            // cboSinhVien
            // 
            this.cboSinhVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSinhVien.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.cboSinhVien.FormattingEnabled = true;
            this.cboSinhVien.Location = new System.Drawing.Point(30, 235);
            this.cboSinhVien.Name = "cboSinhVien";
            this.cboSinhVien.Size = new System.Drawing.Size(433, 28);
            this.cboSinhVien.TabIndex = 3;
            // 
            // lblSinhVien
            // 
            this.lblSinhVien.AutoSize = true;
            this.lblSinhVien.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.lblSinhVien.Location = new System.Drawing.Point(30, 205);
            this.lblSinhVien.Name = "lblSinhVien";
            this.lblSinhVien.Size = new System.Drawing.Size(76, 20);
            this.lblSinhVien.TabIndex = 2;
            this.lblSinhVien.Text = "Sinh viên:";
            // 
            // txtMaPhieu
            // 
            this.txtMaPhieu.BackColor = System.Drawing.Color.White;
            this.txtMaPhieu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaPhieu.Enabled = false;
            this.txtMaPhieu.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.txtMaPhieu.Location = new System.Drawing.Point(30, 155);
            this.txtMaPhieu.Name = "txtMaPhieu";
            this.txtMaPhieu.Size = new System.Drawing.Size(433, 27);
            this.txtMaPhieu.TabIndex = 1;
            // 
            // lblMaPhieu
            // 
            this.lblMaPhieu.AutoSize = true;
            this.lblMaPhieu.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.lblMaPhieu.Location = new System.Drawing.Point(30, 125);
            this.lblMaPhieu.Name = "lblMaPhieu";
            this.lblMaPhieu.Size = new System.Drawing.Size(101, 20);
            this.lblMaPhieu.TabIndex = 0;
            this.lblMaPhieu.Text = "Mã phiếu đặt:";
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.White;
            this.panelRight.Controls.Add(this.btnExport);
            this.panelRight.Controls.Add(this.dgvDanhSach);
            this.panelRight.Controls.Add(this.btnTimKiem);
            this.panelRight.Controls.Add(this.lblTimKiem);
            this.panelRight.Controls.Add(this.txtTimKiem);
            this.panelRight.Controls.Add(this.lblHeadTitle);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(584, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(1320, 761);
            this.panelRight.TabIndex = 1;
            // 
            // dgvDanhSach
            // 
            this.dgvDanhSach.AllowUserToAddRows = false;
            this.dgvDanhSach.AllowUserToDeleteRows = false;
            this.dgvDanhSach.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDanhSach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDanhSach.BackgroundColor = System.Drawing.Color.White;
            this.dgvDanhSach.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDanhSach.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSach.Location = new System.Drawing.Point(16, 205);
            this.dgvDanhSach.MultiSelect = false;
            this.dgvDanhSach.Name = "dgvDanhSach";
            this.dgvDanhSach.ReadOnly = true;
            this.dgvDanhSach.RowTemplate.Height = 32;
            this.dgvDanhSach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDanhSach.Size = new System.Drawing.Size(1150, 417);
            this.dgvDanhSach.TabIndex = 12;
            this.dgvDanhSach.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhSach_CellClick);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(124)))), ((int)(((byte)(191)))));
            this.btnTimKiem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(1048, 119);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(118, 32);
            this.btnTimKiem.TabIndex = 10;
            this.btnTimKiem.Text = "Tìm kiếm 🔍";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.lblTimKiem.Location = new System.Drawing.Point(341, 125);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(73, 20);
            this.lblTimKiem.TabIndex = 10;
            this.lblTimKiem.Text = "Tìm kiếm:";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.BackColor = System.Drawing.Color.White;
            this.txtTimKiem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.txtTimKiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(34)))), ((int)(((byte)(98)))));
            this.txtTimKiem.Location = new System.Drawing.Point(439, 123);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(567, 27);
            this.txtTimKiem.TabIndex = 11;
            // 
            // lblHeadTitle
            // 
            this.lblHeadTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeadTitle.AutoSize = true;
            this.lblHeadTitle.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold);
            this.lblHeadTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(34)))), ((int)(((byte)(98)))));
            this.lblHeadTitle.Location = new System.Drawing.Point(188, 40);
            this.lblHeadTitle.Name = "lblHeadTitle";
            this.lblHeadTitle.Size = new System.Drawing.Size(287, 37);
            this.lblHeadTitle.TabIndex = 0;
            this.lblHeadTitle.Text = "QUẢN LÝ ĐẶT TRƯỚC";
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(124)))), ((int)(((byte)(191)))));
            this.btnExport.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(92, 119);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(102, 32);
            this.btnExport.TabIndex = 13;
            this.btnExport.Text = "Xuất Excel";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // frmQuanLyDatTruoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 761);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Name = "frmQuanLyDatTruoc";
            this.Text = "Quản lý Đặt trước";
            this.Load += new System.EventHandler(this.frmQuanLyDatTruoc_Load);
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Label lblHeadTitle;
        private System.Windows.Forms.DataGridView dgvDanhSach;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txtMaPhieu;
        private System.Windows.Forms.Label lblMaPhieu;
        private System.Windows.Forms.ComboBox cboSinhVien;
        private System.Windows.Forms.Label lblSinhVien;
        private System.Windows.Forms.ComboBox cboSach;
        private System.Windows.Forms.Label lblSach;
        private System.Windows.Forms.DateTimePicker dtpNgayHetHan;
        private System.Windows.Forms.Label lblNgayHetHan;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label lblTimKiem;
    }
}