using System;
using System.Windows.Forms;
using UTT.Library.BLL.Services;
using UTT.Library.GUI.Utilities;

namespace UTT.Library.GUI.Forms.Common
{
    public partial class frmDoiMatKhau : Form
    {
        private BLL_TaiKhoan _bllTaiKhoan = new BLL_TaiKhoan();
        private bool isOldPasswordVisible = false;
        private bool isNewPasswordVisible = false;
        private bool isConfirmPasswordVisible = false;

        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            txtMatKhauCu.UseSystemPasswordChar = true;
            txtMatKhauMoi.UseSystemPasswordChar = true;
            txtXacNhanMatKhau.UseSystemPasswordChar = true;

            picToggleOld.Image = Properties.Resources.eye_close;
            picToggleNew.Image = Properties.Resources.eye_close;
            picToggleConfirm.Image = Properties.Resources.eye_close;

            txtMatKhauCu.Focus();
        }

        private void picToggleOld_Click(object sender, EventArgs e)
        {
            isOldPasswordVisible = !isOldPasswordVisible;

            if (isOldPasswordVisible)
            {
                txtMatKhauCu.UseSystemPasswordChar = false;
                picToggleOld.Image = Properties.Resources.eye_open;
            }
            else
            {
                txtMatKhauCu.UseSystemPasswordChar = true;
                picToggleOld.Image = Properties.Resources.eye_close;
            }
        }

        private void picToggleNew_Click(object sender, EventArgs e)
        {
            isNewPasswordVisible = !isNewPasswordVisible;

            if (isNewPasswordVisible)
            {
                txtMatKhauMoi.UseSystemPasswordChar = false;
                picToggleNew.Image = Properties.Resources.eye_open;
            }
            else
            {
                txtMatKhauMoi.UseSystemPasswordChar = true;
                picToggleNew.Image = Properties.Resources.eye_close;
            }
        }

        private void picToggleConfirm_Click(object sender, EventArgs e)
        {
            isConfirmPasswordVisible = !isConfirmPasswordVisible;

            if (isConfirmPasswordVisible)
            {
                txtXacNhanMatKhau.UseSystemPasswordChar = false;
                picToggleConfirm.Image = Properties.Resources.eye_open;
            }
            else
            {
                txtXacNhanMatKhau.UseSystemPasswordChar = true;
                picToggleConfirm.Image = Properties.Resources.eye_close;
            }
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            string matKhauCu = txtMatKhauCu.Text.Trim();
            string matKhauMoi = txtMatKhauMoi.Text.Trim();
            string xacNhan = txtXacNhanMatKhau.Text.Trim();

            if (string.IsNullOrEmpty(matKhauCu))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu cũ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhauCu.Focus();
                return;
            }

            if (string.IsNullOrEmpty(matKhauMoi))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhauMoi.Focus();
                return;
            }

            if (matKhauMoi.Length < 6)
            {
                MessageBox.Show("Mật khẩu mới phải có ít nhất 6 ký tự", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhauMoi.Focus();
                return;
            }

            if (matKhauMoi != xacNhan)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận không khớp", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtXacNhanMatKhau.Focus();
                return;
            }

            try
            {
                string tenDangNhap = Session.CurrentAccount.TenDangNhap;
                string ketQua = _bllTaiKhoan.DoiMatKhau(tenDangNhap, matKhauCu, matKhauMoi);

                if (string.IsNullOrEmpty(ketQua))
                {
                    MessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(ketQua, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
