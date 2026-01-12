using System;
using System.Drawing;
using System.Windows.Forms;
using UTT.Library.BLL.Services;
using UTT.Library.DTO;
using UTT.Library.GUI.Utilities;
using UTT.Library.DAL.Repositories;



namespace UTT.Library.GUI.Forms.QuanLyNguoi
{
    public partial class frmQuanLyDocGia : Form
    {
        private BLL_DocGia _bll = new BLL_DocGia();
        public frmQuanLyDocGia()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
        }

        private void frmQuanLyDocGia_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            LoadData();
            DecorateDataGridView();
            DecorateSearchBox();
            DecorateButtons();
            LoadCombo();
        }

        // =======================================================
        // =============== LOAD COMBOBOX =========================
        // =======================================================
        private void LoadCombo()
        {
            // LỚP
            BLL_Lop bllLop = new BLL_Lop();
            cboMaLop.DataSource = bllLop.LayDanhSach();
            cboMaLop.DisplayMember = "MaLop";
            cboMaLop.ValueMember = "MaLop";
            cboMaLop.SelectedIndex = -1;

            // KHOA
            BLL_Khoa bllKhoa = new BLL_Khoa();
            cboMaKhoa.DataSource = bllKhoa.LayDanhSach();
            cboMaKhoa.DisplayMember = "MaKhoa";
            cboMaKhoa.ValueMember = "MaKhoa";
            cboMaKhoa.SelectedIndex = -1;
        }
        // =======================================================
        // =============== TRANG TRÍ DATAGRIDVIEW =================
        // =======================================================
        private void DecorateDataGridView()
        {
            dgvDanhSach.BorderStyle = BorderStyle.None;
            dgvDanhSach.BackgroundColor = Color.White;
            dgvDanhSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDanhSach.RowTemplate.Height = 32;
            dgvDanhSach.ReadOnly = true;
            dgvDanhSach.AllowUserToAddRows = false;
            dgvDanhSach.AllowUserToDeleteRows = false;
            dgvDanhSach.MultiSelect = false;
            dgvDanhSach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDanhSach.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            dgvDanhSach.EnableHeadersVisualStyles = false;
            dgvDanhSach.ColumnHeadersHeight = 40;
            dgvDanhSach.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvDanhSach.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(38, 34, 98);
            dgvDanhSach.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDanhSach.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 11, FontStyle.Bold);

            dgvDanhSach.DefaultCellStyle.Font = new Font("Segoe UI", 10);
        }

        // =======================================================
        // =============== TRANG TRÍ SEARCH ======================
        // =======================================================
        private void DecorateSearchBox()
        {
            txtTimKiem.BorderStyle = BorderStyle.FixedSingle;
            txtTimKiem.Font = new Font("Segoe UI", 10);
        }

        // =======================================================
        // ================= TRANG TRÍ BUTTON =====================
        // =======================================================
        private void DecorateButtons()
        {
            Color cam = Color.FromArgb(247, 148, 33);
            Color xanh = Color.FromArgb(71, 124, 191);

            StyleButton(btnThem, cam);
            StyleButton(btnSua, xanh);
            StyleButton(btnXoa, Color.FromArgb(200, 50, 50));
            StyleButton(btnLamMoi, Color.FromArgb(93, 98, 42));
            StyleButton(btnExport, Color.FromArgb(38, 34, 98));
        }

        private void StyleButton(Button btn, Color back)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = back;
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        }

        // =======================================================
        // ================== LOAD DATA ==========================
        // =======================================================
        private void LoadData()
        {
            dgvDanhSach.DataSource = _bll.LayDanhSach();
            ResetInput();
        }

        private void ResetInput()
        {
            txtMaSinhVien.Enabled = true;
            txtMaSinhVien.Clear();
            txtHoTen.Clear();
            txtSoDienThoai.Clear();
            txtEmail.Clear();
            txtTenDangNhap.Clear();
            rdoNam.Checked = true;
            dtpNgaySinh.Value = DateTime.Now;
            cboMaLop.SelectedIndex = -1;
            cboMaKhoa.SelectedIndex = -1;
            txtMaSinhVien.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidationHelper.IsRequired(txtMaSinhVien, "Mã sinh viên")) return;
            if (!ValidationHelper.IsRequired(txtHoTen, "Họ tên")) return;
            if (!ValidationHelper.IsRequired(txtEmail, "Email")) return;
            {
                MessageBox.Show("Email không hợp lệ!");
                txtEmail.Focus();
                return;
            }

            DTO_DocGia dg = new DTO_DocGia
            {
                MaSV = txtMaSinhVien.Text.Trim(),
                HoTen = txtHoTen.Text.Trim(),
                NgaySinh = dtpNgaySinh.Value,
                GioiTinh = rdoNam.Checked ? "Nam" : "Nữ",
                SDT = txtSoDienThoai.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                MaLop = cboMaLop.SelectedValue?.ToString(),
                MaKhoa = cboMaKhoa.SelectedValue?.ToString(),
                TenDangNhap = txtTenDangNhap.Text.Trim()
            };

            string kq = _bll.Them(dg);
            if (string.IsNullOrEmpty(kq))
            {
                MessageBox.Show("Thêm độc giả thành công!");
                LoadData();
            }
            else
            {
                MessageBox.Show(kq, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaSinhVien.Enabled)
            {
                MessageBox.Show("Vui lòng chọn độc giả cần sửa!");
                return;
            }

            if (!ValidationHelper.IsRequired(txtHoTen, "Họ tên")) return;

            DTO_DocGia dg = new DTO_DocGia
            {
                MaSV = txtMaSinhVien.Text.Trim(),
                HoTen = txtHoTen.Text.Trim(),
                NgaySinh = dtpNgaySinh.Value,
                GioiTinh = rdoNam.Checked ? "Nam" : "Nữ",
                SDT = txtSoDienThoai.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                MaLop = cboMaLop.SelectedValue?.ToString(),
                MaKhoa = cboMaKhoa.SelectedValue?.ToString(),
                TenDangNhap = txtTenDangNhap.Text.Trim()
            };

            string kq = _bll.Sua(dg);
            if (string.IsNullOrEmpty(kq))
            {
                MessageBox.Show("Cập nhật độc giả thành công!");
                LoadData();
            }
            else
            {
                MessageBox.Show(kq, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaSinhVien.Enabled || string.IsNullOrEmpty(txtMaSinhVien.Text))
            {
                MessageBox.Show("Vui lòng chọn độc giả cần xóa!");
                return;
            }

            if (ValidationHelper.ConfirmDelete())
            {
                string kq = _bll.Xoa(txtMaSinhVien.Text);
                if (string.IsNullOrEmpty(kq))
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadData();
                }
                else
                {
                    MessageBox.Show(kq, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDanhSach.Rows[e.RowIndex];

                txtMaSinhVien.Text = row.Cells["MaSV"].Value.ToString();
                txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
                dtpNgaySinh.Value = row.Cells["NgaySinh"].Value == DBNull.Value
                    ? DateTime.Now
                    : (DateTime)row.Cells["NgaySinh"].Value;
                string gt = row.Cells["GioiTinh"].Value.ToString();
                rdoNam.Checked = gt == "Nam";
                rdoNu.Checked = gt == "Nữ";
                txtSoDienThoai.Text = row.Cells["SDT"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                cboMaLop.SelectedValue = row.Cells["MaLop"].Value?.ToString();
                cboMaKhoa.SelectedValue = row.Cells["MaKhoa"].Value?.ToString();
                txtTenDangNhap.Text = row.Cells["TenDangNhap"].Value.ToString();
                txtMaSinhVien.Enabled = false;
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            dgvDanhSach.DataSource = _bll.TimKiem(txtTimKiem.Text.Trim());
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelHelper.ExportToExcel(dgvDanhSach, "DanhSachDocGia");
                MessageBox.Show("Xuất Excel thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất Excel: " + ex.Message);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
