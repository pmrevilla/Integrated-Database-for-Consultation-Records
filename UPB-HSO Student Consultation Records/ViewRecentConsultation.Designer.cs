namespace UPB_HSO_Student_Consultation_Records
{
    partial class ViewRecentConsultation
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewRecentConsultation));
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.deletedRecords = new Guna.UI2.WinForms.Guna2Button();
            this.searchBtn = new Guna.UI2.WinForms.Guna2Button();
            this.refreshBtn = new Guna.UI2.WinForms.Guna2GradientButton();
            this.backBtn = new Guna.UI2.WinForms.Guna2GradientButton();
            this.databaseCon = new Guna.UI2.WinForms.Guna2DataGridView();
            this.studentNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeOfCon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lab = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.view = new System.Windows.Forms.DataGridViewButtonColumn();
            this.edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.FilterSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel5 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel6 = new Guna.UI2.WinForms.Guna2Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.guna2Panel7 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.exitBtn = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ShadowPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.databaseCon)).BeginInit();
            this.guna2Panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.Controls.Add(this.deletedRecords);
            this.guna2ShadowPanel1.Controls.Add(this.searchBtn);
            this.guna2ShadowPanel1.Controls.Add(this.refreshBtn);
            this.guna2ShadowPanel1.Controls.Add(this.backBtn);
            this.guna2ShadowPanel1.Controls.Add(this.databaseCon);
            this.guna2ShadowPanel1.Controls.Add(this.FilterSearch);
            this.guna2ShadowPanel1.Controls.Add(this.label5);
            this.guna2ShadowPanel1.Controls.Add(this.guna2Panel3);
            this.guna2ShadowPanel1.Controls.Add(this.guna2Panel7);
            this.guna2ShadowPanel1.FillColor = System.Drawing.Color.AliceBlue;
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(75, 31);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black;
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(1163, 665);
            this.guna2ShadowPanel1.TabIndex = 12;
            // 
            // deletedRecords
            // 
            this.deletedRecords.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.deletedRecords.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.deletedRecords.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.deletedRecords.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.deletedRecords.FillColor = System.Drawing.Color.Maroon;
            this.deletedRecords.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deletedRecords.ForeColor = System.Drawing.Color.White;
            this.deletedRecords.Image = global::UPB_HSO_Student_Consultation_Records.Properties.Resources.delete_icon_white;
            this.deletedRecords.Location = new System.Drawing.Point(39, 615);
            this.deletedRecords.Name = "deletedRecords";
            this.deletedRecords.Size = new System.Drawing.Size(214, 31);
            this.deletedRecords.TabIndex = 140;
            this.deletedRecords.Text = "DELETED RECORDS";
            this.deletedRecords.Click += new System.EventHandler(this.deletedRecords_Click);
            // 
            // searchBtn
            // 
            this.searchBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.searchBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.searchBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.searchBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.searchBtn.FillColor = System.Drawing.Color.SteelBlue;
            this.searchBtn.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBtn.ForeColor = System.Drawing.Color.White;
            this.searchBtn.Location = new System.Drawing.Point(1012, 133);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(53, 36);
            this.searchBtn.TabIndex = 139;
            this.searchBtn.Text = "🔍";
            this.searchBtn.TextTransform = Guna.UI2.WinForms.Enums.TextTransform.LowerCase;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // refreshBtn
            // 
            this.refreshBtn.AutoRoundedCorners = true;
            this.refreshBtn.BorderRadius = 14;
            this.refreshBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.refreshBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.refreshBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.refreshBtn.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.refreshBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.refreshBtn.FillColor = System.Drawing.Color.CadetBlue;
            this.refreshBtn.FillColor2 = System.Drawing.Color.DarkSlateGray;
            this.refreshBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshBtn.ForeColor = System.Drawing.Color.Honeydew;
            this.refreshBtn.HoverState.FillColor = System.Drawing.Color.OliveDrab;
            this.refreshBtn.HoverState.FillColor2 = System.Drawing.Color.Teal;
            this.refreshBtn.HoverState.ForeColor = System.Drawing.Color.White;
            this.refreshBtn.Location = new System.Drawing.Point(998, 615);
            this.refreshBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(147, 31);
            this.refreshBtn.TabIndex = 105;
            this.refreshBtn.Text = "REFRESH";
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // backBtn
            // 
            this.backBtn.AutoRoundedCorners = true;
            this.backBtn.BorderRadius = 14;
            this.backBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.backBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.backBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.backBtn.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.backBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.backBtn.FillColor = System.Drawing.Color.IndianRed;
            this.backBtn.FillColor2 = System.Drawing.Color.Tomato;
            this.backBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backBtn.ForeColor = System.Drawing.Color.Honeydew;
            this.backBtn.HoverState.FillColor = System.Drawing.Color.Maroon;
            this.backBtn.HoverState.FillColor2 = System.Drawing.Color.DarkRed;
            this.backBtn.HoverState.ForeColor = System.Drawing.Color.White;
            this.backBtn.Location = new System.Drawing.Point(877, 615);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(115, 31);
            this.backBtn.TabIndex = 104;
            this.backBtn.Text = "BACK";
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click_1);
            // 
            // databaseCon
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.databaseCon.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.databaseCon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.databaseCon.ColumnHeadersHeight = 65;
            this.databaseCon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.studentNo,
            this.date,
            this.timeOfCon,
            this.lab,
            this.diag,
            this.view,
            this.edit,
            this.delete});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.databaseCon.DefaultCellStyle = dataGridViewCellStyle6;
            this.databaseCon.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.databaseCon.Location = new System.Drawing.Point(96, 184);
            this.databaseCon.Name = "databaseCon";
            this.databaseCon.RowHeadersVisible = false;
            this.databaseCon.RowHeadersWidth = 51;
            this.databaseCon.Size = new System.Drawing.Size(968, 419);
            this.databaseCon.TabIndex = 103;
            this.databaseCon.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.databaseCon.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.databaseCon.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.databaseCon.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.databaseCon.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.databaseCon.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.databaseCon.ThemeStyle.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.databaseCon.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.databaseCon.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.databaseCon.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.databaseCon.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.databaseCon.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.databaseCon.ThemeStyle.HeaderStyle.Height = 65;
            this.databaseCon.ThemeStyle.ReadOnly = false;
            this.databaseCon.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.databaseCon.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.databaseCon.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.databaseCon.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.databaseCon.ThemeStyle.RowsStyle.Height = 22;
            this.databaseCon.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.databaseCon.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // studentNo
            // 
            this.studentNo.HeaderText = "STUDENT / EMPLOYEE NO.";
            this.studentNo.MinimumWidth = 6;
            this.studentNo.Name = "studentNo";
            this.studentNo.ReadOnly = true;
            this.studentNo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // date
            // 
            this.date.FillWeight = 89.54315F;
            this.date.HeaderText = "DATE";
            this.date.MinimumWidth = 6;
            this.date.Name = "date";
            this.date.ReadOnly = true;
            this.date.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // timeOfCon
            // 
            this.timeOfCon.HeaderText = "CONSULTATION TIME";
            this.timeOfCon.MinimumWidth = 6;
            this.timeOfCon.Name = "timeOfCon";
            // 
            // lab
            // 
            this.lab.FillWeight = 89.54315F;
            this.lab.HeaderText = "LABORATORY FINDINGS";
            this.lab.MinimumWidth = 6;
            this.lab.Name = "lab";
            this.lab.ReadOnly = true;
            this.lab.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // diag
            // 
            this.diag.FillWeight = 89.54315F;
            this.diag.HeaderText = "DIAGNOSIS AND MANAGEMENT";
            this.diag.MinimumWidth = 6;
            this.diag.Name = "diag";
            this.diag.ReadOnly = true;
            this.diag.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // view
            // 
            this.view.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.view.HeaderText = "VIEW";
            this.view.MinimumWidth = 6;
            this.view.Name = "view";
            this.view.ReadOnly = true;
            this.view.Width = 66;
            // 
            // edit
            // 
            this.edit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.edit.FillWeight = 152.2843F;
            this.edit.HeaderText = "EDIT";
            this.edit.MinimumWidth = 6;
            this.edit.Name = "edit";
            this.edit.ReadOnly = true;
            this.edit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.edit.Width = 60;
            // 
            // delete
            // 
            this.delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.delete.FillWeight = 89.54315F;
            this.delete.HeaderText = "DELETE";
            this.delete.MinimumWidth = 6;
            this.delete.Name = "delete";
            this.delete.ReadOnly = true;
            this.delete.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.delete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.delete.Width = 109;
            // 
            // FilterSearch
            // 
            this.FilterSearch.BorderThickness = 0;
            this.FilterSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.FilterSearch.DefaultText = "";
            this.FilterSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.FilterSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.FilterSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.FilterSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.FilterSearch.FillColor = System.Drawing.Color.Gainsboro;
            this.FilterSearch.FocusedState.BorderColor = System.Drawing.Color.Transparent;
            this.FilterSearch.FocusedState.FillColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FilterSearch.FocusedState.ForeColor = System.Drawing.Color.Black;
            this.FilterSearch.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilterSearch.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FilterSearch.HoverState.BorderColor = System.Drawing.Color.Transparent;
            this.FilterSearch.HoverState.FillColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FilterSearch.HoverState.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.FilterSearch.Location = new System.Drawing.Point(782, 133);
            this.FilterSearch.Margin = new System.Windows.Forms.Padding(2);
            this.FilterSearch.Name = "FilterSearch";
            this.FilterSearch.PasswordChar = '\0';
            this.FilterSearch.PlaceholderForeColor = System.Drawing.SystemColors.WindowFrame;
            this.FilterSearch.PlaceholderText = "Filter Search";
            this.FilterSearch.SelectedText = "";
            this.FilterSearch.Size = new System.Drawing.Size(225, 35);
            this.FilterSearch.TabIndex = 53;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(10)))), ((int)(((byte)(27)))));
            this.label5.Location = new System.Drawing.Point(89, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 28);
            this.label5.TabIndex = 9;
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.Controls.Add(this.guna2Panel5);
            this.guna2Panel3.Controls.Add(this.guna2Panel6);
            this.guna2Panel3.Controls.Add(this.label15);
            this.guna2Panel3.Controls.Add(this.label16);
            this.guna2Panel3.Controls.Add(this.label17);
            this.guna2Panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel3.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(1163, 121);
            this.guna2Panel3.TabIndex = 9;
            // 
            // guna2Panel5
            // 
            this.guna2Panel5.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("guna2Panel5.BackgroundImage")));
            this.guna2Panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.guna2Panel5.Location = new System.Drawing.Point(893, 17);
            this.guna2Panel5.Name = "guna2Panel5";
            this.guna2Panel5.Size = new System.Drawing.Size(126, 101);
            this.guna2Panel5.TabIndex = 5;
            // 
            // guna2Panel6
            // 
            this.guna2Panel6.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("guna2Panel6.BackgroundImage")));
            this.guna2Panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.guna2Panel6.Location = new System.Drawing.Point(143, 17);
            this.guna2Panel6.Name = "guna2Panel6";
            this.guna2Panel6.Size = new System.Drawing.Size(126, 101);
            this.guna2Panel6.TabIndex = 4;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(10)))), ((int)(((byte)(27)))));
            this.label15.Location = new System.Drawing.Point(436, 17);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(338, 28);
            this.label15.TabIndex = 6;
            this.label15.Text = "University of the Philippines Baguio";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(10)))), ((int)(((byte)(27)))));
            this.label16.Location = new System.Drawing.Point(438, 38);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(327, 37);
            this.label16.TabIndex = 7;
            this.label16.Text = "HEALTH SERVICE OFFICE";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(10)))), ((int)(((byte)(27)))));
            this.label17.Location = new System.Drawing.Point(374, 68);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(469, 50);
            this.label17.TabIndex = 8;
            this.label17.Text = "RECENT CONSULTATIONS";
            this.label17.Click += new System.EventHandler(this.label17_Click);
            // 
            // guna2Panel7
            // 
            this.guna2Panel7.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("guna2Panel7.BackgroundImage")));
            this.guna2Panel7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.guna2Panel7.Location = new System.Drawing.Point(958, 32);
            this.guna2Panel7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guna2Panel7.Name = "guna2Panel7";
            this.guna2Panel7.Size = new System.Drawing.Size(77, 72);
            this.guna2Panel7.TabIndex = 8;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.OliveDrab;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(1217, 8);
            this.guna2ControlBox1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(31, 20);
            this.guna2ControlBox1.TabIndex = 13;
            // 
            // exitBtn
            // 
            this.exitBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exitBtn.FillColor = System.Drawing.Color.DarkRed;
            this.exitBtn.IconColor = System.Drawing.Color.White;
            this.exitBtn.Location = new System.Drawing.Point(1256, 8);
            this.exitBtn.Margin = new System.Windows.Forms.Padding(4);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(31, 20);
            this.exitBtn.TabIndex = 12;
            // 
            // ViewRecentConsultation
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1300, 720);
            this.Controls.Add(this.guna2ControlBox1);
            this.Controls.Add(this.guna2ShadowPanel1);
            this.Controls.Add(this.exitBtn);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ViewRecentConsultation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recent Consultations";
            this.guna2ShadowPanel1.ResumeLayout(false);
            this.guna2ShadowPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.databaseCon)).EndInit();
            this.guna2Panel3.ResumeLayout(false);
            this.guna2Panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private Guna.UI2.WinForms.Guna2TextBox FilterSearch;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel5;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel6;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel7;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2ControlBox exitBtn;
        private Guna.UI2.WinForms.Guna2DataGridView databaseCon;
        private Guna.UI2.WinForms.Guna2GradientButton backBtn;
        private Guna.UI2.WinForms.Guna2GradientButton refreshBtn;
        private Guna.UI2.WinForms.Guna2Button searchBtn;
        private Guna.UI2.WinForms.Guna2Button deletedRecords;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeOfCon;
        private System.Windows.Forms.DataGridViewTextBoxColumn lab;
        private System.Windows.Forms.DataGridViewTextBoxColumn diag;
        private System.Windows.Forms.DataGridViewButtonColumn view;
        private System.Windows.Forms.DataGridViewButtonColumn edit;
        private System.Windows.Forms.DataGridViewButtonColumn delete;
    }
}