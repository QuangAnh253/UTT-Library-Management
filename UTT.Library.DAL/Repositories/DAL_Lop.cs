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
    public class DAL_Lop
    {
        private DatabaseHelper _db = new DatabaseHelper();

        public DataTable GetDanhSach()
        {
            string sql = @"
                SELECT L.MaLop, L.TenLop, L.KhoaHoc, L.MaKhoa, K.TenKhoa
                FROM LOP L
                LEFT JOIN KHOA K ON L.MaKhoa = K.MaKhoa";
            return _db.GetDataTable(sql);
        }

        public bool Them(DTO_Lop l)
        {
            string sql = @"
                INSERT INTO LOP(MaLop, TenLop, KhoaHoc, MaKhoa)
                VALUES(@Ma, @Ten, @KhoaHoc, @MaKhoa)";
            SqlParameter[] param =
            {
                new SqlParameter("@Ma", l.MaLop),
                new SqlParameter("@Ten", l.TenLop),
                new SqlParameter("@KhoaHoc",
                    string.IsNullOrEmpty(l.KhoaHoc) ? (object)DBNull.Value : l.KhoaHoc),
                new SqlParameter("@MaKhoa",
                    string.IsNullOrEmpty(l.MaKhoa) ? (object)DBNull.Value : l.MaKhoa)
            };
            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        public bool Sua(DTO_Lop l)
        {
            string sql = @"
                UPDATE LOP
                SET TenLop = @Ten, KhoaHoc = @KhoaHoc, MaKhoa = @MaKhoa
                WHERE MaLop = @Ma";
            SqlParameter[] param =
            {
                new SqlParameter("@Ma", l.MaLop),
                new SqlParameter("@Ten", l.TenLop),
                new SqlParameter("@KhoaHoc",
                    string.IsNullOrEmpty(l.KhoaHoc) ? (object)DBNull.Value : l.KhoaHoc),
                new SqlParameter("@MaKhoa",
                    string.IsNullOrEmpty(l.MaKhoa) ? (object)DBNull.Value : l.MaKhoa)
            };
            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        public bool Xoa(string ma)
        {
            string sql = "DELETE FROM LOP WHERE MaLop = @Ma";
            SqlParameter[] param =
            {
                new SqlParameter("@Ma", ma)
            };
            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        public DataTable TimKiem(string key)
        {
            string sql = @"
                SELECT L.MaLop, L.TenLop, L.KhoaHoc, L.MaKhoa, K.TenKhoa
                FROM LOP L
                LEFT JOIN KHOA K ON L.MaKhoa = K.MaKhoa
                WHERE L.MaLop LIKE @Key OR L.TenLop LIKE @Key";
            SqlParameter[] param =
            {
                new SqlParameter("@Key", "%" + key + "%")
            };
            return _db.GetDataTable(sql, param);
        }
    }
}
