using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UTT.Library.GUI.Utilities;

namespace UTT.Library.GUI.Forms.QuanLyNguoi
{
    public partial class frmLichSuMuonTra : Form
    {

        public frmLichSuMuonTra()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
        }

        private void frmLichSuMuonTra_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;

            DecorateTitle();
            DecorateDataGridView();
            DecorateSearchBox();
            DecorateButton();

            // Demo data để test form
            LoadFakeData();
        }
        private void DecorateTitle()
        {
            label1.Text = "LỊCH SỬ MƯỢN TRẢ";
            label1.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(38, 34, 98);
            label1.TextAlign = ContentAlignment.MiddleCenter;
        }
        private void DecorateDataGridView()
        {
            dgvDanhSach.ReadOnly = true;
            dgvDanhSach.AllowUserToAddRows = false;
            dgvDanhSach.AllowUserToDeleteRows = false;
            dgvDanhSach.MultiSelect = false;
            dgvDanhSach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDanhSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDanhSach.RowTemplate.Height = 32;
            dgvDanhSach.BackgroundColor = Color.White;
        }
        private void DecorateSearchBox()
        {
            txtTimKiem.BorderStyle = BorderStyle.FixedSingle;
            txtTimKiem.Font = new Font("Segoe UI", 10);
        }
        private void DecorateButton()
        {
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.FlatAppearance.BorderSize = 0;
            btnExport.BackColor = Color.FromArgb(71, 124, 191);
            btnExport.ForeColor = Color.White;
            btnExport.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        }

        // ===================== LOAD DATA (FAKE) =====================
        private void LoadFakeData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã sinh viên");
            dt.Columns.Add("Họ tên");
            dt.Columns.Add("Tên sách");
            dt.Columns.Add("Ngày mượn");
            dt.Columns.Add("Ngày trả");
            dt.Columns.Add("Trạng thái");

            dt.Rows.Add("SV001", "Nguyễn Văn A", "Lập trình C#", "01/12/2025", "10/12/2025", "Đã trả");
            dt.Rows.Add("SV002", "Trần Thị B", "Cơ sở dữ liệu", "05/12/2025", "", "Chưa trả");

            dgvDanhSach.DataSource = dt;
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (dgvDanhSach.DataSource == null) return;

            CurrencyManager cm = (CurrencyManager)BindingContext[dgvDanhSach.DataSource];
            cm.SuspendBinding();

            foreach (DataGridViewRow row in dgvDanhSach.Rows)
            {
                row.Visible = row.Cells.Cast<DataGridViewCell>()
                    .Any(c => c.Value != null &&
                              c.Value.ToString()
                              .ToLower()
                              .Contains(txtTimKiem.Text.ToLower()));
            }

            cm.ResumeBinding();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelHelper.ExportToExcel(dgvDanhSach, "LichSuMuonTra");
                MessageBox.Show("Xuất Excel thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất Excel: " + ex.Message);
            }
        }
    }
}
