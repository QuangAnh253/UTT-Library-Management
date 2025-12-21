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
    public class BLL_Khoa
    {
        private DAL_Khoa _dal = new DAL_Khoa();

        public DataTable LayDanhSach()
        {
            return _dal.GetDanhSach();
        }

        public DataTable TimKiem(string keyword)
        {
            return _dal.TimKiem(keyword);
        }

        public string Them(DTO_Khoa k)
        {
            if (_dal.Them(k)) return "";
            return "Không thể thêm khoa (có thể trùng mã)!";
        }

        public string Sua(DTO_Khoa k)
        {
            if (_dal.Sua(k)) return "";
            return "Cập nhật thất bại!";
        }

        public string Xoa(string ma)
        {
            if (_dal.Xoa(ma)) return "";
            return "Không thể xóa (dữ liệu đang được sử dụng)!";
        }
    }
}
