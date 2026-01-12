using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using UTT.Library.BLL.Services;
using UTT.Library.GUI.Utilities;

namespace UTT.Library.GUI.Forms.NghiepVu
{
    public partial class frmQuanLyTraSach : Form
    {
        private readonly BLL_PhieuMuon _bll = new BLL_PhieuMuon();

        public frmQuanLyTraSach()
        {
            InitializeComponent();
        }

        private void frmQuanLyTraSach_Load(object sender, EventArgs e)
        {
            dgvChiTiet.AutoGenerateColumns = false;
            dgvChiTiet.ReadOnly = true;
            dgvChiTiet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChiTiet.MultiSelect = false;

            ResetTraInput();
        }

        private void btnTaiChiTiet_Click(object sender, EventArgs e)
        {
            if (ValidationHelper.IsRequired(txtMaPhieuMuon, "Mã phiếu mượn") == false)
                return;

            string maPhieuMuon = txtMaPhieuMuon.Text.Trim();

            DataTable dt = _bll.LayChiTiet(maPhieuMuon);
            dgvChiTiet.DataSource = dt;

            ResetTraInput();

            if (dt != null && dt.Rows.Count > 0 && dgvChiTiet.Rows.Count > 0)
            {
                dgvChiTiet.Rows[0].Selected = true;
                FillTraInputFromCurrentRow();
            }
        }

        private void dgvChiTiet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FillTraInputFromCurrentRow();
        }

        private void dgvChiTiet_SelectionChanged(object sender, EventArgs e)
        {
            FillTraInputFromCurrentRow();
        }

        private void FillTraInputFromCurrentRow()
        {
            if (dgvChiTiet.CurrentRow == null)
                return;

            DataRowView drv = dgvChiTiet.CurrentRow.DataBoundItem as DataRowView;
            if (drv == null)
                return;

            if (drv.Row.Table.Columns.Contains("ID") == false)
                return;

            object idObj = drv["ID"];
            if (idObj == null || idObj == DBNull.Value)
                return;

            txtID.Text = idObj.ToString();

            if (drv.Row.Table.Columns.Contains("NgayTra"))
            {
                object ngayTraObj = drv["NgayTra"];
                if (ngayTraObj == null || ngayTraObj == DBNull.Value)
                    dtpNgayTra.Value = DateTime.Now;
                else
                    dtpNgayTra.Value = Convert.ToDateTime(ngayTraObj);
            }

            if (drv.Row.Table.Columns.Contains("TienPhat"))
            {
                object tienPhatObj = drv["TienPhat"];
                txtTienPhat.Text = (tienPhatObj == null || tienPhatObj == DBNull.Value) ? "0" : tienPhatObj.ToString();
            }

            if (drv.Row.Table.Columns.Contains("TinhTrangKhiTra"))
            {
                object ttObj = drv["TinhTrangKhiTra"];
                txtTinhTrangKhiTra.Text = (ttObj == null || ttObj == DBNull.Value) ? "" : ttObj.ToString();
            }

            if (drv.Row.Table.Columns.Contains("GhiChu"))
            {
                object gcObj = drv["GhiChu"];
                txtGhiChu.Text = (gcObj == null || gcObj == DBNull.Value) ? "" : gcObj.ToString();
            }
        }

        private void btnTraSach_Click(object sender, EventArgs e)
        {
            if (ValidationHelper.IsRequired(txtMaPhieuMuon, "Mã phiếu mượn") == false)
                return;

            if (ValidationHelper.IsRequired(txtID, "ID chi tiết") == false)
                return;

            int id;
            if (int.TryParse(txtID.Text.Trim(), out id) == false || id <= 0)
            {
                MessageBox.Show("ID không hợp lệ. Vui lòng ấn chọn lại 1 dòng");
                return;
            }

            decimal tienPhat;
            string tienPhatText = (txtTienPhat.Text ?? "").Trim();
            if (string.IsNullOrEmpty(tienPhatText))
                tienPhatText = "0";

            bool parseOk =
                decimal.TryParse(tienPhatText, NumberStyles.Number, CultureInfo.CurrentCulture, out tienPhat) ||
                decimal.TryParse(tienPhatText, NumberStyles.Number, CultureInfo.InvariantCulture, out tienPhat);

            if (parseOk == false || tienPhat < 0)
            {
                MessageBox.Show("Tiền phạt không hợp lệ. Vui lòng nhập xố nguyên");
                return;
            }

            string tinhTrang = txtTinhTrangKhiTra.Text.Trim();
            string ghiChu = txtGhiChu.Text.Trim();

            string ketQua = _bll.TraSach(id, dtpNgayTra.Value, tienPhat, tinhTrang, ghiChu);

            if (string.IsNullOrEmpty(ketQua))
            {
                MessageBox.Show("Trả sách thành công");
                TaiLaiChiTiet();
            }
            else
            {
                MessageBox.Show(ketQua);
            }
        }

        private void TaiLaiChiTiet()
        {
            string maPhieuMuon = txtMaPhieuMuon.Text.Trim();
            if (string.IsNullOrWhiteSpace(maPhieuMuon))
                return;

            DataTable dt = _bll.LayChiTiet(maPhieuMuon);
            dgvChiTiet.DataSource = dt;

            ResetTraInput();
        }

        private void ResetTraInput()
        {
            txtID.Clear();
            txtTienPhat.Text = "0";
            txtTinhTrangKhiTra.Clear();
            txtGhiChu.Clear();
            dtpNgayTra.Value = DateTime.Now;
        }
    }
}
