using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_Xuong;

namespace BUS_Xuong
{
    public class BUSSach
    {

        DALSach dalSach = new DALSach();
        public List<DALSach> GetAllSach()
        {
            return dalSach.sellectALL();
        }

        public string updatesach(DALSach sach)
        {
            try
            {
                if (string.IsNullOrEmpty(sach.MaSach))
                {
                    return "Mã sách không được để trống";
                }
                dalSach.updatE(sach);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Lỗi thêm sách: " + ex.Message;
            }
        }

        public List<DALSach> getsach()
        {
            return dalSach.sellectALL();
        }
    }
}
