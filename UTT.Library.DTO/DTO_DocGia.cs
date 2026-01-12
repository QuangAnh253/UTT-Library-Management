using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTT.Library.DTO
{
    public class DTO_DocGia
    {
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public string MaLop { get; set; }
        public string MaKhoa { get; set; }
        public string TenDangNhap { get; set; }

        public DTO_DocGia()
        {
        }

        public DTO_DocGia(string maSV, string hoTen, DateTime ngaySinh,string gioiTinh,string sdt,string email, string maLop, string maKhoa, string tenDangNhap)
        {
            MaSV = maSV;
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            GioiTinh = gioiTinh;
            Email = email;
            SDT = sdt;
            MaLop = maLop;
            MaKhoa = maKhoa;
            TenDangNhap = tenDangNhap;
        }
    }
}

