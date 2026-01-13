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
    public class BLL_TheLoai
    {
        private DAL_TheLoai _dal = new DAL_TheLoai();

        public DataTable Laydanhsach()
        {
            return _dal.GetDanhSach();
        }

        public DataTable TimKiem(string keyword)
        {
            return _dal.TimKiem(keyword);
        }

        public string Them(DTO_TheLoai tl)
        {
            if (string.IsNullOrWhiteSpace(tl.MaTheLoai))
                return "Mã thể loại không được để trống!";

            if (string.IsNullOrWhiteSpace(tl.TenTheLoai))
                return "Tên thể loại không được để trống!";

            if (_dal.Them(tl))
                return "";

            return "Thêm thể loại thất bại (có thể trùng mã)!";
        }

        public string Sua(DTO_TheLoai tl)
        {
            if (string.IsNullOrWhiteSpace(tl.MaTheLoai))
                return "Chưa chọn thể loại cần sửa!";

            if (_dal.Sua(tl))
                return "";

            return "Cập nhật thể loại thất bại!";
        }

        public string Xoa(string maTheLoai)
        {
            if (string.IsNullOrWhiteSpace(maTheLoai))
                return "Chưa chọn thể loại cần xóa!";

            if (_dal.Xoa(maTheLoai))
                return "";

            return "Xóa thất bại (dữ liệu đang được sử dụng)!";
        }
    }
}
