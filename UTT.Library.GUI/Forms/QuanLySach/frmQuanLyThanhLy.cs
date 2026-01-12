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

namespace UTT.Library.GUI.Forms.QuanLySach
{
    public partial class frmQuanLyThanhLy : Form
    {
        private BLL_SachThanhLy _bllThanhLy = new BLL_SachThanhLy();
        private BLL_Sach _bllSach = new BLL_Sach();

        public frmQuanLyThanhLy()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
        }

        private void frmQuanLyThanhLy_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            LoadDanhSachKho();
            LoadDanhSachThanhLy();
            dtpNgayXuLy.Value = DateTime.Now;
            txtNguoiXuLy.Text = Session.MaNV;
            txtNguoiXuLy.Enabled = false;
        }

        // Load danh sách sách trong kho
        private void LoadDanhSachKho()
        {
            dgvKhoSach.DataSource = _bllSach.LayDanhSach();
        }

        // Load danh sách sách đã thanh lý
        private void LoadDanhSachThanhLy()
        {
            dgvDanhSachThanhLy.DataSource = _bllThanhLy.LayDanhSach();
            ResetInput();
        }

        private void ResetInput()
        {
            txtMaSach.Clear();
            txtTenSach.Clear();
            txtLyDo.Clear();
            txtSoLuong.Clear();
            dtpNgayXuLy.Value = DateTime.Now;
            lblSoLuongTon.Text = "Số lượng tồn: --";
        }

        // Click vào danh sách kho → Hiển thị thông tin sách
        private void dgvKhoSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow r = dgvKhoSach.Rows[e.RowIndex];

            txtMaSach.Text = r.Cells["MaSach"].Value?.ToString();
            txtTenSach.Text = r.Cells["TenSach"].Value?.ToString();

            int soLuongTon = Convert.ToInt32(r.Cells["SoLuong"].Value ?? 0);
            lblSoLuongTon.Text = $"Số lượng tồn: {soLuongTon}";
            txtSoLuong.Text = "1"; // Mặc định thanh lý 1 cuốn
     
        }

        // Nút Chuyển sang Thanh Lý
        private void btnThanhLy_Click(object sender, EventArgs e)
        {
            if (!ValidationHelper.IsRequired(txtMaSach, "mã sách")) return;
            if (!ValidationHelper.IsRequired(txtLyDo, "lý do thanh lý")) return;
            if (!ValidationHelper.IsNumber(txtSoLuong, "số lượng")) return;

            if (string.IsNullOrEmpty(txtMaSach.Text))
            {
                MessageBox.Show("Vui lòng chọn sách từ danh sách kho!");
                return;
            }

            DTO_SachThanhLy stl = new DTO_SachThanhLy
            {
                MaSach = int.Parse(txtMaSach.Text),
                LyDo = txtLyDo.Text.Trim(),
                NgayXuLy = dtpNgayXuLy.Value,
                NguoiXuLy = txtNguoiXuLy.Text,
                SoLuongThanhLy = int.Parse(txtSoLuong.Text)
            };

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc muốn thanh lý {stl.SoLuongThanhLy} cuốn sách '{txtTenSach.Text}'?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string kq = _bllThanhLy.ThanhLySach(stl);

                if (string.IsNullOrEmpty(kq))
                {
                    MessageBox.Show("Thanh lý sách thành công!");
                    LoadDanhSachKho(); // Reload kho (số lượng đã giảm)
                    LoadDanhSachThanhLy(); // Reload danh sách thanh lý
                }
                else
                {
                    MessageBox.Show(kq, "Lỗi");
                }
            }
        }

        // Nút Xóa khỏi danh sách thanh lý
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachThanhLy.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn bản ghi cần xóa!");
                return;
            }

            int maThanhLy = Convert.ToInt32(dgvDanhSachThanhLy.CurrentRow.Cells["MaThanhLy"].Value);
            string tenSach = dgvDanhSachThanhLy.CurrentRow.Cells["TenSach"].Value?.ToString();

            if (ValidationHelper.ConfirmDelete())
            {
                string kq = _bllThanhLy.Xoa(maThanhLy);

                if (string.IsNullOrEmpty(kq))
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadDanhSachThanhLy();
                }
                else
                {
                    MessageBox.Show(kq, "Lỗi");
                }
            }
        }

        // Click vào danh sách thanh lý → Hiển thị thông tin
        private void dgvDanhSachThanhLy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow r = dgvDanhSachThanhLy.Rows[e.RowIndex];

            txtMaSach.Text = r.Cells["MaSach"].Value?.ToString();
            txtTenSach.Text = r.Cells["TenSach"].Value?.ToString();
            txtLyDo.Text = r.Cells["LyDo"].Value?.ToString();
            txtSoLuong.Text = r.Cells["SoLuongThanhLy"].Value?.ToString();
            dtpNgayXuLy.Value = Convert.ToDateTime(r.Cells["NgayXuLy"].Value);
            txtNguoiXuLy.Text = r.Cells["NguoiXuLy"].Value?.ToString();
            lblSoLuongTon.Text = "Đã thanh lý";
        }

        // Tìm kiếm trong kho
        private void btnTimKiemKho_Click(object sender, EventArgs e)
        {
            dgvKhoSach.DataSource = _bllSach.TimKiem(txtTimKiemKho.Text);
        }

        // Tìm kiếm trong danh sách thanh lý
        private void btnTimKiemThanhLy_Click(object sender, EventArgs e)
        {
            dgvDanhSachThanhLy.DataSource = _bllThanhLy.TimKiem(txtTimKiemThanhLy.Text);
        }

        // Nút Làm Mới
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadDanhSachKho();
            LoadDanhSachThanhLy();
            txtTimKiemKho.Clear();
            txtTimKiemThanhLy.Clear();
        }

        // Xuất Excel danh sách thanh lý
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelHelper.ExportToExcel(dgvDanhSachThanhLy, "DanhSachThanhLy");
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
