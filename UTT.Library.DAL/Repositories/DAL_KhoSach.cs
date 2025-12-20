using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTT.Library.DAL.Database;
using UTT.Library.DTO;

namespace UTT.Library.DAL.Repositories
{
    public class DAL_KhoSach
    {
        // Hàm lấy toàn bộ danh sách kho để hiện lên bảng
        public DataTable GetDanhSach()
        {
            string query = "SELECT * FROM KHOSACH";
            return DatabaseHelper.ExecuteQuery(query); // Gọi hàm dùng chung của nhóm
        }

        // Hàm Thêm (Sử dụng Parameter @ để chống hack SQL Injection)
        public bool Them(DTO_KhoSach kho)
        {
            string query = "INSERT INTO KHOSACH (MaKho, TenKho, SucChua, MoTa) VALUES (@Ma, @Ten, @Sc, @Mt)";
            object[] parameters = { kho.MaKho, kho.TenKho, kho.SucChua, kho.MoTa };
            return DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        // Hàm Sửa
        public bool Sua(DTO_KhoSach kho)
        {
            string query = "UPDATE KHOSACH SET TenKho = @Ten, SucChua = @Sc, MoTa = @Mt WHERE MaKho = @Ma";
            object[] parameters = { kho.TenKho, kho.SucChua, kho.MoTa, kho.MaKho };
            return DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        // Hàm Xóa
        public bool Xoa(string maKho)
        {
            string query = "DELETE FROM KHOSACH WHERE MaKho = @Ma";
            object[] parameters = { maKho };
            return DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
        }
    }
}
