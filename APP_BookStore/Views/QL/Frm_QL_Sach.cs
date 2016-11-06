using APP_BookStore.Models;
using APP_BookStore.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using APP_BookStore.Services;

namespace APP_BookStore.Views.QL
{
    public partial class Frm_QL_Sach : Form
    {
        
        SachCtrl sachCtrl = new SachCtrl();
        NXBService nxbSer = new NXBService();
        TacGiaService tgSer = new TacGiaService();
        TheLoaiService tlSer = new TheLoaiService();
        private int flagSave = 0;
        List<TheLoaiSach> lstLoaiSach;
        List<NhaXuatBan> lstNXB;
        List<TacGia> lstTG;
        public Frm_QL_Sach()
        {
            InitializeComponent();
        }
        
        private void DisEn(bool e)
        {
            btnAdd.Enabled = !e;
            btnDelete.Enabled = !e;
            btnUpdate.Enabled = !e;
            dtgvSach.Enabled = !e;
            btnSave.Enabled = e;
            btnCancel.Enabled = e;
            txtMaSach.Enabled = e;
            txtTenSach.Enabled = e;
            cbbLoaiSach.Enabled = e;
            cbbNXB.Enabled = e;
            cbbTG.Enabled = e;
            txtGiaBan.Enabled = e;
            txtGiaNhap.Enabled = e;
            txtSL.Enabled = e;
            txtGiamGia.Enabled = e;
        }
        private void clearData()
        {
            txtMaSach.Text = "";
            txtTenSach.Text = "";
            txtGiaBan.Text = "";
            txtGiaNhap.Text = "";
            txtSL.Text = "";
            loadCBB();
            txtGiamGia.Text = "";
        }
        private void loadCBB()
        {
            lstLoaiSach = tlSer.GetAllData().AsEnumerable().Select(m => new TheLoaiSach()
            {
                MaTL = m.Field<string>("MaTL"),
                TenTL = m.Field<string>("TenTL")
            }).ToList();
            lstNXB = nxbSer.GetAllData().AsEnumerable().Select(m => new NhaXuatBan()
            {
                MaNXB = m.Field<string>("MaNXB"),
                TenNXB = m.Field<string>("TenNXB")
            }).ToList();
            lstTG = tgSer.GetAllData().AsEnumerable().Select(m => new TacGia()
            {
                MaTG = m.Field<string>("MaTG"),
                TenTG = m.Field<string>("TenTG")
            }).ToList();


            cbbLoaiSach.Items.Clear();
            foreach (TheLoaiSach item in lstLoaiSach)
            {
                cbbLoaiSach.Items.Add(item);
            }
            cbbLoaiSach.SelectedItem = 0;
            cbbNXB.Items.Clear();
            foreach (NhaXuatBan item in lstNXB)
            {
                cbbNXB.Items.Add(item);
            }
            cbbNXB.SelectedItem = 0;
            cbbTG.Items.Clear();
            foreach (TacGia item in lstTG)
            {
                cbbTG.Items.Add(item);
            }
            cbbTG.SelectedItem = 0;
        }

        private bool AssignData(Sach s)
        {
            try
            {
                s.MaSach = txtMaSach.Text.Trim();
                s.TenSach = txtTenSach.Text.Trim();
                s.GiaBan = Int32.Parse(txtGiaBan.Text.Trim());
                s.GiaNhap = Int32.Parse(txtGiaNhap.Text.Trim());
                s.SlTon = Int32.Parse(txtSL.Text.Trim());
                s.GiamGia = Int32.Parse(txtGiamGia.Text != "" ? txtGiamGia.Text.Trim() : "0");
                s.NgayCapNhat = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                s.MaNXB = ((NhaXuatBan)cbbNXB.SelectedItem).MaNXB;
                s.MaTG = ((TacGia)cbbTG.SelectedItem).MaTG;
                s.MaTL = ((TheLoaiSach)cbbLoaiSach.SelectedItem).MaTL;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: "+ ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void ValidateNullInput(Sach s)
        {
            if (AssignData(s))
            {
                return;
            }
            else { throw new System.ArgumentNullException("Các biến không thể NULL"); }
        }

        private void DataBindings()
        {
            txtMaSach.DataBindings.Clear();
            txtMaSach.DataBindings.Add("Text", dtgvSach.DataSource, "MaSach");
            txtTenSach.DataBindings.Clear();
            txtTenSach.DataBindings.Add("Text", dtgvSach.DataSource, "TenSach");
            txtGiaBan.DataBindings.Clear();
            txtGiaBan.DataBindings.Add("Text", dtgvSach.DataSource, "GiaBan");
            txtGiaNhap.DataBindings.Clear();
            txtGiaNhap.DataBindings.Add("Text", dtgvSach.DataSource, "GiaNhap");
            txtSL.DataBindings.Clear();
            txtSL.DataBindings.Add("Text", dtgvSach.DataSource, "SLTon");
            txtGiamGia.DataBindings.Clear();
            txtGiamGia.DataBindings.Add("Text", dtgvSach.DataSource, "GiamGia");
            //cbbTG.DataBindings.Clear();
            //cbbTG.DataBindings.Add("Text", dtgvSach.DataSource, "MaTG");
            //cbbNXB.DataBindings.Clear();
            //cbbNXB.DataBindings.Add("Text", dtgvSach.DataSource, "MaNXB");
            //cbbLoaiSach.DataBindings.Clear();
            //cbbLoaiSach.DataBindings.Add("Text", dtgvSach.DataSource, "MaTL");
        }

        

        private void Frm_QL_Sach_Load(object sender, EventArgs e)
        {
            
            DataTable dt = new DataTable();
            dt = sachCtrl.GetAllSach();
            dtgvSach.DataSource = dt;
            dtgvSach.Columns[2].Visible = false;
            dtgvSach.Columns[3].FillWeight = 90;
            dtgvSach.Columns[4].Width = 55;
            dtgvSach.Columns[7].Width = 55;
            dtgvSach.Columns[8].Width = 150;
            dtgvSach.Columns[9].Width = 55;
            


            
            loadCBB();
            //DataSet ds = new DataSet("Sach");
            //DataRelation relationData;
            //DataColumn sachCol;
            //DataColumn tlCol;
            //sachCol = dt.Columns["MaTL"];
            //tlCol = dt.Columns["MaTL"];

            DataBindings();
            DisEn(false);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            flagSave = 0;
            clearData();
            DisEn(true);
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            flagSave = 1;
            DisEn(true);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Sach sO = new Sach();
            try
            {
                ValidateNullInput(sO);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dtgvSach.Enabled = true;
            if (flagSave == 0)
            {
                if (sachCtrl.AddSach(sO))
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Thêm không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (sachCtrl.UpdateSach(sO))
                    //if (nvCtrl.UpdateNhanVien(nvO))
                    MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Sửa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Frm_QL_Sach_Load(sender, e);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            Frm_QL_Sach_Load(sender, e);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            //cbbLoaiSach.Items.Clear();
            //foreach (DataRow dr in dtLoaiSach.Rows)
            //{
            //    cbbLoaiSach.Items.Add(new KeyValuePair<string, string>(dr["TenTL"].ToString(), dr["MaTL"].ToString()));
            //}
            //cbbLoaiSach.SelectedItem = 0;
            //cbbNXB.Items.Clear();
            //foreach (DataRow dr in dtNXB.Rows)
            //{
            //    cbbNXB.Items.Add(new KeyValuePair<string, string>(dr["TenNXB"].ToString(), dr["MaNXB"].ToString()));
            //}
            //cbbNXB.SelectedItem = 0;
            //cbbTG.Items.Clear();
            //foreach (DataRow dr in dtTG.Rows)
            //{
            //    cbbTG.Items.Add(new KeyValuePair<string, string>(dr["TenTG"].ToString(), dr["MaTG"].ToString()));
            //}
            //cbbTG.SelectedItem = 0;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (sachCtrl.DeleteSach(txtMaSach.Text))
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Xóa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Frm_QL_Sach_Load(sender, e);

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc muốn hủy thao tác đang làm?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                Frm_QL_Sach_Load(sender, e);
            else
                return;
        }


        private void dtgvSach_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dtgvSach.SelectedRows)
            {
                cbbLoaiSach.SelectedIndex = cbbLoaiSach.FindStringExact(tlSer.GetData(row.Cells["MaTL"].Value.ToString()).TenTL);
            }
            foreach (DataGridViewRow row in dtgvSach.SelectedRows)
            {
                cbbTG.SelectedIndex = cbbTG.FindStringExact(tgSer.GetData(row.Cells["MaTG"].Value.ToString()).TenTG);
            }
            foreach (DataGridViewRow row in dtgvSach.SelectedRows)
            {
                cbbNXB.SelectedIndex = cbbNXB.FindStringExact(nxbSer.GetData(row.Cells["MaNXB"].Value.ToString()).TenNXB);
            }
        }

        private void ValidateKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

    }
}
