using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace GUI_QLThuVien
{
    public partial class frmMuonTraSach : Form
    {
        public frmMuonTraSach()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void frmMuonTraSach_Load(object sender, EventArgs e)
        {

        }

        private void guna2TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2TabControl1.SelectedTab != null)
            {
                if(guna2TabControl1.SelectedTab.Name == "traSach")
                {
                    TabPage tab = guna2TabControl1.SelectedTab;
                    frmTraSach frm = new frmTraSach();
                    if (guna2TabControl1.SelectedTab.Name == "traSach")
                    {
                        frm.TopLevel = false;
                        frm.FormBorderStyle = FormBorderStyle.None;
                        frm.Dock = DockStyle.Fill;

                        tab.Controls.Add(frm);
                        frm.Show();
                        return;
                    }
                }
            }
        }
    }
}
