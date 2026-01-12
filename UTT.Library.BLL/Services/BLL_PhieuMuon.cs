using System;
using System.Collections.Generic;
using System.Data;
using UTT.Library.DAL.Repositories;
using UTT.Library.DTO;

namespace UTT.Library.BLL.Services
{
    public class BLL_PhieuMuon
    {
        private readonly DAL_PhieuMuon _dalPhieuMuon = new DAL_PhieuMuon();
        private readonly DAL_CTPhieuMuon _dalChiTiet = new DAL_CTPhieuMuon();

        public DataTable LayDanhSach()
        {
            return _dalPhieuMuon.GetDanhSach();
        }

        public DataTable LayChiTiet(string maPhieuMuon)
        {
            return _dalChiTiet.GetByMaPhieuMuon(maPhieuMuon);
        }

        public DataTable TimKiem(string keyword)
        {
            return _dalPhieuMuon.TimKiem(keyword);
        }

        public string LapPhieuMuon(DTO_PhieuMuon pm, List<int> dsMaSach)
        {
            if (pm == null) return "Dữ liệu phiếu mượn không hợp lệ";
            if (string.IsNullOrWhiteSpace(pm.MaPhieuMuon)) return "Vui lòng nhập mã phiếu mượn";
            if (string.IsNullOrWhiteSpace(pm.MaThe)) return "Vui lòng chọn mã thẻ thư viện";
            if (pm.HanTra < pm.NgayMuon) return "Hạn trả phải lớn hơn hoặc bằng ngày mượn";
            if (dsMaSach == null || dsMaSach.Count == 0) return "Vui lòng chọn ít nhất 1 sách để mượn";

            // ✅ KIỂM TRA TRÙNG MÃ
            if (_dalPhieuMuon.KiemTraTonTai(pm.MaPhieuMuon))
            {
                return "Mã phiếu mượn '" + pm.MaPhieuMuon + "' đã tồn tại! Vui lòng nhập mã khác.";
            }

            if (string.IsNullOrWhiteSpace(pm.TrangThai))
                pm.TrangThai = "Đang mượn";

            if (!_dalPhieuMuon.Them(pm))
                return "Không thể lưu phiếu mượn";

            foreach (int maSach in dsMaSach)
            {
                if (!_dalChiTiet.Them(pm.MaPhieuMuon, maSach))
                    return "Không thể lưu chi tiết phiếu mượn";
            }

            return "";
        }

        public string TraSach(int id, DateTime ngayTra, decimal tienPhat, string tinhTrangKhiTra, string ghiChu)
        {
            if (id <= 0) return "ID không hợp lệ";
            if (tienPhat < 0) return "Tiền phạt không hợp lệ";

            if (_dalChiTiet.CapNhatTra(id, ngayTra, tienPhat, tinhTrangKhiTra, ghiChu))
                return "";

            return "Cập nhật trả sách lỗi";
        }

        public string CapNhatTrangThai(string maPhieuMuon, string trangThai)
        {
            if (string.IsNullOrWhiteSpace(maPhieuMuon)) return "Mã phiếu mượn không hợp lệ";
            if (string.IsNullOrWhiteSpace(trangThai)) return "Trạng thái không hợp lệ";

            if (_dalPhieuMuon.CapNhatTrangThai(maPhieuMuon, trangThai))
                return "";

            return "Cập nhật trạng thái phiếu mượn lỗi";
        }
    }
}
