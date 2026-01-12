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
    public partial class frmQuanLyKhoVaViTri : Form

    {
        private BLL_KhoSach _bll = new BLL_KhoSach();
        public frmQuanLyKhoVaViTri()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
        }
        private void frmQuanLyKho_Load(object sender, EventArgs e)
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
            dgvDanhSach.DataSource = _bll.LayDanhSach();
            ResetInput();
        }

        private void ResetInput()
        {
            txtMaKho.Enabled = true;
            txtMaKho.Clear();
            txtTenKho.Clear();
            txtSucChua.Clear();
            txtMoTa.Clear();
            txtMaKho.Focus();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidationHelper.IsRequired(txtMaKho, "Mã kho")) return;
            if (!ValidationHelper.IsRequired(txtTenKho, "Tên kho")) return;
            if (!ValidationHelper.IsNumber(txtSucChua, "Sức chứa")) return;
            if(!ValidationHelper.IsRequired(txtMoTa, "Mô tả")) return;

            DTO_KhoSach kho = new DTO_KhoSach(txtMaKho.Text, txtTenKho.Text,
                int.Parse(txtSucChua.Text), txtMoTa.Text);

            string ketQua = _bll.Them(kho);
            if (string.IsNullOrEmpty(ketQua))
            {
                MessageBox.Show("Thêm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else MessageBox.Show(ketQua, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaKho.Enabled) 
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa!");
                return;
            }
            if (!ValidationHelper.IsRequired(txtTenKho, "Tên kho"))
                return;

            DTO_KhoSach kho = new DTO_KhoSach(
                txtMaKho.Text,
                txtTenKho.Text,
                int.Parse(txtSucChua.Text),
                txtMoTa.Text);

            string ketQua = _bll.Sua(kho);
            if (string.IsNullOrEmpty(ketQua))
            { 
                MessageBox.Show("Cập nhật thành công!"); LoadData();
            }
            else 
                MessageBox.Show(ketQua, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        
         }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaKho.Enabled || string.IsNullOrEmpty(txtMaKho.Text))
            { 
                MessageBox.Show("Vui lòng chọn dòng cần xóa!"); 
                return;
            }

            if (ValidationHelper.ConfirmDelete())
            {
                string ketQua = _bll.Xoa(txtMaKho.Text);
                if (string.IsNullOrEmpty(ketQua)) 
                { 
                    MessageBox.Show("Xóa thành công!");
                    LoadData();
                }
                else 
                    MessageBox.Show(ketQua, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dgvDanhSach.DataSource = _bll.TimKiem(txtTimKiem.Text.Trim());
        }

        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDanhSach.Rows[e.RowIndex];
                txtMaKho.Text = row.Cells["MaKho"].Value.ToString();
                txtTenKho.Text = row.Cells["TenKho"].Value.ToString();
                txtSucChua.Text = row.Cells["SucChua"].Value.ToString();
                txtMoTa.Text = row.Cells["MoTa"].Value.ToString();
                txtMaKho.Enabled = false;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExcelHelper.ExportToExcel(dgvDanhSach, "DanhSachKhoSach");
            try
            {
                ExcelHelper.ExportToExcel(dgvDanhSach, "DanhSachKhoSach");
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
