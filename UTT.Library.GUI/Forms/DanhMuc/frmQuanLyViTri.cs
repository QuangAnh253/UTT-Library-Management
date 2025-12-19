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
    public partial class frmQuanLyViTri : Form
    {
        private BLL_ViTri _bll = new BLL_ViTri();
        private BLL_KhoSach _bllKho = new BLL_KhoSach();
        public frmQuanLyViTri()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
        }

        private void frmQuanLyViTri_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            LoadKho();
            LoadData();
        }
        // ================= LOAD DATA =================

        private void LoadData()
        {
            dgvDanhSach.DataSource = _bll.LayDanhSach();
            ResetInput();
        }

        private void LoadKho()
        {
            cboKho.DataSource = _bllKho.LayDanhSach();
            cboKho.DisplayMember = "TenKho";
            cboKho.ValueMember = "MaKho";
            cboKho.SelectedIndex = -1;
        }

        private void ResetInput()
        {
            txtMa.Enabled = true;
            txtMa.Clear();
            txtTenKe.Clear();
            txtSoTang.Clear();
            cboKho.SelectedIndex = -1;
            txtMa.Focus();
        }

        // ================= CRUD =================

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidationHelper.IsRequired(txtMa, "Mã vị trí")) return;
            if (!ValidationHelper.IsRequired(txtTenKe, "Tên kệ")) return;
            if (cboKho.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn kho!", "Thông báo");
                return;
            }

            DTO_ViTri vt = new DTO_ViTri(
                txtMa.Text,
                txtTenKe.Text,
               string.IsNullOrWhiteSpace(txtSoTang.Text) ? null : txtSoTang.Text.Trim(),

                cboKho.SelectedValue.ToString()
            );

            string kq = _bll.Them(vt);
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

            DTO_ViTri vt = new DTO_ViTri(
                txtMa.Text,
                txtTenKe.Text,
                string.IsNullOrWhiteSpace(txtSoTang.Text) ? null : txtSoTang.Text.Trim(),
                cboKho.SelectedValue.ToString()
            );

            string kq = _bll.Sua(vt);
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

        // ================= GRID CLICK =================

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow r = dgvDanhSach.Rows[e.RowIndex];
                txtMa.Text = r.Cells["MaViTri"].Value.ToString();
                txtTenKe.Text = r.Cells["TenKe"].Value.ToString();
                txtSoTang.Text = r.Cells["SoTang"].Value?.ToString();
                cboKho.SelectedValue = r.Cells["MaKho"].Value.ToString();
                txtMa.Enabled = false;
            }
        }

        private void cboKho_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
