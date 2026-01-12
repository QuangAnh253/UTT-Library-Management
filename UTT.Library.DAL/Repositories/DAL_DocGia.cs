using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTT.Library.DAL.Database;
using UTT.Library.DTO;

namespace UTT.Library.DAL.Repositories
{
    public class DAL_DocGia
    {
        private DatabaseHelper _db = new DatabaseHelper();

        // ================== LẤY DANH SÁCH ==================
        public DataTable GetDanhSach()
        {
            return _db.GetDataTable("SELECT * FROM DOCGIA");
        }

        // ================== THÊM ==================
        public bool Them(DTO_DocGia dg)
        {
            string sql = @"
                INSERT INTO DOCGIA
                (MaSV, HoTen, NgaySinh, GioiTinh, SDT, Email, MaLop, MaKhoa, TenDangNhap)
                VALUES
                (@MaSV, @HoTen, @NgaySinh, @GioiTinh, @SDT, @Email, @MaLop, @MaKhoa, @TenDN)";

            SqlParameter[] param =
            {
                new SqlParameter("@MaSV", dg.MaSV),
                new SqlParameter("@HoTen", dg.HoTen),
                new SqlParameter("@NgaySinh", dg.NgaySinh ?? (object)DBNull.Value),
                new SqlParameter("@GioiTinh", dg.GioiTinh),
                new SqlParameter("@SDT", dg.SDT),
                new SqlParameter("@Email", dg.Email),
                new SqlParameter("@MaLop", dg.MaLop ?? (object)DBNull.Value),
                new SqlParameter("@MaKhoa", dg.MaKhoa ?? (object)DBNull.Value),
                new SqlParameter("@TenDN", dg.TenDangNhap ?? (object)DBNull.Value)
            };

            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        // ================== SỬA ==================
        public bool Sua(DTO_DocGia dg)
        {
            string sql = @"
                UPDATE DOCGIA
                SET HoTen = @HoTen,
                    NgaySinh = @NgaySinh,
                    GioiTinh = @GioiTinh,
                    SDT = @SDT,
                    Email = @Email,
                    MaLop = @MaLop,
                    MaKhoa = @MaKhoa,
                    TenDangNhap = @TenDN
                    WHERE MaSV = @MaSV";

            SqlParameter[] param =
            {
                new SqlParameter("@MaSV", dg.MaSV),
                new SqlParameter("@HoTen", dg.HoTen),
                new SqlParameter("@NgaySinh", dg.NgaySinh ?? (object)DBNull.Value),
                new SqlParameter("@GioiTinh", dg.GioiTinh),
                new SqlParameter("@SDT", dg.SDT),
                new SqlParameter("@Email", dg.Email),
                new SqlParameter("@MaLop", dg.MaLop ?? (object)DBNull.Value),
                new SqlParameter("@MaKhoa", dg.MaKhoa ?? (object)DBNull.Value),
                new SqlParameter("@TenDN", dg.TenDangNhap ?? (object)DBNull.Value)
            };

            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        // ================== XOÁ ==================
        public bool Xoa(string maSV)
        {
            string sql = "DELETE FROM DOCGIA WHERE MaSV = @MaSV";
            SqlParameter[] param =
            {
                new SqlParameter("@MaSV", maSV)
            };

            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        // ================== TÌM KIẾM ==================
        public DataTable TimKiem(string keyword)
        {
            string sql = @"
                SELECT * FROM DOCGIA
                WHERE MaSV LIKE @Key
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
