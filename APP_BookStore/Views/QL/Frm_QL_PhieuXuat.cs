using APP_BookStore.Controllers;
using APP_BookStore.Models;
using APP_BookStore.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_BookStore.Views.QL
{
    public partial class Frm_QL_PhieuXuat : Form
    {
        PhieuXuatCtrl pxCtrl = new PhieuXuatCtrl();
        SachCtrl sachCtrl = new SachCtrl();
        NhanVienService nvSer = new NhanVienService();
        List<NhanVien> lstNV;
        List<Sach> lstSach;
        bool flagAddNCC = false;
        private Timer timer1;        
        public Frm_QL_PhieuXuat()
        {
            InitializeComponent();
        }

        public void InitTimer()
        {
            timer1 = new Timer();
            timer1.Tick += new EventHandler(DisplayClock);
            timer1.Interval = 1000; // in miliseconds      
            timer1.Start();
        }
        private void DisplayClock(object sender, EventArgs e)
        {
            lblTG.Text = DateTime.Now.ToString("dd/MM/yy HH:mm:ss");
        }
        private void DisEn(bool e)
        {
            btnStartAdd.Enabled = e;
            btnDone.Enabled = !e;
            btnNew.Enabled = !e;
            grPX.Enabled = e;
            grSachXuat.Enabled = !e;
            grCT_Xuat.Enabled = !e;
            btnAddToDtgv.Enabled = !e;
        }
        private void LoadCBB()
        {
            lstSach = sachCtrl.GetAllSach().AsEnumerable().Select(m => new Sach()
            {
                MaSach = m.Field<string>("MaSach"),
                TenSach = m.Field<string>("TenSach")
            }).ToList();
            lstNV = nvSer.GetAllData().AsEnumerable().Select(m => new NhanVien()
            {
                MaNV = m.Field<string>("MaNV"),
                TenNV = m.Field<string>("TenNV")
            }).ToList();


            cbbSach.Items.Clear();
            foreach (Sach item in lstSach)
            {
                cbbSach.Items.Add(item);
            }
            cbbSach.SelectedIndex = 0;
            cbbNV.Items.Clear();
            foreach (NhanVien item in lstNV)
            {
                cbbNV.Items.Add(item);
            }
            cbbNV.SelectedIndex = 0;
        }
        private void ClearData()
        {
            txtSLXuat.Text = "";
            cbbSach.SelectedIndex = 0;
        }
        private void DataBindings()
        {
            txtSLXuat.DataBindings.Clear();
            txtSLXuat.DataBindings.Add("Text", dtgvCT_Xuat.DataSource, "SoLuong");
        }
        private void ValidateNullInputCT()
        {            
            if (cbbSach.SelectedIndex == -1)
            {
                throw new System.Exception("Chưa chọn sách!");
            }
            if (txtSLXuat.Text.Trim() == "")
            {
                throw new System.Exception("Chưa nhập số lượng cần xuất!");
            }
        }
        private void ValidateNullInputPN()
        {
            if (cbbNV.SelectedIndex == -1)
            {
                throw new System.Exception("Chưa chọn nhân viên!");
            }
        }
        private string GenerateID()
        {
            return "PX" + DateTime.Now.ToString("ddMMyyHHmmss");
        }
        private void Frm_QL_PhieuXuat_Load(object sender, EventArgs e)
        {
            DisEn(true);
            txtMaPX.Text = GenerateID();            
            InitTimer();
            LoadCBB();
            ClearData();
            dtgvCT_Xuat.Columns.Clear();
            dtgvCT_Xuat.Rows.Clear();
            dtgvCT_Xuat.Columns.Add("MaSach", "Mã Sách");
            dtgvCT_Xuat.Columns.Add("TenSach", "Tên Sách");
            dtgvCT_Xuat.Columns.Add("SoLuong", "Số Lượng Xuất");
            dtgvCT_Xuat.Columns[0].Visible = false;
        }
        private void btnStartAdd_Click(object sender, EventArgs e)
        {
            ClearData();
            DisEn(false);
        }

        //private void txtMaSach_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (!Object.ReferenceEquals(null, sachCtrl.GetSach(txtMaSach.Text.Trim())))
        //        {
        //            Sach s = new Sach();
        //            s = sachCtrl.GetSach(txtMaSach.Text.Trim());
        //            txtTenSach.DataBindings.Clear();
        //            txtTenSach.DataBindings.Add("Text", s, "TenSach");
        //            txtGiaBan.DataBindings.Clear();
        //            txtGiaBan.DataBindings.Add("Text", s, "GiaBan");
        //            txtGiaNhap.DataBindings.Clear();
        //            txtGiaNhap.DataBindings.Add("Text", s, "GiaNhap");
        //            txtGiamGia.DataBindings.Clear();
        //            txtGiamGia.DataBindings.Add("Text", s, "GiamGia");
        //            cbbLoaiSach.SelectedIndex = cbbLoaiSach.FindStringExact(tlSer.GetData(s.MaTL).TenTL);
        //            cbbNXB.SelectedIndex = cbbNXB.FindStringExact(nxbSer.GetData(s.MaNXB).TenNXB);
        //            cbbTG.SelectedIndex = cbbTG.FindStringExact(tgSer.GetData(s.MaTG).TenTG);
        //        }
        //        else
        //        {
        //            txtTenSach.Text = "";
        //            txtGiaBan.Text = "";
        //            txtGiaNhap.Text = "";
        //            txtGiamGia.Text = "";
        //            txtSLNhap.Text = "";
        //            cbbLoaiSach.SelectedIndex = 0;
        //            cbbNXB.SelectedIndex = 0;
        //            cbbTG.SelectedIndex = 0;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error: " + ex.ToString());
        //    }
        //}

        private void btnAddToDtgv_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateNullInputCT();
                string[] row = new string[] {((Sach)cbbSach.SelectedItem).MaSach,
                                         ((Sach)cbbSach.SelectedItem).TenSach,
                                         txtSLXuat.Text.Trim()};
                dtgvCT_Xuat.Rows.Add(row);
                ClearData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }


        private void btnXoaCTPX_Click(object sender, EventArgs e)
        {
            if (dtgvCT_Xuat.SelectedCells.Count > 0)
            {
                int selectedRowIndex = dtgvCT_Xuat.SelectedCells[0].RowIndex;
                dtgvCT_Xuat.Rows.RemoveAt(selectedRowIndex);
            }
        }       

        private void btnNew_Click(object sender, EventArgs e)
        {
            Frm_QL_PhieuXuat_Load(sender, e);
        }
        private void AssignData(PhieuXuat pn)
        {
            pn.MaPX = txtMaPX.Text.Trim();
            pn.MaNV = ((NhanVien)cbbNV.SelectedItem).MaNV;
            pn.NgayLapPN = lblTG.Text.Trim();
            pn.DtPX = pxCtrl.ConvertDataGrid2DataTable(dtgvCT_Xuat);
        }
        private void btnDone_Click(object sender, EventArgs e)
        {
            PhieuXuat px = new PhieuXuat();
            try
            {
                ValidateNullInputPN();
                AssignData(px);
                if (pxCtrl.AddPhieuXuat(px))
                {
                    Frm_QL_PhieuXuat_Load(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }

        }
        private void btnEditPN_Click(object sender, EventArgs e)
        {
            DisEn(true);
        }
        private void ValidateKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void cbbSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblSLTon.Text = ((Sach)sachCtrl.GetSach(((Sach)cbbSach.SelectedItem).MaSach)).SlTon.ToString();
        }

    }
}
