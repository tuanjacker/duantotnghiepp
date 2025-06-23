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
    public partial class frmNhanVien : Form
    {
        BUSNhanVien busNhanVien = new BUSNhanVien();
        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            ClearForm();
            LoadDanhSachNhanVien();
        }

        private void LoadDanhSachNhanVien()
        {
            dgvNhanVien.DataSource = null;
            dgvNhanVien.DataSource = busNhanVien.GetNhanVienList();

            dgvNhanVien.Columns["MaNhanVien"].HeaderText = "Mã Nhân Viên";
            dgvNhanVien.Columns["Ten"].HeaderText = "Họ Tên";
            dgvNhanVien.Columns["Email"].HeaderText = "Email";
            dgvNhanVien.Columns["SoDienThoai"].HeaderText = "Số Điện Thoại";
            dgvNhanVien.Columns["VaiTroText"].HeaderText = "Vai Trò";
            dgvNhanVien.Columns["TrangThaiText"].HeaderText = "Trạng Thái";
            dgvNhanVien.Columns["NgayTao"].Visible = false;
            dgvNhanVien.Columns["VaiTro"].Visible = false;
            dgvNhanVien.Columns["TrangThai"].Visible = false;
            dgvNhanVien.Columns["MatKhau"].Visible = false;

            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void ClearForm()
        {
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = true;
            txtMaNhanVien.Clear();
            txtTenNhanVien.Clear();
            txtSoDienThoai.Clear();
            txtEmail.Clear();
            txtMatKhau.Clear();
            rdoNhanVien.Checked = true;
            rdoHoatDong.Checked = true;
        }

        private void dgvNhanVien_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];
            // Đổ dữ liệu vào các ô nhập liệu trên form
            txtMaNhanVien.Text = row.Cells["MaNhanVien"].Value.ToString();
            txtTenNhanVien.Text = row.Cells["Ten"].Value.ToString();
            txtEmail.Text = row.Cells["Email"].Value.ToString();
            txtMatKhau.Text = row.Cells["MatKhau"].Value.ToString();
            txtSoDienThoai.Text = row.Cells["SoDienThoai"].Value.ToString();

            bool vaiTro = Convert.ToBoolean(row.Cells["VaiTro"].Value);
            if (vaiTro == false)
            {
                rdoNhanVien.Checked = true;
            }
            else
            {
                rdoQuanLy.Checked = true;
            }

            bool trangThai = Convert.ToBoolean(row.Cells["TrangThai"].Value);
            if (trangThai == false)
            {
                rdoKhongHoatDong.Checked = true;
            }
            else
            {
                rdoHoatDong.Checked = true;
            }

            // Bật nút "Sửa"
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            // Tắt chỉnh sửa mã nhân viên
            txtMaNhanVien.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNhanVien.Text.Trim();
            string hoTen = txtTenNhanVien.Text.Trim();
            string email = txtEmail.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();
            string phone = txtSoDienThoai.Text.Trim();
            bool vaiTro;

            if (rdoNhanVien.Checked)
            {
                vaiTro = true;
            }
            else
            {
                vaiTro = false;
            }
            bool trangThai;

            if (rdoHoatDong.Checked)
            {
                trangThai = true;
            }
            else
            {
                trangThai = false;
            }
            if (string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(matKhau) || string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin nhân viên.");
                return;
            }

            NhanVien nv = new NhanVien
            {
                MaNhanVien = maNV,
                Ten = hoTen,
                Email = email,
                MatKhau = matKhau,
                SoDienThoai = phone,
                VaiTro = vaiTro,
                TrangThai = trangThai
            };
            string result = busNhanVien.InsertNhanVien(nv);

            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Cập nhật thông tin thành công");
                ClearForm();
                LoadDanhSachNhanVien();
            }
            else
            {
                MessageBox.Show(result);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNhanVien.Text.Trim();
            string hoTen = txtTenNhanVien.Text.Trim();
            string email = txtEmail.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();
            string phone = txtSoDienThoai.Text.Trim();
            bool vaiTro;

            if (rdoNhanVien.Checked)
            {
                vaiTro = true;
            }
            else
            {
                vaiTro = false;
            }
            bool trangThai;

            if (rdoHoatDong.Checked)
            {
                trangThai = true;
            }
            else
            {
                trangThai = false;
            }
            if (string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(matKhau) || string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin nhân viên.");
                return;
            }

            NhanVien nv = new NhanVien
            {
                MaNhanVien = maNV,
                Ten = hoTen,
                Email = email,
                MatKhau = matKhau,
                SoDienThoai = phone,
                VaiTro = vaiTro,
                TrangThai = trangThai
            };
            string result = busNhanVien.UpdateNhanVien(nv);

            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Cập nhật thông tin thành công");
                ClearForm();
                LoadDanhSachNhanVien();
            }
            else
            {
                MessageBox.Show(result);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maNhanVien = txtMaNhanVien.Text.Trim();
            string name = txtTenNhanVien.Text.Trim();
            if (string.IsNullOrEmpty(maNhanVien))
            {
                if (dgvNhanVien.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dgvNhanVien.SelectedRows[0];
                    maNhanVien = selectedRow.Cells["MaNhanVien"].Value.ToString();
                    name = selectedRow.Cells["Ten"].Value.ToString();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một nhân viên để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (string.IsNullOrEmpty(maNhanVien))
            {
                MessageBox.Show("Xóa không thành công.");
                return;
            }

            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa nhân viên {maNhanVien} - {name}?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                BUSNhanVien bus = new BUSNhanVien();
                string kq = bus.DeleteNhanVien(maNhanVien);

                if (string.IsNullOrEmpty(kq))
                {
                    MessageBox.Show($"Xóa thông tin nhân viên {maNhanVien} - {name} thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadDanhSachNhanVien();
                }
                else
                {
                    MessageBox.Show(kq, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadDanhSachNhanVien();
        }
    }
}
