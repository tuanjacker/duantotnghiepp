using DAL_PolyCafe;
using DTO_Xuong;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Xuong
{
    public class DALNhanVien
    {
        public NhanVien getNhanVien(string email, string password)
        {
            string sql = "SELECT * FROM NhanVien WHERE Email=@0 AND MatKhau=@1";
            List<object> thamSo = new List<object>();
            thamSo.Add(email);
            thamSo.Add(password);
            NhanVien nv = DBUtil.Value<NhanVien>(sql, thamSo);
            return nv;
        }

        public bool UpdateMatKhau(string email, string matKhauCu, string matKhauMoi)
        {
            //using store procedure
            try
            {
                string sql = "EXEC chgpwd @email=@0 , @opwd=@1 , @npwd=@2";
                CommandType cmdType = CommandType.StoredProcedure;
                List<object> thamSo = new List<object>();
                thamSo.Add(email);
                thamSo.Add(matKhauCu);
                thamSo.Add(matKhauMoi);
                DBUtil.Update(sql, thamSo, cmdType);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<NhanVien> SelectBySql(string sql, List<object> args, CommandType cmdType = CommandType.Text)
        {
            List<NhanVien> list = new List<NhanVien>();
            try
            {
                SqlDataReader reader = DBUtil.Query(sql, args);
                while (reader.Read())
                {
                    NhanVien entity = new NhanVien();
                    entity.MaNhanVien = reader.GetString("MaNhanVien");
                    entity.Ten = reader.GetString("Ten");
                    entity.Email = reader.GetString("Email");
                    entity.SoDienThoai = reader.GetString("SoDienThoai");
                    entity.VaiTro = reader.GetBoolean("VaiTro");
                    entity.TrangThai = reader.GetBoolean("TrangThai");
                    entity.NgayTao = reader.GetDateTime("NgayTao");
                    list.Add(entity);
                  
                }
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }

        public List<NhanVien> selectAll()
        {
            String sql = "SELECT * FROM NhanVien";
            return SelectBySql(sql, new List<object>());
        }

        public List<NhanVien> SearchNhanVien(string keyword)
        {
            string sql = "SELECT * FROM NhanVien WHERE MaNhanVien LIKE " + $"N'%{keyword}%' COLLATE Latin1_General_CI_AI" + " OR HoTen LIKE " + $"N'%{keyword}%' COLLATE Latin1_General_CI_AI";
            // + " OR Email LIKE "+ $"N'%{keyword}%' COLLATE Latin1_General_CI_AI";
            List<object> thamSo = new List<object>();
            return SelectBySql(sql, thamSo);
        }


        public NhanVien selectById(string id)
        {
            String sql = "SELECT * FROM NhanVien WHERE MaNhanVien=@0";
            List<object> thamSo = new List<object>();
            thamSo.Add(id);
            List<NhanVien> list = SelectBySql(sql, thamSo);
            return list.Count > 0 ? list[0] : null;
        }

        public void insertNhanVien(NhanVien nv)
        {
            try
            {
                string sql = @"INSERT INTO NhanVien (MaNhanVien, Ten, Email, MatKhau, SoDienThoai, VaiTro, TrangThai) 
                   VALUES (@0, @1, @2, @3, @4, @5, @6)";
                List<object> thamSo = new List<object>();
                thamSo.Add(nv.MaNhanVien);
                thamSo.Add(nv.Ten);
                thamSo.Add(nv.Email);
                thamSo.Add(nv.MatKhau);
                thamSo.Add(nv.SoDienThoai);
                thamSo.Add(nv.VaiTro);
                thamSo.Add(nv.TrangThai);
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public void updateNhanVien(NhanVien nv)
        {
            try
            {
                string sql = @"UPDATE NhanVien 
                   SET Ten = @1, Email = @2, MatKhau = @3, SoDienThoai = @4, VaiTro = @5, TrangThai = @6 
                   WHERE MaNhanVien = @0";
                List<object> thamSo = new List<object>();
                thamSo.Add(nv.MaNhanVien);
                thamSo.Add(nv.Ten);
                thamSo.Add(nv.Email);
                thamSo.Add(nv.MatKhau);
                thamSo.Add(nv.SoDienThoai);
                thamSo.Add(nv.VaiTro);
                thamSo.Add(nv.TrangThai);
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public void deleteNhanVien(string maNv)
        {
            try
            {
                string sql = "DELETE FROM NhanVien WHERE MaNhanVien = @0";
                List<object> thamSo = new List<object>();
                thamSo.Add(maNv);
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public bool checkEmailExists(string email)
        {
            string sql = "SELECT COUNT(*) FROM NhanVien WHERE Email = @0";
            List<object> thamSo = new List<object>();
            thamSo.Add(email);
            object result = DBUtil.ScalarQuery(sql, thamSo);
            return Convert.ToInt32(result) > 0;
        }

        public string generateMaNhanVien()
        {
            string prefix = "NV";
            string sql = "SELECT MAX(MaNhanVien) FROM NhanVien";
            List<object> thamSo = new List<object>();
            object result = DBUtil.ScalarQuery(sql, thamSo);
            if (result != null && result.ToString().StartsWith(prefix))
            {
                string maxCode = result.ToString().Substring(2);
                int newNumber = int.Parse(maxCode) + 1;
                return $"{prefix}{newNumber:D3}";
            }

            return $"{prefix}001";
        }
    }
}
