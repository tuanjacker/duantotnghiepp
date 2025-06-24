using BUS_Xuong;
using DAL_Xuong;
using Guna.UI2.WinForms;
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
    public partial class frmSach : Form
    {
        private BUSSach sachBLL;
        public frmSach()
        {
            InitializeComponent();
        }

        private void tabSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabSach.SelectedTab != null)
            {
                if (tabSach.SelectedTab.Name == "qlPhiSach")
                {
                    TabPage tab = tabSach.SelectedTab;
                    frmPhiSach frm = new frmPhiSach();
                    if (tabSach.SelectedTab.Name == "qlPhiSach")
                    {
                        frm.TopLevel = false;
                        frm.FormBorderStyle = FormBorderStyle.None;
                        frm.Dock = DockStyle.Fill;

                        tab.Controls.Add(frm);
                        frm.Show();
                        return;
                    }
                }
                else if (tabSach.SelectedTab.Name == "qlLoaiSach")
                {
                    TabPage tab = tabSach.SelectedTab;
                    frmTheLoaiSach frm = new frmTheLoaiSach();
                    if (tabSach.SelectedTab.Name == "qlLoaiSach")
                    {
                        frm.TopLevel = false;
                        frm.FormBorderStyle = FormBorderStyle.None;
                        frm.Dock = DockStyle.Fill;

                        tab.Controls.Add(frm);
                        frm.Show();
                        return;
                    }
                }

                else if (tabSach.SelectedTab.Name == "qlTacGia")
                {
                    TabPage tab = tabSach.SelectedTab;
                    frmTacGia frm = new frmTacGia();
                    if (tabSach.SelectedTab.Name == "qlTacGia")
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

        private void frmSach_Load(object sender, EventArgs e)
        {
            loaddanhsachsach();
        }

        private void loaddanhsachsach()
        {
            dgvsach.DataSource = null;
            dgvsach.DataSource = new BUSSach().GetAllSach();

            // Safely set header text only if the column exists
            if (dgvsach.Columns["MaSach"] != null)
                dgvsach.Columns["MaSach"].HeaderText = "Mã Sách"; if (dgvsach.Columns["TenSach"] != null)
                dgvsach.Columns["TenSach"].HeaderText = "Tên Sách";
            if (dgvsach.Columns["TacGia"] != null)
                dgvsach.Columns["TacGia"].HeaderText = "Tác Giả";
            if (dgvsach.Columns["TheLoai"] != null)
                dgvsach.Columns["TheLoai"].HeaderText = "Thể Loại";
            if (dgvsach.Columns["SoLuong"] != null)
                dgvsach.Columns["SoLuong"].HeaderText = "Số Lượng";
            if (dgvsach.Columns["NhaXuatBan"] != null)
                dgvsach.Columns["NhaXuatBan"].HeaderText = "Nhà Xuất Bản";

            dgvsach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dgvSach_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvsach.Rows[e.RowIndex].DataBoundItem is DALSach sach)
            {
                txtMaSach.Text = sach.MaSach;
                txtTenSach.Text = sach.TieuDe;
                cbTheLoai.Text = sach.MaTheLoai;
                cbTacGia.Text = sach.MaTacGia;
                cbNhaXuatBan.Text = sach.NhaXuatBan;
                txtsoluong.Text = sach.SoLuongTon;
                cbtrangthai.SelectedItem = sach.TrangThai == "True" ? "Còn hàng" : "Hết hàng";
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void bttimkiem_Click(object sender, EventArgs e)
        {

            string keyword = txtTimKiem.Text.Trim().ToLower();
            var allBooks = new BUSSach().GetAllSach();

            var filteredBooks = allBooks.Where(sach =>
                (sach.MaSach != null && sach.MaSach.ToLower().Contains(keyword)) ||
                (sach.TieuDe != null && sach.TieuDe.ToLower().Contains(keyword)) ||
                (sach.MaTheLoai != null && sach.MaTheLoai.ToLower().Contains(keyword)) ||
                (sach.MaTacGia != null && sach.MaTacGia.ToLower().Contains(keyword)) ||
                (sach.NhaXuatBan != null && sach.NhaXuatBan.ToLower().Contains(keyword))
            ).ToList();

            dgvsach.DataSource = null;
            dgvsach.DataSource = filteredBooks;

            // Optionally, re-apply column headers and autosize
            if (dgvsach.Columns["MaSach"] != null)
                dgvsach.Columns["MaSach"].HeaderText = "Mã Sách";
            if (dgvsach.Columns["TieuDe"] != null)
                dgvsach.Columns["TieuDe"].HeaderText = "Tiêu Đề";
            if (dgvsach.Columns["MaTheLoai"] != null)
                dgvsach.Columns["MaTheLoai"].HeaderText = "Mã Thể loại";
            if (dgvsach.Columns["MaTacGia"] != null)
                dgvsach.Columns["MaTacGia"].HeaderText = "Mã Tác Gỉa";
            if (dgvsach.Columns["NhaXuatBan"] != null)
                dgvsach.Columns["NhaXuatBan"].HeaderText = "Nhà Xuất Bản";
            if (dgvsach.Columns["SoLuongTon"] != null)
                dgvsach.Columns["SoLuongTon"].HeaderText = "Số Lượng Tồn";

            dgvsach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Validate required fields
            if (string.IsNullOrWhiteSpace(txtMaSach.Text) ||
                string.IsNullOrWhiteSpace(txtTenSach.Text) ||
                string.IsNullOrWhiteSpace(cbTheLoai.Text) ||
                string.IsNullOrWhiteSpace(cbTacGia.Text) ||
                string.IsNullOrWhiteSpace(cbNhaXuatBan.Text) ||
                string.IsNullOrWhiteSpace(txtsoluong.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create new book object
            var sach = new DALSach
            {
                MaSach = txtMaSach.Text.Trim(),
                TieuDe = txtTenSach.Text.Trim(),
                MaTheLoai = cbTheLoai.Text.Trim(),
                MaTacGia = cbTacGia.Text.Trim(),
                NhaXuatBan = cbNhaXuatBan.Text.Trim(),
                SoLuongTon = txtsoluong.Text.Trim(),
                TrangThai = cbtrangthai.SelectedItem != null && cbtrangthai.SelectedItem.ToString() == "Còn hàng" ? "True" : "False",
                NgayTao = DateTime.Now.ToString("yyyy-MM-dd")
            };

            try
            {
                // Insert the new book
                new DALSach().insert(sach);

                // Refresh the DataGridView
                loaddanhsachsach();

                MessageBox.Show("Thêm sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (dgvsach.CurrentRow == null || dgvsach.CurrentRow.DataBoundItem is not DALSach selectedSach)
            {
                MessageBox.Show("Vui lòng chọn sách cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa sách \"{selectedSach.TieuDe}\" (Mã: {selectedSach.MaSach}) không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    new DALSach().delete(selectedSach.MaSach);
                    loaddanhsachsach();
                    MessageBox.Show("Xóa sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // Validate required fields
            if (string.IsNullOrWhiteSpace(txtMaSach.Text) ||
                string.IsNullOrWhiteSpace(txtTenSach.Text) ||
                string.IsNullOrWhiteSpace(cbTheLoai.Text) ||
                string.IsNullOrWhiteSpace(cbTacGia.Text) ||
                string.IsNullOrWhiteSpace(cbNhaXuatBan.Text) ||
                string.IsNullOrWhiteSpace(txtsoluong.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create updated book object
            var sach = new DALSach
            {
                MaSach = txtMaSach.Text.Trim(),
                TieuDe = txtTenSach.Text.Trim(),
                MaTheLoai = cbTheLoai.Text.Trim(),
                MaTacGia = cbTacGia.Text.Trim(),
                NhaXuatBan = cbNhaXuatBan.Text.Trim(),
                SoLuongTon = txtsoluong.Text.Trim(),
                TrangThai = cbtrangthai.SelectedItem != null && cbtrangthai.SelectedItem.ToString() == "Còn hàng" ? "True" : "False",
                NgayTao = DateTime.Now.ToString("yyyy-MM-dd")
            };

            try
            {
                // Update the book
                new DALSach().updatE(sach);

                // Refresh the DataGridView
                loaddanhsachsach();

                MessageBox.Show("Cập nhật sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            // Xóa nội dung các trường nhập liệu
            txtMaSach.Clear();
            txtTenSach.Clear();
            txtsoluong.Clear();

            // Đặt lại combobox về giá trị đầu tiên (nếu có item)
            if (cbTheLoai.Items.Count > 0)
                cbTheLoai.SelectedIndex = 0;
            else
                cbTheLoai.SelectedIndex = -1;

            if (cbTacGia.Items.Count > 0)
                cbTacGia.SelectedIndex = 0;
            else
                cbTacGia.SelectedIndex = -1;

            if (cbNhaXuatBan.Items.Count > 0)
                cbNhaXuatBan.SelectedIndex = 0;
            else
                cbNhaXuatBan.SelectedIndex = -1;

            if (cbtrangthai.Items.Count > 0)
                cbtrangthai.SelectedIndex = 0;
            else
                cbtrangthai.SelectedIndex = -1;

            // Đặt lại focus về trường đầu tiên nếu muốn
            txtMaSach.Focus();
        }

        private void txtMaSach_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

