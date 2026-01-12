using System;
using System.Data;
using System.Data.SqlClient;
using UTT.Library.DAL.Database;
using UTT.Library.DTO;

namespace UTT.Library.DAL.Repositories
{
    public class DAL_PhieuDatTruoc
    {
        private DatabaseHelper _db = new DatabaseHelper();

        public DataTable GetDanhSach()
        {
            return _db.GetDataTable("SELECT * FROM PHIEUDATTRUOC");
        }

        public bool Them(DTO_PhieuDatTruoc phieu)
        {
            string sql = "INSERT INTO PHIEUDATTRUOC (MaSV, MaSach, NgayDat, TrangThai, NgayHetHan)" +
                         "Values (@MaSV, @MaSach, @NgayDat, @TrangThai, @NgayHetHan)";
            SqlParameter[] param = {
                new SqlParameter ("@MaSV", phieu.MaSV),
                new SqlParameter ("@MaSach", phieu.MaSach),
                new SqlParameter ("@NgayDat", phieu.NgayDat),
                new SqlParameter ("@TrangThai", phieu.TrangThai),
                new SqlParameter ("@NgayHetHan", phieu.NgayHetHan)
            };
            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        public bool Sua(DTO_PhieuDatTruoc phieu)
        {
            string sql = "UPDATE PHIEUDATTRUOC SET MaSV = @MaSV, MaSach = @MaSach, NgayDat = @NgayDat, TrangThai = @TrangThai, NgayHetHan = @NgayHetHan WHERE MaPhieuDat = @MaPhieuDat";
            SqlParameter[] param = {
                new SqlParameter ("@MaPhieuDat", phieu.MaPhieuDat),
                new SqlParameter ("@MaSV", phieu.MaSV),
                new SqlParameter ("@MaSach", phieu.MaSach),
                new SqlParameter ("@NgayDat", phieu.NgayDat),
                new SqlParameter ("@TrangThai", phieu.TrangThai),
                new SqlParameter ("@NgayHetHan", phieu.NgayHetHan)
            };
            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        public bool Xoa(int MaPhieuDat)
        {
            string sql = "DELETE FROM PHIEUDATTRUOC WHERE MaPhieuDat = @MaPhieuDat";
            SqlParameter[] param = { new SqlParameter("@MaPhieuDat", MaPhieuDat) };
            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        public DataTable TimKiem(string keyword)
        {
            string sql = "SELECT * FROM PHIEUDATTRUOC WHERE MaSV LIKE @Key OR CAST(MaSach AS VARCHAR) LIKE @Key OR CAST(MaPhieuDat AS VARCHAR) LIKE @Key";
            SqlParameter[] param = { new SqlParameter("@Key", "%" + keyword + "%") };
            return _db.GetDataTable(sql, param);
        }
    }
}
