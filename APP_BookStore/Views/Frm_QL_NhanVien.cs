using APP_BookStore.Services;
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
using APP_BookStore.Controllers;

namespace APP_BookStore.Views
{
    public partial class Frm_Admin : Form
    {
        NhanVienCtrl nvCtrl = new NhanVienCtrl();
        private int flagSave = 0;
        public Frm_Admin()
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
            txtMaNV.Enabled = e;
            txtTenNV.Enabled = e;
            txtDiaChi.Enabled = e;
            txtSDT.Enabled = e;
            cbbChucVu.Enabled = e;
            txtMatKhau.Enabled = e;
        }
        private void clearData()
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            loadCBB();
            txtMatKhau.Text = "";
        }
        private void loadCBB()
        {
            cbbChucVu.Items.Clear();
            cbbChucVu.Items.Add("Nhân Viên");
            cbbChucVu.Items.Add("Quản Lý");
            cbbChucVu.SelectedItem = 0;
        }


        private void AssignData(NhanVien nv)
        {
            nv.MaNV = txtMaNV.Text.Trim();
            if (cbbChucVu.SelectedIndex == 0)
                nv.ChucVu = "Nhân Viên";
            else
                nv.ChucVu = "Quản Lý";
            nv.TenNV = txtTenNV.Text.Trim();
            nv.DiaChi = txtDiaChi.Text.Trim();
            nv.SDT1 = Int32.Parse(txtSDT.Text.Trim());
            nv.MatKhau = txtMatKhau.Text.Trim();
        }


        private void DataBindings()
        {
            txtMaNV.DataBindings.Clear();
            txtMaNV.DataBindings.Add("Text", dtgvNhanVien.DataSource, "MaNV");
            txtTenNV.DataBindings.Clear();
            txtTenNV.DataBindings.Add("Text", dtgvNhanVien.DataSource, "TenNV");
            cbbChucVu.DataBindings.Clear();
            cbbChucVu.DataBindings.Add("Text", dtgvNhanVien.DataSource, "ChucVu");
            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", dtgvNhanVien.DataSource, "DiaChi");
            txtSDT.DataBindings.Clear();
            txtSDT.DataBindings.Add("Text", dtgvNhanVien.DataSource, "SDT");
            txtMatKhau.DataBindings.Clear();
            txtMatKhau.DataBindings.Add("Text", dtgvNhanVien.DataSource, "MatKhau");
        }


        private void Frm_Admin_Load(object sender, EventArgs e)
        {

            DataTable dt = new System.Data.DataTable();
            dt = nvCtrl.GetAllNhanVien();
            dtgvNhanVien.DataSource = dt;
            DataBindings();
            this.dtgvNhanVien.Columns[5].Visible = false;
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
            loadCBB();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            NhanVien nvO = new NhanVien();
            AssignData(nvO);
            if (flagSave == 0)
            {
                if (nvCtrl.AddNhanVien(nvO))
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Thêm không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (nvCtrl.UpdateNhanVien(nvO))
                    //if (nvCtrl.UpdateNhanVien(nvO))
                    MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Sửa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Frm_Admin_Load(sender, e);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {

            Frm_Admin_Load(sender, e);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (nvCtrl.DeleteNhanVien(txtMaNV.Text))
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Xóa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Frm_Admin_Load(sender, e);

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc muốn hủy thao tác đang làm?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                Frm_Admin_Load(sender, e);
            else
                return;
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar)) 
                e.Handled = true;
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
