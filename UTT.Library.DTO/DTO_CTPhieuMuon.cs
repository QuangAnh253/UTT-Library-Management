using System;

namespace UTT.Library.DTO
{
    public class DTO_CTPhieuMuon
    {
        public int ID { get; set; }
        public string MaPhieuMuon { get; set; }
        public int MaSach { get; set; }
        public DateTime? NgayTra { get; set; }
        public decimal TienPhat { get; set; }
        public string TinhTrangKhiTra { get; set; }
        public int SoLanGiaHan { get; set; }
        public string GhiChu { get; set; }

        public DTO_CTPhieuMuon() { }

        public DTO_CTPhieuMuon(int id, string maPhieuMuon, int maSach, DateTime? ngayTra, decimal tienPhat, string tinhTrangKhiTra, int soLanGiaHan, string ghiChu)
        {
            ID = id;
            MaPhieuMuon = maPhieuMuon;
            MaSach = maSach;
            NgayTra = ngayTra;
            TienPhat = tienPhat;
            TinhTrangKhiTra = tinhTrangKhiTra;
            SoLanGiaHan = soLanGiaHan;
            GhiChu = ghiChu;
        }
    }
}
