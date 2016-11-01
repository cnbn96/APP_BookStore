using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_BookStore.Services
{
    class ConnectToDB
    {
        private SqlConnection Conn;
        private string strCon = null;
        private SqlCommand cmd;
        private string error;

        public string Error
        {
            get { return error; }
            set { error = value; }
        }

        public SqlConnection Connection
        {
            get { return Conn; }
        }

        public SqlCommand Cmd
        {
            get { return cmd; }
            set { cmd = value; }
        }
        public ConnectToDB()
        {
            strCon = @"Data Source=BINH-LAPTOP\SQLEXPRESS;Initial Catalog=BookStoreDatabase;Integrated Security=True";
            Conn = new SqlConnection(strCon);
        }
        public bool OpenConn()
        {
            try
            {
                if (Conn.State == System.Data.ConnectionState.Closed)
                    Conn.Open();
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
            return true;
        }
        public bool CloseConn()
        {
            try
            {
                if (Conn.State == System.Data.ConnectionState.Open)
                    Conn.Close();
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
            return true;
        }
    }
}
