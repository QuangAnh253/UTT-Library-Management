using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using UTT.Library.BLL.Services;
using UTT.Library.DAL.Database;
using UTT.Library.GUI.Utilities;

namespace UTT.Library.GUI.Forms.NghiepVu
{
    public partial class frmQuanLyTraSach : Form
    {
        private BLL_PhieuMuon _bll = new BLL_PhieuMuon();
        private DatabaseHelper _db = new DatabaseHelper();

        public frmQuanLyTraSach()
        {
            InitializeComponent();
        }

        private void frmQuanLyTraSach_Load_1(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            string sql = @"SELECT CT.ID, CT.MaPhieuMuon, CT.MaSach, S.TenSach, PM.MaThe, PM.NgayMuon, PM.HanTra, CT.NgayTra, CT.TienPhat, CT.TinhTrangKhiTra, CT.GhiChu
                        FROM CT_PHIEUMUON CT
                        INNER JOIN PHIEUMUON PM ON CT.MaPhieuMuon = PM.MaPhieuMuon
                        INNER JOIN SACH S ON CT.MaSach = S.MaSach
                        WHERE CT.NgayTra IS NULL
                        ORDER BY PM.HanTra ASC";

            dgvDanhSach.DataSource = _db.GetDataTable(sql);
            ResetInput();
        }

        private void ResetInput()
        {
            txtID.Clear();
            txtMaPhieuMuon.Clear();
            txtMaSach.Clear();
            txtTienPhat.Text = "0";
            txtTinhTrangKhiTra.Clear();
            txtGhiChu.Clear();
            dtpNgayTra.Value = DateTime.Now;
            txtID.Focus();
        }

        private void btnTraSach_Click(object sender, EventArgs e)
        {
            if (!ValidationHelper.IsRequired(txtID, "ID chi tiết")) return;

            int id;
            if (!int.TryParse(txtID.Text.Trim(), out id) || id <= 0)
            {
                MessageBox.Show("ID không hợp lệ!");
                txtID.Focus();
                return;
            }

            decimal tienPhat = 0;
            if (!string.IsNullOrWhiteSpace(txtTienPhat.Text))
            {
                if (!decimal.TryParse(txtTienPhat.Text.Trim(), out tienPhat) || tienPhat < 0)
                {
                    MessageBox.Show("Tiền phạt phải là số >= 0!");
                    txtTienPhat.Focus();
                    return;
                }
            }

            string ketQua = _bll.TraSach(
                id,
                dtpNgayTra.Value,
                tienPhat,
                txtTinhTrangKhiTra.Text.Trim(),
                txtGhiChu.Text.Trim()
            );

            if (string.IsNullOrEmpty(ketQua))
            {
                MessageBox.Show("Trả sách thành công.");
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
                ExcelHelper.ExportToExcel(dgvDanhSach, "DanhSachTraSach");
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

            string sql = @"SELECT CT.ID,  CT.MaPhieuMuon, CT.MaSach, S.TenSach, PM.MaThe, PM.NgayMuon, PM.HanTra, CT.NgayTra,  CT.TienPhat, CT.TinhTrangKhiTra,  CT.GhiChu
                        FROM CT_PHIEUMUON CT
                        INNER JOIN PHIEUMUON PM ON CT.MaPhieuMuon = PM.MaPhieuMuon
                        INNER JOIN SACH S ON CT.MaSach = S.MaSach
                        WHERE CT.NgayTra IS NULL 
                        AND (CT.MaPhieuMuon LIKE @Key OR CAST(CT.MaSach AS VARCHAR) LIKE @Key OR PM.MaThe LIKE @Key)
                        ORDER BY PM.HanTra ASC";

            System.Data.SqlClient.SqlParameter[] param = {
                new System.Data.SqlClient.SqlParameter("@Key", "%" + key + "%")
            };
            dgvDanhSach.DataSource = _db.GetDataTable(sql, param);
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDanhSach.Rows[e.RowIndex];

                txtID.Text = row.Cells["ID"].Value.ToString();
                txtMaPhieuMuon.Text = row.Cells["MaPhieuMuon"].Value.ToString();
                txtMaSach.Text = row.Cells["MaSach"].Value.ToString();

                dtpNgayTra.Value = DateTime.Now;

                txtTienPhat.Text = row.Cells["TienPhat"].Value?.ToString() ?? "0";
                txtTinhTrangKhiTra.Text = row.Cells["TinhTrangKhiTra"].Value?.ToString() ?? "";
                txtGhiChu.Text = row.Cells["GhiChu"].Value?.ToString() ?? "";
            }
        }
    }
}
