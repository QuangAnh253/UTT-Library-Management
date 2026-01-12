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
    public class BLL_SachThanhLy
    {
        private DAL_SachThanhLy _dal = new DAL_SachThanhLy();

        // Lấy danh sách sách đã thanh lý
        public DataTable LayDanhSach()
        {
            return _dal.GetDanhSach();
        }

        // Tìm kiếm sách thanh lý
        public DataTable TimKiem(string keyword)
        {
            return _dal.TimKiem(keyword);
        }

        // Thanh lý sách (Thêm vào SACHTHANHLY + Trừ số lượng)
        public string ThanhLySach(DTO_SachThanhLy stl)
        {
            // Validate
            if (stl.MaSach <= 0)
                return "Vui lòng chọn sách cần thanh lý!";

            if (string.IsNullOrWhiteSpace(stl.LyDo))
                return "Lý do thanh lý không được để trống!";

            if (stl.SoLuongThanhLy <= 0)
                return "Số lượng thanh lý phải lớn hơn 0!";

            // Kiểm tra số lượng tồn kho
            int soLuongTon = _dal.GetSoLuongTon(stl.MaSach);
            if (soLuongTon < stl.SoLuongThanhLy)
                return $"Số lượng thanh lý ({stl.SoLuongThanhLy}) vượt quá số lượng tồn ({soLuongTon})!";

            // Thêm vào bảng SACHTHANHLY
            if (!_dal.Them(stl))
                return "Thêm vào danh sách thanh lý thất bại!";

            // Cập nhật số lượng sách
            if (!_dal.CapNhatSoLuongSach(stl.MaSach, stl.SoLuongThanhLy))
                return "Cập nhật số lượng sách thất bại!";

            return ""; // Thành công
        }

        // Xóa bản ghi thanh lý
        public string Xoa(int maThanhLy)
        {
            if (maThanhLy <= 0)
                return "Mã thanh lý không hợp lệ!";

            if (_dal.Xoa(maThanhLy))
                return "";

            return "Xóa thất bại!";
        }

        // Lấy số lượng tồn kho
        public int GetSoLuongTon(int maSach)
        {
            return _dal.GetSoLuongTon(maSach);
        }

    }
}
