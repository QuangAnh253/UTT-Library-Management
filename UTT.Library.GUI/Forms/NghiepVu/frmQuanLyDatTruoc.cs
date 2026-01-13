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
using UTT.Library.GUI.Utilities;

namespace UTT.Library.GUI.Forms.NghiepVu
{
    public partial class frmQuanLyDatTruoc : Form
    {
        private BLL_PhieuDatTruoc _bll = new BLL_PhieuDatTruoc();
        private BLL_DocGia _bllDocGia = new BLL_DocGia();
        private BLL_Sach _bllSach = new BLL_Sach();

        public frmQuanLyDatTruoc()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
        }

        private void frmQuanLyDatTruoc_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            LoadComboBoxes();
            LoadData();
            dtpNgayHetHan.Value = DateTime.Now.AddDays(14); // Mặc định 14 ngày
        }

        // ================= LOAD DATA =================

        private void LoadComboBoxes()
        {
            // Load sinh viên
            cboSinhVien.DataSource = _bllDocGia.LayDanhSach();
            cboSinhVien.DisplayMember = "HoTen";
            cboSinhVien.ValueMember = "MaSV";
            cboSinhVien.SelectedIndex = -1;

            // Load sách
            cboSach.DataSource = _bllSach.LayDanhSach();
            cboSach.DisplayMember = "TenSach";
            cboSach.ValueMember = "MaSach";
            cboSach.SelectedIndex = -1;

            // Trạng thái
            cboTrangThai.SelectedIndex = 0;
        }

        private void LoadData()
        {
            dgvDanhSach.DataSource = _bll.LayDanhSach();
            ResetInput();
        }

        private void ResetInput()
        {
            txtMaPhieu.Clear();
            cboSinhVien.SelectedIndex = -1;
            cboSach.SelectedIndex = -1;
            dtpNgayHetHan.Value = DateTime.Now.AddDays(14);
            cboTrangThai.SelectedIndex = 0;
            cboSinhVien.Enabled = true;
            cboSach.Enabled = true;
        }

        // ================= CRUD =================

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cboSinhVien.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboSach.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maSV = cboSinhVien.SelectedValue.ToString();
            int maSach = Convert.ToInt32(cboSach.SelectedValue);

            string kq = _bll.Them(maSV, maSach, dtpNgayHetHan.Value);
            if (string.IsNullOrEmpty(kq))
            {
                MessageBox.Show("Đặt trước sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show(kq, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaPhieu.Text))
            {
                MessageBox.Show("Vui lòng chọn phiếu cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maPhieu = Convert.ToInt32(txtMaPhieu.Text);
            string trangThai = cboTrangThai.SelectedItem.ToString();

            string kq = _bll.CapNhatTrangThai(maPhieu, trangThai);
            if (string.IsNullOrEmpty(kq))
            {
                MessageBox.Show("Cập nhật trạng thái thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show(kq, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaPhieu.Text))
            {
                MessageBox.Show("Vui lòng chọn phiếu cần hủy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ValidationHelper.ConfirmDelete("Bạn có muốn hủy phiếu này"))
            {
                int maPhieu = Convert.ToInt32(txtMaPhieu.Text);
                string kq = _bll.Xoa(maPhieu);
                if (string.IsNullOrEmpty(kq))
                {
                    MessageBox.Show("Hủy phiếu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            dgvDanhSach.DataSource = _bll.TimKiem(keyword);
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDanhSach.Rows[e.RowIndex];
                txtMaPhieu.Text = row.Cells["MaPhieuDat"].Value?.ToString();
                cboSinhVien.SelectedValue = row.Cells["MaSV"].Value?.ToString();
                cboSach.SelectedValue = row.Cells["MaSach"].Value;

                if (row.Cells["NgayHetHan"].Value != null && row.Cells["NgayHetHan"].Value != DBNull.Value)
                    dtpNgayHetHan.Value = Convert.ToDateTime(row.Cells["NgayHetHan"].Value);

                string trangThai = row.Cells["TrangThai"].Value?.ToString();
                cboTrangThai.SelectedItem = trangThai;

                cboSinhVien.Enabled = false;
                cboSach.Enabled = false;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelHelper.ExportToExcel(dgvDanhSach, "DanhSachDatTruoc");
                MessageBox.Show("Xuất Excel thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
