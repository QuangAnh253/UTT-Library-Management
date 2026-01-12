using System.Data;
using UTT.Library.DAL.Repositories;
using UTT.Library.DTO;

namespace UTT.Library.BLL.Services
{
    public class BLL_DeXuatMuaSach
    {
        private DAL_DeXuatMuaSach _dal = new DAL_DeXuatMuaSach();

        public DataTable LayDanhSach()
        {
            return _dal.GetDanhSach();
        }

        public DataTable TimKiem(string keyword)
        {
            return _dal.TimKiem(keyword);
        }

        public string Them(DTO_DeXuatMuaSach dx)
        {
            if (_dal.Them(dx)) return "";
            return "Không thể thêm đề xuất mua sách";
        }

        public string Sua(DTO_DeXuatMuaSach dx)
        {
            if (_dal.Sua(dx)) return "";
            return "Cập nhật thất bại!";
        }

        public string Xoa(int MaDeXuat)
        {
            if (_dal.Xoa(MaDeXuat)) return "";
            return "Xóa thất bại";
        }
    }
}