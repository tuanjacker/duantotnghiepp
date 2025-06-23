using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_PolyCafe;
using Microsoft.Data.SqlClient;

namespace DAL_Xuong
{
    public class DALSach
    {

        // Adding missing properties to resolve the errors  
        public string MaSach { get; set; }
        public string TieuDe { get; set; }
        public string MaTheLoai { get; set; }
        public string MaTacGia { get; set; }
        public string NhaXuatBan { get; set; }
        public string SoLuongTon { get; set; }
        public string TrangThai { get; set; }
        public string NgayTao { get; set; }

        public DALSach GetSach(string maSach)
        {
            string sql = "SELECT * FROM Sach WHERE MaSach = @0";
            List<object> thamso = new List<object>();
            thamso.Add(maSach);
            DALSach sach = DBUtil.Value<DALSach>(sql, thamso, System.Data.CommandType.Text);
            return sach;
        }

        public void insert(DALSach entity)
        {
            string sql = "INSERT INTO Sach (MaSach, TieuDe, MaTheLoai, MaTacGia, NhaXuatBan, SoLuongTon, TrangThai, NgayTao) " +
                       "VALUES (@0, @1, @2, @3, @4, @5, @6, @7)";
            List<object> thamSo = new List<object>();
            thamSo.Add(entity.MaSach);
            thamSo.Add(entity.TieuDe);
            thamSo.Add(entity.MaTheLoai);
            thamSo.Add(entity.MaTacGia);
            thamSo.Add(entity.NhaXuatBan);
            thamSo.Add(entity.SoLuongTon);
            thamSo.Add(entity.TrangThai);
            thamSo.Add(entity.NgayTao);
            DBUtil.Update(sql, thamSo);
        }

        public void updatE(DALSach entity)
        {
            try
            {
                string sql = "UPDATE Sach SET TieuDe = @1, MaTheLoai = @2, MaTacGia = @3, NhaXuatBan = @4, SoLuongTon = @5, TrangThai = @6, NgayTao = @7 WHERE MaSach = @0";
                List<object> thamSo = new List<object>();
                thamSo.Add(entity.MaSach);
                thamSo.Add(entity.TieuDe);
                thamSo.Add(entity.MaTheLoai);
                thamSo.Add(entity.MaTacGia);
                thamSo.Add(entity.NhaXuatBan);
                thamSo.Add(entity.SoLuongTon);
                thamSo.Add(entity.TrangThai);
                thamSo.Add(entity.NgayTao);
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception e) { throw; }

        }
        public List<DALSach> selectBySql(string sql, List<object> thamSo)
        {
            List<DALSach> list = new List<DALSach>();
            try
            {
                SqlDataReader reader = DBUtil.Query(sql, thamSo);
                while (reader.Read())
                {
                    DALSach entity = new DALSach();

                    entity.MaSach = reader["MaSach"].ToString();
                    entity.TieuDe = reader["TieuDe"].ToString();
                    entity.MaTheLoai = reader["MaTheLoai"].ToString();
                    entity.MaTacGia = reader["MaTacGia"].ToString();
                    entity.NhaXuatBan = reader["NhaXuatBan"].ToString();
                    entity.SoLuongTon = reader["SoLuongTon"].ToString();
                    entity.TrangThai = reader["TrangThai"].ToString();
                    entity.NgayTao = reader["NgayTao"].ToString();

                    list.Add(entity);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return list;
        }




        public DALSach selectById(string maSach)
        {
            string sql = "SELECT * FROM Sach WHERE MaSach = @0";
            List<object> thamSo = new List<object> { maSach };
            List<DALSach> list = selectBySql(sql, thamSo);
            return list.FirstOrDefault();
        }
        public string generateSach()
        {
            string sql = "SELECT TOP 1 MaSach FROM Sach ORDER BY MaSach DESC";
            List<object> thamSo = new List<object>();
            var reader = DBUtil.Query(sql, thamSo);
            if (reader != null && reader.Read())
            {
                string lastMaSach = reader["MaSach"].ToString();
                int nextId = int.Parse(lastMaSach.Substring(1)) + 1;
                return "S" + nextId.ToString("D3");
            }
            return "S001";
        }
        public void delete(string maSach)
        {
            string sql = "DELETE FROM Sach WHERE MaSach = @0";
            List<object> thamSo = new List<object> { maSach };
            DBUtil.Update(sql, thamSo);
        }

        public List<DALSach> sellectALL()
        {
            string sql = "SELECT * FROM Sach";
            return selectBySql(sql, new List<object>());
        }
    }
}
