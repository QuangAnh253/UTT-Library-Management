using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTT.Library.DTO
{
    public class DTO_SachThanhLy
    {
        public int MaThanhLy { get; set; }
        public int MaSach { get; set; }
        public string TenSach { get; set; }
        public string LyDo { get; set; }
        public DateTime NgayXuLy { get; set; }
        public string NguoiXuLy { get; set; }
        public int SoLuongThanhLy { get; set; }
        public string TacGia { get; set; }
        public string NhaXuatBan { get; set; }

        public DTO_SachThanhLy() { }

        public DTO_SachThanhLy(int maThanhLy, int maSach, string tenSach,
                               string lyDo, DateTime ngayXuLy, string nguoiXuLy,
                               int soLuongThanhLy, string tacGia, string nhaXuatBan)
        {
            MaThanhLy = maThanhLy;
            MaSach = maSach;
            TenSach = tenSach;
            LyDo = lyDo;
            NgayXuLy = ngayXuLy;
            NguoiXuLy = nguoiXuLy;
            SoLuongThanhLy = soLuongThanhLy;
            TacGia = tacGia;
            NhaXuatBan = nhaXuatBan;
        }
    }
}