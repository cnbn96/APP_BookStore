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
    class NCCService
    {
        ConnectToDB con = new ConnectToDB();
        SqlCommand cmd = new SqlCommand();

        public DataTable GetAllData()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "Select * from NhaCungCap";
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
        public NhaCungCap GetData(String ma)
        {
            NhaCungCap ncc = new NhaCungCap();
            cmd.CommandText = String.Format("Select * from NhaCungCap where MaNCC = '{0}' ", ma);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            try
            {
                con.OpenConn();
                SqlDataReader reader = cmd.ExecuteReader();
                int ordMaNV = reader.GetOrdinal("MaNCC");
                int ordTenNV = reader.GetOrdinal("TenNCC");
                int ordDiaChi = reader.GetOrdinal("DiaChi");
                int ordSDT = reader.GetOrdinal("SDT");
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ncc.MaNCC = reader.GetString(ordMaNV);
                        ncc.TenNCC = reader.GetString(ordTenNV);
                        ncc.DiaChi = reader.GetString(ordDiaChi);
                        ncc.SDT1 = reader.GetInt32(ordSDT);
                    }
                }
                else
                {

                    reader.Close();
                    con.CloseConn();
                    return null;
                }
                reader.Close();
                con.CloseConn();
                return ncc;
            }
            catch (Exception ex)
            {                
                string mex = ex.ToString();
                cmd.Dispose();
                con.CloseConn();
            }
            return null;
        }
        public bool AddData(NhaCungCap ncc)
        {
            cmd.CommandText = String.Format("Insert into NhaCungCap values('{0}', N'{1}', N'{2}', '{3}') ", ncc.MaNCC, ncc.TenNCC, ncc.DiaChi, ncc.SDT1);
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
        public bool UpdateData(NhaCungCap ncc)
        {
            cmd.CommandText = String.Format("update NhaCungCap set TenNCC=N'{0}', DiaChi=N'{1}', SDT='{2}' where MaNCC = '{3}'", ncc.TenNCC, ncc.DiaChi, ncc.SDT1, ncc.MaNCC);
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

        public bool DeleteData(string maNCC)
        {
            cmd.CommandText = String.Format("delete NhaCungCap where MaNCC='{0}'", maNCC);
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
