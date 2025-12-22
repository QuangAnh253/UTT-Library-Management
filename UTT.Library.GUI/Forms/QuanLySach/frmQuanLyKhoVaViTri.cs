using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;       // Để xử lý lưu file
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UTT.Library.BLL.Services; // Kết nối với BLL
using UTT.Library.DTO;          // Kết nối với DTO

namespace UTT.Library.GUI.Forms.QuanLySach
{
    public partial class frmQuanLyKhoVaViTri : Form
    {
        private BLL_KhoSach bllKho = new BLL_KhoSach();
        public frmQuanLyKhoVaViTri()
        {
            InitializeComponent();
        }
        

        private void frmQuanLyKhoVaViTri_Load(object sender, EventArgs e)
        {
            LoadData();

        }
        private void LoadData()
        {
            // Gọi qua lớp BLL để lấy dữ liệu
            dgvDanhSach.DataSource = bllKho.GetDanhSach();
        }

        // Nút LÀM MỚI
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaKho.Clear();
            txtTenKho.Clear();
            txtSucChua.Clear();
            txtMoTa.Clear();
            txtMaKho.Enabled = true; // Mở lại để nhập mã mới
            txtMaKho.Focus();

        }
        // Nút THÊM
        private void btnThem_Click_1(object sender, EventArgs e)
        {

            // Validation - Kiểm tra trống
            if (string.IsNullOrEmpty(txtMaKho.Text) || string.IsNullOrEmpty(txtTenKho.Text))
            {
                MessageBox.Show("Mã kho và Tên kho không được để trống!", "Thông báo");
                return;
            }

            // Đóng gói dữ liệu vào DTO
            DTO_KhoSach kho = new DTO_KhoSach();
            kho.MaKho = txtMaKho.Text.Trim();
            kho.TenKho = txtTenKho.Text.Trim();
            kho.SucChua = int.TryParse(txtSucChua.Text, out int sc) ? sc : 0;
            kho.MoTa = txtMoTa.Text.Trim();

            // Gọi BLL thực hiện
            if (bllKho.Them(kho))
            {
                MessageBox.Show("Thêm mới thành công!");
                LoadData();
                btnLamMoi_Click(null, null);
            }
            else
            {
                MessageBox.Show("Thêm thất bại! Mã kho có thể đã tồn tại.");
            }

        }


        //  Nút SỬA
        private void btnSua_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaKho.Text))
            {
                MessageBox.Show("Vui lòng chọn kho cần sửa!");
                return;
            }

            DTO_KhoSach kho = new DTO_KhoSach(
                txtMaKho.Text.Trim(),
                txtTenKho.Text.Trim(),
                int.TryParse(txtSucChua.Text, out int sc) ? sc : 0,
                txtMoTa.Text.Trim()
            );

            if (bllKho.Sua(kho))
            {
                MessageBox.Show("Cập nhật thành công!");
                LoadData();
            }
        }


        //  Nút XÓA
        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            string ma = txtMaKho.Text.Trim();
            if (string.IsNullOrEmpty(ma)) return;

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa kho này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (bllKho.Xoa(ma))
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadData();
                    btnLamMoi_Click(null, null);
                }
            }
        }



        // --- XỬ LÝ SỰ KIỆN GRIDVIEW ---

        // Xử lý khi nhấn vào bảng (CellClick)

        private void dgvDanhSach_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDanhSach.Rows[e.RowIndex];

                // Đổ dữ liệu từ dòng được chọn lên các TextBox
                txtMaKho.Text = row.Cells[0].Value.ToString();
                txtTenKho.Text = row.Cells[1].Value.ToString();
                txtSucChua.Text = row.Cells[2].Value.ToString();
                txtMoTa.Text = row.Cells[3].Value.ToString();

                // Khóa mã kho lại để tránh sửa nhầm khóa chính
                txtMaKho.Enabled = false;
            }
        }
       


        // NÚT TÌM KIẾM 
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                LoadData(); // Nếu để trống thì hiện lại toàn bộ danh sách
            }
            else
            {
                // Cách 1: Lọc trực tiếp trên DataGridView (Nhanh và đơn giản cho GUI)
                DataTable dt = (DataTable)dgvDanhSach.DataSource;
                if (dt != null)
                {
                    // Lọc theo Mã kho hoặc Tên kho
                    dt.DefaultView.RowFilter = string.Format("MaKho LIKE '%{0}%' OR TenKho LIKE '%{0}%'", keyword);
                }
            }
        }

        // NÚT XUẤT FILE EXCEL
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvDanhSach.Rows.Count == 0) return;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV File (*.csv)|*.csv"; // Xuất dạng CSV, Excel mở rất tốt
            sfd.FileName = "KhoSach.csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    // Lấy tiêu đề cột
                    string[] columnNames = dgvDanhSach.Columns.Cast<DataGridViewColumn>().Select(column => column.HeaderText).ToArray();
                    sb.AppendLine(string.Join(",", columnNames));

                    // Lấy dữ liệu từng dòng
                    foreach (DataGridViewRow row in dgvDanhSach.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            string[] cells = row.Cells.Cast<DataGridViewCell>().Select(cell => cell.Value?.ToString().Replace(",", " ")).ToArray();
                            sb.AppendLine(string.Join(",", cells));
                        }
                    }

                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                    MessageBox.Show("Xuất file thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            
        }
        }

        
    }
}
