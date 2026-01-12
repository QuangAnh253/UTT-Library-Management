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
            string sql = @"SELECT PM.MaPhieuMuon, PM.MaThe, PM.MaNV, PM.NgayMuon, PM.HanTra, PM.TrangThai, PM.GhiChu, 
                            STUFF((
                                SELECT ', ' + CAST(CT.MaSach AS VARCHAR)
                                FROM CT_PHIEUMUON CT
                                WHERE CT.MaPhieuMuon = PM.MaPhieuMuon
                                FOR XML PATH('')
                            ), 1, 2, '') AS MaSach
                        FROM PHIEUMUON PM
                        ORDER BY PM.NgayMuon DESC";
            return _db.GetDataTable(sql);
        }

        public bool KiemTraTonTai(string maPhieuMuon)
        {
            string sql = "SELECT COUNT(*) FROM PHIEUMUON WHERE MaPhieuMuon = @MaPhieuMuon";
            SqlParameter[] param = 
            {
                new SqlParameter("@MaPhieuMuon", maPhieuMuon)
            };
            
            DataTable dt = _db.GetDataTable(sql, param);
            if (dt != null && dt.Rows.Count > 0)
            {
                int count = Convert.ToInt32(dt.Rows[0][0]);
                return count > 0;
            }
            return false;
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

        public DataTable TimKiem(string keyword)
        {
            string sql = @"SELECT PM.MaPhieuMuon, PM.MaThe, PM.MaNV, PM.NgayMuon, PM.HanTra, PM.TrangThai, PM.GhiChu, 
                            STUFF((
                                SELECT ', ' + CAST(CT.MaSach AS VARCHAR)
                                FROM CT_PHIEUMUON CT
                                WHERE CT.MaPhieuMuon = PM.MaPhieuMuon
                                FOR XML PATH('')
                            ), 1, 2, '') AS MaSach
                        FROM PHIEUMUON PM
                        WHERE PM.MaPhieuMuon LIKE @Key OR PM.MaThe LIKE @Key OR PM.TrangThai LIKE @Key
                        ORDER BY PM.NgayMuon DESC";
            SqlParameter[] param = { new SqlParameter("@Key", "%" + keyword + "%") };
            return _db.GetDataTable(sql, param);
        }
    }
}
