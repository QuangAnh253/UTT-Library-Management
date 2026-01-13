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

namespace UTT.Library.GUI.Forms.HeThong
{
    public partial class frmDashboard : Form
    {
        private BLL_ThongKe _bll = new BLL_ThongKe();

        public frmDashboard()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            LoadThongKe();
        }

        private void LoadThongKe()
        {
            try
            {
                lblTongSachValue.Text = _bll.DemTongSach().ToString();
                lblDocGiaValue.Text = _bll.DemTongDocGia().ToString();
                lblDangMuonValue.Text = _bll.DemPhieuMuonDangMuon().ToString();
                lblQuaHanValue.Text = _bll.DemPhieuMuonQuaHan().ToString();
                dgvPhieuMuon.DataSource = _bll.LayPhieuMuonGanDay(10);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
