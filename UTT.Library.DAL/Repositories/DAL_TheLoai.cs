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
    public class DAL_TheLoai
    {
        private DatabaseHelper _db = new DatabaseHelper();

        public DataTable GetDanhSach()
        {
            return _db.GetDataTable("SELECT * FROM THELOAI");
        }

        public bool Them(DTO_TheLoai tl)
        {
            string sql = "INSERT INTO THELOAI(MaTheLoai, TenTheLoai, MoTa) VALUES(@Ma, @Ten, @MoTa)";
            SqlParameter[] param = {
                new SqlParameter("@Ma", tl.MaTheLoai),
                new SqlParameter("@Ten", tl.TenTheLoai),
                new SqlParameter("@MoTa", tl.MoTa ?? (object)DBNull.Value)
            };
            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        public bool Sua(DTO_TheLoai tl)
        {
            string sql = "UPDATE THELOAI SET TenTheLoai = @Ten, MoTa = @MoTa WHERE MaTheLoai = @Ma";
            SqlParameter[] param = {
                new SqlParameter("@Ma", tl.MaTheLoai),
                new SqlParameter("@Ten", tl.TenTheLoai),
                new SqlParameter("@MoTa", tl.MoTa ?? (object)DBNull.Value)
            };
            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        public bool Xoa(string ma)
        {
            string sql = "DELETE FROM THELOAI WHERE MaTheLoai = @Ma";
            SqlParameter[] param = { new SqlParameter("@Ma", ma) };
            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        public DataTable TimKiem(string keyword)
        {
            string sql = "SELECT * FROM THELOAI WHERE TenTheLoai LIKE @Key OR MaTheLoai LIKE @Key";
            SqlParameter[] param = { new SqlParameter("@Key", "%" + keyword + "%") };
            return _db.GetDataTable(sql, param);
        }
    }
}
