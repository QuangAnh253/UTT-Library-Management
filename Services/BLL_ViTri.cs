using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTT.Library.DAL.Repositories;
using UTT.Library.DTO;

namespace UTT.Library.BLL.Services
{
    public class BLL_ViTri
    {
        private DAL_ViTri _dal = new DAL_ViTri();

        public DataTable LayDanhSach()
        {
            return _dal.GetDanhSach();
        }

        public DataTable TimKiem(string keyword)
        {
            return _dal.TimKiem(keyword);
        }

        public string Them(DTO_ViTri vt)
        {
            if (_dal.Them(vt)) return ""; 
            return "Không thể thêm vị trí kệ (có thể trùng mã)!";
        }

        public string Sua(DTO_ViTri vt)
        {
            if (_dal.Sua(vt)) return "";
            return "Cập nhật thất bại!";
        }

        public string Xoa(string ma)
        {
            if (_dal.Xoa(ma)) return "";
            return "Xóa thất bại (Dữ liệu đang được sử dụng)!";
        }
    }
}
