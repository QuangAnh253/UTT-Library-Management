using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTT.Library.DTO;
using UTT.Library.DAL;
using UTT.Library.DAL.Repositories;

namespace UTT.Library.BLL.Services
{
    public class BLL_NhaXuatBan
    {
        private DAL_NhaXuatBan _dal = new DAL_NhaXuatBan();

        public DataTable LayDanhSach()
        {
            return _dal.LayDanhSach();
        }

        public string Them(DTO_NhaXuatBan nxb)
        {
            if (_dal.Them(nxb))
                return "";
            return "Thêm nhà xuất bản thất bại!";
        }

        public string Sua(DTO_NhaXuatBan nxb)
        {
            if (_dal.Sua(nxb))
                return "";
            return "Cập nhật nhà xuất bản thất bại!";
        }

        public string Xoa(string ma)
        {
            if (_dal.Xoa(ma))
                return "";
            return "Xóa nhà xuất bản thất bại!";
        }

        public DataTable TimKiem(string key)
        {
            return _dal.TimKiem(key);
        }

    }
}
