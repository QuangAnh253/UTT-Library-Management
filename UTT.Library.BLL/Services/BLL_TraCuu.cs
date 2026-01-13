using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTT.Library.DAL.Repositories;

namespace UTT.Library.BLL.Services
{
    public class BLL_TraCuu
    {
        private DAL_TraCuu _dal = new DAL_TraCuu();

        public DataTable TraCuuNangCao(string keyword, string maTheLoai, string maTacGia, string maNXB)
        {
            return _dal.TraCuuNangCao(keyword, maTheLoai, maTacGia, maNXB);
        }

        public DataTable TraCuuTheoTen(string tenSach)
        {
            return _dal.TraCuuTheoTen(tenSach);
        }

        public DataTable LayTatCaSach()
        {
            return _dal.LayTatCaSach();
        }
    }
}
