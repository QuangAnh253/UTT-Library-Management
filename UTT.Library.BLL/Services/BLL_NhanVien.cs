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
    public class BLL_NhanVien
    {
        private DAL_NhanVien _dal = new DAL_NhanVien();

        // ================== LẤY DANH SÁCH ==================
        public DataTable LayDanhSach()
        {
            return _dal.GetDanhSach();
        }

        // ================== TÌM KIẾM ==================
        public DataTable TimKiem(string keyword)
        {
            return _dal.TimKiem(keyword);
        }
        public string Them(DTO_NhanVien nv)
        {
            // Validate cơ bản (BLL-level)
            if (string.IsNullOrWhiteSpace(nv.MaNV))
                return "Mã nhân viên không được để trống!";

            if (string.IsNullOrWhiteSpace(nv.HoTen))
                return "Họ tên không được để trống!";

            // Email, SĐT: validate chi tiết ở FORM bằng ValidationHelper
            // BLL chỉ check null/empty

            if (_dal.Them(nv))
                return ""; // rỗng = thành công

            return "Không thể thêm nhân viên (có thể trùng mã nhân viên)!";
        }
        public string Sua(DTO_NhanVien nv)
        {
            if (string.IsNullOrWhiteSpace(nv.MaNV))
                return "Chưa chọn nhân viên cần sửa!";

            if (_dal.Sua(nv))
                return "";

            return "Cập nhật nhân viên thất bại!";
        }
        public string Xoa(string maNV)
        {
            if (string.IsNullOrWhiteSpace(maNV))
                return "Chưa chọn nhân viên cần xóa!";

            if (_dal.Xoa(maNV))
                return "";

            return "Xóa thất bại (dữ liệu đang được sử dụng)!";
        }
    }

}
