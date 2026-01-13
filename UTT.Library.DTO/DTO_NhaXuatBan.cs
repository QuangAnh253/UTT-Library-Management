using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTT.Library.DTO
{
    public class DTO_NhaXuatBan
    {
        public string MaNXB { get; set; }
        public string TenNXB { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }

        public DTO_NhaXuatBan()
        {
        }

        public DTO_NhaXuatBan(string maNXB, string tenNXB, string diaChi = null, string sdt = null)
        {
            MaNXB = maNXB;
            TenNXB = tenNXB;
            DiaChi = diaChi;
            SDT = sdt;
        }
    }
}
