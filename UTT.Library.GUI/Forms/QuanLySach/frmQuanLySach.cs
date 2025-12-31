using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UTT.Library.BLL.Services;
using UTT.Library.DTO;
using UTT.Library.GUI.Utilities;

namespace UTT.Library.GUI.Forms.QuanLySach
{
    public partial class frmQuanLySach : Form
    {
        private string anhBiaPath = null;
        private BLL_Sach _bllSach = new BLL_Sach();
        private BLL_TheLoai _bllTheLoai = new BLL_TheLoai();
        private BLL_TacGia _bllTacGia = new BLL_TacGia();
        private BLL_NhaXuatBan _bllNXB = new BLL_NhaXuatBan();
        private BLL_NgonNgu _bllNgonNgu = new BLL_NgonNgu();


        public frmQuanLySach()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
        }

        private void frmQuanLySach_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            LoadData();
            LoadComboBox();
        }
        private void LoadComboBox()
        {
            cboMaTheLoai.DataSource = _bllTheLoai.Laydanhsach();
            cboMaTheLoai.DisplayMember = "TenTheLoai";
            cboMaTheLoai.ValueMember = "MaTheLoai";
            cboMaTheLoai.SelectedIndex = -1;

            cboMaTacGia.DataSource = _bllTacGia.LayDanhSach();
            cboMaTacGia.DisplayMember = "TenTacGia";
            cboMaTacGia.ValueMember = "MaTacGia";
            cboMaTacGia.SelectedIndex = -1;

            cboMaNXB.DataSource = _bllNXB.Laydanhsach();
            cboMaNXB.DisplayMember = "TenNXB";
            cboMaNXB.ValueMember = "MaNXB";
            cboMaNXB.SelectedIndex = -1;

            cboMaNgonNgu.DataSource = _bllNgonNgu.Laydanhsach();
            cboMaNgonNgu.DisplayMember = "TenNgonNgu";
            cboMaNgonNgu.ValueMember = "MaNgonNgu";
            cboMaNgonNgu.SelectedIndex = -1;
        }


        private void LoadData()
        {
            dgvDanhSach.DataSource = _bllSach.LayDanhSach();
            ResetInput();
        }

        private void ResetInput()
        {
            txtMaSach.Clear();
            txtTenSach.Clear();
            txtNamXB.Clear();
            txtGiaTien.Clear();
            txtSoLuongTon.Clear();
            txtMoTa.Clear();           

            cboMaTheLoai.SelectedIndex = -1;
            cboMaTacGia.SelectedIndex = -1;
            cboMaNXB.SelectedIndex = -1;
            cboMaNgonNgu.SelectedIndex = -1;

            picAnhBia.Image = null;
            anhBiaPath = null;

            txtTenSach.Focus();
        }

        // Thêm sách

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidationHelper.IsRequired(txtTenSach, "tên sách")) return;
            if (!ValidationHelper.IsNumber(txtNamXB, "năm xuất bản")) return;
            if (!ValidationHelper.IsNumber(txtGiaTien, "giá tiền")) return;
            if (!ValidationHelper.IsNumber(txtSoLuongTon, "số lượng")) return;

            if (cboMaTheLoai.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn thể loại!");
                return;
            }

            if (cboMaNXB.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn nhà xuất bản!");
                return;
            }

            if( cboMaTacGia.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn tác giả!");
                return;
            }
            if (cboMaNgonNgu.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn ngôn ngữ!");
                return;
            }

            DTO_Sach s = new DTO_Sach
            {
                TenSach = txtTenSach.Text,
                MaTheLoai = cboMaTheLoai.SelectedValue?.ToString(),
                MaTacGia = cboMaTacGia.SelectedValue?.ToString(),
                MaNXB = cboMaNXB.SelectedValue?.ToString(),
                MaNgonNgu = cboMaNgonNgu.SelectedValue?.ToString(),
                NamXB = int.Parse(txtNamXB.Text),
                GiaTien = decimal.Parse(txtGiaTien.Text),
                SoLuongTon = int.Parse(txtSoLuongTon.Text),
                MoTa = txtMoTa.Text,
                AnhBia = anhBiaPath
            };

            string kq = _bllSach.Them(s);
            if (string.IsNullOrEmpty(kq))
            {
                MessageBox.Show("Thêm sách thành công!");
                LoadData();
            }
            else MessageBox.Show(kq, "Lỗi");

        }


        // Sửa sách
        private void btnSua_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaSach.Text))
            {
                MessageBox.Show("Vui lòng chọn sách cần sửa!");
                return;
            }

            if (cboMaTheLoai.SelectedIndex == -1 || cboMaNXB.SelectedIndex == -1)
            {
                MessageBox.Show("Thể loại và Nhà xuất bản không được để trống!");
                return;
            }
            if (cboMaTacGia.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn tác giả!");
                return;
            }
            if (cboMaNgonNgu.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn ngôn ngữ!");
                return;
            }

            DTO_Sach s = new DTO_Sach
            {
                MaSach = int.Parse(txtMaSach.Text),
                TenSach = txtTenSach.Text,
                MaTheLoai = cboMaTheLoai.SelectedValue.ToString(),
                MaTacGia = cboMaTacGia.SelectedValue.ToString(),
                MaNXB = cboMaNXB.SelectedValue.ToString(),
                MaNgonNgu = cboMaNgonNgu.SelectedValue.ToString(),
                NamXB = int.Parse(txtNamXB.Text),
                GiaTien = decimal.Parse(txtGiaTien.Text),
                SoLuongTon = int.Parse(txtSoLuongTon.Text),
                MoTa = txtMoTa.Text,
                AnhBia = anhBiaPath
            };

            string kq = _bllSach.Sua(s);

            if (string.IsNullOrEmpty(kq))
            {
                MessageBox.Show("Cập nhật thành công!");
                LoadData();
            }
            else MessageBox.Show(kq, "Lỗi");

        }

        // Xóa sách
        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaSach.Text))
            {
                MessageBox.Show("Vui lòng chọn sách cần xóa!");
                return;
            }

            if (ValidationHelper.ConfirmDelete())
            {
                string kq = _bllSach.Xoa(int.Parse(txtMaSach.Text));

                if (string.IsNullOrEmpty(kq))
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadData();
                }
                else MessageBox.Show(kq, "Lỗi");
            }
        }


        // Tìm kiếm sách
        private void btnTimKiem_Click_1(object sender, EventArgs e)
        {
            dgvDanhSach.DataSource = _bllSach.TimKiem(txtTimKiem.Text);
        }


        // Hiển thị thông tin sách khi chọn dòng trong DataGridView
        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow r = dgvDanhSach.Rows[e.RowIndex];

            txtMaSach.Text = r.Cells["MaSach"].Value?.ToString();
            txtTenSach.Text = r.Cells["TenSach"].Value?.ToString();
            txtNamXB.Text = r.Cells["NamXB"].Value?.ToString();
            txtGiaTien.Text = r.Cells["GiaTien"].Value?.ToString();
            txtSoLuongTon.Text = r.Cells["SoLuongTon"].Value?.ToString();
            txtMoTa.Text = r.Cells["MoTa"].Value?.ToString();

            cboMaTheLoai.SelectedValue = r.Cells["MaTheLoai"].Value?.ToString();
            cboMaTacGia.SelectedValue = r.Cells["MaTacGia"].Value?.ToString();
            cboMaNXB.SelectedValue = r.Cells["MaNXB"].Value?.ToString();
            cboMaNgonNgu.SelectedValue = r.Cells["MaNgonNgu"].Value?.ToString();

            // ⭐ LOAD ẢNH
            anhBiaPath = r.Cells["AnhBia"].Value?.ToString();

            if (!string.IsNullOrEmpty(anhBiaPath) && System.IO.File.Exists(anhBiaPath))
            {
                using (var fs = new FileStream(anhBiaPath, FileMode.Open, FileAccess.Read))
                {
                    picAnhBia.Image = Image.FromStream(fs);
                }
                picAnhBia.SizeMode = PictureBoxSizeMode.Zoom;

            }
            else
            {
                picAnhBia.Image = null;
            }
        }

        // Xuất danh sách sách ra file Excel
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelHelper.ExportToExcel(dgvDanhSach, "DanhSachSach");
                MessageBox.Show("Xuất Excel thành công!", "Thông báo",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message,
                   "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Chọn ảnh bìa sách
        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.png;*.jpeg";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                anhBiaPath = ofd.FileName;
                using (var fs = new FileStream(anhBiaPath, FileMode.Open, FileAccess.Read))
                {
                    picAnhBia.Image = Image.FromStream(fs);
                }
                picAnhBia.SizeMode = PictureBoxSizeMode.Zoom;

            }
        }

       
    }
}
