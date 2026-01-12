using System;
using System.Data;
using System.Linq;
using UTT.Library.DAL.Repositories;
using UTT.Library.DTO;

namespace UTT.Library.BLL.Services
{
    public class BLL_ThongKe
    {
        private DAL_ThongKe _dal = new DAL_ThongKe();

        public DTO_ThongKe LayThongKeTongQuan()
        {
            return new DTO_ThongKe
            {
                TongSoSach = _dal.DemTongSoSach(),
                TongSoDocGia = _dal.DemTongDocGia(),
                SoPhieuDangMuon = _dal.DemPhieuDangMuon(),
                SoPhieuQuaHan = _dal.DemPhieuQuaHan(),
                SoTaiKhoan = _dal.DemTongTaiKhoan()
            };
        }

        public DataTable LayTop5SachMuonNhieu()
        {
            return _dal.LayTop5SachMuonNhieu();
        }
    }
}
