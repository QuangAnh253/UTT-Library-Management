using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTT.Library.DTO
{
    public class DTO_ViPham
    {
        public int MaViPham { get; set; }
        public string MaSV { get; set; }
        public string LoiViPham { get; set; }
        public string HinhThucXuLy {  get; set; }
        public decimal SoTienPhat { get; set; }
        public DateTime NgayViPham { get; set; }
        public string TrangThai {  get; set; }

        public DTO_ViPham()
        {
        }

        public DTO_ViPham(int maViPham, string maSV, string loiViPham, string hinhThucXuLy, decimal soTienPhat, DateTime ngayViPham, string trangThai)
        {
            MaViPham = maViPham;
            MaSV = maSV;
            LoiViPham = loiViPham;
            HinhThucXuLy = hinhThucXuLy;
            SoTienPhat = soTienPhat;
            NgayViPham = ngayViPham;
            TrangThai = trangThai;
        }
    }
}
