using System;

namespace UTT.Library.DTO
{
    public class DTO_PhieuNhap
    {
        public string MaPhieuNhap { get; set; }
        public string MaNV { get; set; }
        public string MaNCC { get; set; }
        public DateTime NgayNhap { get; set; }
        public decimal TongTien { get; set; }
        public string GhiChu { get; set; }

        public DTO_PhieuNhap() { }

        public DTO_PhieuNhap(string maPhieuNhap, string maNV, string maNCC, DateTime ngayNhap, decimal tongTien, string ghiChu)
        {
            MaPhieuNhap = maPhieuNhap;
            MaNV = maNV;
            MaNCC = maNCC;
            NgayNhap = ngayNhap;
            TongTien = tongTien;
            GhiChu = ghiChu;
        }
    }
}
