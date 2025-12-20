using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTT.Library.DTO
{
    public class DTO_KhoSach
    {
        public string MaKho { get; set; }     
        public string TenKho { get; set; }    
        public int SucChua { get; set; }      
        public string MoTa { get; set; }

        public DTO_KhoSach() { }

        public DTO_KhoSach(string maKho, string tenKho, int sucChua, string moTa)
        {
            MaKho = maKho;
            TenKho = tenKho;
            SucChua = sucChua;
            MoTa = moTa;
        }
    }
}
