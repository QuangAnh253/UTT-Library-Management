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
    public partial class frmQuanLyDatTruoc : Form
    {
        private BLL_PhieuDatTruoc _bll = new BLL_PhieuDatTruoc();

        public frmQuanLyDatTruoc()
        {
            InitializeComponent();
        }

        private void frmQuanLyDatTruoc_Load(object sender, EventArgs e)
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
            txtMaPhieuDat.Enabled = false;
            txtMaPhieuDat.Clear();
            txtMaSV.Clear();
            txtMaSach.Clear();
            dtpNgayDat.Value = DateTime.Now;
            dtpNgayHetHan.Value = DateTime.Now.AddDays(7);
            cboTrangThai.SelectedIndex = 0;
            txtMaSV.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidationHelper.IsRequired(txtMaSV, "Mã sinh viên")) return;
            if (!ValidationHelper.IsRequired(txtMaSach, "Mã sách")) return;

            DTO_PhieuDatTruoc phieu = new DTO_PhieuDatTruoc
            {
                MaSV = txtMaSV.Text,
                MaSach = int.Parse(txtMaSach.Text),
                NgayDat = dtpNgayDat.Value,
                TrangThai = cboTrangThai.SelectedItem.ToString(),
                NgayHetHan = dtpNgayHetHan.Value
            };

            string ketQua = _bll.Them(phieu);

            if (string.IsNullOrEmpty(ketQua))
            {
                MessageBox.Show("Thêm phiếu đặt trước thành công.");
                LoadData();
            }
            else
            {
                MessageBox.Show(ketQua);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaPhieuDat.Text))
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa!");
                return;
            }

            if (!ValidationHelper.IsRequired(txtMaSV, "Mã sinh viên")) return;
            if (!ValidationHelper.IsRequired(txtMaSach, "Mã sách")) return;

            DTO_PhieuDatTruoc phieu = new DTO_PhieuDatTruoc
            {
                MaPhieuDat = int.Parse(txtMaPhieuDat.Text),
                MaSV = txtMaSV.Text,
                MaSach = int.Parse(txtMaSach.Text),
                NgayDat = dtpNgayDat.Value,
                TrangThai = cboTrangThai.SelectedItem.ToString(),
                NgayHetHan = dtpNgayHetHan.Value
            };

            string ketQua = _bll.Sua(phieu);

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
            if (string.IsNullOrEmpty(txtMaPhieuDat.Text))
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!");
                return;
            }

            if (ValidationHelper.ConfirmDelete())
            {
                string ketqua = _bll.Xoa(int.Parse(txtMaPhieuDat.Text));

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
                ExcelHelper.ExportToExcel(dgvDanhSach, "DanhSachPhieuDatTruoc");
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
                txtMaPhieuDat.Text = row.Cells["MaPhieuDat"].Value.ToString();
                txtMaSV.Text = row.Cells["MaSV"].Value.ToString();
                txtMaSach.Text = row.Cells["MaSach"].Value.ToString();
                dtpNgayDat.Value = Convert.ToDateTime(row.Cells["NgayDat"].Value);
                cboTrangThai.SelectedItem = row.Cells["TrangThai"].Value.ToString();
                dtpNgayHetHan.Value = Convert.ToDateTime(row.Cells["NgayHetHan"].Value);
            }
        }
    }
}
