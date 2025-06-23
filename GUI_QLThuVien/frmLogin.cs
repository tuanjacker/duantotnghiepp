using BUS_Xuong;
using DTO_Xuong;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QLThuVien
{
    public partial class frmLogin : Form
    {
        BUSNhanVien busNhanVien = new BUSNhanVien();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassword.Text;
            NhanVien nv = busNhanVien.DangNhap("hoa.nguyen@thuviendhtp.vn", "123456");
            //NhanVien nv = BUSNhanVien.DangNhap("hung.pham@gmail.vn", "hashed_hung789");
            //NhanVien nv = BUSNhanVien.DangNhap(username, password);
            if (nv == null)
            {
                MessageBox.Show(this, "Tài khoản hoặc mật khẩu không chính xác");
            }
            else
            {
                if (nv.TrangThai == false)
                {
                    MessageBox.Show(this, "Tài khoản đang tạm khóa, vui lòng viên hệ QTV!!!");
                    return;
                }

                frmMain main = new frmMain();
                main.Show();
                this.Hide();
            }
        }
    }
}
