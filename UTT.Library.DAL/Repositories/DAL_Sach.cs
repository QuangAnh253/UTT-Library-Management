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
    public class DAL_Sach
    {
        private DatabaseHelper _db = new DatabaseHelper();

        public DataTable GetDanhSach()
        {
            string sql = @"SELECT * FROM SACH";
            return _db.GetDataTable(sql);
        }

        public bool Them(DTO_Sach s)
        {
            string sql = @"INSERT INTO SACH
                (TenSach, MaTheLoai, MaTacGia, MaNXB, MaNgonNgu,
                 NamXB, GiaTien, AnhBia, SoLuongTon, MoTa)
                VALUES
                (@TenSach, @MaTheLoai, @MaTacGia, @MaNXB, @MaNgonNgu,
                 @NamXB, @GiaTien, @AnhBia, @SoLuongTon, @MoTa)";

            SqlParameter[] param =
            {
                new SqlParameter("@TenSach", s.TenSach),
                new SqlParameter("@MaTheLoai", (object)s.MaTheLoai ?? DBNull.Value),
                new SqlParameter("@MaTacGia", (object)s.MaTacGia ?? DBNull.Value),
                new SqlParameter("@MaNXB", (object)s.MaNXB ?? DBNull.Value),
                new SqlParameter("@MaNgonNgu", (object)s.MaNgonNgu ?? DBNull.Value),
                new SqlParameter("@NamXB", s.NamXB),
                new SqlParameter("@GiaTien", s.GiaTien),
                new SqlParameter("@AnhBia", (object)s.AnhBia ?? DBNull.Value),
                new SqlParameter("@SoLuongTon", s.SoLuongTon),
                new SqlParameter("@MoTa", (object)s.MoTa ?? DBNull.Value)
            };

            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        public bool Sua(DTO_Sach s)
        {
            string sql = @"UPDATE SACH SET
                TenSach = @TenSach,
                MaTheLoai = @MaTheLoai,
                MaTacGia = @MaTacGia,
                MaNXB = @MaNXB,
                MaNgonNgu = @MaNgonNgu,
                NamXB = @NamXB,
                GiaTien = @GiaTien,
                AnhBia = @AnhBia,
                SoLuongTon = @SoLuongTon,
                MoTa = @MoTa
                WHERE MaSach = @MaSach";

            SqlParameter[] param =
            {
                new SqlParameter("@MaSach", s.MaSach),
                new SqlParameter("@TenSach", s.TenSach),
                new SqlParameter("@MaTheLoai", (object)s.MaTheLoai ?? DBNull.Value),
                new SqlParameter("@MaTacGia", (object)s.MaTacGia ?? DBNull.Value),
                new SqlParameter("@MaNXB", (object)s.MaNXB ?? DBNull.Value),
                new SqlParameter("@MaNgonNgu", (object)s.MaNgonNgu ?? DBNull.Value),
                new SqlParameter("@NamXB", s.NamXB),
                new SqlParameter("@GiaTien", s.GiaTien),
                new SqlParameter("@AnhBia", (object)s.AnhBia ?? DBNull.Value),
                new SqlParameter("@SoLuongTon", s.SoLuongTon),
                new SqlParameter("@MoTa", (object)s.MoTa ?? DBNull.Value)
            };

            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        public bool Xoa(int maSach)
        {
            string sql = "DELETE FROM SACH WHERE MaSach = @MaSach";
            SqlParameter[] param =
            {
                new SqlParameter("@MaSach", maSach)
            };
            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        public DataTable TimKiem(string keyword)
        {
            string sql = @"SELECT * FROM SACH 
                           WHERE TenSach LIKE @Key";

            SqlParameter[] param =
            {
                new SqlParameter("@Key", "%" + keyword + "%")
            };

            return _db.GetDataTable(sql, param);
        }
    }
}
