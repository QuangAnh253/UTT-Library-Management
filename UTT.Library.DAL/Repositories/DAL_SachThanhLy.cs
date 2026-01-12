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
   public class DAL_SachThanhLy

    {
        private DatabaseHelper _db = new DatabaseHelper();

        // Lấy danh sách sách thanh lý
        public DataTable GetDanhSach()
        {
            string sql = @"SELECT 
                    stl.MaThanhLy, 
                    stl.MaSach, 
                    s.TenSach,
                    stl.LyDo, 
                    stl.NgayXuLy, 
                    stl.NguoiXuLy, 
                    stl.SoLuongThanhLy,
                    s.TacGia,
                    s.NhaXuatBan
                FROM SACHTHANHLY stl
                INNER JOIN SACH s ON stl.MaSach = s.MaSach
                ORDER BY stl.NgayXuLy DESC";

            return _db.GetDataTable(sql);
        }

        // Thêm sách vào thanh lý
        public bool Them(DTO_SachThanhLy stl)
        {
            string sql = @"INSERT INTO SACHTHANHLY 
                (MaSach, LyDo, NgayXuLy, NguoiXuLy, SoLuongThanhLy)
                VALUES 
                (@MaSach, @LyDo, @NgayXuLy, @NguoiXuLy, @SoLuongThanhLy)";

            SqlParameter[] param =
            {
                new SqlParameter("@MaSach", stl.MaSach),
                new SqlParameter("@LyDo", stl.LyDo),
                new SqlParameter("@NgayXuLy", stl.NgayXuLy),
                new SqlParameter("@NguoiXuLy", (object)stl.NguoiXuLy ?? DBNull.Value),
                new SqlParameter("@SoLuongThanhLy", stl.SoLuongThanhLy)
            };

            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        // Cập nhật số lượng sách sau khi thanh lý
        public bool CapNhatSoLuongSach(int maSach, int soLuongThanhLy)
        {
            string sql = @"UPDATE SACH 
                SET SoLuong = SoLuong - @SoLuongThanhLy
                WHERE MaSach = @MaSach AND SoLuong >= @SoLuongThanhLy";

            SqlParameter[] param =
            {
                new SqlParameter("@MaSach", maSach),
                new SqlParameter("@SoLuongThanhLy", soLuongThanhLy)
            };

            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        // Xóa bản ghi thanh lý
        public bool Xoa(int maThanhLy)
        {
            string sql = "DELETE FROM SACHTHANHLY WHERE MaThanhLy = @MaThanhLy";
            SqlParameter[] param =
            {
                new SqlParameter("@MaThanhLy", maThanhLy)
            };
            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        // Lấy số lượng tồn kho
        public int GetSoLuongTon(int maSach)
        {
            string sql = "SELECT SoLuong FROM SACH WHERE MaSach = @MaSach";
            SqlParameter[] param =
            {
                new SqlParameter("@MaSach", maSach)
            };

            object result = _db.ExecuteScalar(sql, param);
            return result != null && result != DBNull.Value ? Convert.ToInt32(result) : 0;
        }

        // Tìm kiếm sách thanh lý
        public DataTable TimKiem(string keyword)
        {
            string sql = @"SELECT 
                    stl.MaThanhLy, 
                    stl.MaSach, 
                    s.TenSach,
                    stl.LyDo, 
                    stl.NgayXuLy, 
                    stl.NguoiXuLy, 
                    stl.SoLuongThanhLy,
                    s.TacGia,
                    s.NhaXuatBan
                FROM SACHTHANHLY stl
                INNER JOIN SACH s ON stl.MaSach = s.MaSach
                WHERE s.TenSach LIKE @Key OR stl.LyDo LIKE @Key
                ORDER BY stl.NgayXuLy DESC";

            SqlParameter[] param =
            {
                new SqlParameter("@Key", "%" + keyword + "%")
            };

            return _db.GetDataTable(sql, param);
        }
    }
}
