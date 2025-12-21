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

namespace UTT.Library.GUI.Forms.DanhMuc
{
    public partial class frmQuanLyKhoa : Form
    {
        private BLL_Khoa _bll = new BLL_Khoa();

        public frmQuanLyKhoa()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
        }

        private void frmQuanLyKhoa_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            LoadData();
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
            txtMoTa.Clear();
            txtMa.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidationHelper.IsRequired(txtMa, "Mã khoa")) return;
            if (!ValidationHelper.IsRequired(txtTen, "Tên khoa")) return;

            DTO_Khoa k = new DTO_Khoa(txtMa.Text, txtTen.Text, txtMoTa.Text);
            string kq = _bll.Them(k);

            if (string.IsNullOrEmpty(kq))
            {
                MessageBox.Show("Thêm thành công!");
                LoadData();
            }
            else MessageBox.Show(kq, "Lỗi");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMa.Enabled)
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa!");
                return;
            }

            DTO_Khoa k = new DTO_Khoa(txtMa.Text, txtTen.Text, txtMoTa.Text);
            string kq = _bll.Sua(k);

            if (string.IsNullOrEmpty(kq))
            {
                MessageBox.Show("Cập nhật thành công!");
                LoadData();
            }
            else MessageBox.Show(kq, "Lỗi");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMa.Enabled) return;

            if (ValidationHelper.ConfirmDelete())
            {
                string kq = _bll.Xoa(txtMa.Text);
                if (string.IsNullOrEmpty(kq))
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadData();
                }
                else MessageBox.Show(kq, "Lỗi");
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dgvDanhSach.DataSource = _bll.TimKiem(txtTimKiem.Text.Trim());
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow r = dgvDanhSach.Rows[e.RowIndex];
                txtMa.Text = r.Cells["MaKhoa"].Value.ToString();
                txtTen.Text = r.Cells["TenKhoa"].Value.ToString();
                txtMoTa.Text = r.Cells["GhiChu"].Value?.ToString();
                txtMa.Enabled = false;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelHelper.ExportToExcel(dgvDanhSach, "DanhSachKhoa");
                MessageBox.Show("Xuất Excel thành công!", "Thông báo",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message,
                   "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
