namespace UTT.Library.GUI.Forms.NghiepVu
{
    partial class frmQuanLyTraSach
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
            this.btnTraSach = new System.Windows.Forms.Button();
            this.txtMaPhieuMuon = new System.Windows.Forms.TextBox();
            this.lblMaPhieuMuon = new System.Windows.Forms.Label();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.btnTaiChiTiet = new System.Windows.Forms.Button();
            this.dgvChiTiet = new System.Windows.Forms.DataGridView();
            this.lblChiTiet = new System.Windows.Forms.Label();
            this.panelRight = new System.Windows.Forms.Panel();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.txtTinhTrangKhiTra = new System.Windows.Forms.TextBox();
            this.lblTinhTrangKhiTra = new System.Windows.Forms.Label();
            this.txtTienPhat = new System.Windows.Forms.TextBox();
            this.lblTienPhat = new System.Windows.Forms.Label();
            this.dtpNgayTra = new System.Windows.Forms.DateTimePicker();
            this.lblNgayTra = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaSach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgayTra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTienPhat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTinhTrangKhiTra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.panelRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTraSach
            // 
            this.btnTraSach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(124)))), ((int)(((byte)(191)))));
            this.btnTraSach.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnTraSach.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnTraSach.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnTraSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTraSach.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTraSach.ForeColor = System.Drawing.Color.White;
            this.btnTraSach.Location = new System.Drawing.Point(720, 664);
            this.btnTraSach.Name = "btnTraSach";
            this.btnTraSach.Size = new System.Drawing.Size(85, 32);
            this.btnTraSach.TabIndex = 8;
            this.btnTraSach.Text = "Trả sách";
            this.btnTraSach.UseVisualStyleBackColor = false;
            this.btnTraSach.Click += new System.EventHandler(this.btnTraSach_Click);
            // 
            // txtMaPhieuMuon
            // 
            this.txtMaPhieuMuon.BackColor = System.Drawing.Color.White;
            this.txtMaPhieuMuon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaPhieuMuon.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaPhieuMuon.Location = new System.Drawing.Point(30, 155);
            this.txtMaPhieuMuon.Name = "txtMaPhieuMuon";
            this.txtMaPhieuMuon.Size = new System.Drawing.Size(450, 27);
            this.txtMaPhieuMuon.TabIndex = 1;
            // 
            // lblMaPhieuMuon
            // 
            this.lblMaPhieuMuon.AutoSize = true;
            this.lblMaPhieuMuon.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaPhieuMuon.Location = new System.Drawing.Point(30, 125);
            this.lblMaPhieuMuon.Name = "lblMaPhieuMuon";
            this.lblMaPhieuMuon.Size = new System.Drawing.Size(117, 20);
            this.lblMaPhieuMuon.TabIndex = 0;
            this.lblMaPhieuMuon.Text = "Mã phiếu mượn:";
            // 
            // panelLeft
            // 
            this.panelLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelLeft.BackColor = System.Drawing.Color.White;
            this.panelLeft.Controls.Add(this.btnTaiChiTiet);
            this.panelLeft.Controls.Add(this.txtMaPhieuMuon);
            this.panelLeft.Controls.Add(this.lblMaPhieuMuon);
            this.panelLeft.ForeColor = System.Drawing.Color.Black;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(600, 761);
            this.panelLeft.TabIndex = 10;
            // 
            // btnTaiChiTiet
            // 
            this.btnTaiChiTiet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(148)))), ((int)(((byte)(33)))));
            this.btnTaiChiTiet.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnTaiChiTiet.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnTaiChiTiet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnTaiChiTiet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaiChiTiet.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaiChiTiet.ForeColor = System.Drawing.Color.White;
            this.btnTaiChiTiet.Location = new System.Drawing.Point(30, 214);
            this.btnTaiChiTiet.Name = "btnTaiChiTiet";
            this.btnTaiChiTiet.Size = new System.Drawing.Size(117, 32);
            this.btnTaiChiTiet.TabIndex = 6;
            this.btnTaiChiTiet.Text = "Tải chi tiết";
            this.btnTaiChiTiet.UseVisualStyleBackColor = false;
            this.btnTaiChiTiet.Click += new System.EventHandler(this.btnTaiChiTiet_Click);
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.AllowUserToAddRows = false;
            this.dgvChiTiet.AllowUserToDeleteRows = false;
            this.dgvChiTiet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvChiTiet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTiet.BackgroundColor = System.Drawing.Color.White;
            this.dgvChiTiet.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvChiTiet.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTiet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colMaSach,
            this.colNgayTra,
            this.colTienPhat,
            this.colTinhTrangKhiTra,
            this.colGhiChu});
            this.dgvChiTiet.Location = new System.Drawing.Point(20, 155);
            this.dgvChiTiet.MultiSelect = false;
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.ReadOnly = true;
            this.dgvChiTiet.RowTemplate.Height = 32;
            this.dgvChiTiet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTiet.Size = new System.Drawing.Size(1150, 240);
            this.dgvChiTiet.TabIndex = 12;
            this.dgvChiTiet.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChiTiet_CellClick);
            this.dgvChiTiet.SelectionChanged += new System.EventHandler(this.dgvChiTiet_SelectionChanged);
            // 
            // lblChiTiet
            // 
            this.lblChiTiet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblChiTiet.AutoSize = true;
            this.lblChiTiet.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold);
            this.lblChiTiet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(34)))), ((int)(((byte)(98)))));
            this.lblChiTiet.Location = new System.Drawing.Point(188, 40);
            this.lblChiTiet.Name = "lblChiTiet";
            this.lblChiTiet.Size = new System.Drawing.Size(274, 37);
            this.lblChiTiet.TabIndex = 0;
            this.lblChiTiet.Text = "CHI TIẾT PHIẾU TRẢ";
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.White;
            this.panelRight.Controls.Add(this.txtGhiChu);
            this.panelRight.Controls.Add(this.lblGhiChu);
            this.panelRight.Controls.Add(this.txtTinhTrangKhiTra);
            this.panelRight.Controls.Add(this.lblTinhTrangKhiTra);
            this.panelRight.Controls.Add(this.txtTienPhat);
            this.panelRight.Controls.Add(this.lblTienPhat);
            this.panelRight.Controls.Add(this.dtpNgayTra);
            this.panelRight.Controls.Add(this.lblNgayTra);
            this.panelRight.Controls.Add(this.btnTraSach);
            this.panelRight.Controls.Add(this.txtID);
            this.panelRight.Controls.Add(this.lblID);
            this.panelRight.Controls.Add(this.dgvChiTiet);
            this.panelRight.Controls.Add(this.lblChiTiet);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(584, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(1320, 761);
            this.panelRight.TabIndex = 11;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.BackColor = System.Drawing.Color.White;
            this.txtGhiChu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGhiChu.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGhiChu.Location = new System.Drawing.Point(720, 582);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(450, 27);
            this.txtGhiChu.TabIndex = 24;
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGhiChu.Location = new System.Drawing.Point(720, 552);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(61, 20);
            this.lblGhiChu.TabIndex = 23;
            this.lblGhiChu.Text = "Ghi chú:";
            // 
            // txtTinhTrangKhiTra
            // 
            this.txtTinhTrangKhiTra.BackColor = System.Drawing.Color.White;
            this.txtTinhTrangKhiTra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTinhTrangKhiTra.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTinhTrangKhiTra.Location = new System.Drawing.Point(48, 669);
            this.txtTinhTrangKhiTra.Name = "txtTinhTrangKhiTra";
            this.txtTinhTrangKhiTra.Size = new System.Drawing.Size(450, 27);
            this.txtTinhTrangKhiTra.TabIndex = 22;
            // 
            // lblTinhTrangKhiTra
            // 
            this.lblTinhTrangKhiTra.AutoSize = true;
            this.lblTinhTrangKhiTra.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTinhTrangKhiTra.Location = new System.Drawing.Point(48, 639);
            this.lblTinhTrangKhiTra.Name = "lblTinhTrangKhiTra";
            this.lblTinhTrangKhiTra.Size = new System.Drawing.Size(124, 20);
            this.lblTinhTrangKhiTra.TabIndex = 21;
            this.lblTinhTrangKhiTra.Text = "Tình trạng khi trả:";
            // 
            // txtTienPhat
            // 
            this.txtTienPhat.BackColor = System.Drawing.Color.White;
            this.txtTienPhat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTienPhat.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTienPhat.Location = new System.Drawing.Point(48, 582);
            this.txtTienPhat.Name = "txtTienPhat";
            this.txtTienPhat.Size = new System.Drawing.Size(450, 27);
            this.txtTienPhat.TabIndex = 20;
            // 
            // lblTienPhat
            // 
            this.lblTienPhat.AutoSize = true;
            this.lblTienPhat.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTienPhat.Location = new System.Drawing.Point(48, 552);
            this.lblTienPhat.Name = "lblTienPhat";
            this.lblTienPhat.Size = new System.Drawing.Size(74, 20);
            this.lblTienPhat.TabIndex = 19;
            this.lblTienPhat.Text = "Tiền phạt:";
            // 
            // dtpNgayTra
            // 
            this.dtpNgayTra.CalendarFont = new System.Drawing.Font("Segoe UI", 11.25F);
            this.dtpNgayTra.Location = new System.Drawing.Point(720, 499);
            this.dtpNgayTra.Name = "dtpNgayTra";
            this.dtpNgayTra.Size = new System.Drawing.Size(450, 20);
            this.dtpNgayTra.TabIndex = 18;
            // 
            // lblNgayTra
            // 
            this.lblNgayTra.AutoSize = true;
            this.lblNgayTra.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayTra.Location = new System.Drawing.Point(720, 469);
            this.lblNgayTra.Name = "lblNgayTra";
            this.lblNgayTra.Size = new System.Drawing.Size(69, 20);
            this.lblNgayTra.TabIndex = 17;
            this.lblNgayTra.Text = "Ngày trả:";
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.Color.White;
            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtID.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(48, 499);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(450, 27);
            this.txtID.TabIndex = 14;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(48, 469);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(27, 20);
            this.lblID.TabIndex = 13;
            this.lblID.Text = "ID:";
            // 
            // colID
            // 
            this.colID.DataPropertyName = "ID";
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            // 
            // colMaSach
            // 
            this.colMaSach.DataPropertyName = "MaSach";
            this.colMaSach.HeaderText = "Mã sách";
            this.colMaSach.Name = "colMaSach";
            // 
            // colNgayTra
            // 
            this.colNgayTra.DataPropertyName = "NgayTra";
            this.colNgayTra.HeaderText = "Ngày trả";
            this.colNgayTra.Name = "colNgayTra";
            // 
            // colTienPhat
            // 
            this.colTienPhat.DataPropertyName = "TienPhat";
            this.colTienPhat.HeaderText = "Tiền phạt";
            this.colTienPhat.Name = "colTienPhat";
            // 
            // colTinhTrangKhiTra
            // 
            this.colTinhTrangKhiTra.DataPropertyName = "TinhTrangKhiTra";
            this.colTinhTrangKhiTra.HeaderText = "Tình trạng khi trả";
            this.colTinhTrangKhiTra.Name = "colTinhTrangKhiTra";
            // 
            // colGhiChu
            // 
            this.colGhiChu.DataPropertyName = "GhiChu";
            this.colGhiChu.HeaderText = "Ghi chú";
            this.colGhiChu.Name = "colGhiChu";
            // 
            // frmQuanLyTraSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 761);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelRight);
            this.Name = "frmQuanLyTraSach";
            this.Text = "frmQuanLyTraSach";
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnTraSach;
        private System.Windows.Forms.TextBox txtMaPhieuMuon;
        private System.Windows.Forms.Label lblMaPhieuMuon;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Button btnTaiChiTiet;
        private System.Windows.Forms.DataGridView dgvChiTiet;
        private System.Windows.Forms.Label lblChiTiet;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.TextBox txtTinhTrangKhiTra;
        private System.Windows.Forms.Label lblTinhTrangKhiTra;
        private System.Windows.Forms.TextBox txtTienPhat;
        private System.Windows.Forms.Label lblTienPhat;
        private System.Windows.Forms.DateTimePicker dtpNgayTra;
        private System.Windows.Forms.Label lblNgayTra;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgayTra;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTienPhat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTinhTrangKhiTra;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGhiChu;
    }
}