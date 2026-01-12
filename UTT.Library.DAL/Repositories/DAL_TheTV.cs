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
    public class DAL_TheTV
    {
        private DatabaseHelper _db = new DatabaseHelper();

        // ================== LẤY DANH SÁCH ==================
        public DataTable GetDanhSach()
        {
            string sql = "SELECT * FROM THETHUVIEN";
            return _db.GetDataTable(sql);
        }

        // ================== CẤP THẺ ==================
        public bool CapThe(DTO_TheTV the)
        {
            string sql = @"
                INSERT INTO THETHUVIEN
                (MaThe, MaSV, NgayCap, NgayHetHan, TrangThai)
                VALUES
                (@MaThe, @MaSV, @NgayCap, @NgayHetHan, @TrangThai)";

            SqlParameter[] param =
            {
                new SqlParameter("@MaThe", the.MaThe),
                new SqlParameter("@MaSV", the.MaSV),
                new SqlParameter("@NgayCap", the.NgayCap),
                new SqlParameter("@NgayHetHan", the.NgayHetHan),
                new SqlParameter("@TrangThai", the.TrangThai)
            };

            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        // ================== GIA HẠN THẺ ==================
        public bool GiaHan(string maThe, DateTime ngayHetHanMoi)
        {
            string sql = @"
                UPDATE THETHUVIEN
                SET NgayHetHan = @NgayHetHan,
                    TrangThai = N'Hoạt động'
                WHERE MaThe = @MaThe";

            SqlParameter[] param =
            {
                new SqlParameter("@MaThe", maThe),
                new SqlParameter("@NgayHetHan", ngayHetHanMoi)
            };

            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        // ================== KHÓA THẺ ==================
        public bool KhoaThe(string maThe)
        {
            string sql = @"
                UPDATE THETHUVIEN
                SET TrangThai = N'Khóa'
                WHERE MaThe = @MaThe";

            SqlParameter[] param =
            {
                new SqlParameter("@MaThe", maThe)
            };

            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        // ================== TÌM KIẾM ==================
        public DataTable TimKiem(string keyword)
        {
            string sql = @"
                SELECT * FROM THETHUVIEN
                WHERE MaThe LIKE @Key
                   OR MaSV LIKE @Key
                   OR TrangThai LIKE @Key";

            SqlParameter[] param =
            {
                new SqlParameter("@Key", "%" + keyword + "%")
            };

            return _db.GetDataTable(sql, param);
        }
    }
}
