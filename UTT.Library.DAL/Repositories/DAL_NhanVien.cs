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
    public class DAL_NhanVien
    {
        private DatabaseHelper _db = new DatabaseHelper();

        // ================== LẤY DANH SÁCH ==================
        public DataTable GetDanhSach()
        {
            return _db.GetDataTable("SELECT * FROM NHANVIEN");
        }

        // ================== THÊM ==================
        public bool Them(DTO_NhanVien nv)
        {
            string sql = @"
                INSERT INTO NHANVIEN
                (MaNV, HoTen, SDT, Email, NgayVaoLam, TenDangNhap)
                VALUES
                (@MaNV, @HoTen, @SDT, @Email, @NgayVaoLam, @TenDN)";

            SqlParameter[] param =
            {
                new SqlParameter("@MaNV", nv.MaNV),
                new SqlParameter("@HoTen", nv.HoTen),
                new SqlParameter("@SDT", nv.SDT ?? (object)DBNull.Value),
                new SqlParameter("@Email", nv.Email ?? (object)DBNull.Value),
                new SqlParameter("@NgayVaoLam", nv.NgayVaoLam ?? (object)DBNull.Value),
                new SqlParameter("@TenDN", nv.TenDangNhap ?? (object)DBNull.Value)
            };

            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        // ================== SỬA ==================
        public bool Sua(DTO_NhanVien nv)
        {
            string sql = @"
                UPDATE NHANVIEN
                SET HoTen = @HoTen,
                    SDT = @SDT,
                    Email = @Email,
                    NgayVaoLam = @NgayVaoLam,
                    TenDangNhap = @TenDN
                WHERE MaNV = @MaNV";

            SqlParameter[] param =
            {
                new SqlParameter("@MaNV", nv.MaNV),
                new SqlParameter("@HoTen", nv.HoTen),
                new SqlParameter("@SDT", nv.SDT ?? (object)DBNull.Value),
                new SqlParameter("@Email", nv.Email ?? (object)DBNull.Value),
                new SqlParameter("@NgayVaoLam", nv.NgayVaoLam ?? (object)DBNull.Value),
                new SqlParameter("@TenDN", nv.TenDangNhap ?? (object)DBNull.Value)
            };

            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        // ================== XOÁ ==================
        public bool Xoa(string maNV)
        {
            string sql = "DELETE FROM NHANVIEN WHERE MaNV = @MaNV";
            SqlParameter[] param =
            {
                new SqlParameter("@MaNV", maNV)
            };

            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        // ================== TÌM KIẾM ==================
        public DataTable TimKiem(string keyword)
        {
            string sql = @"
                SELECT * FROM NHANVIEN
                WHERE MaNV LIKE @Key
                   OR HoTen LIKE @Key
                   OR SDT LIKE @Key
                   OR Email LIKE @Key";

            SqlParameter[] param =
            {
                new SqlParameter("@Key", "%" + keyword + "%")
            };

            return _db.GetDataTable(sql, param);
        }
    }
}
