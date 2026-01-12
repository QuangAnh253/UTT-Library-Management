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
    public class BLL_Sach
    {
        private DAL_Sach _dal = new DAL_Sach();

        public DataTable LayDanhSach()
        {
            return _dal.GetDanhSach();
        }

        public DataTable TimKiem(string keyword)
        {
            return _dal.TimKiem(keyword);
        }

        public string Them(DTO_Sach s)
        {
            if (string.IsNullOrWhiteSpace(s.TenSach))
                return "Tên sách không được để trống";

            if (s.NamXB <= 1900)
                return "Năm xuất bản không hợp lệ";

            if (_dal.Them(s)) return "";
            return "Thêm sách thất bại!";
        }

        public string Sua(DTO_Sach s)
        {
            if (string.IsNullOrWhiteSpace(s.TenSach))
                return "Tên sách không được để trống";

            if (_dal.Sua(s)) return "";
            return "Cập nhật thất bại!";
        }

        public string Xoa(int maSach)
        {
            if (_dal.Xoa(maSach)) return "";
            return "Xóa thất bại (sách đang được sử dụng)!";
        }
    }
}
