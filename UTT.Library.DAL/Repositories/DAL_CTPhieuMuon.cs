using System;
using System.Data;
using System.Data.SqlClient;
using UTT.Library.DAL.Database;

namespace UTT.Library.DAL.Repositories
{
    public class DAL_CTPhieuMuon
    {
        private readonly DatabaseHelper _db = new DatabaseHelper();

        public DataTable GetByMaPhieuMuon(string maPhieuMuon)
        {
            string sql = "SELECT * FROM CT_PHIEUMUON WHERE MaPhieuMuon = @MaPhieuMuon";
            SqlParameter[] param =
            {
                new SqlParameter("@MaPhieuMuon", maPhieuMuon)
            };
            return _db.GetDataTable(sql, param);
        }

        public bool Them(string maPhieuMuon, int maSach)
        {
            string sql = @"INSERT INTO CT_PHIEUMUON (MaPhieuMuon, MaSach) 
                           VALUES (@MaPhieuMuon, @MaSach)";

            SqlParameter[] param =
            {
                new SqlParameter("@MaPhieuMuon", maPhieuMuon),
                new SqlParameter("@MaSach", maSach)
            };

            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        public bool CapNhatTra(int id, DateTime ngayTra, decimal tienPhat, string tinhTrangKhiTra, string ghiChu)
        {
            string sql = @"UPDATE CT_PHIEUMUON
                           SET NgayTra = @NgayTra,
                               TienPhat = @TienPhat,
                               TinhTrangKhiTra = @TinhTrangKhiTra,
                               GhiChu = @GhiChu
                           WHERE ID = @ID";

            SqlParameter[] param =
            {
                new SqlParameter("@ID", id),
                new SqlParameter("@NgayTra", ngayTra),
                new SqlParameter("@TienPhat", tienPhat),
                new SqlParameter("@TinhTrangKhiTra", string.IsNullOrWhiteSpace(tinhTrangKhiTra) ? (object)DBNull.Value : tinhTrangKhiTra),
                new SqlParameter("@GhiChu", string.IsNullOrWhiteSpace(ghiChu) ? (object)DBNull.Value : ghiChu)
            };

            return _db.ExecuteNonQuery(sql, param) > 0;
        }
    }
}
