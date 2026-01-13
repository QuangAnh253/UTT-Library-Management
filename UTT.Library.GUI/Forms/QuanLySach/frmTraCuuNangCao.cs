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
using UTT.Library.GUI.Utilities;

namespace UTT.Library.GUI.Forms.QuanLySach
{
    public partial class frmTraCuuNangCao : Form
    {
        private BLL_Sach _bllSach = new BLL_Sach();
        private BLL_TheLoai _bllTheLoai = new BLL_TheLoai();
        private BLL_TacGia _bllTacGia = new BLL_TacGia();
        private BLL_NhaXuatBan _bllNXB = new BLL_NhaXuatBan();

        public frmTraCuuNangCao()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
        }

        private void frmTraCuuNangCao_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            LoadComboBoxes();
            LoadData();
        }

        // ================= LOAD DATA =================

        private void LoadComboBoxes()
        {
            // Load Thể loại
            DataTable dtTheLoai = _bllTheLoai.Laydanhsach();
            DataRow rowTheLoai = dtTheLoai.NewRow();
            rowTheLoai["MaTheLoai"] = "";
            rowTheLoai["TenTheLoai"] = "-- Tất cả --";
            dtTheLoai.Rows.InsertAt(rowTheLoai, 0);
            cboTheLoai.DataSource = dtTheLoai;
            cboTheLoai.DisplayMember = "TenTheLoai";
            cboTheLoai.ValueMember = "MaTheLoai";
            cboTheLoai.SelectedIndex = 0;

            // Load Tác giả
            DataTable dtTacGia = _bllTacGia.LayDanhSach();
            DataRow rowTacGia = dtTacGia.NewRow();
            rowTacGia["MaTacGia"] = "";
            rowTacGia["TenTacGia"] = "-- Tất cả --";
            dtTacGia.Rows.InsertAt(rowTacGia, 0);
            cboTacGia.DataSource = dtTacGia;
            cboTacGia.DisplayMember = "TenTacGia";
            cboTacGia.ValueMember = "MaTacGia";
            cboTacGia.SelectedIndex = 0;

            // Load NXB
            DataTable dtNXB = _bllNXB.Laydanhsach();
            DataRow rowNXB = dtNXB.NewRow();
            rowNXB["MaNXB"] = "";
            rowNXB["TenNXB"] = "-- Tất cả --";
            dtNXB.Rows.InsertAt(rowNXB, 0);
            cboNXB.DataSource = dtNXB;
            cboNXB.DisplayMember = "TenNXB";
            cboNXB.ValueMember = "MaNXB";
            cboNXB.SelectedIndex = 0;
        }

        private void LoadData()
        {
            dgvKetQua.DataSource = _bllSach.LayTatCaSachChiTiet();
            UpdateResultCount();
        }

        private void UpdateResultCount()
        {
            int count = dgvKetQua.Rows.Count;
            lblKetQua.Text = $"Kết quả tìm kiếm: {count} sách";
        }

        // ================= TRA CỨU =================

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            string maTheLoai = cboTheLoai.SelectedValue?.ToString() ?? "";
            string maTacGia = cboTacGia.SelectedValue?.ToString() ?? "";
            string maNXB = cboNXB.SelectedValue?.ToString() ?? "";

            dgvKetQua.DataSource = _bllSach.TraCuuNangCao(keyword, maTheLoai, maTacGia, maNXB);
            UpdateResultCount();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            cboTheLoai.SelectedIndex = 0;
            cboTacGia.SelectedIndex = 0;
            cboNXB.SelectedIndex = 0;
            LoadData();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelHelper.ExportToExcel(dgvKetQua, "KetQuaTraCuu");
                MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
