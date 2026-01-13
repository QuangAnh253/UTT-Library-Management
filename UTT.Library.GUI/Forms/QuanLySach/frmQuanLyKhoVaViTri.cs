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
using UTT.Library.GUI.Utilities;

namespace UTT.Library.GUI.Forms.QuanLySach
{
    public partial class frmQuanLyKhoVaViTri : Form
    {
        private BLL_KhoSach _bll = new BLL_KhoSach();
        
        public frmQuanLyKhoVaViTri()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
        }
        
        private void frmQuanLyKho_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            // TODO: Thêm controls vào Designer trước khi sử dụng
            // LoadData();
            // DecorateDataGridView();
            // DecorateSearchBox();
            // DecorateButton();
        }
    }
}
