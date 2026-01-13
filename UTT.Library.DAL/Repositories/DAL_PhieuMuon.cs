using System;
using System.Data;
using System.Data.SqlClient;
using UTT.Library.DAL.Database;
using UTT.Library.DTO;

namespace UTT.Library.DAL.Repositories
{
    public class DAL_PhieuMuon
    {
        private readonly DatabaseHelper _db = new DatabaseHelper();

        public DataTable GetDanhSach()
        {
            string sql = "SELECT * FROM PHIEUMUON";
            return _db.GetDataTable(sql);
        }

        public bool Them(DTO_PhieuMuon pm)
        {
            string sql = @"INSERT INTO PHIEUMUON (MaPhieuMuon, MaThe, MaNV, NgayMuon, HanTra, TrangThai, GhiChu)
                           VALUES (@MaPhieuMuon, @MaThe, @MaNV, @NgayMuon, @HanTra, @TrangThai, @GhiChu)";

            SqlParameter[] param =
            {
                new SqlParameter("@MaPhieuMuon", pm.MaPhieuMuon),
                new SqlParameter("@MaThe", pm.MaThe),
                new SqlParameter("@MaNV", string.IsNullOrWhiteSpace(pm.MaNV) ? (object)DBNull.Value : pm.MaNV),
                new SqlParameter("@NgayMuon", pm.NgayMuon),
                new SqlParameter("@HanTra", pm.HanTra),
                new SqlParameter("@TrangThai", string.IsNullOrWhiteSpace(pm.TrangThai) ? (object)DBNull.Value : pm.TrangThai),
                new SqlParameter("@GhiChu", string.IsNullOrWhiteSpace(pm.GhiChu) ? (object)DBNull.Value : pm.GhiChu)
            };

            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        public bool CapNhatTrangThai(string maPhieuMuon, string trangThai)
        {
            string sql = "UPDATE PHIEUMUON SET TrangThai = @TrangThai WHERE MaPhieuMuon = @MaPhieuMuon";
            SqlParameter[] param =
            {
                new SqlParameter("@MaPhieuMuon", maPhieuMuon),
                new SqlParameter("@TrangThai", trangThai)
            };
            return _db.ExecuteNonQuery(sql, param) > 0;
        }
    }
}
