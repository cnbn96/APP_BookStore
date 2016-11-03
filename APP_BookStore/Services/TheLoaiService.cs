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
    class TheLoaiService
    {
        ConnectToDB con = new ConnectToDB();
        SqlCommand cmd = new SqlCommand();

        public DataTable GetAllData()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "Select * from TheLoaiSach";
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
        public TheLoaiSach GetData(String ma)
        {
            TheLoaiSach tl = new TheLoaiSach();
            cmd.CommandText = String.Format("Select * from TheLoaiSach where MaTL = '{0}' ", ma);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            try
            {
                con.OpenConn();
                SqlDataReader reader = cmd.ExecuteReader();
                int ordMaNV = reader.GetOrdinal("MaTL");
                int ordTenNV = reader.GetOrdinal("TenTL");
                while (reader.Read())
                {
                    tl.MaTL = reader.GetString(ordMaNV);
                    tl.TenTL = reader.GetString(ordTenNV);
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
            return tl ;
        }
        public bool AddData(TheLoaiSach tl)
        {
            cmd.CommandText = String.Format("Insert into TheLoaiSach values('{0}', N'{1}') ", tl.MaTL, tl.TenTL);
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
        public bool UpdateData(TheLoaiSach tl)
        {
            cmd.CommandText = String.Format("update TheLoaiSach set TenTL=N'{0}' where MaTL = '{1}'", tl.TenTL, tl.MaTL);
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

        public bool DeleteData(string ma)
        {
            cmd.CommandText = String.Format("delete TheLoaiSach where MaTL='{0}'", ma);
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
