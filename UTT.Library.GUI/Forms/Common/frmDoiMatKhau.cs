using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UTT.Library.BLL.Services;
using UTT.Library.GUI.Utilities;

namespace UTT.Library.GUI.Forms.Common
{
    public partial class frmDoiMatKhau : Form
    {
        private BLL_TaiKhoan _bll = new BLL_TaiKhoan();

        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            if (!Session.IsLoggedIn())
            {
                MessageBox.Show("Bạn chưa đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenDangNhap = Session.CurrentAccount.TenDangNhap;
            string matKhauCu = txtMatKhauCu.Text;
            string matKhauMoi = txtMatKhauMoi.Text;
            string xacNhan = txtXacNhan.Text;

            string kq = _bll.DoiMatKhau(tenDangNhap, matKhauCu, matKhauMoi, xacNhan);

            if (string.IsNullOrEmpty(kq))
            {
                MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show(kq, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
