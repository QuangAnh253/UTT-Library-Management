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
    public class BLL_NhaXuatBan
    {
        private DAL_NhaXuatBan _dal = new DAL_NhaXuatBan();

        public DataTable Laydanhsach()
        {
            return _dal.GetDanhSach();
        }

        public DataTable TimKiem(string keyword)
        {
            return _dal.TimKiem(keyword);
        }

        public string Them(DTO_NhaXuatBan nxb)
        {
            if (string.IsNullOrWhiteSpace(nxb.MaNXB))
                return "Mã NXB không được để trống!";

            if (string.IsNullOrWhiteSpace(nxb.TenNXB))
                return "Tên NXB không được để trống!";

            if (_dal.Them(nxb))
                return "";

            return "Thêm NXB thất bại (có thể trùng mã)!";
        }

        public string Sua(DTO_NhaXuatBan nxb)
        {
            if (string.IsNullOrWhiteSpace(nxb.MaNXB))
                return "Chưa chọn NXB cần sửa!";

            if (_dal.Sua(nxb))
                return "";

            return "Cập nhật NXB thất bại!";
        }

        public string Xoa(string maNXB)
        {
            if (string.IsNullOrWhiteSpace(maNXB))
                return "Chưa chọn NXB cần xóa!";

            if (_dal.Xoa(maNXB))
                return "";

            return "Xóa thất bại (dữ liệu đang được sử dụng)!";
        }
    }
}
