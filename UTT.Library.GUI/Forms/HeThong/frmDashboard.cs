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
using UTT.Library.DTO;

namespace UTT.Library.GUI.Forms.HeThong
{
    public partial class frmDashboard : Form
    {
        private BLL_ThongKe _bll = new BLL_ThongKe();

        public frmDashboard()
        {
            InitializeComponent();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            LoadThongKe();
        }

        private void LoadThongKe()
        {
            try
            {
                DTO_ThongKe tk = _bll.LayThongKeTongQuan();

                lblTongSoSach.Text = tk.TongSoSach.ToString();
                lblTongDocGia.Text = tk.TongSoDocGia.ToString();
                lblPhieuDangMuon.Text = tk.SoPhieuDangMuon.ToString();
                lblPhieuQuaHan.Text = tk.SoPhieuQuaHan.ToString();
                lblTongTaiKhoan.Text = tk.SoTaiKhoan.ToString();

                // Top 5 sách
                dgvTop5.DataSource = _bll.LayTop5SachMuonNhieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load thống kê: " + ex.Message);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadThongKe();
        }
    }
}
