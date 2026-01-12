using System;
using System.Data;
using System.Data.SqlClient;
using UTT.Library.DAL.Database;
using UTT.Library.DTO;

namespace UTT.Library.DAL.Repositories
{
    public class DAL_TaiKhoan
    {
        private DatabaseHelper _db = new DatabaseHelper();

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
                    TrangThai = Convert.ToBoolean(dr["TrangThai"]),
                    NgayTao = Convert.ToDateTime(dr["NgayTao"])
                };
            }
            return null;
        }

        public bool DoiMatKhau(string tenDangNhap, string matKhauMoi)
        {
            string sql = "UPDATE TAIKHOAN SET MatKhau = @MatKhauMoi WHERE TenDangNhap = @TenDangNhap";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@TenDangNhap", tenDangNhap),
                new SqlParameter("@MatKhauMoi", matKhauMoi)
            };

            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        public DataTable GetDanhSach()
        {
            return _db.GetDataTable("SELECT * FROM TAIKHOAN ORDER BY NgayTao DESC");
        }

        public bool KiemTraTonTai(string tenDangNhap)
        {
            string sql = "SELECT COUNT(*) FROM TAIKHOAN WHERE TenDangNhap = @TenDangNhap";
            SqlParameter[] param = { new SqlParameter("@TenDangNhap", tenDangNhap) };

            DataTable dt = _db.GetDataTable(sql, param);
            if (dt != null && dt.Rows.Count > 0)
            {
                int count = Convert.ToInt32(dt.Rows[0][0]);
                return count > 0;
            }
            return false;
        }

        public bool Them(DTO_TaiKhoan tk)
        {
            string sql = "INSERT INTO TAIKHOAN (TenDangNhap, MatKhau, Quyen, TrangThai, NgayTao) " +
                         "VALUES (@TenDangNhap, @MatKhau, @Quyen, @TrangThai, @NgayTao)";
            SqlParameter[] param = {
                new SqlParameter("@TenDangNhap", tk.TenDangNhap),
                new SqlParameter("@MatKhau", tk.MatKhau),
                new SqlParameter("@Quyen", tk.Quyen),
                new SqlParameter("@TrangThai", tk.TrangThai),
                new SqlParameter("@NgayTao", tk.NgayTao)
            };

            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        public bool Sua(DTO_TaiKhoan tk)
        {
            string sql = "UPDATE TAIKHOAN SET MatKhau = @MatKhau, Quyen = @Quyen, TrangThai = @TrangThai " +
                         "WHERE TenDangNhap = @TenDangNhap";
            SqlParameter[] param = {
                new SqlParameter("@TenDangNhap", tk.TenDangNhap),
                new SqlParameter("@MatKhau", tk.MatKhau),
                new SqlParameter("@Quyen", tk.Quyen),
                new SqlParameter("@TrangThai", tk.TrangThai)
            };

            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        public bool Xoa(string tenDangNhap)
        {
            string sql = "DELETE FROM TAIKHOAN WHERE TenDangNhap = @TenDangNhap";
            SqlParameter[] param = { new SqlParameter("@TenDangNhap", tenDangNhap) };

            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        public DataTable TimKiem(string keyword)
        {
            string sql = "SELECT * FROM TAIKHOAN WHERE TenDangNhap LIKE @Key OR CAST(Quyen AS VARCHAR) LIKE @Key";
            SqlParameter[] param = { new SqlParameter("@Key", "%" + keyword + "%") };

            return _db.GetDataTable(sql, param);
        }
    }
}
