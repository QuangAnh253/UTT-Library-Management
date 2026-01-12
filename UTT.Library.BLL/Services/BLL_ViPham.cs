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
    public class BLL_ViPham
    {
        private DAL_ViPham _dal = new DAL_ViPham();

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

        // ================== GHI NHẬN VI PHẠM ==================
        public string GhiNhan(DTO_ViPham vp)
        {
            if (string.IsNullOrWhiteSpace(vp.MaSV))
                return "Mã sinh viên không được để trống!";

            if (string.IsNullOrWhiteSpace(vp.LoiViPham))
                return "Lỗi vi phạm không được để trống!";

            if (vp.SoTienPhat < 0)
                return "Số tiền phạt không hợp lệ!";

            // Set nghiệp vụ
            vp.NgayViPham = DateTime.Now;
            vp.TrangThai = "Chưa xử lý";

            if (_dal.GhiNhan(vp))
                return "";

            return "Không thể ghi nhận vi phạm!";
        }

        // ================== XỬ LÝ VI PHẠM ==================
        public string XuLy(int maViPham, string hinhThucXuLy)
        {
            if (maViPham <= 0)
                return "Chưa chọn vi phạm cần xử lý!";

            if (_dal.XuLy(maViPham, hinhThucXuLy))
                return "";

            return "Xử lý vi phạm thất bại!";
        }
    }
}
