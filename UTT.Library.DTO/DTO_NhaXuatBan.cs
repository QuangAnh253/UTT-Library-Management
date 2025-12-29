using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTT.Library.DTO
{
    public class DTO_NhaXuatBan
<<<<<<< HEAD

    {
        public string MaNXB { get; set; }
        public string TenNXB { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }

        public DTO_NhaXuatBan() { }

        public DTO_NhaXuatBan(string ma, string ten, string diachi, string sdt)
        {
            MaNXB = ma;
            TenNXB = ten;
            DiaChi = diachi;
            SDT = sdt;
        }
    }

=======
    {
        public string MaNhaXuatBan { get; set; }
        public string TenNhaXuatBan { get; set; }

        public DTO_NhaXuatBan()
        {
        }

        public DTO_NhaXuatBan(string maNhaXuatBan, string tenNhaXuatBan)
        {
            MaNhaXuatBan = maNhaXuatBan;
            TenNhaXuatBan = tenNhaXuatBan;
        }
    }
>>>>>>> 19738ad26204ded7890aafbeda36010057251c57
}
