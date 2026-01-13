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
    public class BLL_TaiKhoan
    {
        private DAL_TaiKhoan _dal = new DAL_TaiKhoan();

        public DTO_TaiKhoan CheckLogin(string user, string pass)
        {
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
                return null;

            return _dal.CheckLogin(user, pass);
        }

        public DataTable LayDanhSach()
        {
            return _dal.GetDanhSach();
        }

        public DataTable TimKiem(string keyword)
        {
            return _dal.TimKiem(keyword);
        }

        public string Them(DTO_TaiKhoan tk)
        {
            if (string.IsNullOrWhiteSpace(tk.TenDangNhap))
                return "Tên đăng nhập không được để trống!";

            if (tk.TenDangNhap.Length < 3)
                return "Tên đăng nhập phải có ít nhất 3 ký tự!";

            if (string.IsNullOrWhiteSpace(tk.MatKhau))
                return "Mật khẩu không được để trống!";

            if (_dal.KiemTraTonTai(tk.TenDangNhap))
                return "Tên đăng nhập đã tồn tại!";

            if (_dal.Them(tk)) return "";
            return "Thêm tài khoản thất bại!";
        }

        public string Sua(DTO_TaiKhoan tk)
        {
            if (string.IsNullOrWhiteSpace(tk.MatKhau))
                return "Mật khẩu không được để trống!";

            if (_dal.Sua(tk)) return "";
            return "Cập nhật tài khoản thất bại!";
        }

        public string Xoa(string tenDangNhap)
        {
            if (_dal.Xoa(tenDangNhap)) return "";
            return "Xóa tài khoản thất bại!";
        }

        public string DoiMatKhau(string tenDangNhap, string matKhauCu, string matKhauMoi, string xacNhanMatKhau)
        {
            if (string.IsNullOrWhiteSpace(matKhauCu))
                return "Vui lòng nhập mật khẩu cũ!";

            if (string.IsNullOrWhiteSpace(matKhauMoi))
                return "Vui lòng nhập mật khẩu mới!";

            if (matKhauMoi != xacNhanMatKhau)
                return "Mật khẩu mới không khớp!";

            if (matKhauMoi.Length < 3)
                return "Mật khẩu mới phải có ít nhất 3 ký tự!";

            // Kiểm tra mật khẩu cũ
            DTO_TaiKhoan tk = _dal.CheckLogin(tenDangNhap, matKhauCu);
            if (tk == null)
                return "Mật khẩu cũ không đúng!";

            if (_dal.DoiMatKhau(tenDangNhap, matKhauMoi)) return "";
            return "Đổi mật khẩu thất bại!";
        }
    }
}
