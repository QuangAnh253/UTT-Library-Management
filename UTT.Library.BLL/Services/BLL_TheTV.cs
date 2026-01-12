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
    public class BLL_TheTV
    {
        private DAL_TheTV _dal = new DAL_TheTV();

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

        // ================== CẤP THẺ ==================
        public string CapThe(DTO_TheTV the)
        {
            // Validate nghiệp vụ
            if (string.IsNullOrWhiteSpace(the.MaThe))
                return "Mã thẻ không được để trống!";

            if (string.IsNullOrWhiteSpace(the.MaSV))
                return "Chưa chọn sinh viên!";

            if (the.NgayHetHan <= DateTime.Now)
                return "Ngày hết hạn phải lớn hơn ngày hiện tại!";

            // Set tự động
            the.NgayCap = DateTime.Now;
            the.TrangThai = "Hoạt động";

            if (_dal.CapThe(the))
                return "";

            return "Không thể cấp thẻ (có thể thẻ đã tồn tại)!";
        }

        // ================== GIA HẠN THẺ ==================
        public string GiaHan(string maThe, DateTime ngayHetHanMoi)
        {
            if (string.IsNullOrWhiteSpace(maThe))
                return "Chưa chọn thẻ cần gia hạn!";

            if (ngayHetHanMoi <= DateTime.Now)
                return "Ngày gia hạn không hợp lệ!";

            if (_dal.GiaHan(maThe, ngayHetHanMoi))
                return "";

            return "Gia hạn thẻ thất bại!";
        }

        // ================== KHÓA THẺ ==================
        public string KhoaThe(string maThe)
        {
            if (string.IsNullOrWhiteSpace(maThe))
                return "Chưa chọn thẻ cần khóa!";

            if (_dal.KhoaThe(maThe))
                return "";

            return "Khóa thẻ thất bại!";
        }
    }
}
