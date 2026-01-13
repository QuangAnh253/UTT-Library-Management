using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTT.Library.DAL.Database;

namespace UTT.Library.BLL.Services
{
    public class BLL_ThongKe
    {
        private DatabaseHelper _db = new DatabaseHelper();

        public int DemTongSach()
        {
            string sql = "SELECT COUNT(*) FROM SACH";
            object result = _db.ExecuteScalar(sql);
            return result != null ? Convert.ToInt32(result) : 0;
        }

        public int DemTongDocGia()
        {
            string sql = "SELECT COUNT(*) FROM DOCGIA";
            object result = _db.ExecuteScalar(sql);
            return result != null ? Convert.ToInt32(result) : 0;
        }

        public int DemPhieuMuonDangMuon()
        {
            string sql = "SELECT COUNT(*) FROM PHIEUMUON WHERE TrangThai = N'Đang mượn'";
            object result = _db.ExecuteScalar(sql);
            return result != null ? Convert.ToInt32(result) : 0;
        }

        public int DemPhieuMuonQuaHan()
        {
            string sql = "SELECT COUNT(*) FROM PHIEUMUON WHERE TrangThai = N'Quá hạn'";
            object result = _db.ExecuteScalar(sql);
            return result != null ? Convert.ToInt32(result) : 0;
        }

        public int DemSachSapHet()
        {
            string sql = "SELECT COUNT(*) FROM SACH WHERE SoLuongTon <= 2 AND SoLuongTon > 0";
            object result = _db.ExecuteScalar(sql);
            return result != null ? Convert.ToInt32(result) : 0;
        }

        public int DemSachHetHang()
        {
            string sql = "SELECT COUNT(*) FROM SACH WHERE SoLuongTon = 0";
            object result = _db.ExecuteScalar(sql);
            return result != null ? Convert.ToInt32(result) : 0;
        }

        public int DemPhieuDatTruocDangCho()
        {
            string sql = "SELECT COUNT(*) FROM PHIEUDATTRUOC WHERE TrangThai = N'Đang chờ'";
            object result = _db.ExecuteScalar(sql);
            return result != null ? Convert.ToInt32(result) : 0;
        }

        public DataTable LaySachMuonNhieuNhat(int top = 5)
        {
            string sql = $@"SELECT TOP {top} s.TenSach, COUNT(ct.MaSach) AS SoLanMuon
                           FROM CT_PHIEUMUON ct
                           INNER JOIN SACH s ON ct.MaSach = s.MaSach
                           GROUP BY s.TenSach
                           ORDER BY SoLanMuon DESC";
            return _db.GetDataTable(sql);
        }

        public DataTable LayPhieuMuonGanDay(int top = 10)
        {
            string sql = $@"SELECT TOP {top} pm.MaPhieuMuon, d.HoTen, pm.NgayMuon, pm.HanTra, pm.TrangThai
                           FROM PHIEUMUON pm
                           INNER JOIN THETHUVIEN t ON pm.MaThe = t.MaThe
                           INNER JOIN DOCGIA d ON t.MaSV = d.MaSV
                           ORDER BY pm.NgayMuon DESC";
            return _db.GetDataTable(sql);
        }
    }
}
