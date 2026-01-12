using System;
using System.Data;
using UTT.Library.DAL.Database;

namespace UTT.Library.DAL.Repositories
{
    public class DAL_ThongKe
    {
        private DatabaseHelper _db = new DatabaseHelper();

        // Tổng số sách
        public int DemTongSoSach()
        {
            string sql = "SELECT ISNULL(SUM(SoLuongTon), 0) FROM SACH";
            DataTable dt = _db.GetDataTable(sql);
            return dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0][0]) : 0;
        }

        // Tổng số độc giả
        public int DemTongDocGia()
        {
            string sql = "SELECT COUNT(*) FROM DOCGIA";
            DataTable dt = _db.GetDataTable(sql);
            return dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0][0]) : 0;
        }

        // Số phiếu đang mượn
        public int DemPhieuDangMuon()
        {
            string sql = "SELECT COUNT(*) FROM PHIEUMUON WHERE TrangThai = N'Đang mượn'";
            DataTable dt = _db.GetDataTable(sql);
            return dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0][0]) : 0;
        }

        // Số phiếu quá hạn
        public int DemPhieuQuaHan()
        {
            string sql = "SELECT COUNT(*) FROM PHIEUMUON WHERE TrangThai = N'Quá hạn'";
            DataTable dt = _db.GetDataTable(sql);
            return dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0][0]) : 0;
        }

        // Tổng số tài khoản
        public int DemTongTaiKhoan()
        {
            string sql = "SELECT COUNT(*) FROM TAIKHOAN";
            DataTable dt = _db.GetDataTable(sql);
            return dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0][0]) : 0;
        }

        // Top 5 sách được mượn nhiều nhất
        public DataTable LayTop5SachMuonNhieu()
        {
            string sql = @"SELECT TOP 5 
                            S.MaSach, 
                            S.TenSach, 
                            COUNT(*) AS SoLanMuon
                        FROM CT_PHIEUMUON CT
                        INNER JOIN SACH S ON CT.MaSach = S.MaSach
                        GROUP BY S.MaSach, S.TenSach
                        ORDER BY SoLanMuon DESC";
            return _db.GetDataTable(sql);
        }
    }
}