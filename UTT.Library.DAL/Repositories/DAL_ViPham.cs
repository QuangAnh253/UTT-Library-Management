using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTT.Library.DAL.Database;
using UTT.Library.DTO;

namespace UTT.Library.DAL.Repositories
{
    public class DAL_ViPham
    {
        private DatabaseHelper _db = new DatabaseHelper();

        // ================== LẤY DANH SÁCH ==================
        public DataTable GetDanhSach()
        {
            string sql = "SELECT * FROM VIPHAM ORDER BY NgayViPham DESC";
            return _db.GetDataTable(sql);
        }

        // ================== GHI NHẬN VI PHẠM ==================
        public bool GhiNhan(DTO_ViPham vp)
        {
            string sql = @"
                INSERT INTO VIPHAM
                (MaSV, LoiViPham, HinhThucXuLy, SoTienPhat, NgayViPham, TrangThai)
                VALUES
                (@MaSV, @Loi, @HinhThuc, @SoTien, @Ngay, @TrangThai)";

            SqlParameter[] param =
            {
                new SqlParameter("@MaSV", vp.MaSV),
                new SqlParameter("@Loi", vp.LoiViPham),
                new SqlParameter("@HinhThuc", vp.HinhThucXuLy ?? (object)DBNull.Value),
                new SqlParameter("@SoTien", vp.SoTienPhat),
                new SqlParameter("@Ngay", vp.NgayViPham),
                new SqlParameter("@TrangThai", vp.TrangThai)
            };

            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        // ================== XỬ LÝ VI PHẠM ==================
        public bool XuLy(int maViPham, string hinhThucXuLy)
        {
            string sql = @"
                UPDATE VIPHAM
                SET TrangThai = N'Đã xử lý',
                    HinhThucXuLy = @HinhThuc
                WHERE MaViPham = @Ma";

            SqlParameter[] param =
            {
                new SqlParameter("@Ma", maViPham),
                new SqlParameter("@HinhThuc", hinhThucXuLy ?? (object)DBNull.Value)
            };

            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        // ================== TÌM KIẾM ==================
        public DataTable TimKiem(string keyword)
        {
            string sql = @"
                SELECT * FROM VIPHAM
                WHERE MaSV LIKE @Key
                   OR LoiViPham LIKE @Key
                   OR TrangThai LIKE @Key";

            SqlParameter[] param =
            {
                new SqlParameter("@Key", "%" + keyword + "%")
            };

            return _db.GetDataTable(sql, param);
        }
    }
}
