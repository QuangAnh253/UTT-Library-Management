using System;

namespace UTT.Library.DTO
{
    public class DTO_PhieuMuon
    {
        public string MaPhieuMuon { get; set; }
        public string MaThe { get; set; }
        public string MaNV { get; set; }
        public DateTime NgayMuon { get; set; }
        public DateTime HanTra { get; set; }
        public string TrangThai { get; set; }
        public string GhiChu { get; set; }

        public DTO_PhieuMuon() { }

        public DTO_PhieuMuon(string maPhieuMuon, string maThe, string maNV, DateTime ngayMuon, DateTime hanTra, string trangThai, string ghiChu)
        {
            MaPhieuMuon = maPhieuMuon;
            MaThe = maThe;
            MaNV = maNV;
            NgayMuon = ngayMuon;
            HanTra = hanTra;
            TrangThai = trangThai;
            GhiChu = ghiChu;
        }
    }
}
