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
    public partial class frmQuanLyNhaCungCap : Form
    {
        private BLL_NhaCungCap _bll = new BLL_NhaCungCap();

        public frmQuanLyNhaCungCap()
        {
            InitializeComponent();
        }

        private void frmQuanLyNhaCungCap_Load(object sender, EventArgs e)
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
            txtMaNCC.Enabled = true;
            txtMaNCC.Clear();
            txtTenNCC.Clear();
            txtDiaChi.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            txtMaNCC.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidationHelper.IsRequired(txtMaNCC, "Mã Nhà cung cấp")) return;
            if (!ValidationHelper.IsRequired(txtTenNCC, "Tên Nhà cung cấp")) return;

            DTO_NhaCungCap ncc = new DTO_NhaCungCap
            {
                MaNCC = txtMaNCC.Text,
                TenNCC = txtTenNCC.Text,
                DiaChi = txtDiaChi.Text,
                SDT = txtSDT.Text,
                Email = txtEmail.Text
            };

            string ketQua = _bll.Them(ncc);

            if (string.IsNullOrEmpty(ketQua))
            {
                MessageBox.Show("Thêm Nhà thành công.");
                LoadData();
            }
            else
            {
                MessageBox.Show(ketQua);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaNCC.Enabled)
            { 
                MessageBox.Show("Vui lòng chọn dòng cần sửa!");
                return;
            }

            if (!ValidationHelper.IsRequired(txtTenNCC, "Tên Nhà cung cấp")) return;

            DTO_NhaCungCap ncc = new DTO_NhaCungCap
            {
                MaNCC = txtMaNCC.Text,
                TenNCC = txtTenNCC.Text,
                DiaChi = txtDiaChi.Text,
                SDT = txtSDT.Text,
                Email = txtEmail.Text
            };

            string ketQua = _bll.Sua(ncc);

            if (string.IsNullOrEmpty(ketQua))
            {
                MessageBox.Show("Cập nhập thành công.");
                LoadData();
            }
            else
            {
                MessageBox.Show(ketQua);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaNCC.Enabled || string.IsNullOrEmpty(txtMaNCC.Text))
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!");
                return;
            }

            if (ValidationHelper.ConfirmDelete())
            { 
                string ketqua = _bll.Xoa(txtMaNCC.Text);

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
                ExcelHelper.ExportToExcel(dgvDanhSach, "DanhSachNhaCungCap");
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
                txtMaNCC.Text = row.Cells["MaNCC"].Value.ToString();
                txtTenNCC.Text = row.Cells["TenNCC"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                txtSDT.Text = row.Cells["SDT"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtMaNCC.Enabled = false;
            }
        }
    }
}
