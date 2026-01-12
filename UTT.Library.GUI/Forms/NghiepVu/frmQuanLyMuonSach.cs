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
            LoadData();
            LoadComboBoxes();
        }

        private void LoadData()
        {
            dgvDanhSach.DataSource = _bll.LayDanhSach();
            ResetInput();
        }

        private void LoadComboBoxes()
        {
            DataTable dtThe = _db.GetDataTable("SELECT MaThe FROM THETHUVIEN WHERE TrangThai = N'Hoạt động'");
            cboThe.DataSource = dtThe;
            cboThe.DisplayMember = "MaThe";
            cboThe.ValueMember = "MaThe";
            cboThe.SelectedIndex = -1;

            DataTable dtNV = _db.GetDataTable("SELECT MaNV, HoTen FROM NHANVIEN");
            cboNhanVien.DataSource = dtNV;
            cboNhanVien.DisplayMember = "HoTen";
            cboNhanVien.ValueMember = "MaNV";
            cboNhanVien.SelectedIndex = -1;
        }

        private void ResetInput()
        {
            txtMaPhieuMuon.Clear();
            txtMaSach.Clear();
            txtGhiChu.Clear();
            dtpNgayMuon.Value = DateTime.Now;
            dtpHanTra.Value = DateTime.Now.AddDays(30);
            cboThe.SelectedIndex = -1;
            cboNhanVien.SelectedIndex = -1;
            if (cboTrangThai.Items.Count > 0)
                cboTrangThai.SelectedIndex = 0;
            txtMaPhieuMuon.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidationHelper.IsRequired(txtMaPhieuMuon, "Mã phiếu mượn")) return;
            if (!ValidationHelper.IsRequired(txtMaSach, "Mã sách")) return;

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

            List<int> dsMaSach = new List<int>();
            string[] arrMaSach = txtMaSach.Text.Split(new char[] { ',', ' ', ';' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string ms in arrMaSach)
            {
                int maSach;
                if (int.TryParse(ms.Trim(), out maSach) && maSach > 0)
                {
                    if (!dsMaSach.Contains(maSach))
                        dsMaSach.Add(maSach);
                }
                else
                {
                    MessageBox.Show("Mã sách phải là số nguyên dương! Lỗi tại: " + ms);
                    txtMaSach.Focus();
                    return;
                }
            }

            if (dsMaSach.Count == 0)
            {
                MessageBox.Show("Vui lòng nhập ít nhất 1 mã sách!");
                txtMaSach.Focus();
                return;
            }

            DTO_PhieuMuon pm = new DTO_PhieuMuon
            {
                MaPhieuMuon = txtMaPhieuMuon.Text.Trim(),
                MaThe = cboThe.SelectedValue.ToString(),
                MaNV = cboNhanVien.SelectedValue.ToString(),
                NgayMuon = dtpNgayMuon.Value,
                HanTra = dtpHanTra.Value,
                TrangThai = cboTrangThai.SelectedItem.ToString(),
                GhiChu = txtGhiChu.Text.Trim()
            };

            string ketQua = _bll.LapPhieuMuon(pm, dsMaSach);

            if (string.IsNullOrEmpty(ketQua))
            {
                MessageBox.Show("Thêm phiếu mượn thành công.");
                LoadData();
            }
            else
            {
                MessageBox.Show(ketQua);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelHelper.ExportToExcel(dgvDanhSach, "DanhSachPhieuMuon");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất file: " + ex.Message);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string key = txtTimKiem.Text.Trim();
            if (string.IsNullOrEmpty(key))
            {
                LoadData();
                return;
            }

            dgvDanhSach.DataSource = _bll.TimKiem(key);
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDanhSach.Rows[e.RowIndex];
                txtMaPhieuMuon.Text = row.Cells["MaPhieuMuon"].Value.ToString();

                if (row.Cells["MaThe"].Value != DBNull.Value)
                    cboThe.SelectedValue = row.Cells["MaThe"].Value.ToString();

                if (row.Cells["MaNV"].Value != DBNull.Value)
                    cboNhanVien.SelectedValue = row.Cells["MaNV"].Value.ToString();

                dtpNgayMuon.Value = Convert.ToDateTime(row.Cells["NgayMuon"].Value);
                dtpHanTra.Value = Convert.ToDateTime(row.Cells["HanTra"].Value);
                cboTrangThai.SelectedItem = row.Cells["TrangThai"].Value.ToString();
                txtGhiChu.Text = row.Cells["GhiChu"].Value?.ToString() ?? "";

                if (row.Cells["MaSach"].Value != DBNull.Value)
                    txtMaSach.Text = row.Cells["MaSach"].Value.ToString();
            }
        }
    }
}
