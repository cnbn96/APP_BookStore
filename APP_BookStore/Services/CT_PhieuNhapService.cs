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
    class CT_PhieuNhapService
    {
        ConnectToDB con = new ConnectToDB();
        SqlCommand cmd = new SqlCommand();
        public DataTable GetAllData(string ma)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = String.Format(@"select s.MaSach 'Mã Sách', s.TenSach 'Tên Sách', s.MaTG 'Mã Tác Giả', s.MaNXB 'Mã NXB', s.GiaBan 'Giá Bán', s.GiaNhap 'Giá Nhập', ct.SoLuong 'Số Lượng' from Sach s, CT_PhieuNhap ct where s.MaSach = ct.MaSach and MaPN = '{0}' ", ma);
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
                System.Windows.Forms.MessageBox.Show("Error: " + ex.ToString(), "Lỗi", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                con.CloseConn();
                cmd.Dispose();
            }
            return dt;
        }
        public bool AddData(CT_PhieuNhap ctpn)
        {
            cmd.CommandText = String.Format("Insert into CT_PhieuNhap values('{0}','{1}', '{2}') ", ctpn.MaPN, ctpn.MaSach, ctpn.SoLuong);
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
                con.CloseConn();
                cmd.Dispose();
                return false;
            }

            return false;
        }
        public bool DeleteData(string ma)
        {
            cmd.CommandText = String.Format("delete CT_PhieuNhap where MaPN='{0}'", ma);
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
