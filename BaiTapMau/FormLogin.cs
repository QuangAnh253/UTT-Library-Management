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
    public partial class FormLogin : Form
    {
        string strCon = @"Data Source=LAPTOP-B80ILKK5;Initial Catalog=QuanLyThuVienUTT;Integrated Security=True";

        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string u = txtUsername.Text.Trim();
            string p = txtPassword.Text.Trim();

            if (u == "" || p == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            try
            {
                using (SqlConnection sqlCon = new SqlConnection(strCon))
                {
                    sqlCon.Open();
                    // Câu lệnh đếm số tài khoản trùng khớp
                    string sql = "SELECT COUNT(*) FROM TAIKHOAN WHERE TenDangNhap = '" + u + "' AND MatKhau = '" + p + "'";

                    SqlCommand cmd = new SqlCommand(sql, sqlCon);
                    int kq = (int)cmd.ExecuteScalar();

                    if (kq > 0)
                    {
                        MessageBox.Show("Đăng nhập thành công!");
                        this.Hide();
                        FormStudent f = new FormStudent();
                        f.Show();
                    }
                    else
                    {
                        MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        }
    }
}
