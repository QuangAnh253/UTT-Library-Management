using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using UTT.Library.DAL.Database;
using UTT.Library.DTO;
namespace UTT.Library.DAL.Repositories
{
    public class DAL_ViTri
    {
        private DatabaseHelper _db = new DatabaseHelper();
        public DataTable GetDanhSach()
        {
            return _db.GetDataTable("SELECT * FROM VITRI");
        }
        public bool Them(DTO_ViTri vt)
        {
            string sql = "INSERT INTO VITRI(MaViTri, TenKe, SoTang, MaKho) VALUES(@Ma, @Ten, @Tang, @MaKho)";
            SqlParameter[] param = {
                new SqlParameter("@Ma", vt.MaViTri),
                new SqlParameter("@Ten", vt.TenKe),
                new SqlParameter("@Tang", vt.SoTang),
                new SqlParameter("@MaKho", vt.MaKho)
            };
            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        public bool Sua(DTO_ViTri vt)
        {
            string sql = "UPDATE VITRI SET TenKe = @Ten, SoTang = @Tang, MaKho = @Kho WHERE MaViTri = @Ma";
            SqlParameter[] param =
            {
                new SqlParameter("@Ma", vt.MaViTri),
                new SqlParameter("@Ten", vt.TenKe),
                new SqlParameter("@Tang", vt.SoTang),
                new SqlParameter("@Kho", vt.MaKho)
            };
            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        public bool Xoa(string ma)
        {
            string sql = "DELETE FROM VITRI WHERE MaViTri = @Ma";
            SqlParameter[] param = { new SqlParameter("@Ma", ma) };
            return _db.ExecuteNonQuery(sql, param) > 0;
        }

        public DataTable TimKiem(string keyword)
        {
            string sql = "SELECT * FROM VITRI WHERE TenKe LIKE @Key OR MaViTri LIKE @Key";
            SqlParameter[] param = { new SqlParameter("@Key", "%" + keyword + "%") };
            return _db.GetDataTable(sql, param);
        }
    }
}
