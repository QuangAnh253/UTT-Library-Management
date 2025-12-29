using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTT.Library.DTO
{
    public class DTO_ViTri
    {
        public string MaViTri { get; set; }
        public string TenKe { get; set; }
        public string SoTang { get; set; }
        public string MaKho { get; set; }


        public DTO_ViTri()
        {
        }

        public DTO_ViTri(string maViTri, string tenKe, string soTang, string maKho)
        {
            MaViTri = maViTri;
            TenKe = tenKe;
            SoTang = soTang;
            MaKho = maKho;
        }
    }
}
