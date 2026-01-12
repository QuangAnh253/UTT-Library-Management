using System.Data;
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
            {
                return null;
            }

            return _dal.CheckLogin(user, pass);
        }

        public string DoiMatKhau(string tenDangNhap, string matKhauCu, string matKhauMoi)
        {
            if (string.IsNullOrEmpty(tenDangNhap)) return "Tên đăng nhập không hợp lệ";
            if (string.IsNullOrEmpty(matKhauCu)) return "Vui lòng nhập mật khẩu cũ";
            if (string.IsNullOrEmpty(matKhauMoi)) return "Vui lòng nhập mật khẩu mới";
            if (matKhauMoi.Length < 6) return "Mật khẩu mới phải có ít nhất 6 ký tự";

            if (_dal.CheckLogin(tenDangNhap, matKhauCu) == null)
            {
                return "Mật khẩu cũ không đúng";
            }

            if (_dal.DoiMatKhau(tenDangNhap, matKhauMoi))
                return "";

            return "Đổi mật khẩu thất bại";
        }

        // ✅ THÊM CRUD
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
            if (string.IsNullOrEmpty(tk.TenDangNhap)) return "Vui lòng nhập tên đăng nhập";
            if (tk.TenDangNhap.Length < 3) return "Tên đăng nhập phải có ít nhất 3 ký tự";
            if (string.IsNullOrEmpty(tk.MatKhau)) return "Vui lòng nhập mật khẩu";
            if (tk.MatKhau.Length < 6) return "Mật khẩu phải có ít nhất 6 ký tự";

            // Kiểm tra trùng
            if (_dal.KiemTraTonTai(tk.TenDangNhap))
            {
                return "Tên đăng nhập '" + tk.TenDangNhap + "' đã tồn tại!";
            }

            if (_dal.Them(tk)) return "";
            return "Không thể thêm tài khoản";
        }

        public string Sua(DTO_TaiKhoan tk)
        {
            if (string.IsNullOrEmpty(tk.TenDangNhap)) return "Tên đăng nhập không hợp lệ";
            if (string.IsNullOrEmpty(tk.MatKhau)) return "Vui lòng nhập mật khẩu";
            if (tk.MatKhau.Length < 6) return "Mật khẩu phải có ít nhất 6 ký tự";

            if (_dal.Sua(tk)) return "";
            return "Cập nhật thất bại";
        }

        public string Xoa(string tenDangNhap)
        {
            if (string.IsNullOrEmpty(tenDangNhap)) return "Tên đăng nhập không hợp lệ";

            if (_dal.Xoa(tenDangNhap)) return "";
            return "Xóa thất bại";
        }
    }
}
