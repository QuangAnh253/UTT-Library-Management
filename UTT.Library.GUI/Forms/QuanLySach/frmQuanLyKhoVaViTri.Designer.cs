namespace UTT.Library.GUI.Forms.QuanLySach
{
    partial class frmQuanLyKhoVaViTri
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
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.panelRight = new System.Windows.Forms.Panel();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.txtSucChua = new System.Windows.Forms.TextBox();
            this.lblSucChua = new System.Windows.Forms.Label();
            this.txtTenKho = new System.Windows.Forms.TextBox();
            this.txtMaKho = new System.Windows.Forms.TextBox();
            this.lblTenKho = new System.Windows.Forms.Label();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.lblMaKho = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            this.panelRight.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.SuspendLayout();
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
            this.dgvDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSach.Location = new System.Drawing.Point(15, 106);
            this.dgvDanhSach.MultiSelect = false;
            this.dgvDanhSach.Name = "dgvDanhSach";
            this.dgvDanhSach.ReadOnly = true;
            this.dgvDanhSach.RowTemplate.Height = 32;
            this.dgvDanhSach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDanhSach.Size = new System.Drawing.Size(700, 500);
            this.dgvDanhSach.TabIndex = 12;
            this.dgvDanhSach.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhSach_CellClick);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.txtTimKiem.Location = new System.Drawing.Point(116, 62);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(301, 27);
            this.txtTimKiem.TabIndex = 11;
            // 
            // lblMoTa
            // 
            this.lblMoTa.AutoSize = true;
            this.lblMoTa.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.lblMoTa.Location = new System.Drawing.Point(22, 276);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(52, 20);
            this.lblMoTa.TabIndex = 4;
            this.lblMoTa.Text = "Mô tả:";
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(124)))), ((int)(((byte)(191)))));
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(284, 340);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(75, 32);
            this.btnLamMoi.TabIndex = 9;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(200, 340);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 32);
            this.btnXoa.TabIndex = 8;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(124)))), ((int)(((byte)(191)))));
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(111, 340);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 32);
            this.btnSua.TabIndex = 7;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(148)))), ((int)(((byte)(33)))));
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(22, 340);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 32);
            this.btnThem.TabIndex = 6;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtMoTa
            // 
            this.txtMoTa.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.txtMoTa.Location = new System.Drawing.Point(22, 297);
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(326, 27);
            this.txtMoTa.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(34)))), ((int)(((byte)(98)))));
            this.label1.Location = new System.Drawing.Point(15, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(316, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ KHO LƯU TRỮ";
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(124)))), ((int)(((byte)(191)))));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(553, 59);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(90, 28);
            this.btnExport.TabIndex = 10;
            this.btnExport.Text = "Xuất Excel";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.White;
            this.panelRight.Controls.Add(this.label1);
            this.panelRight.Controls.Add(this.btnExport);
            this.panelRight.Controls.Add(this.dgvDanhSach);
            this.panelRight.Controls.Add(this.btnTimKiem);
            this.panelRight.Controls.Add(this.lblTimKiem);
            this.panelRight.Controls.Add(this.txtTimKiem);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(375, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(800, 650);
            this.panelRight.TabIndex = 5;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(124)))), ((int)(((byte)(191)))));
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(448, 59);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(90, 28);
            this.btnTimKiem.TabIndex = 4;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.lblTimKiem.Location = new System.Drawing.Point(15, 65);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(73, 20);
            this.lblTimKiem.TabIndex = 10;
            this.lblTimKiem.Text = "Tìm kiếm:";
            // 
            // txtSucChua
            // 
            this.txtSucChua.BackColor = System.Drawing.Color.White;
            this.txtSucChua.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSucChua.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.txtSucChua.Location = new System.Drawing.Point(22, 240);
            this.txtSucChua.Name = "txtSucChua";
            this.txtSucChua.Size = new System.Drawing.Size(325, 27);
            this.txtSucChua.TabIndex = 3;
            // 
            // lblSucChua
            // 
            this.lblSucChua.AutoSize = true;
            this.lblSucChua.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.lblSucChua.Location = new System.Drawing.Point(22, 219);
            this.lblSucChua.Name = "lblSucChua";
            this.lblSucChua.Size = new System.Drawing.Size(72, 20);
            this.lblSucChua.TabIndex = 2;
            this.lblSucChua.Text = "Sức chứa:";
            // 
            // txtTenKho
            // 
            this.txtTenKho.BackColor = System.Drawing.Color.White;
            this.txtTenKho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTenKho.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.txtTenKho.Location = new System.Drawing.Point(22, 183);
            this.txtTenKho.Name = "txtTenKho";
            this.txtTenKho.Size = new System.Drawing.Size(325, 27);
            this.txtTenKho.TabIndex = 3;
            // 
            // txtMaKho
            // 
            this.txtMaKho.BackColor = System.Drawing.Color.White;
            this.txtMaKho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaKho.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.txtMaKho.Location = new System.Drawing.Point(22, 126);
            this.txtMaKho.Name = "txtMaKho";
            this.txtMaKho.Size = new System.Drawing.Size(325, 27);
            this.txtMaKho.TabIndex = 1;
            // 
            // lblTenKho
            // 
            this.lblTenKho.AutoSize = true;
            this.lblTenKho.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.lblTenKho.Location = new System.Drawing.Point(22, 162);
            this.lblTenKho.Name = "lblTenKho";
            this.lblTenKho.Size = new System.Drawing.Size(64, 20);
            this.lblTenKho.TabIndex = 2;
            this.lblTenKho.Text = "Tên kho:";
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.White;
            this.panelLeft.Controls.Add(this.lblMoTa);
            this.panelLeft.Controls.Add(this.btnLamMoi);
            this.panelLeft.Controls.Add(this.btnXoa);
            this.panelLeft.Controls.Add(this.btnSua);
            this.panelLeft.Controls.Add(this.btnThem);
            this.panelLeft.Controls.Add(this.txtMoTa);
            this.panelLeft.Controls.Add(this.txtSucChua);
            this.panelLeft.Controls.Add(this.lblSucChua);
            this.panelLeft.Controls.Add(this.txtTenKho);
            this.panelLeft.Controls.Add(this.txtMaKho);
            this.panelLeft.Controls.Add(this.lblTenKho);
            this.panelLeft.Controls.Add(this.lblMaKho);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(375, 650);
            this.panelLeft.TabIndex = 4;
            // 
            // lblMaKho
            // 
            this.lblMaKho.AutoSize = true;
            this.lblMaKho.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.lblMaKho.Location = new System.Drawing.Point(22, 106);
            this.lblMaKho.Name = "lblMaKho";
            this.lblMaKho.Size = new System.Drawing.Size(62, 20);
            this.lblMaKho.TabIndex = 1;
            this.lblMaKho.Text = "Mã kho:";
            // 
            // frmQuanLyKhoVaViTri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 650);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Name = "frmQuanLyKhoVaViTri";
            this.Text = "Quản lý Kho lưu trữ";
            this.Load += new System.EventHandler(this.frmQuanLyKho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDanhSach;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.TextBox txtSucChua;
        private System.Windows.Forms.Label lblSucChua;
        private System.Windows.Forms.TextBox txtTenKho;
        private System.Windows.Forms.TextBox txtMaKho;
        private System.Windows.Forms.Label lblTenKho;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Label lblMaKho;
    }
}