using DAL_Xuong;
using DTO_Xuong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_Xuong
{
    public class BUSNhanVien
    {
        DALNhanVien dalNhanVien = new DALNhanVien();

        public NhanVien DangNhap(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return null;
            }

            return dalNhanVien.getNhanVien(username, password);
        }

        public bool UpdateMatKhau(string email, string matKhauCu, string matKhauMoi)
        {
            try
            {
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(matKhauCu) || string.IsNullOrEmpty(matKhauMoi))
                {
                    return false;
                }
                return dalNhanVien.UpdateMatKhau(email, matKhauCu, matKhauMoi);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<NhanVien> GetNhanVienList()
        {
            return dalNhanVien.selectAll();
        }

        public List<NhanVien> SearchNhanVien(string keyword)
        {
            List<NhanVien> nv = new List<NhanVien>();
            try
            {
                return dalNhanVien.SearchNhanVien(keyword);
            }
            catch (Exception ex)
            {
                return nv;
            }
        }
        public string InsertNhanVien(NhanVien nv)
        {
            try
            {
                nv.MaNhanVien = dalNhanVien.generateMaNhanVien();
                if (string.IsNullOrEmpty(nv.MaNhanVien))
                {
                    return "Mã nhân viên không hợp lệ.";
                }
                if (dalNhanVien.checkEmailExists(nv.Email))
                {
                    return "Email đã tồn tại.";
                }
                dalNhanVien.insertNhanVien(nv);
                return string.Empty;
            }
            catch (Exception ex)
            {
                //return "Thêm mới không thành công.";
                return "Lỗi: " + ex.Message;
            }
        }

        public string UpdateNhanVien(NhanVien nv)
        {
            try
            {
                if (string.IsNullOrEmpty(nv.MaNhanVien))
                {
                    return "Mã nhân viên không hợp lệ.";
                }

                dalNhanVien.updateNhanVien(nv);
                return string.Empty;
            }
            catch (Exception ex)
            {
                //return "Cập nhật không thành công.";
                return "Lỗi: " + ex.Message;
            }
        }

        public string DeleteNhanVien(string maNV)
        {
            try
            {
                if (string.IsNullOrEmpty(maNV))
                {
                    return "Mã nhân viên không hợp lệ.";
                }

                dalNhanVien.deleteNhanVien(maNV);
                return string.Empty;
            }
            catch (Exception ex)
            {
                //return "Xóa không thành công.";
                return "Lỗi: " + ex.Message;
            }
        }
    }
}
