using System.Collections.Generic;
using System.Data;
using UTT.Library.DAL.Repositories;
using UTT.Library.DTO;

namespace UTT.Library.BLL.Services
{
    public class BLL_PhieuNhap
    {
        private readonly DAL_PhieuNhap _dalPhieuNhap = new DAL_PhieuNhap();
        private readonly DAL_CTPhieuNhap _dalChiTiet = new DAL_CTPhieuNhap();

        public DataTable LayDanhSach()
        {
            return _dalPhieuNhap.GetDanhSach();
        }

        public DataTable LayChiTiet(string maPhieuNhap)
        {
            return _dalChiTiet.GetByMaPhieuNhap(maPhieuNhap);
        }

        public string LuuPhieuNhap(DTO_PhieuNhap pn, List<DTO_CTPhieuNhap> dsChiTiet)
        {
            if (pn == null) return "Dữ liệu phiếu nhập không hợp lệ";
            if (string.IsNullOrWhiteSpace(pn.MaPhieuNhap)) return "Vui lòng nhập mã phiếu nhập";
            if (string.IsNullOrWhiteSpace(pn.MaNCC)) return "Vui lòng chọn nhà cung cấp";
            if (string.IsNullOrWhiteSpace(pn.MaNV)) return "Vui lòng chọn nhân viên";
            if (dsChiTiet == null || dsChiTiet.Count == 0) return "Vui lòng nhập ít nhất 1 dòng";

            pn.TongTien = 0;

            if (!_dalPhieuNhap.Them(pn))
                return "Không thể lưu phiếu nhập (có thể trùng mã)!";

            foreach (DTO_CTPhieuNhap ct in dsChiTiet)
            {
                ct.MaPhieuNhap = pn.MaPhieuNhap;

                if (!_dalChiTiet.Them(ct))
                    return "Không thể lưu chi tiết phiếu nhập";

                ct.ThanhTien = ct.SoLuong * ct.DonGia;
                pn.TongTien += ct.ThanhTien;
            }

            return "";
        }
    }
}