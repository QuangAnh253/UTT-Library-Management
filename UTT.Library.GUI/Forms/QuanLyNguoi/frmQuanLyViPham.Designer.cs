namespace UTT.Library.GUI.Forms.QuanLyNguoi
{
    partial class frmQuanLyViPham
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
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.lblNgayViPham = new System.Windows.Forms.Label();
            this.lblSoTienPhat = new System.Windows.Forms.Label();
            this.lblHinhThucXuLy = new System.Windows.Forms.Label();
            this.lblLoiViPham = new System.Windows.Forms.Label();
            this.lblMaSinhVien = new System.Windows.Forms.Label();
            this.lblMaViPham = new System.Windows.Forms.Label();
            this.txtMaViPham = new System.Windows.Forms.TextBox();
            this.txtMaSinhVien = new System.Windows.Forms.TextBox();
            this.txtLoiViPham = new System.Windows.Forms.TextBox();
            this.txtHinhThucXuLy = new System.Windows.Forms.TextBox();
            this.txtTrangThai = new System.Windows.Forms.TextBox();
            this.dtpNgayViPham = new System.Windows.Forms.DateTimePicker();
            this.nudSoTienPhat = new System.Windows.Forms.NumericUpDown();
            this.btnGhiNhan = new System.Windows.Forms.Button();
            this.btnXuLy = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();
            this.btnExport = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblTimKiem = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoTienPhat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 22.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(271, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(556, 78);
            this.label1.TabIndex = 1;
            this.label1.Text = "QUẢN LÝ VI PHẠM";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(402, 474);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 40);
            this.label2.TabIndex = 2;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Font = new System.Drawing.Font("Segoe UI", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrangThai.Location = new System.Drawing.Point(127, 548);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(149, 40);
            this.lblTrangThai.TabIndex = 3;
            this.lblTrangThai.Text = "Trạng thái:";
            // 
            // lblNgayViPham
            // 
            this.lblNgayViPham.AutoSize = true;
            this.lblNgayViPham.Font = new System.Drawing.Font("Segoe UI", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayViPham.Location = new System.Drawing.Point(127, 484);
            this.lblNgayViPham.Name = "lblNgayViPham";
            this.lblNgayViPham.Size = new System.Drawing.Size(201, 40);
            this.lblNgayViPham.TabIndex = 4;
            this.lblNgayViPham.Text = "Ngày vi phạm:";
            // 
            // lblSoTienPhat
            // 
            this.lblSoTienPhat.AutoSize = true;
            this.lblSoTienPhat.Font = new System.Drawing.Font("Segoe UI", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoTienPhat.Location = new System.Drawing.Point(127, 418);
            this.lblSoTienPhat.Name = "lblSoTienPhat";
            this.lblSoTienPhat.Size = new System.Drawing.Size(177, 40);
            this.lblSoTienPhat.TabIndex = 5;
            this.lblSoTienPhat.Text = "Số tiền phạt:";
            // 
            // lblHinhThucXuLy
            // 
            this.lblHinhThucXuLy.AutoSize = true;
            this.lblHinhThucXuLy.Font = new System.Drawing.Font("Segoe UI", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHinhThucXuLy.Location = new System.Drawing.Point(127, 354);
            this.lblHinhThucXuLy.Name = "lblHinhThucXuLy";
            this.lblHinhThucXuLy.Size = new System.Drawing.Size(214, 40);
            this.lblHinhThucXuLy.TabIndex = 6;
            this.lblHinhThucXuLy.Text = "Hình thức xử lý:";
            // 
            // lblLoiViPham
            // 
            this.lblLoiViPham.AutoSize = true;
            this.lblLoiViPham.Font = new System.Drawing.Font("Segoe UI", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoiViPham.Location = new System.Drawing.Point(127, 291);
            this.lblLoiViPham.Name = "lblLoiViPham";
            this.lblLoiViPham.Size = new System.Drawing.Size(171, 40);
            this.lblLoiViPham.TabIndex = 7;
            this.lblLoiViPham.Text = "Lỗi vi phạm:";
            // 
            // lblMaSinhVien
            // 
            this.lblMaSinhVien.AutoSize = true;
            this.lblMaSinhVien.Font = new System.Drawing.Font("Segoe UI", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaSinhVien.Location = new System.Drawing.Point(130, 227);
            this.lblMaSinhVien.Name = "lblMaSinhVien";
            this.lblMaSinhVien.Size = new System.Drawing.Size(183, 40);
            this.lblMaSinhVien.TabIndex = 8;
            this.lblMaSinhVien.Text = "Mã sinh viên:";
            // 
            // lblMaViPham
            // 
            this.lblMaViPham.AutoSize = true;
            this.lblMaViPham.Font = new System.Drawing.Font("Segoe UI", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaViPham.Location = new System.Drawing.Point(130, 162);
            this.lblMaViPham.Name = "lblMaViPham";
            this.lblMaViPham.Size = new System.Drawing.Size(174, 40);
            this.lblMaViPham.TabIndex = 9;
            this.lblMaViPham.Text = "Mã vi phạm:";
            // 
            // txtMaViPham
            // 
            this.txtMaViPham.Font = new System.Drawing.Font("Segoe UI", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaViPham.Location = new System.Drawing.Point(353, 159);
            this.txtMaViPham.Name = "txtMaViPham";
            this.txtMaViPham.Size = new System.Drawing.Size(315, 46);
            this.txtMaViPham.TabIndex = 10;
            // 
            // txtMaSinhVien
            // 
            this.txtMaSinhVien.Font = new System.Drawing.Font("Segoe UI", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaSinhVien.Location = new System.Drawing.Point(353, 224);
            this.txtMaSinhVien.Name = "txtMaSinhVien";
            this.txtMaSinhVien.Size = new System.Drawing.Size(315, 46);
            this.txtMaSinhVien.TabIndex = 11;
            // 
            // txtLoiViPham
            // 
            this.txtLoiViPham.Font = new System.Drawing.Font("Segoe UI", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoiViPham.Location = new System.Drawing.Point(353, 288);
            this.txtLoiViPham.Name = "txtLoiViPham";
            this.txtLoiViPham.Size = new System.Drawing.Size(315, 46);
            this.txtLoiViPham.TabIndex = 12;
            // 
            // txtHinhThucXuLy
            // 
            this.txtHinhThucXuLy.Font = new System.Drawing.Font("Segoe UI", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHinhThucXuLy.Location = new System.Drawing.Point(353, 351);
            this.txtHinhThucXuLy.Name = "txtHinhThucXuLy";
            this.txtHinhThucXuLy.Size = new System.Drawing.Size(315, 46);
            this.txtHinhThucXuLy.TabIndex = 13;
            // 
            // txtTrangThai
            // 
            this.txtTrangThai.Font = new System.Drawing.Font("Segoe UI", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTrangThai.Location = new System.Drawing.Point(353, 545);
            this.txtTrangThai.Name = "txtTrangThai";
            this.txtTrangThai.Size = new System.Drawing.Size(315, 46);
            this.txtTrangThai.TabIndex = 14;
            // 
            // dtpNgayViPham
            // 
            this.dtpNgayViPham.Font = new System.Drawing.Font("Segoe UI", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayViPham.Location = new System.Drawing.Point(353, 479);
            this.dtpNgayViPham.Name = "dtpNgayViPham";
            this.dtpNgayViPham.Size = new System.Drawing.Size(424, 46);
            this.dtpNgayViPham.TabIndex = 15;
            // 
            // nudSoTienPhat
            // 
            this.nudSoTienPhat.Font = new System.Drawing.Font("Segoe UI", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSoTienPhat.Location = new System.Drawing.Point(353, 416);
            this.nudSoTienPhat.Name = "nudSoTienPhat";
            this.nudSoTienPhat.Size = new System.Drawing.Size(305, 46);
            this.nudSoTienPhat.TabIndex = 16;
            // 
            // btnGhiNhan
            // 
            this.btnGhiNhan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(148)))), ((int)(((byte)(33)))));
            this.btnGhiNhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGhiNhan.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnGhiNhan.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnGhiNhan.Location = new System.Drawing.Point(163, 619);
            this.btnGhiNhan.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGhiNhan.Name = "btnGhiNhan";
            this.btnGhiNhan.Size = new System.Drawing.Size(165, 61);
            this.btnGhiNhan.TabIndex = 17;
            this.btnGhiNhan.Text = "Ghi nhận";
            this.btnGhiNhan.UseVisualStyleBackColor = false;
            this.btnGhiNhan.Click += new System.EventHandler(this.btnGhiNhan_Click);
            // 
            // btnXuLy
            // 
            this.btnXuLy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(124)))), ((int)(((byte)(191)))));
            this.btnXuLy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuLy.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnXuLy.ForeColor = System.Drawing.Color.White;
            this.btnXuLy.Location = new System.Drawing.Point(381, 619);
            this.btnXuLy.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnXuLy.Name = "btnXuLy";
            this.btnXuLy.Size = new System.Drawing.Size(150, 61);
            this.btnXuLy.TabIndex = 18;
            this.btnXuLy.Text = "Xử lý";
            this.btnXuLy.UseVisualStyleBackColor = false;
            this.btnXuLy.Click += new System.EventHandler(this.btnXuLy_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(604, 619);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(191, 61);
            this.btnLamMoi.TabIndex = 19;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // dgvDanhSach
            // 
            this.dgvDanhSach.BackgroundColor = System.Drawing.Color.White;
            this.dgvDanhSach.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSach.Location = new System.Drawing.Point(41, 828);
            this.dgvDanhSach.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvDanhSach.Name = "dgvDanhSach";
            this.dgvDanhSach.RowHeadersWidth = 51;
            this.dgvDanhSach.RowTemplate.Height = 24;
            this.dgvDanhSach.Size = new System.Drawing.Size(959, 262);
            this.dgvDanhSach.TabIndex = 25;
            this.dgvDanhSach.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhSach_CellContentClick);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(124)))), ((int)(((byte)(191)))));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(410, 757);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(204, 61);
            this.btnExport.TabIndex = 24;
            this.btnExport.Text = "Xuất Excel";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.txtTimKiem.Location = new System.Drawing.Point(267, 700);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(676, 47);
            this.txtTimKiem.TabIndex = 23;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.lblTimKiem.Location = new System.Drawing.Point(77, 703);
            this.lblTimKiem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(146, 41);
            this.lblTimKiem.TabIndex = 22;
            this.lblTimKiem.Text = "Tìm kiếm:";
            // 
            // frmQuanLyViPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 1106);
            this.Controls.Add(this.dgvDanhSach);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.lblTimKiem);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnXuLy);
            this.Controls.Add(this.btnGhiNhan);
            this.Controls.Add(this.nudSoTienPhat);
            this.Controls.Add(this.dtpNgayViPham);
            this.Controls.Add(this.txtTrangThai);
            this.Controls.Add(this.txtHinhThucXuLy);
            this.Controls.Add(this.txtLoiViPham);
            this.Controls.Add(this.txtMaSinhVien);
            this.Controls.Add(this.txtMaViPham);
            this.Controls.Add(this.lblMaViPham);
            this.Controls.Add(this.lblMaSinhVien);
            this.Controls.Add(this.lblLoiViPham);
            this.Controls.Add(this.lblHinhThucXuLy);
            this.Controls.Add(this.lblSoTienPhat);
            this.Controls.Add(this.lblNgayViPham);
            this.Controls.Add(this.lblTrangThai);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmQuanLyViPham";
            this.Text = "frmQuanLyViPham";
            this.Load += new System.EventHandler(this.frmQuanLyViPham_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudSoTienPhat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.Label lblNgayViPham;
        private System.Windows.Forms.Label lblSoTienPhat;
        private System.Windows.Forms.Label lblHinhThucXuLy;
        private System.Windows.Forms.Label lblLoiViPham;
        private System.Windows.Forms.Label lblMaSinhVien;
        private System.Windows.Forms.Label lblMaViPham;
        private System.Windows.Forms.TextBox txtMaViPham;
        private System.Windows.Forms.TextBox txtMaSinhVien;
        private System.Windows.Forms.TextBox txtLoiViPham;
        private System.Windows.Forms.TextBox txtHinhThucXuLy;
        private System.Windows.Forms.TextBox txtTrangThai;
        private System.Windows.Forms.DateTimePicker dtpNgayViPham;
        private System.Windows.Forms.NumericUpDown nudSoTienPhat;
        private System.Windows.Forms.Button btnGhiNhan;
        private System.Windows.Forms.Button btnXuLy;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.DataGridView dgvDanhSach;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label lblTimKiem;
    }
}