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

namespace UTT.Library.GUI.Forms.NghiepVu
{
    public partial class frmQuanLyDeXuatMuaSach : Form
    {
        private BLL_DeXuatMuaSach _bll = new BLL_DeXuatMuaSach();

        public frmQuanLyDeXuatMuaSach()
        {
            InitializeComponent();
        }

        private void frmQuanLyDeXuatMuaSach_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dgvDanhSach.DataSource = _bll.LayDanhSach();
            ResetInput();
        }

        private void ResetInput()
        {
            txtMaDeXuat.Enabled = false;
            txtMaDeXuat.Clear();
            txtTenSach.Clear();
            txtTacGia.Clear();
            txtNhaXuatBan.Clear();
            txtSoLuong.Clear();
            txtGiaDuKien.Clear();
            txtGhiChu.Clear();
            dtpNgayDeXuat.Value = DateTime.Now;
            cboTrangThai.SelectedIndex = 0;
            txtTenSach.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidationHelper.IsRequired(txtTenSach, "Tên sách")) return;
            if (!ValidationHelper.IsRequired(txtSoLuong, "Số lượng")) return;

            int soLuong;
            if (!int.TryParse(txtSoLuong.Text, out soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên dương!");
                txtSoLuong.Focus();
                return;
            }

            decimal giaDuKien = 0;
            if (!string.IsNullOrWhiteSpace(txtGiaDuKien.Text))
            {
                if (!decimal.TryParse(txtGiaDuKien.Text, out giaDuKien) || giaDuKien < 0)
                {
                    MessageBox.Show("Giá dự kiến phải là số >= 0!");
                    txtGiaDuKien.Focus();
                    return;
                }
            }

            DTO_DeXuatMuaSach dx = new DTO_DeXuatMuaSach
            {
                TenSach = txtTenSach.Text,
                TacGia = txtTacGia.Text,
                NhaXuatBan = txtNhaXuatBan.Text,
                SoLuong = soLuong,
                GiaDuKien = giaDuKien,
                NgayDeXuat = dtpNgayDeXuat.Value,
                TrangThai = cboTrangThai.SelectedItem.ToString(),
                GhiChu = txtGhiChu.Text
            };

            string ketQua = _bll.Them(dx);

            if (string.IsNullOrEmpty(ketQua))
            {
                MessageBox.Show("Thêm đề xuất mua sách thành công.");
                LoadData();
            }
            else
            {
                MessageBox.Show(ketQua);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaDeXuat.Text))
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa!");
                return;
            }

            if (!ValidationHelper.IsRequired(txtTenSach, "Tên sách")) return;
            if (!ValidationHelper.IsRequired(txtSoLuong, "Số lượng")) return;

            int soLuong;
            if (!int.TryParse(txtSoLuong.Text, out soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên dương!");
                txtSoLuong.Focus();
                return;
            }

            decimal giaDuKien = 0;
            if (!string.IsNullOrWhiteSpace(txtGiaDuKien.Text))
            {
                if (!decimal.TryParse(txtGiaDuKien.Text, out giaDuKien) || giaDuKien < 0)
                {
                    MessageBox.Show("Giá dự kiến phải là số >= 0!");
                    txtGiaDuKien.Focus();
                    return;
                }
            }

            DTO_DeXuatMuaSach dx = new DTO_DeXuatMuaSach
            {
                MaDeXuat = int.Parse(txtMaDeXuat.Text),
                TenSach = txtTenSach.Text,
                TacGia = txtTacGia.Text,
                NhaXuatBan = txtNhaXuatBan.Text,
                SoLuong = soLuong,
                GiaDuKien = giaDuKien,
                NgayDeXuat = dtpNgayDeXuat.Value,
                TrangThai = cboTrangThai.SelectedItem.ToString(),
                GhiChu = txtGhiChu.Text
            };

            string ketQua = _bll.Sua(dx);

            if (string.IsNullOrEmpty(ketQua))
            {
                MessageBox.Show("Cập nhật thành công.");
                LoadData();
            }
            else
            {
                MessageBox.Show(ketQua);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaDeXuat.Text))
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!");
                return;
            }

            if (ValidationHelper.ConfirmDelete())
            {
                string ketqua = _bll.Xoa(int.Parse(txtMaDeXuat.Text));

                if (string.IsNullOrEmpty(ketqua))
                {
                    MessageBox.Show("Xóa thành công.");
                    LoadData();
                }
                else
                {
                    MessageBox.Show(ketqua);
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
                ExcelHelper.ExportToExcel(dgvDanhSach, "DanhSachDeXuatMuaSach");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất file: " + ex.Message);
            }
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
                txtMaDeXuat.Text = row.Cells["MaDeXuat"].Value.ToString();
                txtTenSach.Text = row.Cells["TenSach"].Value.ToString();
                txtTacGia.Text = row.Cells["TacGia"].Value?.ToString() ?? "";
                txtNhaXuatBan.Text = row.Cells["NhaXuatBan"].Value?.ToString() ?? "";
                txtSoLuong.Text = row.Cells["SoLuong"].Value.ToString();
                txtGiaDuKien.Text = row.Cells["GiaDuKien"].Value.ToString();
                dtpNgayDeXuat.Value = Convert.ToDateTime(row.Cells["NgayDeXuat"].Value);
                cboTrangThai.SelectedItem = row.Cells["TrangThai"].Value.ToString();
                txtGhiChu.Text = row.Cells["GhiChu"].Value?.ToString() ?? "";
            }
        }
    }
}
