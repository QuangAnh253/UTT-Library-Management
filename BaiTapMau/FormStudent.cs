using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapMau
{
    public partial class FormStudent : Form
    {
        string strCon = @"Data Source=LAPTOP-B80ILKK5;Initial Catalog=QuanLyThuVienUTT;Integrated Security=True";
        SqlConnection sqlCon = null;

        // Biến trạng thái: "Reset" (Mặc định), "Add" (Thêm), "Edit" (Sửa)
        string Status = "Reset";

        public FormStudent()
        {
            InitializeComponent();
        }

        private void FormStudent_Load(object sender, EventArgs e)
        {
            ConnectDB();
            GetData();
            SetInterface("Reset");
        }
        private void ConnectDB()
        {
            try
            {
                if (sqlCon == null) sqlCon = new SqlConnection(strCon);
                if (sqlCon.State == ConnectionState.Closed) sqlCon.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        }

        // --- HÀM 2: LẤY DỮ LIỆU & ĐỔ VÀO TEXTBOX (Phong cách của thầy) ---
        private void GetData()
        {
            try
            {
                string sql = "SELECT * FROM DOCGIA";
                SqlDataAdapter da = new SqlDataAdapter(sql, sqlCon);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Đổ lên lưới
                dgvStudent.DataSource = dt;

                // Đổ dòng đầu tiên lên TextBox (Nếu bảng có dữ liệu)
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    txtMaSV.Text = row["MaSV"].ToString();
                    txtHoTen.Text = row["HoTen"].ToString();
                    txtLop.Text = row["MaLop"].ToString();
                    // ... Gán tiếp các trường khác nếu có
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu: " + ex.Message);
            }
        }

        // --- HÀM 3: QUẢN LÝ TRẠNG THÁI GIAO DIỆN ---
        private void SetInterface(string state)
        {
            Status = state; // Cập nhật trạng thái hiện tại

            if (state == "Reset")
            {
                // Khóa nhập, chỉ cho xem
                txtMaSV.Enabled = false;
                txtHoTen.Enabled = false;
                txtLop.Enabled = false;

                // Mở nút chức năng
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;

                // Khóa nút Lưu/Hủy
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
            }
            else if (state == "Add" || state == "Edit")
            {
                // Mở nhập liệu
                txtMaSV.Enabled = true;
                txtHoTen.Enabled = true;
                txtLop.Enabled = true;

                // Khóa nút chức năng
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;

                // Mở nút Lưu/Hủy để hoàn tất
                btnLuu.Enabled = true;
                btnHuy.Enabled = true;

                if (state == "Add")
                {
                    // Xóa trắng để nhập mới
                    txtMaSV.Text = "";
                    txtHoTen.Text = "";
                    txtLop.Text = "";
                    txtMaSV.Focus();
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SetInterface("Add");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SetInterface("Edit");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn xóa?", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    string ma = txtMaSV.Text;
                    string sql = "DELETE FROM DOCGIA WHERE MaSV = '" + ma + "'";
                    SqlCommand cmd = new SqlCommand(sql, sqlCon);
                    cmd.ExecuteNonQuery();

                    GetData(); // Load lại
                    MessageBox.Show("Đã xóa!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa: " + ex.Message);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql = "";
            string ma = txtMaSV.Text.Trim();
            string ten = txtHoTen.Text.Trim();
            string lop = txtLop.Text.Trim();

            // Kiểm tra rỗng
            if (ma == "") { MessageBox.Show("Chưa nhập Mã SV"); return; }

            // 1. Kiểm tra xem đang Thêm hay Sửa để viết SQL tương ứng
            if (Status == "Add")
            {
                // Câu lệnh INSERT
                sql = "INSERT INTO DOCGIA (MaSV, HoTen, MaLop) VALUES (N'" + ma + "', N'" + ten + "', N'" + lop + "')";
            }
            else if (Status == "Edit")
            {
                // Câu lệnh UPDATE
                sql = "UPDATE DOCGIA SET HoTen = N'" + ten + "', MaLop = N'" + lop + "' WHERE MaSV = N'" + ma + "'";
            }

            // 2. Thực thi lệnh
            try
            {
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                cmd.ExecuteNonQuery(); // Chạy lệnh Insert/Update

                MessageBox.Show("Lưu thành công!");

                // 3. Làm mới lại giao diện
                GetData();
                SetInterface("Reset");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SetInterface("Reset"); // Quay về ban đầu
            GetData(); // Load lại dữ liệu cũ
        }

        private void dgvStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Tránh bấm vào tiêu đề
            {
                DataGridViewRow row = dgvStudent.Rows[e.RowIndex];
                txtMaSV.Text = row.Cells["MaSV"].Value.ToString();
                txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
                txtLop.Text = row.Cells["MaLop"].Value.ToString();
            }
        }
    }
}
