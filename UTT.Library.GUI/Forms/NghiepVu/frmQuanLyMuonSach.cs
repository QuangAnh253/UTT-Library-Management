using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using UTT.Library.BLL.Services;
using UTT.Library.DAL.Database;
using UTT.Library.DTO;
using UTT.Library.GUI.Utilities;

namespace UTT.Library.GUI.Forms.NghiepVu
{
    public partial class frmQuanLyMuonSach : Form
    {
        private readonly BLL_PhieuMuon _bll = new BLL_PhieuMuon();
        private readonly DatabaseHelper _db = new DatabaseHelper();

        public frmQuanLyMuonSach()
        {
            InitializeComponent();
        }

        private void frmQuanLyMuonSach_Load(object sender, EventArgs e)
        {
            dtpNgayMuon.Value = DateTime.Now;
            dtpHanTra.Value = DateTime.Now.AddDays(30);

            dgvChiTiet.ReadOnly = false;
            dgvChiTiet.AllowUserToAddRows = false;

            LoadComboThe();
            LoadComboNhanVien();

            if (dgvChiTiet.Rows.Count == 0)
                dgvChiTiet.Rows.Add();
        }

        private void LoadComboThe()
        {
            DataTable dt = _db.GetDataTable("SELECT MaThe FROM THETHUVIEN");
            cboThe.DataSource = dt;
            cboThe.DisplayMember = "MaThe";
            cboThe.ValueMember = "MaThe";
            cboThe.SelectedIndex = -1;
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

        private void btnLapPhieu_Click(object sender, EventArgs e)
        {
            if (!ValidationHelper.IsRequired(txtMaPhieuMuon, "Mã phiếu mượn")) return;

            if (cboThe.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn thẻ thư viện!");
                cboThe.Focus();
                return;
            }

            if (cboNhanVien.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên!");
                cboNhanVien.Focus();
                return;
            }

            if (dtpHanTra.Value < dtpNgayMuon.Value)
            {
                MessageBox.Show("Hạn trả phải lớn hơn hoặc bằng ngày mượn!");
                dtpHanTra.Focus();
                return;
            }

            DTO_PhieuMuon pm = new DTO_PhieuMuon
            {
                MaPhieuMuon = txtMaPhieuMuon.Text.Trim(),
                MaThe = cboThe.SelectedValue.ToString(),
                MaNV = cboNhanVien.SelectedValue.ToString(),
                NgayMuon = dtpNgayMuon.Value,
                HanTra = dtpHanTra.Value,
                TrangThai = "Đang mượn",
                GhiChu = txtGhiChu.Text.Trim()
            };

            List<int> dsMaSach = new List<int>();

            foreach (DataGridViewRow row in dgvChiTiet.Rows)
            {
                if (row.IsNewRow) continue;

                string maSachText = row.Cells["colMaSach"].Value == null ? "" : row.Cells["colMaSach"].Value.ToString().Trim();
                if (string.IsNullOrWhiteSpace(maSachText)) continue;

                int maSach;
                if (!int.TryParse(maSachText, out maSach) || maSach <= 0)
                {
                    MessageBox.Show("Mã sách phải là số > 0!");
                    return;
                }

                if (!dsMaSach.Contains(maSach))
                    dsMaSach.Add(maSach);
            }

            if (dsMaSach.Count == 0)
            {
                MessageBox.Show("Vui lòng nhập ít nhất 1 mã sách để mượn!");
                return;
            }

            string ketQua = _bll.LapPhieuMuon(pm, dsMaSach);

            if (string.IsNullOrEmpty(ketQua))
            {
                MessageBox.Show("Đã tạo phiếu mượn!");
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
            txtMaPhieuMuon.Clear();
            txtGhiChu.Clear();

            dtpNgayMuon.Value = DateTime.Now;
            dtpHanTra.Value = DateTime.Now.AddDays(30);

            cboThe.SelectedIndex = -1;
            cboNhanVien.SelectedIndex = -1;

            dgvChiTiet.Rows.Clear();
            dgvChiTiet.Rows.Add();

            txtMaPhieuMuon.Focus();
        }
    }
}
