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
    public partial class Frm_QL_PhieuNhap : Form
    {
        PhieuNhapCtrl pnCtrl = new PhieuNhapCtrl();
        SachCtrl sachCtrl = new SachCtrl();
        NCCService nccSer = new NCCService();
        NhanVienService nvSer = new NhanVienService();
        TacGiaService tgSer = new TacGiaService();
        TheLoaiService tlSer = new TheLoaiService();
        NXBService nxbSer = new NXBService();
        List<NhaCungCap> lstNCC;
        List<NhanVien> lstNV;
        List<NhaXuatBan> lstNXB;
        List<TacGia> lstTG;
        List<TheLoaiSach> lstLoaiSach;
        bool flagAddNCC = false;
        public Frm_QL_PhieuNhap()
        {
            InitializeComponent();
        }
        private void DisEn(bool e)
        {
            btnStartAdd.Enabled = e;
            btnDone.Enabled = !e;
            btnNew.Enabled = !e;
            grPN.Enabled = e;
            grNCC.Enabled = e;
            grAddNCC.Enabled = !e;
            grDetail.Enabled = !e;
            btnAddToDtgv.Enabled = !e;
        }
        private void CheckedRadioNCC()
        {
            if (rdThemNCC.Checked)
            {
                flagAddNCC = true;
            }
        }
        private void LoadCBB()
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
            lstNCC = nccSer.GetAllData().AsEnumerable().Select(m => new NhaCungCap()
            {
                MaNCC = m.Field<string>("MaNCC"),
                TenNCC = m.Field<string>("TenNCC")
            }).ToList();
            lstNV = nvSer.GetAllData().AsEnumerable().Select(m => new NhanVien()
            {
                MaNV = m.Field<string>("MaNV"),
                TenNV = m.Field<string>("TenNV")
            }).ToList();


            cbbLoaiSach.Items.Clear();
            foreach (TheLoaiSach item in lstLoaiSach)
            {
                cbbLoaiSach.Items.Add(item);
            }
            cbbLoaiSach.SelectedIndex = 0;
            cbbNXB.Items.Clear();
            foreach (NhaXuatBan item in lstNXB)
            {
                cbbNXB.Items.Add(item);
            }
            cbbNXB.SelectedIndex = 0;
            cbbTG.Items.Clear();
            foreach (TacGia item in lstTG)
            {
                cbbTG.Items.Add(item);
            }
            cbbTG.SelectedIndex = 0;
            cbbNCC.Items.Clear();
            foreach (NhaCungCap item in lstNCC)
            {
                cbbNCC.Items.Add(item);
            }
            cbbNCC.SelectedIndex = 0;
            cbbNV.Items.Clear();
            foreach (NhanVien item in lstNV)
            {
                cbbNV.Items.Add(item);
            }
            cbbNV.SelectedIndex = 0;
        }
        private void ClearData()
        {
            txtMaSach.Text = "";
            txtTenSach.Text = "";
            txtGiaBan.Text = "";
            txtGiamGia.Text = "";
            txtGiaNhap.Text = "";
            txtSLNhap.Text = "";
            cbbLoaiSach.SelectedIndex = 0;
            cbbNXB.SelectedIndex = 0;
            cbbTG.SelectedIndex = 0;
        }
        private void DataBindings()
        {
            txtMaSach.DataBindings.Clear();
            txtMaSach.DataBindings.Add("Text", dtgvCT_PhieuNhap.DataSource, "MaSach");
            txtTenSach.DataBindings.Clear();
            txtTenSach.DataBindings.Add("Text", dtgvCT_PhieuNhap.DataSource, "TenSach");
            txtGiaBan.DataBindings.Clear();
            txtGiaBan.DataBindings.Add("Text", dtgvCT_PhieuNhap.DataSource, "GiaBan");
            txtGiaNhap.DataBindings.Clear();
            txtGiaNhap.DataBindings.Add("Text", dtgvCT_PhieuNhap.DataSource, "GiaNhap");
            txtGiamGia.DataBindings.Clear();
            txtGiamGia.DataBindings.Add("Text", dtgvCT_PhieuNhap.DataSource, "GiamGia");
            txtSLNhap.DataBindings.Clear();
            txtSLNhap.DataBindings.Add("Text", dtgvCT_PhieuNhap.DataSource, "SoLuong");
        }
        private void ValidateNullInputCT()
        {            
            if (cbbNXB.SelectedIndex == -1)
            {
                throw new System.Exception("Chưa chọn nhà xuất bản!");
            }
            if (cbbTG.SelectedIndex == -1)
            {
                throw new System.Exception("Chưa chọn tác giả!");
            }
            if (cbbLoaiSach.SelectedIndex == -1)
            {
                throw new System.Exception("Chưa chọn loại sách!");
            }
            if (txtMaSach.Text.Trim() == "")
            {
                throw new System.Exception("Chưa nhập mã sách!");
            }
            if (txtTenSach.Text.Trim() == "")
            {
                throw new System.Exception("Chưa nhập tên sách!");
            }
            if (txtGiaBan.Text.Trim() == "")
            {
                throw new System.Exception("Chưa nhập giá bán!");
            }
            if (txtGiaNhap.Text.Trim() == "")
            {
                throw new System.Exception("Chưa nhập giá nhập!");
            }
            if (txtGiamGia.Text.Trim() == "")
            {
                throw new System.Exception("Chưa nhập giảm giá!");
            }
            if (txtSLNhap.Text.Trim() == "")
            {
                throw new System.Exception("Chưa số lượng cần nhập!");
            }
        }
        private void ValidateNullInputPN()
        {
            if (rdChonNCC.Checked)
            {
                if (cbbNCC.SelectedIndex == -1)
                {
                    throw new System.Exception("Chưa chọn nhà cung cấp!");
                }
            }

            if (cbbNV.SelectedIndex == -1)
            {
                throw new System.Exception("Chưa chọn nhân viên!");
            }
        }
        private string GenerateID()
        {
            return "PN" + DateTime.Now.ToString("ddMMyyHHmmss");
        }
        private void Frm_QL_PhieuNhap_Load(object sender, EventArgs e)
        {
            DisEn(true);

            txtMaPN.Text = GenerateID();
            LoadCBB();
            ClearData();
            dtgvCT_PhieuNhap.Columns.Clear();
            dtgvCT_PhieuNhap.Rows.Clear();
            dtgvCT_PhieuNhap.Columns.Add("MaSach", "Mã Sách");
            dtgvCT_PhieuNhap.Columns.Add("TenSach", "Tên Sách");
            dtgvCT_PhieuNhap.Columns.Add("MaTL", "Thể Loại");
            dtgvCT_PhieuNhap.Columns.Add("MaNXB", "Mã NXB");
            dtgvCT_PhieuNhap.Columns.Add("MaTG", "Mã TG");
            dtgvCT_PhieuNhap.Columns.Add("GiaBan", "Giá Bán");
            dtgvCT_PhieuNhap.Columns.Add("GiaNhap", "Giá Nhập");
            dtgvCT_PhieuNhap.Columns.Add("GiamGia", "Giảm Giá");
            dtgvCT_PhieuNhap.Columns.Add("SoLuong", "Số Lượng Nhập");
            dtgvCT_PhieuNhap.Columns[2].Visible = false;
            dtgvCT_PhieuNhap.Columns[3].Visible = false;
            dtgvCT_PhieuNhap.Columns[4].Visible = false;

        }

        private void rdThemNCC_CheckedChanged(object sender, EventArgs e)
        {
            if (rdThemNCC.Checked)
            {
                cbbNCC.Enabled = false;
                grAddNCC.Enabled = true;
            }
            else
            {
                cbbNCC.Enabled = true;
                grAddNCC.Enabled = false;
            }
        }
        private void CheckNCC()
        {
            if (rdThemNCC.Checked)
            {
                try
                {
                    if (Object.ReferenceEquals(null, nccSer.GetData(txtMaNCC.Text.Trim())))
                    {
                        NhaCungCap ncc = new NhaCungCap();
                        ncc.MaNCC = txtMaNCC.Text.Trim();
                        ncc.TenNCC = txtTenNCC.Text.Trim();
                        ncc.DiaChi = txtDiaChi.Text.Trim();
                        ncc.SDT1 = Int32.Parse(txtSDT.Text.Trim());
                        nccSer.AddData(ncc);
                    }
                    else if (txtTenNCC.Text.Trim() == "")
                    {
                        MessageBox.Show("Chưa nhập tên NCC");
                    }
                    else if (txtMaNCC.Text.Trim() == "")
                    {
                        MessageBox.Show("Chưa nhập mã NCC");
                    }
                    else
                    {
                        MessageBox.Show("Mã nhà cung cấp đã tồn tại!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.ToString());
                }
            }
        }
        private void btnStartAdd_Click(object sender, EventArgs e)
        {
            CheckNCC();
            DisEn(false);
        }

        private void txtMaSach_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!Object.ReferenceEquals(null, sachCtrl.GetSach(txtMaSach.Text.Trim())))
                {
                    Sach s = new Sach();
                    s = sachCtrl.GetSach(txtMaSach.Text.Trim());
                    txtTenSach.DataBindings.Clear();
                    txtTenSach.DataBindings.Add("Text", s, "TenSach");
                    txtGiaBan.DataBindings.Clear();
                    txtGiaBan.DataBindings.Add("Text", s, "GiaBan");
                    txtGiaNhap.DataBindings.Clear();
                    txtGiaNhap.DataBindings.Add("Text", s, "GiaNhap");
                    txtGiamGia.DataBindings.Clear();
                    txtGiamGia.DataBindings.Add("Text", s, "GiamGia");
                    cbbLoaiSach.SelectedIndex = cbbLoaiSach.FindStringExact(tlSer.GetData(s.MaTL).TenTL);
                    cbbNXB.SelectedIndex = cbbNXB.FindStringExact(nxbSer.GetData(s.MaNXB).TenNXB);
                    cbbTG.SelectedIndex = cbbTG.FindStringExact(tgSer.GetData(s.MaTG).TenTG);
                }
                else
                {
                    txtTenSach.Text = "";
                    txtGiaBan.Text = "";
                    txtGiaNhap.Text = "";
                    txtGiamGia.Text = "";
                    txtSLNhap.Text = "";
                    cbbLoaiSach.SelectedIndex = 0;
                    cbbNXB.SelectedIndex = 0;
                    cbbTG.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }

        private void btnAddToDtgv_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateNullInputCT();
                string[] row = new string[] {txtMaSach.Text.Trim(),
                                         txtTenSach.Text.Trim(),
                                         ((TheLoaiSach)cbbLoaiSach.SelectedItem).MaTL,
                                         ((NhaXuatBan)cbbNXB.SelectedItem).MaNXB,
                                         ((TacGia)cbbTG.SelectedItem).MaTG,
                                         txtGiaBan.Text.Trim(),
                                         txtGiaNhap.Text.Trim(),
                                         txtGiamGia.Text.Trim(),
                                         txtSLNhap.Text.Trim()};
                dtgvCT_PhieuNhap.Rows.Add(row);
                ClearData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }


        private void btnXoaCTPN_Click(object sender, EventArgs e)
        {
            if (dtgvCT_PhieuNhap.SelectedCells.Count > 0)
            {
                int selectedRowIndex = dtgvCT_PhieuNhap.SelectedCells[0].RowIndex;
                dtgvCT_PhieuNhap.Rows.RemoveAt(selectedRowIndex);
            }
        }

        private void dtgvCT_PhieuNhap_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgvCT_PhieuNhap.SelectedCells.Count > 0)
            {
                int selectedRowIndex = dtgvCT_PhieuNhap.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dtgvCT_PhieuNhap.Rows[selectedRowIndex];
                if (!object.ReferenceEquals(null, selectedRow.Cells["MaSach"].Value))
                {
                    txtMaSach.DataBindings.Clear();
                    txtMaSach.Text = selectedRow.Cells["MaSach"].Value.ToString();
                    txtTenSach.DataBindings.Clear();
                    txtTenSach.Text = selectedRow.Cells["TenSach"].Value.ToString();
                    txtGiaBan.DataBindings.Clear();
                    txtGiaBan.Text = selectedRow.Cells["GiaBan"].Value.ToString();
                    txtGiaNhap.DataBindings.Clear();
                    txtGiaNhap.Text = selectedRow.Cells["GiaNhap"].Value.ToString();
                    txtGiamGia.DataBindings.Clear();
                    txtGiamGia.Text = selectedRow.Cells["GiamGia"].Value.ToString();
                    txtSLNhap.DataBindings.Clear();
                    txtSLNhap.Text = selectedRow.Cells["SoLuong"].Value.ToString();
                    cbbLoaiSach.SelectedIndex = cbbLoaiSach.FindStringExact(tlSer.GetData(selectedRow.Cells["MaTL"].Value.ToString()).TenTL);
                    cbbTG.SelectedIndex = cbbTG.FindStringExact(tgSer.GetData(selectedRow.Cells["MaTG"].Value.ToString()).TenTG);
                    cbbNXB.SelectedIndex = cbbNXB.FindStringExact(nxbSer.GetData(selectedRow.Cells["MaNXB"].Value.ToString()).TenNXB);
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Frm_QL_PhieuNhap_Load(sender, e);
        }
        private void AssignData(PhieuNhap pn)
        {
            pn.MaPN = txtMaPN.Text.Trim();
            pn.MaPN = txtMaPN.Text.Trim();
            pn.MaNCC = rdChonNCC.Checked ? ((NhaCungCap)cbbNCC.SelectedItem).MaNCC : txtMaNCC.Text.Trim();
            pn.MaNV = ((NhanVien)cbbNV.SelectedItem).MaNV;
            pn.NgayLapPN = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            pn.DtPN = pnCtrl.ConvertDataGrid2DataTable(dtgvCT_PhieuNhap);
        }
        private void btnDone_Click(object sender, EventArgs e)
        {
            PhieuNhap pn = new PhieuNhap();
            try
            {
                ValidateNullInputPN();
                AssignData(pn);
                if (pnCtrl.AddPhieuNhap(pn))
                {
                    Frm_QL_PhieuNhap_Load(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }

        }
        private void btnEditPN_Click(object sender, EventArgs e)
        {
            CheckNCC();
            DisEn(true);
        }
        private void ValidateKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }



    }
}
