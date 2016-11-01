using APP_BookStore.Controllers;
using APP_BookStore.Models;
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
    public partial class Frm_QL_NCC : Form
    {

        NCCCtrl nccCtrl = new NCCCtrl();
        private int flagSave = 0;
        public Frm_QL_NCC()
        {
            InitializeComponent();
        }
        
        private void DisEn(bool e)
        {
            btnAdd.Enabled = !e;
            btnDelete.Enabled = !e;
            btnUpdate.Enabled = !e;
            btnSave.Enabled = e;
            btnCancel.Enabled = e;
            txtMaNCC.Enabled = e;
            txtTenNCC.Enabled = e;
            txtDiaChi.Enabled = e;
            txtSDT.Enabled = e;
        }
        private void clearData()
        {
            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
        }


        private void AssignData(NhaCungCap obj)
        {
            obj.MaNCC = txtMaNCC.Text.Trim();
            obj.TenNCC = txtTenNCC.Text.Trim();
            obj.DiaChi = txtDiaChi.Text.Trim();
            obj.SDT1 = Int32.Parse(txtSDT.Text.Trim());
        }


        private void DataBindings()
        {
            txtMaNCC.DataBindings.Clear();
            txtMaNCC.DataBindings.Add("Text", dtgvNCC.DataSource, "MaNCC");
            txtTenNCC.DataBindings.Clear();
            txtTenNCC.DataBindings.Add("Text", dtgvNCC.DataSource, "TenNCC");
            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", dtgvNCC.DataSource, "DiaChi");
            txtSDT.DataBindings.Clear();
            txtSDT.DataBindings.Add("Text", dtgvNCC.DataSource, "SDT");
        }




        private void Frm_QL_NCC_Load(object sender, EventArgs e)
        {
            DataTable dt = new System.Data.DataTable();
            dt = nccCtrl.GetAllNXB();
            dtgvNCC.DataSource = dt;
            DataBindings();
            DisEn(false);
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
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
            //loadCBB();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            NhaCungCap nxbO = new NhaCungCap();
            AssignData(nxbO);
            if (flagSave == 0)
            {
                if (nccCtrl.AddNCC(nxbO))
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Thêm không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (nccCtrl.UpdateNCC(nxbO))
                    //if (nvCtrl.UpdateNhanVien(nvO))
                    MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Sửa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Frm_QL_NCC_Load(sender, e);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            Frm_QL_NCC_Load(sender, e);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (nccCtrl.DeleteNCC(txtMaNCC.Text))
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Xóa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Frm_QL_NCC_Load(sender, e);

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc muốn hủy thao tác đang làm?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                Frm_QL_NCC_Load(sender, e);
            else
                return;
        }


    }
}
