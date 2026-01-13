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

namespace UTT.Library.GUI.Forms.HeThong
{
    public partial class frmQuanLyTaiKhoan : Form
    {
        private BLL_TaiKhoan _bll = new BLL_TaiKhoan();

        public frmQuanLyTaiKhoan()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
        }

        private void frmQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            LoadComboBox();
            LoadData();
        }

        private void LoadComboBox()
        {
            cboQuyen.Items.Clear();
            cboQuyen.Items.Add(new { Text = "Admin", Value = 1 });
            cboQuyen.Items.Add(new { Text = "Thủ thư", Value = 2 });
            cboQuyen.Items.Add(new { Text = "Sinh viên", Value = 3 });
            cboQuyen.DisplayMember = "Text";
            cboQuyen.ValueMember = "Value";
            cboQuyen.SelectedIndex = 1; // Mặc định Thủ thư
        }

        private void LoadData()
        {
            dgvDanhSach.DataSource = _bll.LayDanhSach();
            ResetInput();
        }

        private void ResetInput()
        {
            txtTenDangNhap.Enabled = true;
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
            cboQuyen.SelectedIndex = 1;
            chkTrangThai.Checked = true;
            txtTenDangNhap.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidationHelper.IsRequired(txtTenDangNhap, "Tên đăng nhập")) return;
            if (!ValidationHelper.IsRequired(txtMatKhau, "Mật khẩu")) return;

            if (cboQuyen.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn quyền!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dynamic selected = cboQuyen.SelectedItem;

            DTO_TaiKhoan tk = new DTO_TaiKhoan
            {
                TenDangNhap = txtTenDangNhap.Text.Trim(),
                MatKhau = txtMatKhau.Text,
                Quyen = selected.Value,
                TrangThai = chkTrangThai.Checked
            };

            string kq = _bll.Them(tk);
            if (string.IsNullOrEmpty(kq))
            {
                MessageBox.Show("Thêm tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show(kq, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Enabled)
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidationHelper.IsRequired(txtMatKhau, "Mật khẩu")) return;

            dynamic selected = cboQuyen.SelectedItem;

            DTO_TaiKhoan tk = new DTO_TaiKhoan
            {
                TenDangNhap = txtTenDangNhap.Text.Trim(),
                MatKhau = txtMatKhau.Text,
                Quyen = selected.Value,
                TrangThai = chkTrangThai.Checked
            };

            string kq = _bll.Sua(tk);
            if (string.IsNullOrEmpty(kq))
            {
                MessageBox.Show("Cập nhật tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show(kq, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Enabled || string.IsNullOrEmpty(txtTenDangNhap.Text))
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ValidationHelper.ConfirmDelete())
            {
                string kq = _bll.Xoa(txtTenDangNhap.Text.Trim());
                if (string.IsNullOrEmpty(kq))
                {
                    MessageBox.Show("Xóa tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                txtTenDangNhap.Text = row.Cells["TenDangNhap"].Value?.ToString();
                txtMatKhau.Text = row.Cells["MatKhau"].Value?.ToString();

                int quyen = Convert.ToInt32(row.Cells["Quyen"].Value);
                for (int i = 0; i < cboQuyen.Items.Count; i++)
                {
                    dynamic item = cboQuyen.Items[i];
                    if (item.Value == quyen)
                    {
                        cboQuyen.SelectedIndex = i;
                        break;
                    }
                }

                chkTrangThai.Checked = Convert.ToBoolean(row.Cells["TrangThai"].Value);
                txtTenDangNhap.Enabled = false;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelHelper.ExportToExcel(dgvDanhSach, "DanhSachTaiKhoan");
                MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
