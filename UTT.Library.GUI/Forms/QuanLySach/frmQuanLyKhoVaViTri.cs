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

namespace UTT.Library.GUI.Forms.QuanLySach
{
    public partial class frmQuanLyKhoVaViTri : Form
    {
        private BLL_KhoSach _bll = new BLL_KhoSach();
        
        public frmQuanLyKhoVaViTri()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
        }
        
        private void frmQuanLyKho_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            LoadData();
        }

        // ================= LOAD DATA =================

        private void LoadData()
        {
            dgvDanhSach.DataSource = _bll.LayDanhSach();
            ResetInput();
        }

        private void ResetInput()
        {
            txtMaKho.Enabled = true;
            txtMaKho.Clear();
            txtTenKho.Clear();
            txtSucChua.Clear();
            txtMoTa.Clear();
            txtMaKho.Focus();
        }

        // ================= CRUD =================

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidationHelper.IsRequired(txtMaKho, "Mã kho")) return;
            if (!ValidationHelper.IsRequired(txtTenKho, "Tên kho")) return;

            int sucChua = 0;
            if (!string.IsNullOrWhiteSpace(txtSucChua.Text))
            {
                if (!int.TryParse(txtSucChua.Text.Trim(), out sucChua) || sucChua < 0)
                {
                    MessageBox.Show("Sức chứa phải là số nguyên dương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSucChua.Focus();
                    return;
                }
            }

            DTO_Kho kho = new DTO_Kho(
                txtMaKho.Text.Trim(),
                txtTenKho.Text.Trim(),
                sucChua,
                txtMoTa.Text.Trim()
            );

            string kq = _bll.Them(kho);
            if (string.IsNullOrEmpty(kq))
            {
                MessageBox.Show("Thêm kho thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show(kq, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaKho.Enabled)
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidationHelper.IsRequired(txtTenKho, "Tên kho")) return;

            int sucChua = 0;
            if (!string.IsNullOrWhiteSpace(txtSucChua.Text))
            {
                if (!int.TryParse(txtSucChua.Text.Trim(), out sucChua) || sucChua < 0)
                {
                    MessageBox.Show("Sức chứa phải là số nguyên dương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSucChua.Focus();
                    return;
                }
            }

            DTO_Kho kho = new DTO_Kho(
                txtMaKho.Text.Trim(),
                txtTenKho.Text.Trim(),
                sucChua,
                txtMoTa.Text.Trim()
            );

            string kq = _bll.Sua(kho);
            if (string.IsNullOrEmpty(kq))
            {
                MessageBox.Show("Cập nhật kho thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show(kq, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaKho.Enabled || string.IsNullOrEmpty(txtMaKho.Text))
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ValidationHelper.ConfirmDelete())
            {
                string kq = _bll.Xoa(txtMaKho.Text.Trim());
                if (string.IsNullOrEmpty(kq))
                {
                    MessageBox.Show("Xóa kho thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        // ================= GRID CLICK =================

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDanhSach.Rows[e.RowIndex];
                txtMaKho.Text = row.Cells["MaKho"].Value?.ToString();
                txtTenKho.Text = row.Cells["TenKho"].Value?.ToString();
                txtSucChua.Text = row.Cells["SucChua"].Value?.ToString();
                txtMoTa.Text = row.Cells["MoTa"].Value?.ToString();
                txtMaKho.Enabled = false;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelHelper.ExportToExcel(dgvDanhSach, "DanhSachKho");
                MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
