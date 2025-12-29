using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using UTT.Library.DAL.Repositories;
using UTT.Library.DTO;
using System.Runtime.InteropServices.WindowsRuntime;

namespace UTT.Library.BLL.Services
{
    public class BLL_NgonNgu
    {
        public BLL_NgonNgu() { }
        private DAL_NgonNgu _dal = new DAL_NgonNgu();
        public DataTable Laydanhsach()
        { 
            return _dal.GetDanhSach();
        }
        
        public DataTable TimKiem(string keyword)
        {
            return _dal.TimKiem(keyword);
        }

        public string Them(DTO_NgonNgu nn)
        {
            if (string.IsNullOrWhiteSpace(nn.MaNgonNgu))
                return "Mã ngôn ngữ không được để trống";

            if (string.IsNullOrWhiteSpace(nn.TenNgonNgu))
                return "Tên ngôn ngữ không được để trống";

            if (_dal.Them(nn)) return "";
            return "Không thể thêm ngôn ngữ (có thể trùng mã)!";
        }

        public string Sua(DTO_NgonNgu nn)
        {
            if (string.IsNullOrWhiteSpace(nn.TenNgonNgu))
                return "Tên ngôn ngữ không được để trống";

            if (_dal.Sua(nn)) return "";
                return "Cập nhật thất bại!";
        }

        public string Xoa(string ma)
        {
            if (_dal.Xoa(ma)) return "";
            return "Xoa thất bại (Dữ liệu đang được sử dụng)!";
        }
    }
}
