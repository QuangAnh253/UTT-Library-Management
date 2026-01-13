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
    public class DAL_TraCuu
    {
        private DatabaseHelper _db = new DatabaseHelper();

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

        public DataTable TraCuuTheoTen(string tenSach)
        {
            string sql = @"SELECT s.MaSach, s.TenSach, 
                                  tl.TenTheLoai, tg.TenTacGia, nxb.TenNXB, 
                                  s.NamXB, s.GiaTien, s.SoLuongTon
                           FROM SACH s
                           LEFT JOIN THELOAI tl ON s.MaTheLoai = tl.MaTheLoai
                           LEFT JOIN TACGIA tg ON s.MaTacGia = tg.MaTacGia
                           LEFT JOIN NHAXUATBAN nxb ON s.MaNXB = nxb.MaNXB
                           WHERE s.TenSach LIKE @TenSach
                           ORDER BY s.TenSach";

            SqlParameter[] param =
            {
                new SqlParameter("@TenSach", "%" + tenSach + "%")
            };

            return _db.GetDataTable(sql, param);
        }

        public DataTable LayTatCaSach()
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
