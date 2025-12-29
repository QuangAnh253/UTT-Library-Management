using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
<<<<<<< HEAD
using UTT.Library.BLL.Services;
using UTT.Library.DTO;
using UTT.Library.GUI.Utilities;
=======
>>>>>>> 19738ad26204ded7890aafbeda36010057251c57

namespace UTT.Library.GUI.Forms.DanhMuc
{
    public partial class frmQuanLyNhaXuatBan : Form
    {
<<<<<<< HEAD
        private BLL_NhaXuatBan _bll = new BLL_NhaXuatBan();
        public frmQuanLyNhaXuatBan()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
           
        }

        private void frmQuanLyNhaXuatBan_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            LoadData();
            DecorateDataGridView();
            DecorateSearchBox();
            DecorateButtons();
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

        private void DecorateSearchBox()
        {
            txtTimKiem.BorderStyle = BorderStyle.FixedSingle;
            txtTimKiem.Font = new Font("Segoe UI", 10);
            txtTimKiem.ForeColor = Color.FromArgb(38, 34, 98);
            txtTimKiem.Text = "";
        }

        private void DecorateButtons()
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

        private void LoadData()
        {
            dgvDanhSach.DataSource = _bll.LayDanhSach();
            ResetInput();
        }

        private void ResetInput()
        {
            txtMa.Enabled = true;
            txtMa.Clear();
            txtTen.Clear();
            txtDiachi.Clear();
            txtSdt.Clear();
            txtMa.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidationHelper.IsRequired(txtMa, "Mã nhà xuất bản")) return;
            if (!ValidationHelper.IsRequired(txtTen, "Tên nhà xuất bản")) return;

            DTO_NhaXuatBan nxb =
                new DTO_NhaXuatBan(txtMa.Text, txtTen.Text, txtDiachi.Text,txtSdt.Text);

            string ketQua = _bll.Them(nxb);
            if (string.IsNullOrEmpty(ketQua))
            {
                MessageBox.Show("Thêm mới thành công!");
                LoadData();
            }
            else MessageBox.Show(ketQua, "Lỗi");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMa.Enabled)
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa!");
                return;
            }

            if (!ValidationHelper.IsRequired(txtTen, "Tên nhà xuất bản")) return;

            DTO_NhaXuatBan nxb =
                new DTO_NhaXuatBan(txtMa.Text, txtTen.Text, txtDiachi.Text, txtSdt.Text);

            string ketQua = _bll.Sua(nxb);
            if (string.IsNullOrEmpty(ketQua))
            {
                MessageBox.Show("Cập nhật thành công!");
                LoadData();
            }
            else MessageBox.Show(ketQua, "Lỗi");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMa.Enabled || string.IsNullOrEmpty(txtMa.Text))
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!");
                return;
            }

            if (ValidationHelper.ConfirmDelete())
            {
                string ketQua = _bll.Xoa(txtMa.Text);
                if (string.IsNullOrEmpty(ketQua))
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadData();
                }
                else MessageBox.Show(ketQua, "Lỗi");
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

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDanhSach.Rows[e.RowIndex];
                txtMa.Text = row.Cells["MaNXB"].Value.ToString();
                txtTen.Text = row.Cells["TenNXB"].Value.ToString();
                txtDiachi.Text = row.Cells["DiaChi"].Value.ToString();
                txtSdt.Text = row.Cells["SDT"].Value.ToString();
                txtMa.Enabled = false;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExcelHelper.ExportToExcel(dgvDanhSach, "DanhSachNhaXuatBan");
            MessageBox.Show("Xuất Excel thành công!");

        }

        private void panelLeft_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
        
=======
        public frmQuanLyNhaXuatBan()
        {
            InitializeComponent();
        }
    }
}
>>>>>>> 19738ad26204ded7890aafbeda36010057251c57
