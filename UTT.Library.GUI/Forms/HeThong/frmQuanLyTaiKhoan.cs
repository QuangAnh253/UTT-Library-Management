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
        }

        private void frmQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadComboQuyen();
            LoadData();
        }

        private void LoadData()
        {
            dgvDanhSach.DataSource = _bll.LayDanhSach();
            ResetInput();
        }

        private void LoadComboQuyen()
        {
            cboQuyen.Items.Clear();
            cboQuyen.Items.Add("1 - Admin");
            cboQuyen.Items.Add("2 - Thủ thư");
            cboQuyen.Items.Add("3 - Sinh viên");
            cboQuyen.SelectedIndex = 1;

            cboTrangThai.Items.Clear();
            cboTrangThai.Items.Add("Hoạt động");
            cboTrangThai.Items.Add("Khóa");
            cboTrangThai.SelectedIndex = 0;
        }

        private void ResetInput()
        {
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
            dtpNgayTao.Value = DateTime.Now;
            if (cboQuyen.Items.Count > 0)
                cboQuyen.SelectedIndex = 1;
            if (cboTrangThai.Items.Count > 0)
                cboTrangThai.SelectedIndex = 0;
            txtTenDangNhap.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidationHelper.IsRequired(txtTenDangNhap, "Tên đăng nhập")) return;
            if (!ValidationHelper.IsRequired(txtMatKhau, "Mật khẩu")) return;

            int quyen = int.Parse(cboQuyen.SelectedItem.ToString().Substring(0, 1));
            bool trangThai = cboTrangThai.SelectedIndex == 0;

            DTO_TaiKhoan tk = new DTO_TaiKhoan
            {
                TenDangNhap = txtTenDangNhap.Text.Trim(),
                MatKhau = txtMatKhau.Text.Trim(),
                Quyen = quyen,
                TrangThai = trangThai,
                NgayTao = dtpNgayTao.Value
            };

            string ketQua = _bll.Them(tk);

            if (string.IsNullOrEmpty(ketQua))
            {
                MessageBox.Show("Thêm tài khoản thành công");
                LoadData();
            }
            else
            {
                MessageBox.Show(ketQua);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!ValidationHelper.IsRequired(txtTenDangNhap, "Tên đăng nhập")) return;
            if (!ValidationHelper.IsRequired(txtMatKhau, "Mật khẩu")) return;

            int quyen = int.Parse(cboQuyen.SelectedItem.ToString().Substring(0, 1));
            bool trangThai = cboTrangThai.SelectedIndex == 0;

            DTO_TaiKhoan tk = new DTO_TaiKhoan
            {
                TenDangNhap = txtTenDangNhap.Text.Trim(),
                MatKhau = txtMatKhau.Text.Trim(),
                Quyen = quyen,
                TrangThai = trangThai
            };

            string ketQua = _bll.Sua(tk);

            if (string.IsNullOrEmpty(ketQua))
            {
                MessageBox.Show("Cập nhật thành công");
                LoadData();
            }
            else
            {
                MessageBox.Show(ketQua);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!ValidationHelper.IsRequired(txtTenDangNhap, "Tên đăng nhập")) return;

            if (ValidationHelper.ConfirmDelete())
            {
                string ketQua = _bll.Xoa(txtTenDangNhap.Text.Trim());

                if (string.IsNullOrEmpty(ketQua))
                {
                    MessageBox.Show("Xóa thành công.");
                    LoadData();
                }
                else
                {
                    MessageBox.Show(ketQua);
                }
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
                ExcelHelper.ExportToExcel(dgvDanhSach, "DanhSachTaiKhoan");
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
                txtTenDangNhap.Text = row.Cells["TenDangNhap"].Value.ToString();
                txtMatKhau.Text = row.Cells["MatKhau"].Value.ToString();

                int quyen = Convert.ToInt32(row.Cells["Quyen"].Value);
                cboQuyen.SelectedIndex = quyen - 1;

                bool trangThai = Convert.ToBoolean(row.Cells["TrangThai"].Value);
                cboTrangThai.SelectedIndex = trangThai ? 0 : 1;

                dtpNgayTao.Value = Convert.ToDateTime(row.Cells["NgayTao"].Value);
            }
        }
    }
}
