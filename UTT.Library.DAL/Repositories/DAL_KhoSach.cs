using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTT.Library.DAL.Database;
using System.Data;
using System.Data.SqlClient;
using UTT.Library.DTO;

namespace UTT.Library.DAL.Repositories
{
    public class DAL_KhoSach
    {
        private DatabaseHelper _db = new DatabaseHelper();

        public DataTable GetDanhSach()
        {
            return _db.GetDataTable("SELECT MaKho, TenKho, SucChua, MoTa FROM KHOSACH");
        }

        public bool Them(DTO_Kho kho)
        {
            string sql = @"INSERT INTO KHOSACH (MaKho, TenKho, SucChua, MoTa) 
                           VALUES (@MaKho, @TenKho, @SucChua, @MoTa)";
            SqlParameter[] param =
            {
                new SqlParameter("@MaKho", kho.MaKho),
                new SqlParameter("@TenKho", kho.TenKho),
                new SqlParameter("@SucChua", kho.SucChua),
                new SqlParameter("@MoTa", (object)kho.MoTa ?? DBNull.Value)
            };
            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        public bool Sua(DTO_Kho kho)
        {
            string sql = @"UPDATE KHOSACH SET TenKho = @TenKho, SucChua = @SucChua, MoTa = @MoTa 
                           WHERE MaKho = @MaKho";
            SqlParameter[] param =
            {
                new SqlParameter("@MaKho", kho.MaKho),
                new SqlParameter("@TenKho", kho.TenKho),
                new SqlParameter("@SucChua", kho.SucChua),
                new SqlParameter("@MoTa", (object)kho.MoTa ?? DBNull.Value)
            };
            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        public bool Xoa(string maKho)
        {
            string sql = "DELETE FROM KHOSACH WHERE MaKho = @MaKho";
            SqlParameter[] param =
            {
                new SqlParameter("@MaKho", maKho)
            };
            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        public DataTable TimKiem(string keyword)
        {
            string sql = @"SELECT MaKho, TenKho, SucChua, MoTa FROM KHOSACH 
                           WHERE MaKho LIKE @Key OR TenKho LIKE @Key OR MoTa LIKE @Key";
            SqlParameter[] param =
            {
                new SqlParameter("@Key", "%" + keyword + "%")
            };
            return _db.GetDataTable(sql, param);
        }

        public bool KiemTraTonTai(string maKho)
        {
            string sql = "SELECT COUNT(*) FROM KHOSACH WHERE MaKho = @MaKho";
            SqlParameter[] param =
            {
                new SqlParameter("@MaKho", maKho)
            };
            object result = _db.ExecuteScalar(sql, param);
            return result != null && Convert.ToInt32(result) > 0;
        }
    }
}
