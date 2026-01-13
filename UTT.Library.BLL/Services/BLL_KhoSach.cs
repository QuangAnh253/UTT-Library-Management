using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTT.Library.DTO;
using UTT.Library.DAL.Repositories;

namespace UTT.Library.BLL.Services
{
    public class BLL_KhoSach
    {
        private DAL_KhoSach _dal = new DAL_KhoSach();

        public DataTable LayDanhSach()
        {
            return _dal.GetDanhSach();
        }

        public DataTable TimKiem(string keyword)
        {
            return _dal.TimKiem(keyword);
        }

        public string Them(DTO_Kho kho)
        {
            if (string.IsNullOrWhiteSpace(kho.MaKho))
                return "Mã kho không được để trống!";

            if (string.IsNullOrWhiteSpace(kho.TenKho))
                return "Tên kho không được để trống!";

            if (_dal.KiemTraTonTai(kho.MaKho))
                return "Mã kho đã tồn tại!";

            if (_dal.Them(kho)) return "";
            return "Thêm kho thất bại!";
        }

        public string Sua(DTO_Kho kho)
        {
            if (string.IsNullOrWhiteSpace(kho.TenKho))
                return "Tên kho không được để trống!";

            if (_dal.Sua(kho)) return "";
            return "Cập nhật kho thất bại!";
        }

        public string Xoa(string maKho)
        {
            if (_dal.Xoa(maKho)) return "";
            return "Xóa kho thất bại (kho đang được sử dụng)!";
        }
    }
}
