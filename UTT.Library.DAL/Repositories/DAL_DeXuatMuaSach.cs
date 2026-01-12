using System;
using System.Data;
using System.Data.SqlClient;
using UTT.Library.DAL.Database;
using UTT.Library.DTO;

namespace UTT.Library.DAL.Repositories
{
    public class DAL_DeXuatMuaSach
    {
        private DatabaseHelper _db = new DatabaseHelper();

        public DataTable GetDanhSach()
        {
            return _db.GetDataTable("SELECT * FROM DEXUATMUASACH");
        }

        public bool Them(DTO_DeXuatMuaSach dx)
        {
            string sql = "INSERT INTO DEXUATMUASACH (TenSach, TacGia, NhaXuatBan, SoLuong, GiaDuKien, NgayDeXuat, TrangThai, GhiChu)" +
                         "VALUES (@TenSach, @TacGia, @NhaXuatBan, @SoLuong, @GiaDuKien, @NgayDeXuat, @TrangThai, @GhiChu)";
            SqlParameter[] param = {
                new SqlParameter("@TenSach", dx.TenSach),
                new SqlParameter("@TacGia", (object)dx.TacGia ?? DBNull.Value),
                new SqlParameter("@NhaXuatBan", (object)dx.NhaXuatBan ?? DBNull.Value),
                new SqlParameter("@SoLuong", dx.SoLuong),
                new SqlParameter("@GiaDuKien", dx.GiaDuKien),
                new SqlParameter("@NgayDeXuat", dx.NgayDeXuat),
                new SqlParameter("@TrangThai", dx.TrangThai),
                new SqlParameter("@GhiChu", (object)dx.GhiChu ?? DBNull.Value)
            };
            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        public bool Sua(DTO_DeXuatMuaSach dx)
        {
            string sql = "UPDATE DEXUATMUASACH SET TenSach = @TenSach, TacGia = @TacGia, NhaXuatBan = @NhaXuatBan, " +
                         "SoLuong = @SoLuong, GiaDuKien = @GiaDuKien, NgayDeXuat = @NgayDeXuat, " +
                         "TrangThai = @TrangThai, GhiChu = @GhiChu WHERE MaDeXuat = @MaDeXuat";
            SqlParameter[] param = {
                new SqlParameter("@MaDeXuat", dx.MaDeXuat),
                new SqlParameter("@TenSach", dx.TenSach),
                new SqlParameter("@TacGia", (object)dx.TacGia ?? DBNull.Value),
                new SqlParameter("@NhaXuatBan", (object)dx.NhaXuatBan ?? DBNull.Value),
                new SqlParameter("@SoLuong", dx.SoLuong),
                new SqlParameter("@GiaDuKien", dx.GiaDuKien),
                new SqlParameter("@NgayDeXuat", dx.NgayDeXuat),
                new SqlParameter("@TrangThai", dx.TrangThai),
                new SqlParameter("@GhiChu", (object)dx.GhiChu ?? DBNull.Value)
            };
            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        public bool Xoa(int MaDeXuat)
        {
            string sql = "DELETE FROM DEXUATMUASACH WHERE MaDeXuat = @MaDeXuat";
            SqlParameter[] param = { new SqlParameter("@MaDeXuat", MaDeXuat) };
            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        public DataTable TimKiem(string keyword)
        {
            string sql = "SELECT * FROM DEXUATMUASACH WHERE TenSach LIKE @Key OR TacGia LIKE @Key OR NhaXuatBan LIKE @Key";
            SqlParameter[] param = { new SqlParameter("@Key", "%" + keyword + "%") };
            return _db.GetDataTable(sql, param);
        }
    }
}
