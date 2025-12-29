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
    public partial class frmQuanLyNgonNgu : Form
    {
        private BLL_NgonNgu _bll = new BLL_NgonNgu();
        public frmQuanLyNgonNgu()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
        }

        private void frmQuanLyNgonNgu_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            LoadData();
            DecorateDataGridView();
            DecorateSearchBox();
            DecorateButton();
        }

        // =======================================================
        // ================= TRANG TRÍ DATAGRIDVIEW ===============
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
            dgvDanhSach.MultiSelect = false;
            dgvDanhSach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDanhSach.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            dgvDanhSach.EnableHeadersVisualStyles = false;
            dgvDanhSach.ColumnHeadersHeight = 40;
            dgvDanhSach.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvDanhSach.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(38, 34, 98);
            dgvDanhSach.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDanhSach.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 11, FontStyle.Bold);

            dgvDanhSach.DefaultCellStyle.BackColor = Color.White;
            dgvDanhSach.DefaultCellStyle.ForeColor = Color.FromArgb(38, 34, 98);
            dgvDanhSach.DefaultCellStyle.Font = new Font("Segoe UI", 10);

            dgvDanhSach.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(185, 217, 137);

            dgvDanhSach.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(71, 124, 191);
            dgvDanhSach.DefaultCellStyle.SelectionForeColor = Color.White;

            dgvDanhSach.GridColor = Color.FromArgb(224, 224, 224);
        }

        // =======================================================
        // ================= TRANG TRÍ TÌM KIẾM ===================
        // =======================================================

        private void DecorateSearchBox()
        {
            lblTimKiem.BorderStyle = BorderStyle.FixedSingle;
            lblTimKiem.Font = new Font("Segoe UI", 10);
            lblTimKiem.ForeColor = Color.FromArgb(38, 34, 98);
            lblTimKiem.Text = "";
        }

        // =======================================================
        // ================= TRANG TRÍ BUTTON ====================
        // =======================================================

        private void DecorateButton()
        {
            Color primary = Color.FromArgb(247, 148, 33);
            Color primaryDark = Color.FromArgb(200, 120, 20);
            Color blueBrand = Color.FromArgb(71, 124, 191);

            StyleButton(btnThem, primary, primaryDark);
            StyleButton(btnSua, blueBrand, Color.FromArgb(50, 90, 150));
            StyleButton(btnXoa, Color.FromArgb(200, 50, 50), Color.FromArgb(150, 20, 20));
            StyleButton(btnLamMoi, Color.FromArgb(93, 98, 42), Color.FromArgb(70, 75, 30));
            StyleButton(btnTimKiem, Color.FromArgb(38, 34, 98), Color.FromArgb(25, 22, 70));
        }

        private void StyleButton(Button btn, Color back, Color backHover)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = back;
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            btn.MouseEnter += (s, e) => btn.BackColor = backHover;
            btn.MouseLeave += (s, e) => btn.BackColor = back;
        }

        // =======================================================
        // ================= LOAD & CRUD =========================
        // =======================================================

        private void LoadData()
        {
            dgvDanhSach.DataSource = _bll.Laydanhsach();
            ResetInput();
        }

        private void ResetInput()
        {
            txtMaNgonNgu.Enabled = true;
            txtMaNgonNgu.Clear();
            txtTenNgonNgu.Clear();
            txtMoTa.Clear();
            txtMaNgonNgu.Focus();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ValidationHelper.IsRequired(txtMaNgonNgu, "Mã ngôn ngữ")) return;
            if (!ValidationHelper.IsRequired(txtTenNgonNgu, "Tên ngôn ngữ")) return;

            DTO_NgonNgu nn = new DTO_NgonNgu
            {
                MaNgonNgu = txtMaNgonNgu.Text,
                TenNgonNgu = txtTenNgonNgu.Text,
                MoTa = txtMoTa.Text
            };

            string ketQua = _bll.Them(nn);
            if (string.IsNullOrEmpty(ketQua))
            {
                MessageBox.Show("Thêm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
                MessageBox.Show(ketQua, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }    

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaNgonNgu.Enabled)
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa!", "Thông báo");
                return;
            }

            if (!ValidationHelper.IsRequired(txtTenNgonNgu, "Tên ngôn ngữ")) return;

            DTO_NgonNgu nn = new DTO_NgonNgu
            {
                MaNgonNgu = txtMaNgonNgu.Text,
                TenNgonNgu = txtTenNgonNgu.Text,
                MoTa = txtMoTa.Text
            };

            string ketQua = _bll.Sua(nn);
            if (string.IsNullOrEmpty(ketQua))
            {
                MessageBox.Show("Cập nhật thành công!");
                LoadData();
            }
            else
                MessageBox.Show(ketQua, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaNgonNgu.Enabled || string.IsNullOrEmpty(txtMaNgonNgu.Text))
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!", "Thông báo");
                return;
            }

            if (ValidationHelper.ConfirmDelete())
            {
                string ketQua = _bll.Xoa(txtMaNgonNgu.Text);
                if (string.IsNullOrEmpty(ketQua))
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadData();
                }
                else
                    MessageBox.Show(ketQua, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dgvDanhSach.DataSource =
                _bll.TimKiem(txtTimKiem.Text.Trim());
        }

        private void dgvDanhsach_CellContentClick(Object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDanhSach.Rows[e.RowIndex];
                txtMaNgonNgu.Text = row.Cells["MaNgonNgu"].Value.ToString();
                txtTenNgonNgu.Text = row.Cells["TenNgonNgu"].Value.ToString();
                txtMoTa.Text = row.Cells["MoTa"].Value.ToString();

                txtMaNgonNgu.Enabled = false;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelHelper.ExportToExcel(dgvDanhSach, "DanhSachNgonNgu");
                MessageBox.Show("Xuất Excel thành công!", "Thông báo",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message,
                   "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMaNgonNgu_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblMa_Click(object sender, EventArgs e)
        {

        }

        private void lblTimKiem_Click(object sender, EventArgs e)
        {

        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblTen_Click(object sender, EventArgs e)
        {

        }

        private void txtMoTa_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblGhiChu_Click(object sender, EventArgs e)
        {

        }

        private void dgvDanhSach_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelRight_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtTenNgonNgu_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
