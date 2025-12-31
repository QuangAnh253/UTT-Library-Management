using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTT.Library.DTO
{
    public class DTO_Sach
    {
        public int MaSach { get; set; }
        public string TenSach { get; set; }
        public string MaTheLoai { get; set; }
        public string MaTacGia { get; set; }
        public string MaNXB { get; set; }
        public string MaNgonNgu { get; set; }
        public int NamXB { get; set; }
        public decimal GiaTien { get; set; }
        public string AnhBia { get; set; }
        public int SoLuongTon { get; set; }
        public string MoTa { get; set; }

        public DTO_Sach() { }

        public DTO_Sach(int maSach, string tenSach, string maTheLoai,
                        string maTacGia, string maNXB, string maNgonNgu,
                        int namXB, decimal giaTien, string anhBia,
                        int soLuongTon, string moTa)
        {
            MaSach = maSach;
            TenSach = tenSach;
            MaTheLoai = maTheLoai;
            MaTacGia = maTacGia;
            MaNXB = maNXB;
            MaNgonNgu = maNgonNgu;
            NamXB = namXB;
            GiaTien = giaTien;
            AnhBia = anhBia;
            SoLuongTon = soLuongTon;
            MoTa = moTa;
        }
    }
}
