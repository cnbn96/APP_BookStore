using APP_BookStore.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_BookStore.Services
{
    class NhanVienService
    {
        ConnectToDB con = new ConnectToDB();
        SqlCommand cmd = new SqlCommand();

        public DataTable GetAllData()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "Select MaNV, TenNV, ChucVu, DiaChi, SDT, MatKhau from NhanVien";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            try
            {
                con.OpenConn();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                string mex = ex.ToString();
                cmd.Dispose();
                con.CloseConn();
            }
            return dt;
        }
        public bool AddData(NhanVien nv)
        {            
            cmd.CommandText = String.Format("Insert into NhanVien values('{0}', N'{1}', N'{2}', N'{3}', '{4}', '{5}','{6}') ", nv.MaNV, nv.TenNV, nv.ChucVu, nv.DiaChi, nv.GioiTinh != null ? nv.GioiTinh : 'M', nv.SDT1, nv.MatKhau);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            try
            {
                con.OpenConn();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                string mex = ex.ToString();
                cmd.Dispose();
                con.CloseConn();
            }
            return false;
        }
        public bool UpdateData(NhanVien nv)
        {
            cmd.CommandText = String.Format("update NhanVien set TenNV=N'{0}', ChucVu=N'{1}', DiaChi=N'{2}', SDT='{3}', MatKhau='{4}' where MaNV='{5}' ", nv.TenNV, nv.ChucVu, nv.DiaChi, nv.SDT1, nv.MatKhau, nv.MaNV);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            try
            {
                con.OpenConn();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                string mex = ex.ToString();
                cmd.Dispose();
                con.CloseConn();
            }
            return false;
        }
       
        public bool UpdateMK(NhanVien nv)
        {
            cmd.CommandText = String.Format("update NhanVien set MatKhau='{0}' where MaNV='{1}'", nv.MatKhau, nv.MaNV);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            try
            {
                con.OpenConn();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                string mex = ex.ToString();
                cmd.Dispose();
                con.CloseConn();
            }
            return false;
        }
        public string GetDataMK(string maNV)
        {
            cmd.CommandText = String.Format("Select IsNull(MatKhau, '') from NhanVien where MaNV='{0}' ", maNV);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            try
            {
                con.OpenConn();
                var matKhau = cmd.ExecuteScalar();
                return matKhau.ToString();
            }
            catch (Exception ex)
            {
                string mex = ex.ToString();
                cmd.Dispose();
                con.CloseConn();
            }
            return "";
        }
        public bool DeleteData(string maNV)
        {
            cmd.CommandText = String.Format("delete NhanVien where MaNV='{0}'", maNV);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            try
            {
                con.OpenConn();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                string mex = ex.ToString();
                cmd.Dispose();
                con.CloseConn();
            }
            return false;
        }
    }
}
