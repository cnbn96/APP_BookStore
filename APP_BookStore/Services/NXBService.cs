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
    class NXBService
    {
        ConnectToDB con = new ConnectToDB();
        SqlCommand cmd = new SqlCommand();

        public DataTable GetAllData()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "Select * from NhaXuatBan";
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
        public NhaXuatBan GetData(String maNV)
        {
            NhaXuatBan nxb = new NhaXuatBan();
            cmd.CommandText = String.Format("Select * from NhanVien where MaNV = '{0}' ", maNV);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            try
            {
                con.OpenConn();
                SqlDataReader reader = cmd.ExecuteReader();
                int ordMaNV = reader.GetOrdinal("MaNXB");
                int ordTenNV = reader.GetOrdinal("TenNXB");
                int ordDiaChi = reader.GetOrdinal("DiaChi");
                int ordSDT = reader.GetOrdinal("SDT");
                while (reader.Read())
                {
                    nxb.MaNXB = reader.GetString(ordMaNV);
                    nxb.TenNXB = reader.GetString(ordTenNV);
                    nxb.DiaChi = reader.GetString(ordDiaChi);
                    nxb.SDT1 = reader.GetInt32(ordSDT);
                }
                reader.Close();
                con.CloseConn();
            }
            catch (Exception ex)
            {
                string mex = ex.ToString();
                cmd.Dispose();
                con.CloseConn();
            }
            return nxb;
        }
        public bool AddData(NhaXuatBan nxb)
        {
            cmd.CommandText = String.Format("Insert into NhaXuatBan values('{0}', N'{1}', N'{2}', '{3}') ", nxb.MaNXB, nxb.TenNXB, nxb.DiaChi, nxb.SDT1);
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
        public bool UpdateData(NhaXuatBan nxb)
        {
            cmd.CommandText = String.Format("update NhaXuatBan set TenNXB=N'{0}', DiaChi=N'{1}', SDT='{2}' where MaNXB = '{3}'", nxb.TenNXB, nxb.DiaChi, nxb.SDT1, nxb.MaNXB);
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

        public bool DeleteData(string maNXB)
        {
            cmd.CommandText = String.Format("delete NhaXuatBan where MaNXB='{0}'", maNXB);
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
