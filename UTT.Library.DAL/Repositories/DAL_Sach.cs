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

        // ================= TRA CỨU NÂNG CAO =================

        public DataTable TraCuuNangCao(string keyword, string maTheLoai, string maTacGia, string maNXB)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"SELECT s.MaSach, s.TenSach, 
                                tl.TenTheLoai, tg.TenTacGia, nxb.TenNXB, 
                                s.NamXB, s.GiaTien, s.SoLuongTon
                         FROM SACH s
                         LEFT JOIN THELOAI tl ON s.MaTheLoai = tl.MaTheLoai
                         LEFT JOIN TACGIA tg ON s.MaTacGia = tg.MaTacGia
                         LEFT JOIN NHAXUATBAN nxb ON s.MaNXB = nxb.MaNXB
                         WHERE 1=1 ");

            List<SqlParameter> paramList = new List<SqlParameter>();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                sql.Append(" AND (s.TenSach LIKE @Keyword OR tg.TenTacGia LIKE @Keyword)");
                paramList.Add(new SqlParameter("@Keyword", "%" + keyword + "%"));
            }

            if (!string.IsNullOrWhiteSpace(maTheLoai))
            {
                sql.Append(" AND s.MaTheLoai = @MaTheLoai");
                paramList.Add(new SqlParameter("@MaTheLoai", maTheLoai));
            }

            if (!string.IsNullOrWhiteSpace(maTacGia))
            {
                sql.Append(" AND s.MaTacGia = @MaTacGia");
                paramList.Add(new SqlParameter("@MaTacGia", maTacGia));
            }

            if (!string.IsNullOrWhiteSpace(maNXB))
            {
                sql.Append(" AND s.MaNXB = @MaNXB");
                paramList.Add(new SqlParameter("@MaNXB", maNXB));
            }

            sql.Append(" ORDER BY s.TenSach");

            return _db.GetDataTable(sql.ToString(), paramList.ToArray());
        }

        public DataTable LayTatCaSachChiTiet()
        {
            string sql = @"SELECT s.MaSach, s.TenSach, 
                                  tl.TenTheLoai, tg.TenTacGia, nxb.TenNXB, 
                                  s.NamXB, s.GiaTien, s.SoLuongTon
                           FROM SACH s
                           LEFT JOIN THELOAI tl ON s.MaTheLoai = tl.MaTheLoai
                           LEFT JOIN TACGIA tg ON s.MaTacGia = tg.MaTacGia
                           LEFT JOIN NHAXUATBAN nxb ON s.MaNXB = nxb.MaNXB
                           ORDER BY s.TenSach";

            return _db.GetDataTable(sql);
        }
    }
}
