using System.Data;
using UTT.Library.DAL.Repositories;
using UTT.Library.DTO;

namespace UTT.Library.BLL.Services
{
    public class BLL_NhaCungCap
    {
        private DAL_NhaCungCap _dal = new DAL_NhaCungCap();

        public DataTable LayDanhSach()
        { 
            return _dal.GetDanhSach();
        }

        public DataTable TimKiem(string keyword)
        {
            return _dal.TimKiem(keyword);
        }

        public string Them(DTO_NhaCungCap ncc)
        {
            if (_dal.Them(ncc)) return "";
            return "Không thể thêm nhà cung cấp";
        }

        public string Sua(DTO_NhaCungCap ncc)
        {
            if (_dal.Sua(ncc)) return "";
            return "Cập nhật thất bại!";
        }

        public string Xoa(string MaNCC)
        { 
            if(_dal.Xoa(MaNCC)) return "";
            return "Xóa thất bại";
        }
    }
}
