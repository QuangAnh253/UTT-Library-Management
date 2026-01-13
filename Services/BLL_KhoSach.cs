using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTT.Library.DTO;
using UTT.Library.DAL.Repositories;

namespace UTT.Library.BLL.Services
{
    public class BLL_KhoSach
    {
        private DAL_KhoSach _dal = new DAL_KhoSach();

        public DataTable LayDanhSach()
        {
            return _dal.GetDanhSach();
        }

    }
}
