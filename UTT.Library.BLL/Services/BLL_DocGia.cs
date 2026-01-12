using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTT.Library.DAL.Repositories;
using UTT.Library.DTO;

namespace UTT.Library.BLL.Services
{
    public class BLL_DocGia
    {
        private DAL_DocGia _dal = new DAL_DocGia();

        public DataTable LayDanhSach()
        {
            return _dal.GetDanhSach();
        }

        public DataTable TimKiem(string keyword)
        {
            return _dal.TimKiem(keyword);
        }

        public string Them(DTO_DocGia dg)
        {
            // Validate cơ bản (BLL-level)
            if (string.IsNullOrWhiteSpace(dg.MaSV))
                return "Mã sinh viên không được để trống!";

            if (string.IsNullOrWhiteSpace(dg.HoTen))
                return "Họ tên không được để trống!";

            // Email, SĐT: validate chi tiết ở FORM bằng ValidationHelper
            // BLL chỉ check null/empty để tránh lỗi logic

            if (_dal.Them(dg))
                return ""; // rỗng = thành công

            return "Không thể thêm độc giả (có thể trùng mã sinh viên)!";
        }

        public string Sua(DTO_DocGia dg)
        {
            if (string.IsNullOrWhiteSpace(dg.MaSV))
                return "Chưa chọn sinh viên cần sửa!";

            if (_dal.Sua(dg))
                return "";

            return "Cập nhật độc giả thất bại!";
        }

        public string Xoa(string maSV)
        {
            if (string.IsNullOrWhiteSpace(maSV))
                return "Chưa chọn sinh viên cần xóa!";

            if (_dal.Xoa(maSV))
                return "";

            return "Xóa thất bại (dữ liệu đang được sử dụng)!";
        }
    }
}
