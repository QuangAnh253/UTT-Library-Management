using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTT.Library.DTO
{
    public class DTO_TheTV
    {
        public string MaThe { get; set; }
        public string MaSV { get; set; }
        public DateTime NgayCap { get; set; }
        public DateTime NgayHetHan {  get; set; }
        public string TrangThai { get; set; }
        public DTO_TheTV()
        {
        }
        public DTO_TheTV(string maThe, string maSV, DateTime ngayCap, DateTime ngayHetHan, string trangThai)
        {
            MaThe = maThe;
            MaSV = maSV;
            NgayCap = ngayCap;
            NgayHetHan = ngayHetHan;
            TrangThai = trangThai;
        }
    }
}
