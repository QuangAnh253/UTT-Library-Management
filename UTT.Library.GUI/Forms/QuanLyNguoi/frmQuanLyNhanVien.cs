using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UTT.Library.BLL.Services;
using UTT.Library.DAL.Repositories;
using UTT.Library.DTO;
using UTT.Library.GUI.Utilities;

namespace UTT.Library.GUI.Forms.QuanLyNguoi
{
    public partial class frmQuanLyNhanVien : Form
    {
        private BLL_NhanVien _bll = new BLL_NhanVien();
        public frmQuanLyNhanVien()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
        }

        private void frmQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            LoadData();
            DecorateDataGridView();
            DecorateSearchBox();
            DecorateButtons(); ;
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

            dgvDanhSach.DefaultCellStyle.BackColor = Color.White;
            dgvDanhSach.DefaultCellStyle.ForeColor = Color.FromArgb(38, 34, 98);
            dgvDanhSach.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvDanhSach.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(185, 217, 137);

            dgvDanhSach.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(71, 124, 191);
            dgvDanhSach.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvDanhSach.GridColor = Color.FromArgb(224, 224, 224);
        }

        // =======================================================
        // =============== TRANG TRÍ Ô TÌM KIẾM ===================
        // =======================================================
        private void DecorateSearchBox()
        {
            txtTimKiem.BorderStyle = BorderStyle.FixedSingle;
            txtTimKiem.Font = new Font("Segoe UI", 10);
            txtTimKiem.ForeColor = Color.FromArgb(38, 34, 98);
            txtTimKiem.Text = "";
        }

        // =======================================================
        // ================= TRANG TRÍ BUTTON =====================
        // =======================================================
        private void DecorateButtons()
        {
            Color cam = Color.FromArgb(247, 148, 33);
            Color camDam = Color.FromArgb(200, 120, 20);
            Color xanh = Color.FromArgb(71, 124, 191);

            StyleButton(btnThem, cam, camDam);
            StyleButton(btnSua, xanh, Color.FromArgb(50, 90, 150));
            StyleButton(btnXoa, Color.FromArgb(200, 50, 50), Color.FromArgb(150, 20, 20));
            StyleButton(btnLamMoi, Color.FromArgb(93, 98, 42), Color.FromArgb(70, 75, 30));
            StyleButton(btnExport, Color.FromArgb(38, 34, 98), Color.FromArgb(25, 22, 70));
        }

        private void StyleButton(Button btn, Color back, Color backHover)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = back;
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            btn.MouseEnter += (s, e) => btn.BackColor = backHover;
            btn.MouseLeave += (s, e) => btn.BackColor = back;
        }

        // =======================================================
        // ================== LOAD & RESET =======================
        // =======================================================
        private void LoadData()
        {
            dgvDanhSach.DataSource = _bll.LayDanhSach();
            ResetInput();
        }

        private void ResetInput()
        {
            txtMaNhanVien.Enabled = true;
            txtMaNhanVien.Clear();
            txtHoTen.Clear();
            txtSoDienThoai.Clear();
            txtEmail.Clear();
            txtTenDangNhap.Clear();

            dtpNgayVaoLam.Value = DateTime.Now;
            txtMaNhanVien.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidationHelper.IsRequired(txtMaNhanVien, "Mã nhân viên")) return;
            if (!ValidationHelper.IsRequired(txtHoTen, "Họ tên")) return;
            if (!ValidationHelper.IsRequired(txtSoDienThoai, "Số điện thoại")) return;
            if (!ValidationHelper.IsRequired(txtEmail, "Email")) return;

            DTO_NhanVien nv = new DTO_NhanVien
            {
                MaNV = txtMaNhanVien.Text.Trim(),
                HoTen = txtHoTen.Text.Trim(),
                SDT = txtSoDienThoai.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                NgayVaoLam = dtpNgayVaoLam.Value,
                TenDangNhap = txtTenDangNhap.Text.Trim()
            };

            string kq = _bll.Them(nv);
            if (string.IsNullOrEmpty(kq))
            {
                MessageBox.Show("Thêm nhân viên thành công!");
                LoadData();
            }
            else
            {
                MessageBox.Show(kq, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaNhanVien.Enabled)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa!");
                return;
            }

            if (!ValidationHelper.IsRequired(txtHoTen, "Họ tên")) return;
            if (!ValidationHelper.IsRequired(txtSoDienThoai, "Số điện thoại")) return;
            if (!ValidationHelper.IsRequired(txtEmail, "Email")) return;

            DTO_NhanVien nv = new DTO_NhanVien
            {
                MaNV = txtMaNhanVien.Text.Trim(),
                HoTen = txtHoTen.Text.Trim(),
                SDT = txtSoDienThoai.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                NgayVaoLam = dtpNgayVaoLam.Value,
                TenDangNhap = txtTenDangNhap.Text.Trim()
            };

            string kq = _bll.Sua(nv);
            if (string.IsNullOrEmpty(kq))
            {
                MessageBox.Show("Cập nhật thành công!");
                LoadData();
            }
            else
            {
                MessageBox.Show(kq, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaNhanVien.Enabled || string.IsNullOrEmpty(txtMaNhanVien.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa!");
                return;
            }

            if (ValidationHelper.ConfirmDelete())
            {
                string kq = _bll.Xoa(txtMaNhanVien.Text);
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

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            dgvDanhSach.DataSource = _bll.TimKiem(txtTimKiem.Text.Trim());
        }

        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDanhSach.Rows[e.RowIndex];

                txtMaNhanVien.Text = row.Cells["MaNhanVien"].Value.ToString();
                txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
                txtSoDienThoai.Text = row.Cells["SoDienThoai"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                dtpNgayVaoLam.Value = (DateTime)row.Cells["NgayVaoLam"].Value;
                txtTenDangNhap.Text = row.Cells["TenDangNhap"].Value.ToString();

                txtMaNhanVien.Enabled = false;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelHelper.ExportToExcel(dgvDanhSach, "DanhSachNhanVien");
                MessageBox.Show("Xuất Excel thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất Excel: " + ex.Message);
            }
        }

       
    }
}
