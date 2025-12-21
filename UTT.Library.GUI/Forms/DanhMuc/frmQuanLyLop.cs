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
    public partial class frmQuanLyLop : Form
    {
        private BLL_Lop _bll = new BLL_Lop();
        private BLL_Khoa _bllKhoa = new BLL_Khoa();

        public frmQuanLyLop()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
        }

        // ================= FORM LOAD =================
        private void frmQuanLyLop_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            LoadKhoa();
            LoadData();
        }

        // ================= LOAD DATA =================
        private void LoadData()
        {
            dgvDanhSach.DataSource = _bll.LayDanhSach();
            ResetInput();
        }

        private void LoadKhoa()
        {
            cboKhoa.DataSource = _bllKhoa.LayDanhSach();
            cboKhoa.DisplayMember = "TenKhoa";
            cboKhoa.ValueMember = "MaKhoa";
            cboKhoa.SelectedIndex = -1;
        }

        private void ResetInput()
        {
            txtMa.Enabled = true;
            txtMa.Clear();
            txtTen.Clear();
            txtKhoaHoc.Clear();
            cboKhoa.SelectedIndex = -1;
            txtMa.Focus();
        }

        // ================= THÊM =================
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidationHelper.IsRequired(txtMa, "Mã lớp")) return;
            if (!ValidationHelper.IsRequired(txtTen, "Tên lớp")) return;

            DTO_Lop lop = new DTO_Lop(
                txtMa.Text,
                txtTen.Text,
                txtKhoaHoc.Text,
                cboKhoa.SelectedIndex == -1 ? null : cboKhoa.SelectedValue.ToString()
            );

            string kq = _bll.Them(lop);
            if (string.IsNullOrEmpty(kq))
            {
                MessageBox.Show("Thêm lớp thành công!");
                LoadData();
            }
            else
                MessageBox.Show(kq, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // ================= SỬA =================
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMa.Enabled)
            {
                MessageBox.Show("Vui lòng chọn lớp cần sửa!");
                return;
            }

            DTO_Lop lop = new DTO_Lop(
                txtMa.Text,
                txtTen.Text,
                txtKhoaHoc.Text,
                cboKhoa.SelectedIndex == -1 ? null : cboKhoa.SelectedValue.ToString()
            );

            string kq = _bll.Sua(lop);
            if (string.IsNullOrEmpty(kq))
            {
                MessageBox.Show("Cập nhật thành công!");
                LoadData();
            }
            else
                MessageBox.Show(kq, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // ================= XÓA =================
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
                else
                    MessageBox.Show(kq, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= LÀM MỚI =================
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        // ================= TÌM KIẾM =================
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dgvDanhSach.DataSource = _bll.TimKiem(txtTimKiem.Text.Trim());
        }

        // ================= CLICK GRID =================
        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow r = dgvDanhSach.Rows[e.RowIndex];
                txtMa.Text = r.Cells["MaLop"].Value.ToString();
                txtTen.Text = r.Cells["TenLop"].Value.ToString();
                txtKhoaHoc.Text = r.Cells["KhoaHoc"].Value?.ToString();
                cboKhoa.SelectedValue = r.Cells["MaKhoa"].Value?.ToString();
                txtMa.Enabled = false;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelHelper.ExportToExcel(dgvDanhSach, "DanhSachLop");
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
