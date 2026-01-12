using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTT.Library.DTO
{
    public class DTO_PhieuDatTruoc
    {
        public int MaPhieuDat { get; set; }
        public string MaSV { get; set; }
        public int MaSach { get; set; }
        public DateTime NgayDat { get; set; }
        public string TrangThai { get; set; }
        public DateTime NgayHetHan { get; set; }

        public DTO_PhieuDatTruoc() { }

        public DTO_PhieuDatTruoc(int maPhieuDat, string maSV, int maSach, DateTime ngayDat, string trangThai, DateTime ngayHetHan)
        {
            MaPhieuDat = maPhieuDat;
            MaSV = maSV;
            MaSach = maSach;
            NgayDat = ngayDat;
            TrangThai = trangThai;
            NgayHetHan = ngayHetHan;
        }
    }
}
