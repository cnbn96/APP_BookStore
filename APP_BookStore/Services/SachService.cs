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
    class SachService
    {
        ConnectToDB con = new ConnectToDB();
        SqlCommand cmd = new SqlCommand();

        public DataTable GetAllData()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = String.Format("Select * from Sach");
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
                string mex = ex.Message;
                cmd.Dispose();
                con.CloseConn();
            }
            return dt;
        }
        public Sach GetData(String ma)
        {
            Sach s = new Sach();
            cmd.CommandText = String.Format("Select * from Sach where MaSach = '{0}' ", ma);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            try
            {
                con.OpenConn();
                SqlDataReader reader = cmd.ExecuteReader();
                int ordMaSach = reader.GetOrdinal("MaSach");
                int ordTenSach = reader.GetOrdinal("TenSach");
                int ordMaTL = reader.GetOrdinal("MaTL");
                int ordMaTG = reader.GetOrdinal("MaTG");
                int ordMaNXB = reader.GetOrdinal("MaNXB");
                int ordSLTon = reader.GetOrdinal("SLTon");
                int ordGiaBan = reader.GetOrdinal("GiaBan");
                int ordGiaNhap = reader.GetOrdinal("GiaNhap");
                int ordNgayCapNhat = reader.GetOrdinal("NgayCapNhat");
                int ordGiamGia = reader.GetOrdinal("GiamGia");
                while (reader.Read())
                {
                    s.MaSach = reader.GetString(ordMaSach);
                    s.TenSach = reader.GetString(ordTenSach);
                    s.MaTL = reader.GetString(ordMaTL);
                    s.MaTG = reader.GetString(ordMaTG);
                    s.MaNXB = reader.GetString(ordMaNXB);
                    s.SlTon = reader.GetInt32(ordSLTon);
                    s.GiaBan = reader.GetInt32(ordGiaBan);
                    s.GiaNhap = reader.GetInt32(ordGiaNhap);
                    s.NgayCapNhat = reader.GetDateTime(ordNgayCapNhat).ToShortDateString();
                    s.GiamGia = reader.GetInt32(ordGiamGia);
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
            return s;
        }
        public List<Sach> GetDataByCondition(String dieukien)
        {
            List<Sach> lst = new List<Sach>();
            cmd.CommandText = String.Format("Select * from Sach " + dieukien);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            try
            {
                con.OpenConn();
                SqlDataReader reader = cmd.ExecuteReader();
                int ordMaSach = reader.GetOrdinal("MaSach");
                int ordTenSach = reader.GetOrdinal("TenSach");
                int ordMaTL = reader.GetOrdinal("MaTL");
                int ordMaTG = reader.GetOrdinal("MaTG");
                int ordMaNXB = reader.GetOrdinal("MaNXB");
                int ordSLTon = reader.GetOrdinal("SLTon");
                int ordGiaBan = reader.GetOrdinal("GiaBan");
                int ordGiaNhap = reader.GetOrdinal("GiaNhap");
                int ordNgayCapNhat = reader.GetOrdinal("NgayCapNhat");
                int ordGiamGia = reader.GetOrdinal("GiamGia");
                while (reader.Read())
                {
                    Sach s = new Sach();
                    s.MaSach = reader.GetString(ordMaSach);
                    s.TenSach = reader.GetString(ordTenSach);
                    s.MaTL = reader.GetString(ordMaTL);
                    s.MaTG = reader.GetString(ordMaTG);
                    s.MaNXB = reader.GetString(ordMaNXB);
                    s.SlTon = reader.GetInt32(ordSLTon);
                    s.GiaBan = reader.GetInt32(ordGiaBan);
                    s.GiaNhap = reader.GetInt32(ordGiaNhap);
                    s.NgayCapNhat = reader.GetDateTime(ordNgayCapNhat).ToShortDateString();
                    s.GiamGia = reader.GetInt32(ordGiamGia);
                    lst.Add(s);
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
            return lst;
        }
        public bool AddData(Sach s)
        {
            cmd.CommandText = String.Format("Insert into Sach values('{0}', N'{1}', '{2}', N'{3}', '{4}', '{5}', '{6}', '{7}', CONVERT(varchar(25), '{8}', 131), '{9}') ", s.MaSach, s.TenSach, s.MaTL, s.MaTG, s.MaNXB, s.GiaBan, s.GiaNhap, s.SlTon, s.NgayCapNhat, s.GiamGia > 0 ? s.GiamGia : 0);
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
                System.Windows.Forms.MessageBox.Show("Error: " + ex.ToString(), "Lỗi", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                cmd.Dispose();
                con.CloseConn();
            }
            return false;
        }
        public bool UpdateData(Sach s)
        {
            cmd.CommandText = String.Format("update Sach set TenSach=N'{0}', MaTL='{1}', MaTG='{2}', MaNXB='{3}', GiaBan ='{4}', GiaNhap ='{5}', SLTon ='{6}', NgayCapNhat = CONVERT(varchar(25), '{7}', 131) , GiamGia ='{8}' where MaSach = '{9}' ", s.TenSach, s.MaTL, s.MaTG, s.MaNXB, s.GiaBan, s.GiaNhap, s.SlTon, s.NgayCapNhat, s.GiamGia, s.MaSach);
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
                System.Windows.Forms.MessageBox.Show("Error: " + ex.ToString(), "Lỗi", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                cmd.Dispose();
                con.CloseConn();
            }
            return false;
        }
        public bool UpdateSL(string ma, int sl, string ngaycn)
        {
            cmd.CommandText = String.Format("update Sach set SLTon ='{0}', NgayCapNhat = CONVERT(varchar(25), '{1}', 131)  where MaSach = '{2}' ", sl, ngaycn, ma);
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
                System.Windows.Forms.MessageBox.Show("Error: " + ex.ToString(), "Lỗi", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                cmd.Dispose();
                con.CloseConn();
            }
            return false;
        }
        public bool DeleteData(string ma)
        {
            cmd.CommandText = String.Format("delete NhanVien where MaSach='{0}'", ma);
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
                System.Windows.Forms.MessageBox.Show("Error: " + ex.ToString(), "Lỗi", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                cmd.Dispose();
                con.CloseConn();
            }
            return false;
        }

    }
}
