using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using UTT.Library.DAL.Database;
using UTT.Library.DTO;
using System.Data.SqlClient;

namespace UTT.Library.DAL.Repositories
{
    public class DAL_NgonNgu
    {
        private DatabaseHelper _db = new DatabaseHelper();

        public DataTable GetDanhSach()
        {
            return _db.GetDataTable("SELECT * FROM NGONNGU");
        }
        public bool Them(DTO_NgonNgu nn)
        {
            string sql = "INSERT INTO NGONNGU(MaNgonNgu, TenNgonNgu, MoTa) VALUES(@Ma, @Ten, @MoTa)";
            SqlParameter[] param = {
                new SqlParameter("@Ma", nn.MaNgonNgu),
                new SqlParameter("@Ten", nn.TenNgonNgu),
                new SqlParameter("@MoTa", nn.MoTa ?? (object)DBNull.Value)
            };
            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        public bool Sua(DTO_NgonNgu nn)
        {
            string sql = "UPDATE NGONNGU SET TenNgonNgu = @Ten, MoTa = @MoTa WHERE MaNgonNgu = @Ma";
            SqlParameter[] param = {
                new SqlParameter("@Ma", nn.MaNgonNgu),
                new SqlParameter("@Ten", nn.TenNgonNgu),
                new SqlParameter("@MoTa", nn.MoTa ?? (object)DBNull.Value)
            };
            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        public bool Xoa(string ma)
        {
            string sql = "DELETE FROM NGONNGU WHERE MaNgonNgu = @Ma";
            SqlParameter[] param = { new SqlParameter("@Ma", ma) };
            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        public DataTable TimKiem(string keyword)
        {
            string sql = "SELECT * FROM NGONNGU WHERE TenNgonNgu LIKE @Key OR MaNgonNgu LIKE @Key";
            SqlParameter[] param = { new SqlParameter("@Key", "%" + keyword + "%") };
            return _db.GetDataTable(sql, param);
        }
    }
}
