using System.Data;
using UTT.Library.DAL.Repositories;
using UTT.Library.DTO;

namespace UTT.Library.BLL.Services
{
    public class BLL_PhieuDatTruoc
    {
        private DAL_PhieuDatTruoc _dal = new DAL_PhieuDatTruoc();

        public DataTable LayDanhSach()
        {
            return _dal.GetDanhSach();
        }

        public DataTable TimKiem(string keyword)
        {
            return _dal.TimKiem(keyword);
        }

        public string Them(DTO_PhieuDatTruoc phieu)
        {
            if (_dal.Them(phieu)) return "";
            return "Không thể thêm phiếu đặt trước";
        }

        public string Sua(DTO_PhieuDatTruoc phieu)
        {
            if (_dal.Sua(phieu)) return "";
            return "Cập nhật thất bại!";
        }

        public string Xoa(int MaPhieuDat)
        {
            if (_dal.Xoa(MaPhieuDat)) return "";
            return "Xóa thất bại";
        }
    }
}
