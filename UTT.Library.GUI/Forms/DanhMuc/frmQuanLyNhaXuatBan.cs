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
    public partial class frmQuanLyNhaXuatBan : Form
    {
        private BLL_NhaXuatBan _bll = new BLL_NhaXuatBan();

        public frmQuanLyNhaXuatBan()
        {
            InitializeComponent();
        }

        private void frmQuanLyNhaXuatBan_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dgvDanhSach.DataSource = _bll.Laydanhsach();
            ResetInput();
        }

        private void ResetInput()
        {
            txtMaNXB.Enabled = true;
            txtMaNXB.Clear();
            txtTenNXB.Clear();
            txtDiaChi.Clear();
            txtSDT.Clear();
            txtMaNXB.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidationHelper.IsRequired(txtMaNXB, "Mã NXB")) return;
            if (!ValidationHelper.IsRequired(txtTenNXB, "Tên NXB")) return;

            DTO_NhaXuatBan nxb = new DTO_NhaXuatBan
            {
                MaNXB = txtMaNXB.Text,
                TenNXB = txtTenNXB.Text,
                DiaChi = txtDiaChi.Text,
                SDT = txtSDT.Text
            };

            string ketQua = _bll.Them(nxb);

            if (string.IsNullOrEmpty(ketQua))
            {
                MessageBox.Show("Thêm NXB thành công!", "Thông báo");
                LoadData();
            }
            else
            {
                MessageBox.Show(ketQua, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaNXB.Enabled)
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa!");
                return;
            }

            if (!ValidationHelper.IsRequired(txtTenNXB, "Tên NXB")) return;

            DTO_NhaXuatBan nxb = new DTO_NhaXuatBan
            {
                MaNXB = txtMaNXB.Text,
                TenNXB = txtTenNXB.Text,
                DiaChi = txtDiaChi.Text,
                SDT = txtSDT.Text
            };

            string ketQua = _bll.Sua(nxb);

            if (string.IsNullOrEmpty(ketQua))
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo");
                LoadData();
            }
            else
            {
                MessageBox.Show(ketQua, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaNXB.Enabled || string.IsNullOrEmpty(txtMaNXB.Text))
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!");
                return;
            }

            if (ValidationHelper.ConfirmDelete())
            {
                string ketQua = _bll.Xoa(txtMaNXB.Text);

                if (string.IsNullOrEmpty(ketQua))
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo");
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

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelHelper.ExportToExcel(dgvDanhSach, "DanhSachNhaXuatBan");
                MessageBox.Show("Xuất Excel thành công!", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất file: " + ex.Message, "Lỗi");
            }
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDanhSach.Rows[e.RowIndex];
                txtMaNXB.Text = row.Cells["MaNXB"].Value?.ToString();
                txtTenNXB.Text = row.Cells["TenNXB"].Value?.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString();
                txtSDT.Text = row.Cells["SDT"].Value?.ToString();
                txtMaNXB.Enabled = false;
            }
        }
    }
}
