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
    public partial class frmQuanLyTheLoai : Form
    {
        private BLL_TheLoai _bll = new BLL_TheLoai();

        public frmQuanLyTheLoai()
        {
            InitializeComponent();
        }

        private void frmQuanLyTheLoai_Load(object sender, EventArgs e)
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
            txtMaTheLoai.Enabled = true;
            txtMaTheLoai.Clear();
            txtTenTheLoai.Clear();
            txtMoTa.Clear();
            txtMaTheLoai.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidationHelper.IsRequired(txtMaTheLoai, "Mã thể loại")) return;
            if (!ValidationHelper.IsRequired(txtTenTheLoai, "Tên thể loại")) return;

            DTO_TheLoai tl = new DTO_TheLoai
            {
                MaTheLoai = txtMaTheLoai.Text,
                TenTheLoai = txtTenTheLoai.Text,
                MoTa = txtMoTa.Text
            };

            string ketQua = _bll.Them(tl);

            if (string.IsNullOrEmpty(ketQua))
            {
                MessageBox.Show("Thêm thể loại thành công!", "Thông báo");
                LoadData();
            }
            else
            {
                MessageBox.Show(ketQua, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaTheLoai.Enabled)
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa!");
                return;
            }

            if (!ValidationHelper.IsRequired(txtTenTheLoai, "Tên thể loại")) return;

            DTO_TheLoai tl = new DTO_TheLoai
            {
                MaTheLoai = txtMaTheLoai.Text,
                TenTheLoai = txtTenTheLoai.Text,
                MoTa = txtMoTa.Text
            };

            string ketQua = _bll.Sua(tl);

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
            if (txtMaTheLoai.Enabled || string.IsNullOrEmpty(txtMaTheLoai.Text))
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!");
                return;
            }

            if (ValidationHelper.ConfirmDelete())
            {
                string ketQua = _bll.Xoa(txtMaTheLoai.Text);

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
                ExcelHelper.ExportToExcel(dgvDanhSach, "DanhSachTheLoai");
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
                txtMaTheLoai.Text = row.Cells["MaTheLoai"].Value?.ToString();
                txtTenTheLoai.Text = row.Cells["TenTheLoai"].Value?.ToString();
                txtMoTa.Text = row.Cells["MoTa"].Value?.ToString();
                txtMaTheLoai.Enabled = false;
            }
        }
    }
}
