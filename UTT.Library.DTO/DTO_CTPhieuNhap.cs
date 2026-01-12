using System;

namespace UTT.Library.DTO
{
    public class DTO_CTPhieuNhap
    {
        public string MaPhieuNhap { get; set; }
        public int MaSach { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }

        public DTO_CTPhieuNhap() { }

        public DTO_CTPhieuNhap(string maPhieuNhap, int maSach, int soLuong, decimal donGia, decimal thanhTien)
        {
            MaPhieuNhap = maPhieuNhap;
            MaSach = maSach;
            SoLuong = soLuong;
            DonGia = donGia;
            ThanhTien = thanhTien;
        }
    }
}
