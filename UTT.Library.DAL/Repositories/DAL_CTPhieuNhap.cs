using System.Data;
using System.Data.SqlClient;
using UTT.Library.DAL.Database;
using UTT.Library.DTO;

namespace UTT.Library.DAL.Repositories
{
    public class DAL_CTPhieuNhap
    {
        private readonly DatabaseHelper _db = new DatabaseHelper();

        public DataTable GetByMaPhieuNhap(string maPhieuNhap)
        {
            string sql = "SELECT * FROM CT_PHIEUNHAP WHERE MaPhieuNhap = @MaPhieuNhap";
            SqlParameter[] param =
            {
                new SqlParameter("@MaPhieuNhap", maPhieuNhap)
            };
            return _db.GetDataTable(sql, param);
        }

        public bool Them(DTO_CTPhieuNhap ct)
        {
            string sql = @"INSERT INTO CT_PHIEUNHAP (MaPhieuNhap, MaSach, SoLuong, DonGia)
                           VALUES (@MaPhieuNhap, @MaSach, @SoLuong, @DonGia)";

            SqlParameter[] param =
            {
                new SqlParameter("@MaPhieuNhap", ct.MaPhieuNhap),
                new SqlParameter("@MaSach", ct.MaSach),
                new SqlParameter("@SoLuong", ct.SoLuong),
                new SqlParameter("@DonGia", ct.DonGia)
            };

            return _db.ExecuteNonQuery(sql, param) > 0;
        }
    }
}
