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
    class TacGiaService
    {
        ConnectToDB con = new ConnectToDB();
        SqlCommand cmd = new SqlCommand();

        public DataTable GetAllData()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "Select * from TacGia";
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
        public TacGia GetData(String ma)
        {
            TacGia tg = new TacGia();
            cmd.CommandText = String.Format("Select * from TacGia where MaTG = '{0}' ", ma);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            try
            {
                con.OpenConn();
                SqlDataReader reader = cmd.ExecuteReader();
                int ordMaNV = reader.GetOrdinal("MaTG");
                int ordTenNV = reader.GetOrdinal("TenTG");
                int ordDiaChi = reader.GetOrdinal("DiaChi");
                int ordSDT = reader.GetOrdinal("SDT");
                while (reader.Read())
                {
                    tg.MaTG = reader.GetString(ordMaNV);
                    tg.TenTG = reader.GetString(ordTenNV);
                    tg.DiaChi = reader.GetString(ordDiaChi);
                    tg.SDT1 = reader.GetInt32(ordSDT);
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
            return tg;
        }
        public bool AddData(TacGia tg)
        {
            cmd.CommandText = String.Format("Insert into TacGia values('{0}', N'{1}', N'{2}', '{3}') ", tg.MaTG, tg.TenTG, tg.DiaChi, tg.SDT1);
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
        public bool UpdateData(TacGia tg)
        {
            cmd.CommandText = String.Format("update TacGia set TenTG=N'{0}', DiaChi=N'{1}', SDT='{2}' where MaTG = '{3}'", tg.TenTG, tg.DiaChi, tg.SDT1, tg.MaTG);
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
            cmd.CommandText = String.Format("delete TacGia where MaTG='{0}'", ma);
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
