using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTT.Library.DTO
{
    public class DTO_TheLoai
    {
        public string MaTheLoai { get; set; }
        public string TenTheLoai { get; set; }
<<<<<<< HEAD
        public string MoTa {  get; set; }

        public DTO_TheLoai() { }

        public DTO_TheLoai(string maTheLoai, string tenTheLoai, string moTa)
        {
            MaTheLoai = maTheLoai;
            TenTheLoai = tenTheLoai;
            MoTa = moTa;
            
=======

        public DTO_TheLoai() { }

        public DTO_TheLoai(string maTheLoai, string tenTheLoai)
        {
            MaTheLoai = maTheLoai;
            TenTheLoai = tenTheLoai;
>>>>>>> 19738ad26204ded7890aafbeda36010057251c57
        }
    }
}
