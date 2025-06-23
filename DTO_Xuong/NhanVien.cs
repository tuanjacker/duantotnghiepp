using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Xuong
{
    public class NhanVien
    {
        public string MaNhanVien { get; set; }
        public string Ten { get; set; }
        public string Email { get; set; }
        public string MatKhau { get; set; }
        public string SoDienThoai { get; set; }
        public bool VaiTro { get; set; }
        public bool TrangThai { get; set; }
        public DateTime NgayTao { get; set; }

        public string VaiTroText => VaiTro ? "Quản Lý" : "Nhân Viên";
        public string TrangThaiText => TrangThai ? "Đang Hoạt Động" : "Tạm Ngưng";
    }
}
