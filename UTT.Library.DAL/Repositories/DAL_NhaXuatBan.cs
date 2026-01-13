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
    public class DAL_NhaXuatBan
    {
        private DatabaseHelper _db = new DatabaseHelper();

        public DataTable GetDanhSach()
        {
            return _db.GetDataTable("SELECT * FROM NHAXUATBAN");
        }

        public bool Them(DTO_NhaXuatBan nxb)
        {
            string sql = "INSERT INTO NHAXUATBAN(MaNXB, TenNXB, DiaChi, SDT) VALUES(@Ma, @Ten, @DiaChi, @SDT)";
            SqlParameter[] param = {
                new SqlParameter("@Ma", nxb.MaNXB),
                new SqlParameter("@Ten", nxb.TenNXB),
                new SqlParameter("@DiaChi", nxb.DiaChi ?? (object)DBNull.Value),
                new SqlParameter("@SDT", nxb.SDT ?? (object)DBNull.Value)
            };
            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        public bool Sua(DTO_NhaXuatBan nxb)
        {
            string sql = "UPDATE NHAXUATBAN SET TenNXB = @Ten, DiaChi = @DiaChi, SDT = @SDT WHERE MaNXB = @Ma";
            SqlParameter[] param = {
                new SqlParameter("@Ma", nxb.MaNXB),
                new SqlParameter("@Ten", nxb.TenNXB),
                new SqlParameter("@DiaChi", nxb.DiaChi ?? (object)DBNull.Value),
                new SqlParameter("@SDT", nxb.SDT ?? (object)DBNull.Value)
            };
            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        public bool Xoa(string ma)
        {
            string sql = "DELETE FROM NHAXUATBAN WHERE MaNXB = @Ma";
            SqlParameter[] param = { new SqlParameter("@Ma", ma) };
            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        public DataTable TimKiem(string keyword)
        {
            string sql = "SELECT * FROM NHAXUATBAN WHERE TenNXB LIKE @Key OR MaNXB LIKE @Key";
            SqlParameter[] param = { new SqlParameter("@Key", "%" + keyword + "%") };
            return _db.GetDataTable(sql, param);
        }
    }
}
