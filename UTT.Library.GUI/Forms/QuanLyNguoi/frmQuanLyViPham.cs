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
using UTT.Library.DTO;
using UTT.Library.GUI.Utilities;

namespace UTT.Library.GUI.Forms.QuanLyNguoi
{
    public partial class frmQuanLyViPham : Form
    {
        private BLL_ViPham _bll = new BLL_ViPham();
        private int _maViPhamDangChon = 0;
        public frmQuanLyViPham()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
        }

        private void frmQuanLyViPham_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            LoadData();
            DecorateDataGridView();
            DecorateSearchBox();
            DecorateButtons();

            // khóa các field hệ thống
            txtMaViPham.ReadOnly = true;
            txtTrangThai.ReadOnly = true;
            dtpNgayViPham.Enabled = false;
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
            dgvDanhSach.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);

            dgvDanhSach.DefaultCellStyle.BackColor = Color.White;
            dgvDanhSach.DefaultCellStyle.ForeColor = Color.FromArgb(38, 34, 98);
            dgvDanhSach.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvDanhSach.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(185, 217, 137);

            dgvDanhSach.DefaultCellStyle.SelectionBackColor = Color.FromArgb(71, 124, 191);
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
            StyleButton(btnGhiNhan, Color.FromArgb(247, 148, 33), Color.FromArgb(200, 120, 20));
            StyleButton(btnXuLy, Color.FromArgb(71, 124, 191), Color.FromArgb(50, 90, 150));
            StyleButton(btnLamMoi, Color.FromArgb(200, 50, 50), Color.FromArgb(150, 20, 20));
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
            _maViPhamDangChon = 0;

            txtMaViPham.Clear();
            txtMaSinhVien.Clear();
            txtLoiViPham.Clear();
            txtHinhThucXuLy.Clear();
            nudSoTienPhat.Value = 0;

            dtpNgayViPham.Value = DateTime.Now;
            txtTrangThai.Text = "Chưa xử lý";

            txtMaSinhVien.Focus();
        }

        private void btnGhiNhan_Click(object sender, EventArgs e)
        {
            if (!ValidationHelper.IsRequired(txtMaSinhVien, "Mã sinh viên")) return;
            if (!ValidationHelper.IsRequired(txtLoiViPham, "Lỗi vi phạm")) return;

            DTO_ViPham vp = new DTO_ViPham
            {
                MaSV = txtMaSinhVien.Text.Trim(),
                LoiViPham = txtLoiViPham.Text.Trim(),
                HinhThucXuLy = txtHinhThucXuLy.Text.Trim(),
                SoTienPhat = nudSoTienPhat.Value
            };

            string ketQua = _bll.GhiNhan(vp);

            if (string.IsNullOrEmpty(ketQua))
            {
                MessageBox.Show("Ghi nhận vi phạm thành công!");
                LoadData();
            }
            else
            {
                MessageBox.Show(ketQua, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXuLy_Click(object sender, EventArgs e)
        {
            if (_maViPhamDangChon <= 0)
            {
                MessageBox.Show("Vui lòng chọn vi phạm cần xử lý!");
                return;
            }

            string ketQua = _bll.XuLy(_maViPhamDangChon, txtHinhThucXuLy.Text.Trim());

            if (string.IsNullOrEmpty(ketQua))
            {
                MessageBox.Show("Xử lý vi phạm thành công!");
                LoadData();
            }
            else
            {
                MessageBox.Show(ketQua, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvDanhSach.Rows[e.RowIndex];

            _maViPhamDangChon = Convert.ToInt32(row.Cells["MaViPham"].Value);

            txtMaViPham.Text = row.Cells["MaViPham"].Value.ToString();
            txtMaSinhVien.Text = row.Cells["MaSV"].Value.ToString();
            txtLoiViPham.Text = row.Cells["LoiViPham"].Value.ToString();
            txtHinhThucXuLy.Text = row.Cells["HinhThucXuLy"].Value?.ToString();
            nudSoTienPhat.Value = Convert.ToDecimal(row.Cells["SoTienPhat"].Value);
            dtpNgayViPham.Value = Convert.ToDateTime(row.Cells["NgayViPham"].Value);
            txtTrangThai.Text = row.Cells["TrangThai"].Value.ToString();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelHelper.ExportToExcel(dgvDanhSach, "DanhSachViPham");
                MessageBox.Show("Xuất Excel thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất Excel: " + ex.Message);
            }
        }
    }
}
