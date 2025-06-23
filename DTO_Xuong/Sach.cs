using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Xuong
{
    public class Sach
    {

        public class sach
        {
            public string MaSach { get; set; }
            public string TieuDe { get; set; }
            public string MaTheLoai { get; set; }
            public string MaTacGia { get; set; }
            public string NhaXuatBan { get; set; }
            public string SoLuongTon { get; set; }
            public string TrangThai { get; set; }
            public string NgayTao { get; set; }
            public sach(string maSach, string tieuDe, string theLoai, string tacGia, string nhaXuatBan, string soLuong)
            {
                MaSach = maSach;
                TieuDe = tieuDe;
                MaTheLoai = theLoai;
                MaTacGia = tacGia;
                NhaXuatBan = nhaXuatBan;
                SoLuongTon = soLuong.ToString();
                TrangThai = "Available"; // Assuming default status
                NgayTao = DateTime.Now.ToString("yyyy-MM-dd"); // Assuming current date as creation date



            }
            public sach() { }
        }
    }
}
