namespace MedicalStoreManagementSystem.GUI
{
    partial class BillManagement
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BillManagement));
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.cbLoaiTim = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnExport = new Guna.UI2.WinForms.Guna2Button();
            this.btnRemove = new Guna.UI2.WinForms.Guna2Button();
            this.btnUpdate = new Guna.UI2.WinForms.Guna2Button();
            this.tbxSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpToDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpFromDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvBills = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colHoaDonID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenKhachHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgayTao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHinhThucTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.dtpNgayTao = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dgvBillInfor = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colThuocID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenThuoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxTotalPrice = new Guna.UI2.WinForms.Guna2TextBox();
            this.tbxPhone = new Guna.UI2.WinForms.Guna2TextBox();
            this.tbxCustomerName = new Guna.UI2.WinForms.Guna2TextBox();
            this.tbxID = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnTimNgay = new Guna.UI2.WinForms.Guna2Button();
            this.eLoi = new System.Windows.Forms.ErrorProvider(this.components);
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBills)).BeginInit();
            this.guna2Panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillInfor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eLoi)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 25;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.DragForm = false;
            this.guna2BorderlessForm1.HasFormShadow = false;
            this.guna2BorderlessForm1.ResizeForm = false;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(87)))), ((int)(((byte)(66)))));
            this.guna2Panel1.BorderRadius = 10;
            this.guna2Panel1.BorderThickness = 2;
            this.guna2Panel1.Controls.Add(this.btnTimNgay);
            this.guna2Panel1.Controls.Add(this.cbLoaiTim);
            this.guna2Panel1.Controls.Add(this.btnExport);
            this.guna2Panel1.Controls.Add(this.btnRemove);
            this.guna2Panel1.Controls.Add(this.btnUpdate);
            this.guna2Panel1.Controls.Add(this.tbxSearch);
            this.guna2Panel1.Controls.Add(this.label2);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Controls.Add(this.dtpToDate);
            this.guna2Panel1.Controls.Add(this.dtpFromDate);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1590, 150);
            this.guna2Panel1.TabIndex = 0;
            // 
            // cbLoaiTim
            // 
            this.cbLoaiTim.AutoRoundedCorners = true;
            this.cbLoaiTim.BackColor = System.Drawing.Color.Transparent;
            this.cbLoaiTim.BorderRadius = 17;
            this.cbLoaiTim.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbLoaiTim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLoaiTim.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(183)))), ((int)(((byte)(108)))));
            this.cbLoaiTim.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(183)))), ((int)(((byte)(108)))));
            this.cbLoaiTim.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLoaiTim.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(87)))), ((int)(((byte)(66)))));
            this.cbLoaiTim.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(183)))), ((int)(((byte)(108)))));
            this.cbLoaiTim.ItemHeight = 30;
            this.cbLoaiTim.Items.AddRange(new object[] {
            "Hóa đơn ID",
            "Tên khách hàng",
            "Số điện thoại"});
            this.cbLoaiTim.Location = new System.Drawing.Point(718, 28);
            this.cbLoaiTim.Name = "cbLoaiTim";
            this.cbLoaiTim.Size = new System.Drawing.Size(189, 36);
            this.cbLoaiTim.TabIndex = 77;
            // 
            // btnExport
            // 
            this.btnExport.Animated = true;
            this.btnExport.BackColor = System.Drawing.Color.Transparent;
            this.btnExport.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(148)))), ((int)(((byte)(87)))));
            this.btnExport.BorderRadius = 10;
            this.btnExport.BorderThickness = 2;
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExport.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExport.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExport.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExport.FillColor = System.Drawing.Color.White;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnExport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(148)))), ((int)(((byte)(87)))));
            this.btnExport.HoverState.BorderColor = System.Drawing.Color.White;
            this.btnExport.HoverState.CustomBorderColor = System.Drawing.Color.White;
            this.btnExport.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(148)))), ((int)(((byte)(87)))));
            this.btnExport.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnExport.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.Location = new System.Drawing.Point(1365, 82);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(180, 45);
            this.btnExport.TabIndex = 7;
            this.btnExport.Text = "Export";
            this.btnExport.UseTransparentBackground = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Animated = true;
            this.btnRemove.BackColor = System.Drawing.Color.Transparent;
            this.btnRemove.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(148)))), ((int)(((byte)(87)))));
            this.btnRemove.BorderRadius = 10;
            this.btnRemove.BorderThickness = 2;
            this.btnRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemove.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRemove.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRemove.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRemove.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRemove.FillColor = System.Drawing.Color.White;
            this.btnRemove.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnRemove.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(148)))), ((int)(((byte)(87)))));
            this.btnRemove.HoverState.BorderColor = System.Drawing.Color.White;
            this.btnRemove.HoverState.CustomBorderColor = System.Drawing.Color.White;
            this.btnRemove.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(148)))), ((int)(((byte)(87)))));
            this.btnRemove.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnRemove.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image2")));
            this.btnRemove.Image = ((System.Drawing.Image)(resources.GetObject("btnRemove.Image")));
            this.btnRemove.Location = new System.Drawing.Point(1179, 82);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(180, 45);
            this.btnRemove.TabIndex = 6;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseTransparentBackground = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Animated = true;
            this.btnUpdate.BackColor = System.Drawing.Color.Transparent;
            this.btnUpdate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(148)))), ((int)(((byte)(87)))));
            this.btnUpdate.BorderRadius = 10;
            this.btnUpdate.BorderThickness = 2;
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnUpdate.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnUpdate.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnUpdate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnUpdate.FillColor = System.Drawing.Color.White;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(148)))), ((int)(((byte)(87)))));
            this.btnUpdate.HoverState.BorderColor = System.Drawing.Color.White;
            this.btnUpdate.HoverState.CustomBorderColor = System.Drawing.Color.White;
            this.btnUpdate.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(148)))), ((int)(((byte)(87)))));
            this.btnUpdate.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image3")));
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.Location = new System.Drawing.Point(993, 82);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(180, 45);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseTransparentBackground = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // tbxSearch
            // 
            this.tbxSearch.Animated = true;
            this.tbxSearch.AutoRoundedCorners = true;
            this.tbxSearch.BorderRadius = 28;
            this.tbxSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbxSearch.DefaultText = "";
            this.tbxSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbxSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbxSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbxSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbxSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(87)))), ((int)(((byte)(66)))));
            this.tbxSearch.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.tbxSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(87)))), ((int)(((byte)(66)))));
            this.tbxSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(87)))), ((int)(((byte)(66)))));
            this.tbxSearch.IconRight = ((System.Drawing.Image)(resources.GetObject("tbxSearch.IconRight")));
            this.tbxSearch.IconRightOffset = new System.Drawing.Point(10, 0);
            this.tbxSearch.Location = new System.Drawing.Point(130, 15);
            this.tbxSearch.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.PasswordChar = '\0';
            this.tbxSearch.PlaceholderText = "Search";
            this.tbxSearch.SelectedText = "";
            this.tbxSearch.Size = new System.Drawing.Size(567, 59);
            this.tbxSearch.TabIndex = 4;
            this.tbxSearch.TextOffset = new System.Drawing.Point(10, 0);
            this.tbxSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxSearch_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(425, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(70, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "From";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Animated = true;
            this.dtpToDate.BackColor = System.Drawing.Color.Transparent;
            this.dtpToDate.BorderRadius = 15;
            this.dtpToDate.Checked = true;
            this.dtpToDate.FillColor = System.Drawing.Color.White;
            this.dtpToDate.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(461, 82);
            this.dtpToDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpToDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(236, 62);
            this.dtpToDate.TabIndex = 1;
            this.dtpToDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtpToDate.UseTransparentBackground = true;
            this.dtpToDate.Value = new System.DateTime(2023, 12, 20, 11, 11, 0, 0);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Animated = true;
            this.dtpFromDate.BackColor = System.Drawing.Color.Transparent;
            this.dtpFromDate.BorderRadius = 15;
            this.dtpFromDate.Checked = true;
            this.dtpFromDate.FillColor = System.Drawing.Color.White;
            this.dtpFromDate.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(130, 82);
            this.dtpFromDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpFromDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(236, 62);
            this.dtpFromDate.TabIndex = 0;
            this.dtpFromDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtpFromDate.UseTransparentBackground = true;
            this.dtpFromDate.Value = new System.DateTime(2023, 12, 12, 11, 11, 0, 0);
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(87)))), ((int)(((byte)(66)))));
            this.guna2Panel2.BorderRadius = 10;
            this.guna2Panel2.BorderThickness = 2;
            this.guna2Panel2.Controls.Add(this.dgvBills);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2Panel2.Location = new System.Drawing.Point(0, 150);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(940, 772);
            this.guna2Panel2.TabIndex = 1;
            // 
            // dgvBills
            // 
            this.dgvBills.AllowUserToAddRows = false;
            this.dgvBills.AllowUserToDeleteRows = false;
            this.dgvBills.AllowUserToResizeColumns = false;
            this.dgvBills.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(205)))), ((int)(((byte)(123)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvBills.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvBills.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBills.BackgroundColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(148)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(148)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBills.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvBills.ColumnHeadersHeight = 30;
            this.dgvBills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvBills.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colHoaDonID,
            this.colTenKhachHang,
            this.colSdt,
            this.colNgayTao,
            this.colHinhThucTT,
            this.colTongTien});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(205)))), ((int)(((byte)(123)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBills.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvBills.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvBills.Location = new System.Drawing.Point(12, 16);
            this.dgvBills.MultiSelect = false;
            this.dgvBills.Name = "dgvBills";
            this.dgvBills.ReadOnly = true;
            this.dgvBills.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBills.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvBills.RowHeadersVisible = false;
            this.dgvBills.RowHeadersWidth = 51;
            this.dgvBills.RowTemplate.Height = 24;
            this.dgvBills.Size = new System.Drawing.Size(913, 744);
            this.dgvBills.TabIndex = 0;
            this.dgvBills.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvBills.ThemeStyle.AlternatingRowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvBills.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvBills.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(205)))), ((int)(((byte)(123)))));
            this.dgvBills.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvBills.ThemeStyle.BackColor = System.Drawing.Color.Silver;
            this.dgvBills.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvBills.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(148)))), ((int)(((byte)(87)))));
            this.dgvBills.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvBills.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvBills.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvBills.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvBills.ThemeStyle.HeaderStyle.Height = 30;
            this.dgvBills.ThemeStyle.ReadOnly = true;
            this.dgvBills.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvBills.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvBills.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvBills.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvBills.ThemeStyle.RowsStyle.Height = 24;
            this.dgvBills.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(205)))), ((int)(((byte)(123)))));
            this.dgvBills.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvBills.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBills_RowEnter);
            // 
            // colHoaDonID
            // 
            this.colHoaDonID.DataPropertyName = "HoaDonID";
            this.colHoaDonID.HeaderText = "Hóa đơn ID";
            this.colHoaDonID.MinimumWidth = 6;
            this.colHoaDonID.Name = "colHoaDonID";
            this.colHoaDonID.ReadOnly = true;
            // 
            // colTenKhachHang
            // 
            this.colTenKhachHang.DataPropertyName = "TenKhachHang";
            this.colTenKhachHang.HeaderText = "Tên khách hàng";
            this.colTenKhachHang.MinimumWidth = 6;
            this.colTenKhachHang.Name = "colTenKhachHang";
            this.colTenKhachHang.ReadOnly = true;
            // 
            // colSdt
            // 
            this.colSdt.DataPropertyName = "Sdt";
            this.colSdt.HeaderText = "Số điện thoại";
            this.colSdt.MinimumWidth = 6;
            this.colSdt.Name = "colSdt";
            this.colSdt.ReadOnly = true;
            // 
            // colNgayTao
            // 
            this.colNgayTao.DataPropertyName = "NgayTao";
            this.colNgayTao.HeaderText = "Ngày tạo";
            this.colNgayTao.MinimumWidth = 6;
            this.colNgayTao.Name = "colNgayTao";
            this.colNgayTao.ReadOnly = true;
            // 
            // colHinhThucTT
            // 
            this.colHinhThucTT.DataPropertyName = "TenHinhThucThanhToan";
            this.colHinhThucTT.HeaderText = "Hình thức thanh toán";
            this.colHinhThucTT.MinimumWidth = 6;
            this.colHinhThucTT.Name = "colHinhThucTT";
            this.colHinhThucTT.ReadOnly = true;
            // 
            // colTongTien
            // 
            this.colTongTien.DataPropertyName = "TongTien";
            this.colTongTien.HeaderText = "Tổng tiền";
            this.colTongTien.MinimumWidth = 6;
            this.colTongTien.Name = "colTongTien";
            this.colTongTien.ReadOnly = true;
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(87)))), ((int)(((byte)(66)))));
            this.guna2Panel3.BorderRadius = 10;
            this.guna2Panel3.BorderThickness = 2;
            this.guna2Panel3.Controls.Add(this.dtpNgayTao);
            this.guna2Panel3.Controls.Add(this.dgvBillInfor);
            this.guna2Panel3.Controls.Add(this.label3);
            this.guna2Panel3.Controls.Add(this.tbxTotalPrice);
            this.guna2Panel3.Controls.Add(this.tbxPhone);
            this.guna2Panel3.Controls.Add(this.tbxCustomerName);
            this.guna2Panel3.Controls.Add(this.tbxID);
            this.guna2Panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel3.Location = new System.Drawing.Point(940, 150);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(650, 772);
            this.guna2Panel3.TabIndex = 2;
            // 
            // dtpNgayTao
            // 
            this.dtpNgayTao.Animated = true;
            this.dtpNgayTao.BackColor = System.Drawing.Color.Transparent;
            this.dtpNgayTao.BorderRadius = 15;
            this.dtpNgayTao.Checked = true;
            this.dtpNgayTao.Enabled = false;
            this.dtpNgayTao.FillColor = System.Drawing.Color.White;
            this.dtpNgayTao.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.dtpNgayTao.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayTao.Location = new System.Drawing.Point(308, 17);
            this.dtpNgayTao.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNgayTao.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNgayTao.Name = "dtpNgayTao";
            this.dtpNgayTao.Size = new System.Drawing.Size(318, 62);
            this.dtpNgayTao.TabIndex = 8;
            this.dtpNgayTao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtpNgayTao.UseTransparentBackground = true;
            this.dtpNgayTao.Value = new System.DateTime(2023, 11, 27, 11, 11, 58, 859);
            // 
            // dgvBillInfor
            // 
            this.dgvBillInfor.AllowUserToAddRows = false;
            this.dgvBillInfor.AllowUserToDeleteRows = false;
            this.dgvBillInfor.AllowUserToResizeColumns = false;
            this.dgvBillInfor.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(205)))), ((int)(((byte)(123)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvBillInfor.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBillInfor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBillInfor.BackgroundColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(148)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(148)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBillInfor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBillInfor.ColumnHeadersHeight = 30;
            this.dgvBillInfor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvBillInfor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colThuocID,
            this.colTenThuoc,
            this.colSoLuong,
            this.colGia});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(205)))), ((int)(((byte)(123)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBillInfor.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBillInfor.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvBillInfor.Location = new System.Drawing.Point(18, 329);
            this.dgvBillInfor.MultiSelect = false;
            this.dgvBillInfor.Name = "dgvBillInfor";
            this.dgvBillInfor.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBillInfor.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvBillInfor.RowHeadersVisible = false;
            this.dgvBillInfor.RowHeadersWidth = 51;
            this.dgvBillInfor.RowTemplate.Height = 24;
            this.dgvBillInfor.Size = new System.Drawing.Size(608, 431);
            this.dgvBillInfor.TabIndex = 12;
            this.dgvBillInfor.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvBillInfor.ThemeStyle.AlternatingRowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvBillInfor.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvBillInfor.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(205)))), ((int)(((byte)(123)))));
            this.dgvBillInfor.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvBillInfor.ThemeStyle.BackColor = System.Drawing.Color.Silver;
            this.dgvBillInfor.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvBillInfor.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(148)))), ((int)(((byte)(87)))));
            this.dgvBillInfor.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvBillInfor.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvBillInfor.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvBillInfor.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvBillInfor.ThemeStyle.HeaderStyle.Height = 30;
            this.dgvBillInfor.ThemeStyle.ReadOnly = false;
            this.dgvBillInfor.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvBillInfor.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvBillInfor.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvBillInfor.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvBillInfor.ThemeStyle.RowsStyle.Height = 24;
            this.dgvBillInfor.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(205)))), ((int)(((byte)(123)))));
            this.dgvBillInfor.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvBillInfor.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBillInfor_CellContentClick);
            this.dgvBillInfor.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBillInfor_CellEndEdit);
            this.dgvBillInfor.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvBillInfor_CellValidating);
            // 
            // colThuocID
            // 
            this.colThuocID.DataPropertyName = "ThuocID";
            this.colThuocID.HeaderText = "ID thuốc";
            this.colThuocID.MinimumWidth = 6;
            this.colThuocID.Name = "colThuocID";
            this.colThuocID.ReadOnly = true;
            // 
            // colTenThuoc
            // 
            this.colTenThuoc.DataPropertyName = "TenThuoc";
            this.colTenThuoc.HeaderText = "Tên thuốc";
            this.colTenThuoc.MinimumWidth = 6;
            this.colTenThuoc.Name = "colTenThuoc";
            this.colTenThuoc.ReadOnly = true;
            // 
            // colSoLuong
            // 
            this.colSoLuong.DataPropertyName = "SoLuong";
            this.colSoLuong.HeaderText = "Số lượng";
            this.colSoLuong.MinimumWidth = 6;
            this.colSoLuong.Name = "colSoLuong";
            // 
            // colGia
            // 
            this.colGia.DataPropertyName = "GiaBan";
            this.colGia.HeaderText = "Giá";
            this.colGia.MinimumWidth = 6;
            this.colGia.Name = "colGia";
            this.colGia.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(87)))), ((int)(((byte)(66)))));
            this.label3.Location = new System.Drawing.Point(13, 287);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 28);
            this.label3.TabIndex = 11;
            this.label3.Text = "Chi tiết hoá đơn";
            // 
            // tbxTotalPrice
            // 
            this.tbxTotalPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxTotalPrice.Animated = true;
            this.tbxTotalPrice.BorderRadius = 20;
            this.tbxTotalPrice.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbxTotalPrice.DefaultText = "";
            this.tbxTotalPrice.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbxTotalPrice.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbxTotalPrice.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbxTotalPrice.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbxTotalPrice.Enabled = false;
            this.tbxTotalPrice.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(87)))), ((int)(((byte)(66)))));
            this.tbxTotalPrice.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.tbxTotalPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(87)))), ((int)(((byte)(66)))));
            this.tbxTotalPrice.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(87)))), ((int)(((byte)(66)))));
            this.tbxTotalPrice.Location = new System.Drawing.Point(18, 223);
            this.tbxTotalPrice.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbxTotalPrice.Name = "tbxTotalPrice";
            this.tbxTotalPrice.PasswordChar = '\0';
            this.tbxTotalPrice.PlaceholderText = "Tổng tiền";
            this.tbxTotalPrice.ReadOnly = true;
            this.tbxTotalPrice.SelectedText = "";
            this.tbxTotalPrice.Size = new System.Drawing.Size(620, 59);
            this.tbxTotalPrice.TabIndex = 10;
            this.tbxTotalPrice.TextOffset = new System.Drawing.Point(10, 0);
            // 
            // tbxPhone
            // 
            this.tbxPhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxPhone.Animated = true;
            this.tbxPhone.BorderRadius = 20;
            this.tbxPhone.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbxPhone.DefaultText = "";
            this.tbxPhone.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbxPhone.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbxPhone.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbxPhone.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbxPhone.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(87)))), ((int)(((byte)(66)))));
            this.tbxPhone.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.tbxPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(87)))), ((int)(((byte)(66)))));
            this.tbxPhone.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(87)))), ((int)(((byte)(66)))));
            this.tbxPhone.Location = new System.Drawing.Point(18, 154);
            this.tbxPhone.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbxPhone.Name = "tbxPhone";
            this.tbxPhone.PasswordChar = '\0';
            this.tbxPhone.PlaceholderText = "Số điện thoại";
            this.tbxPhone.SelectedText = "";
            this.tbxPhone.Size = new System.Drawing.Size(620, 59);
            this.tbxPhone.TabIndex = 9;
            this.tbxPhone.TextOffset = new System.Drawing.Point(10, 0);
            // 
            // tbxCustomerName
            // 
            this.tbxCustomerName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxCustomerName.Animated = true;
            this.tbxCustomerName.BorderRadius = 20;
            this.tbxCustomerName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbxCustomerName.DefaultText = "";
            this.tbxCustomerName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbxCustomerName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbxCustomerName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbxCustomerName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbxCustomerName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(87)))), ((int)(((byte)(66)))));
            this.tbxCustomerName.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.tbxCustomerName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(87)))), ((int)(((byte)(66)))));
            this.tbxCustomerName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(87)))), ((int)(((byte)(66)))));
            this.tbxCustomerName.Location = new System.Drawing.Point(18, 87);
            this.tbxCustomerName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbxCustomerName.Name = "tbxCustomerName";
            this.tbxCustomerName.PasswordChar = '\0';
            this.tbxCustomerName.PlaceholderText = "Tên khách hàng";
            this.tbxCustomerName.SelectedText = "";
            this.tbxCustomerName.Size = new System.Drawing.Size(620, 59);
            this.tbxCustomerName.TabIndex = 6;
            this.tbxCustomerName.TextOffset = new System.Drawing.Point(10, 0);
            // 
            // tbxID
            // 
            this.tbxID.Animated = true;
            this.tbxID.BorderRadius = 20;
            this.tbxID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbxID.DefaultText = "";
            this.tbxID.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbxID.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbxID.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbxID.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbxID.Enabled = false;
            this.tbxID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(87)))), ((int)(((byte)(66)))));
            this.tbxID.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.tbxID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(87)))), ((int)(((byte)(66)))));
            this.tbxID.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(87)))), ((int)(((byte)(66)))));
            this.tbxID.Location = new System.Drawing.Point(18, 16);
            this.tbxID.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbxID.Name = "tbxID";
            this.tbxID.PasswordChar = '\0';
            this.tbxID.PlaceholderText = "ID bill";
            this.tbxID.ReadOnly = true;
            this.tbxID.SelectedText = "";
            this.tbxID.Size = new System.Drawing.Size(284, 59);
            this.tbxID.TabIndex = 5;
            this.tbxID.TextOffset = new System.Drawing.Point(10, 0);
            // 
            // btnTimNgay
            // 
            this.btnTimNgay.Animated = true;
            this.btnTimNgay.BackColor = System.Drawing.Color.Transparent;
            this.btnTimNgay.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(148)))), ((int)(((byte)(87)))));
            this.btnTimNgay.BorderRadius = 10;
            this.btnTimNgay.BorderThickness = 2;
            this.btnTimNgay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimNgay.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTimNgay.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTimNgay.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTimNgay.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTimNgay.FillColor = System.Drawing.Color.White;
            this.btnTimNgay.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnTimNgay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(148)))), ((int)(((byte)(87)))));
            this.btnTimNgay.HoverState.BorderColor = System.Drawing.Color.White;
            this.btnTimNgay.HoverState.CustomBorderColor = System.Drawing.Color.White;
            this.btnTimNgay.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(148)))), ((int)(((byte)(87)))));
            this.btnTimNgay.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnTimNgay.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.btnTimNgay.Location = new System.Drawing.Point(718, 82);
            this.btnTimNgay.Name = "btnTimNgay";
            this.btnTimNgay.Size = new System.Drawing.Size(180, 45);
            this.btnTimNgay.TabIndex = 78;
            this.btnTimNgay.Text = "Search date";
            this.btnTimNgay.UseTransparentBackground = true;
            this.btnTimNgay.Click += new System.EventHandler(this.btnTimNgay_Click);
            // 
            // eLoi
            // 
            this.eLoi.ContainerControl = this;
            // 
            // BillManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1590, 922);
            this.Controls.Add(this.guna2Panel3);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BillManagement";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "BillManagement";
            this.Load += new System.EventHandler(this.BillManagement_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.guna2Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBills)).EndInit();
            this.guna2Panel3.ResumeLayout(false);
            this.guna2Panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillInfor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eLoi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpFromDate;
        private Guna.UI2.WinForms.Guna2TextBox tbxSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpToDate;
        private Guna.UI2.WinForms.Guna2TextBox tbxCustomerName;
        private Guna.UI2.WinForms.Guna2TextBox tbxID;
        private Guna.UI2.WinForms.Guna2DataGridView dgvBills;
        private Guna.UI2.WinForms.Guna2DataGridView dgvBillInfor;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox tbxTotalPrice;
        private Guna.UI2.WinForms.Guna2TextBox tbxPhone;
        private Guna.UI2.WinForms.Guna2DataGridViewStyler guna2DataGridViewStyler1;
        private Guna.UI2.WinForms.Guna2Button btnRemove;
        private Guna.UI2.WinForms.Guna2Button btnUpdate;
        private Guna.UI2.WinForms.Guna2Button btnExport;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHoaDonID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenKhachHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSdt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgayTao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHinhThucTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTongTien;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpNgayTao;
        private Guna.UI2.WinForms.Guna2ComboBox cbLoaiTim;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThuocID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenThuoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGia;
        private Guna.UI2.WinForms.Guna2Button btnTimNgay;
        private System.Windows.Forms.ErrorProvider eLoi;
    }
}