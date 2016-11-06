namespace APP_BookStore.Views.QL
{
    partial class Frm_QL_PhieuXuat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grPX = new System.Windows.Forms.GroupBox();
            this.txtMaPX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTG = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbNV = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grSachXuat = new System.Windows.Forms.GroupBox();
            this.txtSLXuat = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbbSach = new System.Windows.Forms.ComboBox();
            this.btnAddToDtgv = new System.Windows.Forms.Button();
            this.dtgvCT_Xuat = new System.Windows.Forms.DataGridView();
            this.grCT_Xuat = new System.Windows.Forms.GroupBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnXoaCTPX = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnStartAdd = new System.Windows.Forms.Button();
            this.btnEditPN = new System.Windows.Forms.Button();
            this.btnDone = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lblSLTon = new System.Windows.Forms.Label();
            this.grPX.SuspendLayout();
            this.grSachXuat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvCT_Xuat)).BeginInit();
            this.grCT_Xuat.SuspendLayout();
            this.SuspendLayout();
            // 
            // grPX
            // 
            this.grPX.Controls.Add(this.txtMaPX);
            this.grPX.Controls.Add(this.label1);
            this.grPX.Controls.Add(this.lblTG);
            this.grPX.Controls.Add(this.label3);
            this.grPX.Controls.Add(this.cbbNV);
            this.grPX.Controls.Add(this.label2);
            this.grPX.Location = new System.Drawing.Point(12, 12);
            this.grPX.Name = "grPX";
            this.grPX.Size = new System.Drawing.Size(710, 125);
            this.grPX.TabIndex = 6;
            this.grPX.TabStop = false;
            this.grPX.Text = "Phiếu nhập";
            // 
            // txtMaPX
            // 
            this.txtMaPX.Enabled = false;
            this.txtMaPX.Location = new System.Drawing.Point(128, 24);
            this.txtMaPX.Name = "txtMaPX";
            this.txtMaPX.Size = new System.Drawing.Size(180, 20);
            this.txtMaPX.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nhân viên: ";
            // 
            // lblTG
            // 
            this.lblTG.AutoSize = true;
            this.lblTG.Location = new System.Drawing.Point(127, 57);
            this.lblTG.Name = "lblTG";
            this.lblTG.Size = new System.Drawing.Size(106, 13);
            this.lblTG.TabIndex = 4;
            this.lblTG.Text = "Thời gian xuất phiếu:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Thời gian xuất phiếu:";
            // 
            // cbbNV
            // 
            this.cbbNV.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbbNV.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbbNV.DisplayMember = "TenNV";
            this.cbbNV.FormattingEnabled = true;
            this.cbbNV.Location = new System.Drawing.Point(128, 81);
            this.cbbNV.Name = "cbbNV";
            this.cbbNV.Size = new System.Drawing.Size(180, 21);
            this.cbbNV.TabIndex = 42;
            this.cbbNV.ValueMember = "MaNV";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mã Phiếu Xuất: ";
            // 
            // grSachXuat
            // 
            this.grSachXuat.Controls.Add(this.txtSLXuat);
            this.grSachXuat.Controls.Add(this.lblSLTon);
            this.grSachXuat.Controls.Add(this.label6);
            this.grSachXuat.Controls.Add(this.label4);
            this.grSachXuat.Controls.Add(this.label5);
            this.grSachXuat.Controls.Add(this.cbbSach);
            this.grSachXuat.Location = new System.Drawing.Point(12, 233);
            this.grSachXuat.Name = "grSachXuat";
            this.grSachXuat.Size = new System.Drawing.Size(277, 118);
            this.grSachXuat.TabIndex = 7;
            this.grSachXuat.TabStop = false;
            this.grSachXuat.Text = "Xuất sách";
            // 
            // txtSLXuat
            // 
            this.txtSLXuat.Location = new System.Drawing.Point(98, 59);
            this.txtSLXuat.Name = "txtSLXuat";
            this.txtSLXuat.Size = new System.Drawing.Size(173, 20);
            this.txtSLXuat.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Số lượng xuất:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tên sách: ";
            // 
            // cbbSach
            // 
            this.cbbSach.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbbSach.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbbSach.DisplayMember = "TenSach";
            this.cbbSach.FormattingEnabled = true;
            this.cbbSach.Location = new System.Drawing.Point(98, 23);
            this.cbbSach.Name = "cbbSach";
            this.cbbSach.Size = new System.Drawing.Size(173, 21);
            this.cbbSach.TabIndex = 42;
            this.cbbSach.ValueMember = "MaSach";
            this.cbbSach.SelectedIndexChanged += new System.EventHandler(this.cbbSach_SelectedIndexChanged);
            // 
            // btnAddToDtgv
            // 
            this.btnAddToDtgv.Location = new System.Drawing.Point(295, 273);
            this.btnAddToDtgv.Name = "btnAddToDtgv";
            this.btnAddToDtgv.Size = new System.Drawing.Size(75, 23);
            this.btnAddToDtgv.TabIndex = 8;
            this.btnAddToDtgv.Text = ">>";
            this.btnAddToDtgv.UseVisualStyleBackColor = true;
            this.btnAddToDtgv.Click += new System.EventHandler(this.btnAddToDtgv_Click);
            // 
            // dtgvCT_Xuat
            // 
            this.dtgvCT_Xuat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgvCT_Xuat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvCT_Xuat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvCT_Xuat.Location = new System.Drawing.Point(6, 19);
            this.dtgvCT_Xuat.MultiSelect = false;
            this.dtgvCT_Xuat.Name = "dtgvCT_Xuat";
            this.dtgvCT_Xuat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvCT_Xuat.Size = new System.Drawing.Size(334, 244);
            this.dtgvCT_Xuat.TabIndex = 9;
            // 
            // grCT_Xuat
            // 
            this.grCT_Xuat.Controls.Add(this.dtgvCT_Xuat);
            this.grCT_Xuat.Location = new System.Drawing.Point(376, 157);
            this.grCT_Xuat.Name = "grCT_Xuat";
            this.grCT_Xuat.Size = new System.Drawing.Size(346, 269);
            this.grCT_Xuat.TabIndex = 9;
            this.grCT_Xuat.TabStop = false;
            this.grCT_Xuat.Text = "Chi tiết sách muốn xuất";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(640, 428);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(74, 28);
            this.btnBack.TabIndex = 10;
            this.btnBack.Text = "Trở về";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // btnXoaCTPX
            // 
            this.btnXoaCTPX.Location = new System.Drawing.Point(457, 429);
            this.btnXoaCTPX.Name = "btnXoaCTPX";
            this.btnXoaCTPX.Size = new System.Drawing.Size(74, 28);
            this.btnXoaCTPX.TabIndex = 11;
            this.btnXoaCTPX.Text = "Xóa sách";
            this.btnXoaCTPX.UseVisualStyleBackColor = true;
            this.btnXoaCTPX.Click += new System.EventHandler(this.btnXoaCTPX_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(360, 428);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(74, 28);
            this.btnNew.TabIndex = 12;
            this.btnNew.Text = "Phiếu mới";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnStartAdd
            // 
            this.btnStartAdd.Location = new System.Drawing.Point(12, 429);
            this.btnStartAdd.Name = "btnStartAdd";
            this.btnStartAdd.Size = new System.Drawing.Size(107, 26);
            this.btnStartAdd.TabIndex = 13;
            this.btnStartAdd.Text = "Bắt đầu thêm sách";
            this.btnStartAdd.UseVisualStyleBackColor = true;
            this.btnStartAdd.Click += new System.EventHandler(this.btnStartAdd_Click);
            // 
            // btnEditPN
            // 
            this.btnEditPN.Location = new System.Drawing.Point(125, 430);
            this.btnEditPN.Name = "btnEditPN";
            this.btnEditPN.Size = new System.Drawing.Size(111, 26);
            this.btnEditPN.TabIndex = 14;
            this.btnEditPN.Text = "Quay lại sửa phiếu";
            this.btnEditPN.UseVisualStyleBackColor = true;
            this.btnEditPN.Click += new System.EventHandler(this.btnEditPN_Click);
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(272, 429);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(66, 26);
            this.btnDone.TabIndex = 15;
            this.btnDone.Text = "Xong";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Số lượng tồn:";
            // 
            // lblSLTon
            // 
            this.lblSLTon.AutoSize = true;
            this.lblSLTon.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSLTon.Location = new System.Drawing.Point(103, 89);
            this.lblSLTon.Name = "lblSLTon";
            this.lblSLTon.Size = new System.Drawing.Size(17, 18);
            this.lblSLTon.TabIndex = 4;
            this.lblSLTon.Text = "1";
            // 
            // Frm_QL_PhieuXuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 461);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnXoaCTPX);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnStartAdd);
            this.Controls.Add(this.btnEditPN);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.grCT_Xuat);
            this.Controls.Add(this.btnAddToDtgv);
            this.Controls.Add(this.grSachXuat);
            this.Controls.Add(this.grPX);
            this.Name = "Frm_QL_PhieuXuat";
            this.Text = "Frm_QL_PhieuXuat";
            this.Load += new System.EventHandler(this.Frm_QL_PhieuXuat_Load);
            this.grPX.ResumeLayout(false);
            this.grPX.PerformLayout();
            this.grSachXuat.ResumeLayout(false);
            this.grSachXuat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvCT_Xuat)).EndInit();
            this.grCT_Xuat.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grPX;
        private System.Windows.Forms.TextBox txtMaPX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbbNV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grSachXuat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbbSach;
        private System.Windows.Forms.Button btnAddToDtgv;
        private System.Windows.Forms.DataGridView dtgvCT_Xuat;
        private System.Windows.Forms.GroupBox grCT_Xuat;
        private System.Windows.Forms.TextBox txtSLXuat;
        private System.Windows.Forms.Label lblTG;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnXoaCTPX;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnStartAdd;
        private System.Windows.Forms.Button btnEditPN;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Label lblSLTon;
        private System.Windows.Forms.Label label6;
    }
}