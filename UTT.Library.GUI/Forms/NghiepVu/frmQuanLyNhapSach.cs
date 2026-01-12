using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using UTT.Library.BLL.Services;
using UTT.Library.DAL.Database;
using UTT.Library.DTO;

namespace UTT.Library.GUI.Forms.NghiepVu
{
    public partial class frmQuanLyNhapSach : Form
    {
        private readonly BLL_PhieuNhap _bll = new BLL_PhieuNhap();
        private readonly DatabaseHelper _db = new DatabaseHelper();

        public frmQuanLyNhapSach()
        {
            InitializeComponent();
        }

        private void frmQuanLyNhapSach_Load(object sender, EventArgs e)
        {
            dtpNgayNhap.Value = DateTime.Now;

            dgvChiTiet.ReadOnly = false;
            dgvChiTiet.AllowUserToAddRows = false;

            LoadComboNCC();
            LoadComboNhanVien();

            if (dgvChiTiet.Rows.Count == 0)
                dgvChiTiet.Rows.Add();
        }

        private void LoadComboNCC()
        {
            DataTable dt = _db.GetDataTable("SELECT MaNCC, TenNCC FROM NHACUNGCAP");

            cboNCC.DataSource = dt;
            cboNCC.DisplayMember = "TenNCC";
            cboNCC.ValueMember = "MaNCC";
            cboNCC.SelectedIndex = -1;
        }

        private void LoadComboNhanVien()
        {
            DataTable dt = _db.GetDataTable("SELECT MaNV, HoTen FROM NHANVIEN");

            cboNhanVien.DataSource = dt;
            cboNhanVien.DisplayMember = "HoTen";
            cboNhanVien.ValueMember = "MaNV";
            cboNhanVien.SelectedIndex = -1;
        }

        private void btnThemDong_Click(object sender, EventArgs e)
        {
            dgvChiTiet.Rows.Add();
        }

        private void btnXoaDong_Click(object sender, EventArgs e)
        {
            if (dgvChiTiet.CurrentRow == null) return;
            if (dgvChiTiet.CurrentRow.IsNewRow) return;

            dgvChiTiet.Rows.RemoveAt(dgvChiTiet.CurrentRow.Index);
        }

        private void btnLuuPhieu_Click(object sender, EventArgs e)
        {
            string maPhieu = txtMaPhieuNhap.Text.Trim();

            if (string.IsNullOrWhiteSpace(maPhieu))
            {
                MessageBox.Show("Vui lòng nhập mã phiếu nhập!");
                txtMaPhieuNhap.Focus();
                return;
            }

            if (cboNCC.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp!");
                cboNCC.Focus();
                return;
            }

            if (cboNhanVien.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên!");
                cboNhanVien.Focus();
                return;
            }

            DTO_PhieuNhap pn = new DTO_PhieuNhap
            {
                MaPhieuNhap = maPhieu,
                MaNCC = cboNCC.SelectedValue.ToString(),
                MaNV = cboNhanVien.SelectedValue.ToString(),
                NgayNhap = dtpNgayNhap.Value,
                TongTien = 0,
                GhiChu = ""
            };

            List<DTO_CTPhieuNhap> ds = new List<DTO_CTPhieuNhap>();

            foreach (DataGridViewRow row in dgvChiTiet.Rows)
            {
                if (row.IsNewRow) continue;

                string maSachText = row.Cells["colMaSach"].Value == null ? "" : row.Cells["colMaSach"].Value.ToString().Trim();
                string soLuongText = row.Cells["colSoLuong"].Value == null ? "" : row.Cells["colSoLuong"].Value.ToString().Trim();
                string donGiaText = row.Cells["colDonGia"].Value == null ? "" : row.Cells["colDonGia"].Value.ToString().Trim();

                if (string.IsNullOrWhiteSpace(maSachText) &&
                    string.IsNullOrWhiteSpace(soLuongText) &&
                    string.IsNullOrWhiteSpace(donGiaText))
                {
                    continue;
                }

                int maSach;
                int soLuong;
                decimal donGia;

                if (!int.TryParse(maSachText, out maSach))
                {
                    MessageBox.Show("Mã sách phải là số (dòng chi tiết).");
                    return;
                }

                if (!int.TryParse(soLuongText, out soLuong) || soLuong <= 0)
                {
                    MessageBox.Show("Số lượng phải là số > 0 (dòng chi tiết).");
                    return;
                }

                if (!decimal.TryParse(donGiaText, NumberStyles.Number, CultureInfo.InvariantCulture, out donGia) &&
                    !decimal.TryParse(donGiaText, NumberStyles.Number, CultureInfo.CurrentCulture, out donGia))
                {
                    MessageBox.Show("Đơn giá không hợp lệ (dòng chi tiết).");
                    return;
                }

                ds.Add(new DTO_CTPhieuNhap
                {
                    MaPhieuNhap = maPhieu,
                    MaSach = maSach,
                    SoLuong = soLuong,
                    DonGia = donGia,
                    ThanhTien = soLuong * donGia
                });
            }

            if (ds.Count == 0)
            {
                MessageBox.Show("Vui lòng nhập ít nhất 1 dòng chi tiết!");
                return;
            }

            string ketQua = _bll.LuuPhieuNhap(pn, ds);

            if (string.IsNullOrEmpty(ketQua))
            {
                MessageBox.Show("Lưu phiếu nhập thành công!");
                ResetForm();
            }
            else
            {
                MessageBox.Show(ketQua);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            txtMaPhieuNhap.Clear();
            dtpNgayNhap.Value = DateTime.Now;

            cboNCC.SelectedIndex = -1;
            cboNhanVien.SelectedIndex = -1;

            dgvChiTiet.Rows.Clear();
            dgvChiTiet.Rows.Add();

            txtMaPhieuNhap.Focus();
        }
    }
}