using System;
using System.Windows.Forms;
using UTT.Library.BLL.Services;
using UTT.Library.DTO;
using UTT.Library.GUI.Utilities;

namespace UTT.Library.GUI.Forms.DanhMuc
{
    public partial class frmQuanLyTacGia : Form
    {
        private BLL_TacGia _bll = new BLL_TacGia();

        public frmQuanLyTacGia()
        {
            InitializeComponent();
        }

        private void frmQuanLyTacGia_Load(object sender, EventArgs e)
        {
            LoadData();
            dgvDanhSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDanhSach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void LoadData()
        {
            dgvDanhSach.DataSource = _bll.LayDanhSach();
            ResetInput();
        }

        private void ResetInput()
        {
            txtMa.Enabled = true;
            txtMa.Clear();
            txtTen.Clear();
            txtGhiChu.Clear();
            txtMa.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidationHelper.IsRequired(txtMa, "Mã tác giả")) return;
            if (!ValidationHelper.IsRequired(txtTen, "Tên tác giả")) return;

            DTO_TacGia tg = new DTO_TacGia(txtMa.Text, txtTen.Text, txtGhiChu.Text);
            string ketQua = _bll.Them(tg);

            if (string.IsNullOrEmpty(ketQua))
            {
                MessageBox.Show("Thêm mới thành công!", "Thông báo");
                LoadData();
            }
            else
            {
                MessageBox.Show(ketQua, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMa.Enabled)
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa!");
                return;
            }

            if (!ValidationHelper.IsRequired(txtTen, "Tên tác giả")) return;

            DTO_TacGia tg = new DTO_TacGia(txtMa.Text, txtTen.Text, txtGhiChu.Text);
            string ketQua = _bll.Sua(tg);

            if (string.IsNullOrEmpty(ketQua))
            {
                MessageBox.Show("Cập nhật thành công!");
                LoadData();
            }
            else
            {
                MessageBox.Show(ketQua, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMa.Enabled || string.IsNullOrEmpty(txtMa.Text))
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!");
                return;
            }

            if (ValidationHelper.ConfirmDelete())
            {
                string ketQua = _bll.Xoa(txtMa.Text);
                if (string.IsNullOrEmpty(ketQua))
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadData();
                }
                else
                {
                    MessageBox.Show(ketQua, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string key = txtTimKiem.Text.Trim();
            dgvDanhSach.DataSource = _bll.TimKiem(key);
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDanhSach.Rows[e.RowIndex];
                txtMa.Text = row.Cells["MaTacGia"].Value.ToString();
                txtTen.Text = row.Cells["TenTacGia"].Value.ToString();
                txtGhiChu.Text = row.Cells["GhiChu"].Value?.ToString() ?? "";
                txtMa.Enabled = false;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelHelper.ExportToExcel(dgvDanhSach, "DanhSachTacGia");
                MessageBox.Show("Xuất Excel thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message);
            }
        }
    }
}
