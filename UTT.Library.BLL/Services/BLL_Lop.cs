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
    public class BLL_Lop
    {
        private DAL_Lop _dal = new DAL_Lop();

        public DataTable LayDanhSach() => _dal.GetDanhSach();

        public DataTable TimKiem(string key) => _dal.TimKiem(key);

        public string Them(DTO_Lop l)
        {
            if (_dal.Them(l)) return "";
            return "Thêm lớp thất bại (trùng mã?)";
        }

        public string Sua(DTO_Lop l)
        {
            if (_dal.Sua(l)) return "";
            return "Cập nhật thất bại!";
        }

        public string Xoa(string ma)
        {
            if (_dal.Xoa(ma)) return "";
            return "Không thể xóa lớp!";
        }
    }
}
