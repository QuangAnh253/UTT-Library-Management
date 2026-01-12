using System;
using System.Data;
using System.Data.SqlClient;
using UTT.Library.DAL.Database;
using UTT.Library.DTO;

namespace UTT.Library.DAL.Repositories
{
    public class DAL_PhieuNhap
    {
        private readonly DatabaseHelper _db = new DatabaseHelper();

        public DataTable GetDanhSach()
        { 
            string sql = "SELECT * FROM PHIEUNHAP";
            return _db.GetDataTable(sql);
        }

        public bool Them(DTO_PhieuNhap pn)
        { 
            string sql = @"INSERT INTO PHIEUNHAP (MaPhieuNhap, MaNV, MaNCC, NgayNhap, TongTien, GhiChu) 
                           VALUES (@MaPhieuNhap, @MaNV, @MaNCC, @NgayNhap, @TongTien, @GhiChu)";
            SqlParameter[] param =
            {
                new SqlParameter("@MaPhieuNhap", pn.MaPhieuNhap),
                new SqlParameter("@MaNV", string .IsNullOrWhiteSpace(pn.MaNV) ? (object)DBNull.Value : pn.MaNV),
                new SqlParameter("@MaNCC", string.IsNullOrWhiteSpace(pn.MaNCC) ? (object)DBNull.Value : pn.MaNCC),
                new SqlParameter("@NgayNhap", pn.NgayNhap),
                new SqlParameter("@TongTien", pn.TongTien),
                new SqlParameter("@GhiChu", string.IsNullOrWhiteSpace(pn.GhiChu) ? (object)DBNull.Value : pn.GhiChu)
            };
            return _db.ExecuteNonQuery(sql, param) > 0;
        }
    }
}
