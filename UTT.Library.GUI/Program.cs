using System;
using System.Windows.Forms;
using UTT.Library.GUI.Forms.Common;
<<<<<<< HEAD
using UTT.Library.GUI.Forms.DanhMuc;
=======
>>>>>>> 19738ad26204ded7890aafbeda36010057251c57

namespace UTT.Library.GUI
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Chạy Form Đăng Nhập đầu tiên
<<<<<<< HEAD
            Application.Run(new frmQuanLyTacGia ());
=======
            Application.Run(new frmDangNhap());
>>>>>>> 19738ad26204ded7890aafbeda36010057251c57
        }
    }
}
