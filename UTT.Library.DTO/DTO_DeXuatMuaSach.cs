using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTT.Library.DTO
{
    public class DTO_DeXuatMuaSach
    {
        public int MaDeXuat { get; set; }
        public string TenSach { get; set; }
        public string TacGia { get; set; }
        public string NhaXuatBan { get; set; }
        public int SoLuong { get; set; }
        public decimal GiaDuKien { get; set; }
        public DateTime NgayDeXuat { get; set; }
        public string TrangThai { get; set; }
        public string GhiChu { get; set; }

        public DTO_DeXuatMuaSach() { }

        public DTO_DeXuatMuaSach(int maDeXuat, string tenSach, string tacGia, string nhaXuatBan, 
            int soLuong, decimal giaDuKien, DateTime ngayDeXuat, string trangThai, string ghiChu)
        {
            MaDeXuat = maDeXuat;
            TenSach = tenSach;
            TacGia = tacGia;
            NhaXuatBan = nhaXuatBan;
            SoLuong = soLuong;
            GiaDuKien = giaDuKien;
            NgayDeXuat = ngayDeXuat;
            TrangThai = trangThai;
            GhiChu = ghiChu;
        }
    }
}