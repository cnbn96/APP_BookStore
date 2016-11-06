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
    class PhieuXuatCtrl
    {
        PhieuXuatService pxSer = new PhieuXuatService();
        CT_PhieuXuatService ctpxSer = new CT_PhieuXuatService();
        SachService sachSer = new SachService();
        public bool AddPhieuXuat(PhieuXuat px)
        {
            try
            {
                pxSer.AddData(px);
                foreach (DataRow row in px.DtPX.Rows)
                {
                    CT_PhieuXuat ctpx = new CT_PhieuXuat();
                    ctpx.MaPX = px.MaPX;
                    ctpx.MaSach = row["MaSach"].ToString();
                    ctpx.SoLuong = int.Parse(row["SoLuong"].ToString());
                    //Get số lượng từ chi tiết phiếu nhập và trừ với số lượng sẵn có trong kho

                    if (!(Object.ReferenceEquals(null, sachSer.GetData(ctpx.MaSach))))
                    {
                        int soLuongTon = sachSer.GetData(ctpx.MaSach).SlTon - ctpx.SoLuong;
                        if (soLuongTon < 0) {
                            throw new System.Exception("Số lượng xuất lớn hơn số lượng tồn!");
                        }
                        else{
                            sachSer.UpdateSL(ctpx.MaSach, soLuongTon, px.NgayLapPN);
                        }
                        ctpxSer.AddData(ctpx);
                    }
                }
            }
            catch (Exception ex)
            {
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
