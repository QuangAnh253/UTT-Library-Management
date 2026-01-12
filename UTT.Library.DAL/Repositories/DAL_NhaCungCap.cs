using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTT.Library.DAL.Database;
using UTT.Library.DTO;


namespace UTT.Library.DAL.Repositories
{
    public class DAL_NhaCungCap
    {
        private DatabaseHelper _db = new DatabaseHelper();

        public DataTable GetDanhSach()
        {
            return _db.GetDataTable("SELECT * FROM NHACUNGCAP");
        }

        public bool Them(DTO_NhaCungCap ncc)
        {
            string sql = "INSERT INTO NHACUNGCAP (MaNCC, TenNCC, DiaChi, SDT, Email)" +
                         "Values (@MaNCC, @TenNCC, @DiaChi, @SDT, @Email)";
            SqlParameter[] param = {
                new SqlParameter ("@MaNCC", ncc.MaNCC),
                new SqlParameter ("@TenNCC", ncc.TenNCC),
                new SqlParameter ("@DiaChi", ncc.DiaChi),
                new SqlParameter ("@SDT", ncc.SDT),
                new SqlParameter ("@Email", ncc.Email)
            };
            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        public bool Sua(DTO_NhaCungCap ncc)
        {
            string sql = "UPDATE NHACUNGCAP SET TenNCC = @TenNCC, DiaChi = @DiaChi, SDT = @SDT, Email = @Email WHERE MaNCC = @MaNCC";
            SqlParameter[] param = {
                new SqlParameter ("@MaNCC", ncc.MaNCC),
                new SqlParameter ("@TenNCC", ncc.TenNCC),
                new SqlParameter ("@DiaChi", ncc.DiaChi),
                new SqlParameter ("@SDT", ncc.SDT),
                new SqlParameter ("@Email", ncc.Email)
        };
            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        public bool Xoa(string MaNCC)
        { 
            string sql = "DELETE FROM NHACUNGCAP WHERE MaNCC = @MaNCC";
            SqlParameter[] param = { new SqlParameter("@MaNCC", MaNCC) };
            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        public DataTable TimKiem(string keyword)
        {
            string sql = "SELECT * FROM NHACUNGCAP WHERE TenNCC LIKE @Key OR MaNCC LIKE @Key OR SDT LIKE @Key";
            SqlParameter[] param = { new SqlParameter("@Key", "%" + keyword + "%") };
            return _db.GetDataTable(sql, param);
        }
    }
}