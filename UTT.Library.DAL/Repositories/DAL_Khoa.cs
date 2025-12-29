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
    public class DAL_Khoa
    {
        private DatabaseHelper _db = new DatabaseHelper();

        public DataTable GetDanhSach()
        {
            return _db.GetDataTable("SELECT * FROM KHOA");
        }

        public bool Them(DTO_Khoa k)
        {
            string sql = @"INSERT INTO KHOA(MaKhoa, TenKhoa, MoTa)
                           VALUES(@Ma, @Ten, @MoTa)";
            SqlParameter[] param =
            {
                new SqlParameter("@Ma", k.MaKhoa),
                new SqlParameter("@Ten", k.TenKhoa),
                new SqlParameter("@MoTa", k.MoTa ?? (object)DBNull.Value)
            };
            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        public bool Sua(DTO_Khoa k)
        {
            string sql = @"UPDATE KHOA 
                           SET TenKhoa = @Ten, MoTa = @MoTa
                           WHERE MaKhoa = @Ma";
            SqlParameter[] param =
            {
                new SqlParameter("@Ma", k.MaKhoa),
                new SqlParameter("@Ten", k.TenKhoa),
                new SqlParameter("@MoTa", k.MoTa?? (object)DBNull.Value)
            };
            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        public bool Xoa(string ma)
        {
            string sql = "DELETE FROM KHOA WHERE MaKhoa = @Ma";
            SqlParameter[] param =
            {
                new SqlParameter("@Ma", ma)
            };
            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        public DataTable TimKiem(string keyword)
        {
            string sql = @"SELECT * FROM KHOA 
                           WHERE MaKhoa LIKE @Key OR TenKhoa LIKE @Key";
            SqlParameter[] param =
            {
                new SqlParameter("@Key", "%" + keyword + "%")
            };
            return _db.GetDataTable(sql, param);
        }
    }
}
