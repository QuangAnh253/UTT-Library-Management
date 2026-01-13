using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTT.Library.DAL.Database;

namespace UTT.Library.DAL.Repositories
{
    public class DAL_PhieuDatTruoc
    {
        private DatabaseHelper _db = new DatabaseHelper();

        public DataTable GetDanhSach()
        {
            string sql = @"SELECT p.MaPhieuDat, p.MaSV, d.HoTen, p.MaSach, s.TenSach, 
                                  p.NgayDat, p.NgayHetHan, p.TrangThai
                           FROM PHIEUDATTRUOC p
                           LEFT JOIN DOCGIA d ON p.MaSV = d.MaSV
                           LEFT JOIN SACH s ON p.MaSach = s.MaSach
                           ORDER BY p.NgayDat DESC";
            return _db.GetDataTable(sql);
        }

        public bool Them(string maSV, int maSach, DateTime ngayHetHan)
        {
            string sql = @"INSERT INTO PHIEUDATTRUOC (MaSV, MaSach, NgayDat, NgayHetHan, TrangThai)
                           VALUES (@MaSV, @MaSach, GETDATE(), @NgayHetHan, N'Đang chờ')";
            SqlParameter[] param =
            {
                new SqlParameter("@MaSV", maSV),
                new SqlParameter("@MaSach", maSach),
                new SqlParameter("@NgayHetHan", ngayHetHan)
            };
            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        public bool CapNhatTrangThai(int maPhieuDat, string trangThai)
        {
            string sql = "UPDATE PHIEUDATTRUOC SET TrangThai = @TrangThai WHERE MaPhieuDat = @MaPhieuDat";
            SqlParameter[] param =
            {
                new SqlParameter("@MaPhieuDat", maPhieuDat),
                new SqlParameter("@TrangThai", trangThai)
            };
            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        public bool Xoa(int maPhieuDat)
        {
            string sql = "DELETE FROM PHIEUDATTRUOC WHERE MaPhieuDat = @MaPhieuDat";
            SqlParameter[] param =
            {
                new SqlParameter("@MaPhieuDat", maPhieuDat)
            };
            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        public DataTable TimKiem(string keyword)
        {
            string sql = @"SELECT p.MaPhieuDat, p.MaSV, d.HoTen, p.MaSach, s.TenSach, 
                                  p.NgayDat, p.NgayHetHan, p.TrangThai
                           FROM PHIEUDATTRUOC p
                           LEFT JOIN DOCGIA d ON p.MaSV = d.MaSV
                           LEFT JOIN SACH s ON p.MaSach = s.MaSach
                           WHERE p.MaSV LIKE @Key OR d.HoTen LIKE @Key OR s.TenSach LIKE @Key
                           ORDER BY p.NgayDat DESC";
            SqlParameter[] param =
            {
                new SqlParameter("@Key", "%" + keyword + "%")
            };
            return _db.GetDataTable(sql, param);
        }
    }
}
