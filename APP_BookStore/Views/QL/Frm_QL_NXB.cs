﻿using APP_BookStore.Controllers;
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
    public partial class Frm_QL_NXB : Form
    {

        NXBCtrl nxbCtrl = new NXBCtrl();
        private int flagSave = 0;
        public Frm_QL_NXB()
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
            txtMaNXB.Enabled = e;
            txtTenNXB.Enabled = e;
            txtDiaChi.Enabled = e;
            txtSDT.Enabled = e;
        }
        private void clearData()
        {
            txtMaNXB.Text = "";
            txtTenNXB.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
        }


        private void AssignData(NhaXuatBan nxb)
        {
            nxb.MaNXB = txtMaNXB.Text.Trim();
            nxb.TenNXB = txtTenNXB.Text.Trim();
            nxb.DiaChi = txtDiaChi.Text.Trim();
            nxb.SDT1 = Int32.Parse(txtSDT.Text.Trim());
        }


        private void DataBindings()
        {
            txtMaNXB.DataBindings.Clear();
            txtMaNXB.DataBindings.Add("Text", dtgvNXB.DataSource, "MaNXB");
            txtTenNXB.DataBindings.Clear();
            txtTenNXB.DataBindings.Add("Text", dtgvNXB.DataSource, "TenNXB");
            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", dtgvNXB.DataSource, "DiaChi");
            txtSDT.DataBindings.Clear();
            txtSDT.DataBindings.Add("Text", dtgvNXB.DataSource, "SDT");
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
            NhaXuatBan nxbO = new NhaXuatBan();
            AssignData(nxbO);
            if (flagSave == 0)
            {
                if (nxbCtrl.AddNXB(nxbO))
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Thêm không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (nxbCtrl.UpdateNXB(nxbO))
                    //if (nvCtrl.UpdateNhanVien(nvO))
                    MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Sửa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Frm_QL_NXB_Load(sender, e);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            Frm_QL_NXB_Load(sender, e);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (nxbCtrl.DeleteNXB(txtMaNXB.Text))
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Xóa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Frm_QL_NXB_Load(sender, e);

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc muốn hủy thao tác đang làm?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                Frm_QL_NXB_Load(sender, e);
            else
                return;
        }


        private void Frm_QL_NXB_Load(object sender, EventArgs e)
        {
            DataTable dt = new System.Data.DataTable();
            dt = nxbCtrl.GetAllNXB();
            dtgvNXB.DataSource = dt;
            DataBindings();
            DisEn(false);
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
