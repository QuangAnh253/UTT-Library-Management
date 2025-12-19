using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTT.Library.DAL.Database;
using System.Data;
namespace UTT.Library.DAL.Repositories
{
    public class DAL_KhoSach
    {

        private DatabaseHelper _db = new DatabaseHelper();

        public DataTable GetDanhSach()
        {
            return _db.GetDataTable("SELECT MaKho, TenKho FROM KHOSACH");
        }
    }
}
