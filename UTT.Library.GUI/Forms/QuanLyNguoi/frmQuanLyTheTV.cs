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

namespace UTT.Library.GUI.Forms.QuanLyNguoi
{
    public partial class frmQuanLyTheTV : Form
    {
        private BLL_TheTV _bll = new BLL_TheTV();
        public frmQuanLyTheTV()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
        }

        private void frmQuanLyTheTV_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            LoadData();
            DecorateDataGridView();
            DecorateSearchBox();
            DecorateButtons();
            SetDefaultState();
        }

        // =======================================================
        // =============== XÁC ĐỊNH TRẠNG THÁI ===================
        // =======================================================
        private string XacDinhTrangThai(DateTime ngayHetHan, string trangThaiCu = "")
        {
            if (trangThaiCu == "Khóa")
                return "Khóa";

            if (ngayHetHan.Date < DateTime.Now.Date)
                return "Hết hạn";

            return "Hoạt động";
        }
        // =======================================================
        // =============== TRANG TRÍ DATAGRIDVIEW =================
        // =======================================================
        private void DecorateDataGridView()
        {
            dgvDanhSach.BorderStyle = BorderStyle.None;
            dgvDanhSach.BackgroundColor = Color.White;
            dgvDanhSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDanhSach.RowTemplate.Height = 32;
            dgvDanhSach.ReadOnly = true;
            dgvDanhSach.AllowUserToAddRows = false;
            dgvDanhSach.AllowUserToDeleteRows = false;
            dgvDanhSach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        // =======================================================
        // ================= TRANG TRÍ BUTTON =====================
        // =======================================================
        private void DecorateButtons()
        {
            StyleButton(btnCapThe, Color.FromArgb(247, 148, 33));
            StyleButton(btnGiaHan, Color.FromArgb(71, 124, 191));
            StyleButton(btnKhoaThe, Color.FromArgb(180, 60, 60));
            StyleButton(btnExport, Color.FromArgb(38, 34, 98));
        }

        private void StyleButton(Button btn, Color back)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = back;
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        }
        // =======================================================
        // ================= TRANG TRÍ SEARCH =====================
        // =======================================================
        private void DecorateSearchBox()
        {
            txtTimKiem.BorderStyle = BorderStyle.FixedSingle;
            txtTimKiem.Font = new Font("Segoe UI", 10);
        }
        // =======================================================
        // ================== LOAD DATA ==========================
        // =======================================================
        private void LoadData()
        {
            dgvDanhSach.DataSource = _bll.LayDanhSach();
            ResetInput();
        }
        private void ResetInput()
        {
            txtMaThe.Clear();
            txtMaSinhVien.Clear();
            txtTrangThai.Clear();
            txtMaThe.Enabled = true;
            dtpNgayCap.Value = DateTime.Now;
            dtpNgayCap.Enabled = false;
            dtpNgayHetHan.Value = DateTime.Now.AddYears(1);
            txtTrangThai.ReadOnly = true;
        }

        private void SetDefaultState()
        {
            txtTrangThai.ReadOnly = true;
        }
        private void btnCapThe_Click(object sender, EventArgs e)
        {
            if (!ValidationHelper.IsRequired(txtMaThe, "Mã thẻ")) return;
            if (!ValidationHelper.IsRequired(txtMaSinhVien, "Mã sinh viên")) return;

            string trangThai = XacDinhTrangThai(dtpNgayHetHan.Value);

            DTO_TheTV the = new DTO_TheTV
            {
                MaThe = txtMaThe.Text.Trim(),
                MaSV = txtMaSinhVien.Text.Trim(),
                NgayCap = DateTime.Now,
                NgayHetHan = dtpNgayHetHan.Value,
                TrangThai = trangThai
            };

            string kq = _bll.CapThe(the);
            if (string.IsNullOrEmpty(kq))
            {
                MessageBox.Show("Cấp thẻ thành công!");
                LoadData();
            }
            else
            {
                MessageBox.Show(kq, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGiaHan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaThe.Text))
            {
                MessageBox.Show("Vui lòng chọn thẻ cần gia hạn!");
                return;
            }

            string kq = _bll.GiaHan(txtMaThe.Text, dtpNgayHetHan.Value);
            if (string.IsNullOrEmpty(kq))
            {
                MessageBox.Show("Gia hạn thẻ thành công!");
                LoadData();
            }
            else
            {
                MessageBox.Show(kq, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaThe.Text))
            {
                MessageBox.Show("Vui lòng chọn thẻ cần khóa!");
                return;
            }

            string kq = _bll.KhoaThe(txtMaThe.Text);
            if (string.IsNullOrEmpty(kq))
            {
                MessageBox.Show("Khóa thẻ thành công!");
                LoadData();
            }
            else
            {
                MessageBox.Show(kq, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // =======================================================
        // ================== GRID CLICK =========================
        // =======================================================
        

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            dgvDanhSach.DataSource = _bll.TimKiem(txtTimKiem.Text.Trim());
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelHelper.ExportToExcel(dgvDanhSach, "DanhSachTheThuVien");
                MessageBox.Show("Xuất Excel thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất Excel: " + ex.Message);
            }
        }

        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDanhSach.Rows[e.RowIndex];

                txtMaThe.Text = row.Cells["MaThe"].Value.ToString();
                txtMaSinhVien.Text = row.Cells["MaSV"].Value.ToString();
                dtpNgayCap.Value = (DateTime)row.Cells["NgayCap"].Value;
                dtpNgayHetHan.Value = (DateTime)row.Cells["NgayHetHan"].Value;

                txtTrangThai.Text = XacDinhTrangThai(
                    dtpNgayHetHan.Value,
                    row.Cells["TrangThai"].Value.ToString()
                );

                txtMaThe.Enabled = false;
            }
        }
    }
}
