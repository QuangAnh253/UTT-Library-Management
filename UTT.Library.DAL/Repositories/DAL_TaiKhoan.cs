using System;
using System.Data;
using System.Data.SqlClient;
using UTT.Library.DAL.Database;
using UTT.Library.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTT.Library.DAL.Repositories
{
    public class DAL_TaiKhoan
    {
        private DatabaseHelper _db = new DatabaseHelper();

        // Kiểm tra đăng nhập
        public DTO_TaiKhoan CheckLogin(string user, string pass)
        {
            string sql = "SELECT * FROM TAIKHOAN WHERE TenDangNhap = @user AND MatKhau = @pass AND TrangThai = 1";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@user", user),
                new SqlParameter("@pass", pass)
            };

            DataTable dt = _db.GetDataTable(sql, param);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                return new DTO_TaiKhoan()
                {
                    TenDangNhap = dr["TenDangNhap"].ToString(),
                    MatKhau = dr["MatKhau"].ToString(),
                    Quyen = Convert.ToInt32(dr["Quyen"]),
                    TrangThai = Convert.ToBoolean(dr["TrangThai"])
                };
            }
            return null;
        }

        // Lấy danh sách tài khoản
        public DataTable GetDanhSach()
        {
            string sql = "SELECT TenDangNhap, MatKhau, Quyen, TrangThai, NgayTao FROM TAIKHOAN";
            return _db.GetDataTable(sql);
        }

        // Thêm tài khoản
        public bool Them(DTO_TaiKhoan tk)
        {
            string sql = @"INSERT INTO TAIKHOAN (TenDangNhap, MatKhau, Quyen, TrangThai)
                           VALUES (@TenDN, @MatKhau, @Quyen, @TrangThai)";
            SqlParameter[] param =
            {
                new SqlParameter("@TenDN", tk.TenDangNhap),
                new SqlParameter("@MatKhau", tk.MatKhau),
                new SqlParameter("@Quyen", tk.Quyen),
                new SqlParameter("@TrangThai", tk.TrangThai)
            };
            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        // Sửa tài khoản
        public bool Sua(DTO_TaiKhoan tk)
        {
            string sql = @"UPDATE TAIKHOAN SET MatKhau = @MatKhau, Quyen = @Quyen, TrangThai = @TrangThai
                           WHERE TenDangNhap = @TenDN";
            SqlParameter[] param =
            {
                new SqlParameter("@TenDN", tk.TenDangNhap),
                new SqlParameter("@MatKhau", tk.MatKhau),
                new SqlParameter("@Quyen", tk.Quyen),
                new SqlParameter("@TrangThai", tk.TrangThai)
            };
            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        // Xóa tài khoản
        public bool Xoa(string tenDangNhap)
        {
            string sql = "DELETE FROM TAIKHOAN WHERE TenDangNhap = @TenDN";
            SqlParameter[] param =
            {
                new SqlParameter("@TenDN", tenDangNhap)
            };
            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        // Tìm kiếm
        public DataTable TimKiem(string keyword)
        {
            string sql = "SELECT TenDangNhap, MatKhau, Quyen, TrangThai, NgayTao FROM TAIKHOAN WHERE TenDangNhap LIKE @Key";
            SqlParameter[] param =
            {
                new SqlParameter("@Key", "%" + keyword + "%")
            };
            return _db.GetDataTable(sql, param);
        }

        // Đổi mật khẩu
        public bool DoiMatKhau(string tenDangNhap, string matKhauMoi)
        {
            string sql = "UPDATE TAIKHOAN SET MatKhau = @MatKhau WHERE TenDangNhap = @TenDN";
            SqlParameter[] param =
            {
                new SqlParameter("@TenDN", tenDangNhap),
                new SqlParameter("@MatKhau", matKhauMoi)
            };
            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        // Kiểm tra tồn tại
        public bool KiemTraTonTai(string tenDangNhap)
        {
            string sql = "SELECT COUNT(*) FROM TAIKHOAN WHERE TenDangNhap = @TenDN";
            SqlParameter[] param =
            {
                new SqlParameter("@TenDN", tenDangNhap)
            };
            object result = _db.ExecuteScalar(sql, param);
            return result != null && Convert.ToInt32(result) > 0;
        }
    }
}
