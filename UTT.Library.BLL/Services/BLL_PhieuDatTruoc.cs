using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTT.Library.DAL.Repositories;

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

        public string Them(string maSV, int maSach, DateTime ngayHetHan)
        {
            if (string.IsNullOrWhiteSpace(maSV))
                return "Vui lòng chọn sinh viên!";

            if (maSach <= 0)
                return "Vui lòng chọn sách!";

            if (ngayHetHan <= DateTime.Now)
                return "Ngày hết hạn phải sau ngày hiện tại!";

            if (_dal.Them(maSV, maSach, ngayHetHan)) return "";
            return "Thêm phiếu đặt trước thất bại!";
        }

        public string CapNhatTrangThai(int maPhieuDat, string trangThai)
        {
            if (_dal.CapNhatTrangThai(maPhieuDat, trangThai)) return "";
            return "Cập nhật trạng thái thất bại!";
        }

        public string Xoa(int maPhieuDat)
        {
            if (_dal.Xoa(maPhieuDat)) return "";
            return "Xóa phiếu đặt trước thất bại!";
        }
    }
}
