using APP_BookStore.Models;
using APP_BookStore.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_BookStore.Controllers
{
    class PhieuNhapCtrl
    {
        PhieuNhapService pnSer = new PhieuNhapService();
        CT_PhieuNhapService ctpnSer = new CT_PhieuNhapService();
        SachService sachSer = new SachService();
        public bool AddPhieuNhap(PhieuNhap pn){
            try
            {
                pnSer.AddData(pn);
                foreach (DataRow row in pn.DtPN.Rows)
                {
                    CT_PhieuNhap ctpn = new CT_PhieuNhap();
                    ctpn.MaPN = pn.MaPN;
                    ctpn.MaSach = row["MaSach"].ToString();
                    ctpn.SoLuong = int.Parse(row["SoLuong"].ToString());
                    //Get số lượng từ chi tiết phiếu nhập và cộng với số lượng sẵn có trong kho
                    
                    if (!(Object.ReferenceEquals(null, sachSer.GetData(ctpn.MaSach))))
                    {
                        int soLuongTon = sachSer.GetData(ctpn.MaSach).SlTon + ctpn.SoLuong;
                        sachSer.UpdateSL(ctpn.MaSach, soLuongTon, pn.NgayLapPN);
                        ctpnSer.AddData(ctpn);                    
                    }
                    else
                    {
                        Sach s = new Sach(row["MaSach"].ToString().Trim(),
                                          row["TenSach"].ToString().Trim(),
                                          row["MaTL"].ToString().Trim(),
                                          row["MaNXB"].ToString().Trim(),
                                          row["MaTG"].ToString().Trim(),
                                          pn.NgayLapPN,
                                          Int32.Parse(row["GiaBan"].ToString()),
                                          Int32.Parse(row["GiaNhap"].ToString()),
                                          Int32.Parse(row["GiamGia"].ToString()),
                                          Int32.Parse(row["SoLuong"].ToString()));
                        sachSer.AddData(s);
                        ctpnSer.AddData(ctpn);
                    }
                }
            }catch(Exception ex){
                System.Windows.Forms.MessageBox.Show("Error: " + ex.ToString(), "Lỗi", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        public DataTable ConvertDataGrid2DataTable(System.Windows.Forms.DataGridView dtgvTemp)
        {
            DataTable dt = new DataTable();
            while (dt.Rows.Count < dtgvTemp.Rows.Count - 1)
            {
                dt.Rows.Add();//Đếm số row để khởi tạo
            }
            for (int i = 0; i < dtgvTemp.Columns.Count; i++)
            {
                dt.Columns.Add(dtgvTemp.Columns[i].Name.ToString());
                for (int j = 0; j < dtgvTemp.Rows.Count - 1; j++)
                {
                    dt.Rows[j][i] = dtgvTemp[i, j].Value.ToString();
                }
            }
            return dt;
        }



    }
}
