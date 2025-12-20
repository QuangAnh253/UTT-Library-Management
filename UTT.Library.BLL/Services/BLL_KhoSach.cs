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
    public class BLL_KhoSach
    {
        // Khởi tạo lớp DAL để gọi các hàm truy vấn dữ liệu
        private DAL_KhoSach _dal = new DAL_KhoSach();

        /// <summary>
        /// Lấy toàn bộ danh sách kho sách để hiển thị lên DataGridView
        /// </summary>
        public DataTable GetDanhSach()
        {
            return _dal.GetDanhSach();
        }

        /// <summary>
        /// Hàm xử lý thêm kho mới (Có kiểm tra nghiệp vụ)
        /// </summary>
        public bool Them(DTO_KhoSach kho)
        {
            // Quy tắc 4: Kiểm tra sơ bộ dữ liệu đầu vào (Validation)
            if (string.IsNullOrEmpty(kho.MaKho) || string.IsNullOrEmpty(kho.TenKho))
            {
                return false; // Trả về false nếu để trống thông tin bắt buộc
            }

            // Gọi xuống tầng DAL để thực hiện lưu vào CSDL
            return _dal.Them(kho);
        }

        /// <summary>
        /// Hàm xử lý sửa thông tin kho
        /// </summary>
        public bool Sua(DTO_KhoSach kho)
        {
            // Kiểm tra Validation trước khi sửa
            if (string.IsNullOrEmpty(kho.MaKho) || string.IsNullOrEmpty(kho.TenKho))
            {
                return false;
            }

            return _dal.Sua(kho);
        }

        /// <summary>
        /// Hàm xử lý xóa kho dựa trên mã kho
        /// </summary>
        public bool Xoa(string maKho)
        {
            if (string.IsNullOrEmpty(maKho))
            {
                return false;
            }

            return _dal.Xoa(maKho);
        }
    }
}
