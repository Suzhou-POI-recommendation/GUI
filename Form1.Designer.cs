namespace recommendation_system
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.Exit_Button = new System.Windows.Forms.Button();
            this.file_slide = new System.Windows.Forms.Panel();
            this.btnCategory13 = new System.Windows.Forms.Button();
            this.btnCategory15 = new System.Windows.Forms.Button();
            this.btnCategory12 = new System.Windows.Forms.Button();
            this.btnCategory10 = new System.Windows.Forms.Button();
            this.btnCategory5 = new System.Windows.Forms.Button();
            this.btnCategory7 = new System.Windows.Forms.Button();
            this.btnCategory16 = new System.Windows.Forms.Button();
            this.btnCategory14 = new System.Windows.Forms.Button();
            this.btnCategory9 = new System.Windows.Forms.Button();
            this.btnCategory11 = new System.Windows.Forms.Button();
            this.btnCategory8 = new System.Windows.Forms.Button();
            this.btnCategory6 = new System.Windows.Forms.Button();
            this.btnCategory4 = new System.Windows.Forms.Button();
            this.btnCategory1 = new System.Windows.Forms.Button();
            this.btnCategory3 = new System.Windows.Forms.Button();
            this.btnCategory2 = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.search_button = new System.Windows.Forms.Button();
            this.bunifuWebClient1 = new Bunifu.Framework.UI.BunifuWebClient(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.bunifuMaterialTextbox1 = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.map_webbrowser = new System.Windows.Forms.WebBrowser();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.btnReturn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnShowPicture = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.textBoxHint = new System.Windows.Forms.TextBox();
            this.panelResult = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.file_slide.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(96)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(170, 630);
            this.panel1.TabIndex = 5;
            this.panel1.MouseEnter += new System.EventHandler(this.file_slide_MouseLeave);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(151)))), ((int)(((byte)(201)))));
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 58);
            this.label1.TabIndex = 5;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            // 
            // panel6
            // 
            this.panel6.Location = new System.Drawing.Point(180, 2);
            this.panel6.Margin = new System.Windows.Forms.Padding(1);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(570, 56);
            this.panel6.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "MENU";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button7);
            this.panel2.Controls.Add(this.button6);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Location = new System.Drawing.Point(0, 130);
            this.panel2.Margin = new System.Windows.Forms.Padding(1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(181, 199);
            this.panel2.TabIndex = 6;
            // 
            // button7
            // 
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(68)))), ((int)(((byte)(117)))));
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button7.Image = ((System.Drawing.Image)(resources.GetObject("button7.Image")));
            this.button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button7.Location = new System.Drawing.Point(6, 150);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(175, 50);
            this.button7.TabIndex = 10;
            this.button7.Text = "        猜你喜欢";
            this.button7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            this.button7.MouseEnter += new System.EventHandler(this.button7_MouseEnter);
            // 
            // button6
            // 
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(68)))), ((int)(((byte)(117)))));
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button6.Image = ((System.Drawing.Image)(resources.GetObject("button6.Image")));
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.Location = new System.Drawing.Point(3, 100);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(175, 50);
            this.button6.TabIndex = 9;
            this.button6.Text = "        实时定位";
            this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            this.button6.MouseEnter += new System.EventHandler(this.button6_MouseEnter);
            // 
            // button5
            // 
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(68)))), ((int)(((byte)(117)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.Location = new System.Drawing.Point(6, 50);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(175, 50);
            this.button5.TabIndex = 8;
            this.button5.Text = "        周边POI检索";
            this.button5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            this.button5.MouseEnter += new System.EventHandler(this.button5_MouseEnter);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(151)))), ((int)(((byte)(201)))));
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(6, 50);
            this.panel5.TabIndex = 7;
            // 
            // button4
            // 
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(68)))), ((int)(((byte)(117)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(6, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(175, 50);
            this.button4.TabIndex = 0;
            this.button4.Text = "        分类推荐";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            this.button4.MouseEnter += new System.EventHandler(this.File_Button_MouseEnter);
            // 
            // Exit_Button
            // 
            this.Exit_Button.BackColor = System.Drawing.Color.Transparent;
            this.Exit_Button.Cursor = System.Windows.Forms.Cursors.Default;
            this.Exit_Button.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Exit_Button.FlatAppearance.BorderSize = 0;
            this.Exit_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(188)))), ((int)(((byte)(169)))));
            this.Exit_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exit_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exit_Button.ForeColor = System.Drawing.Color.Black;
            this.Exit_Button.Image = ((System.Drawing.Image)(resources.GetObject("Exit_Button.Image")));
            this.Exit_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Exit_Button.Location = new System.Drawing.Point(680, 9);
            this.Exit_Button.Margin = new System.Windows.Forms.Padding(1);
            this.Exit_Button.Name = "Exit_Button";
            this.Exit_Button.Size = new System.Drawing.Size(67, 40);
            this.Exit_Button.TabIndex = 6;
            this.Exit_Button.Text = "Exit";
            this.Exit_Button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Exit_Button.UseVisualStyleBackColor = false;
            this.Exit_Button.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Exit_Button_MouseClick);
            // 
            // file_slide
            // 
            this.file_slide.BackColor = System.Drawing.Color.Transparent;
            this.file_slide.Controls.Add(this.btnCategory13);
            this.file_slide.Controls.Add(this.btnCategory15);
            this.file_slide.Controls.Add(this.btnCategory12);
            this.file_slide.Controls.Add(this.btnCategory10);
            this.file_slide.Controls.Add(this.btnCategory5);
            this.file_slide.Controls.Add(this.btnCategory7);
            this.file_slide.Controls.Add(this.btnCategory16);
            this.file_slide.Controls.Add(this.btnCategory14);
            this.file_slide.Controls.Add(this.btnCategory9);
            this.file_slide.Controls.Add(this.btnCategory11);
            this.file_slide.Controls.Add(this.btnCategory8);
            this.file_slide.Controls.Add(this.btnCategory6);
            this.file_slide.Controls.Add(this.btnCategory4);
            this.file_slide.Controls.Add(this.btnCategory1);
            this.file_slide.Controls.Add(this.btnCategory3);
            this.file_slide.Controls.Add(this.btnCategory2);
            this.file_slide.Location = new System.Drawing.Point(170, 130);
            this.file_slide.Name = "file_slide";
            this.file_slide.Size = new System.Drawing.Size(320, 200);
            this.file_slide.TabIndex = 7;
            this.file_slide.Visible = false;
            this.file_slide.MouseLeave += new System.EventHandler(this.file_slide_MouseLeave);
            // 
            // btnCategory13
            // 
            this.btnCategory13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(197)))), ((int)(((byte)(228)))));
            this.btnCategory13.FlatAppearance.BorderSize = 0;
            this.btnCategory13.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(68)))), ((int)(((byte)(117)))));
            this.btnCategory13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategory13.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCategory13.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCategory13.Location = new System.Drawing.Point(240, 0);
            this.btnCategory13.Name = "btnCategory13";
            this.btnCategory13.Size = new System.Drawing.Size(80, 50);
            this.btnCategory13.TabIndex = 15;
            this.btnCategory13.Text = "酒吧";
            this.btnCategory13.UseVisualStyleBackColor = false;
            this.btnCategory13.Click += new System.EventHandler(this.btnCategory13_Click);
            // 
            // btnCategory15
            // 
            this.btnCategory15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(197)))), ((int)(((byte)(228)))));
            this.btnCategory15.FlatAppearance.BorderSize = 0;
            this.btnCategory15.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(68)))), ((int)(((byte)(117)))));
            this.btnCategory15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategory15.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCategory15.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCategory15.Location = new System.Drawing.Point(240, 100);
            this.btnCategory15.Name = "btnCategory15";
            this.btnCategory15.Size = new System.Drawing.Size(80, 50);
            this.btnCategory15.TabIndex = 14;
            this.btnCategory15.Text = "企业单位";
            this.btnCategory15.UseVisualStyleBackColor = false;
            this.btnCategory15.Click += new System.EventHandler(this.btnCategory15_Click);
            // 
            // btnCategory12
            // 
            this.btnCategory12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(197)))), ((int)(((byte)(228)))));
            this.btnCategory12.FlatAppearance.BorderSize = 0;
            this.btnCategory12.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(68)))), ((int)(((byte)(117)))));
            this.btnCategory12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategory12.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCategory12.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCategory12.Location = new System.Drawing.Point(160, 150);
            this.btnCategory12.Name = "btnCategory12";
            this.btnCategory12.Size = new System.Drawing.Size(80, 50);
            this.btnCategory12.TabIndex = 13;
            this.btnCategory12.Text = "医疗健康";
            this.btnCategory12.UseVisualStyleBackColor = false;
            this.btnCategory12.Click += new System.EventHandler(this.btnCategory12_Click);
            // 
            // btnCategory10
            // 
            this.btnCategory10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(197)))), ((int)(((byte)(228)))));
            this.btnCategory10.FlatAppearance.BorderSize = 0;
            this.btnCategory10.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(68)))), ((int)(((byte)(117)))));
            this.btnCategory10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategory10.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCategory10.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCategory10.Location = new System.Drawing.Point(160, 50);
            this.btnCategory10.Name = "btnCategory10";
            this.btnCategory10.Size = new System.Drawing.Size(80, 50);
            this.btnCategory10.TabIndex = 12;
            this.btnCategory10.Text = "家装";
            this.btnCategory10.UseVisualStyleBackColor = false;
            this.btnCategory10.Click += new System.EventHandler(this.btnCategory10_Click);
            // 
            // btnCategory5
            // 
            this.btnCategory5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(197)))), ((int)(((byte)(228)))));
            this.btnCategory5.FlatAppearance.BorderSize = 0;
            this.btnCategory5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(68)))), ((int)(((byte)(117)))));
            this.btnCategory5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategory5.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCategory5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCategory5.Location = new System.Drawing.Point(80, 0);
            this.btnCategory5.Name = "btnCategory5";
            this.btnCategory5.Size = new System.Drawing.Size(80, 50);
            this.btnCategory5.TabIndex = 11;
            this.btnCategory5.Text = "生活服务";
            this.btnCategory5.UseVisualStyleBackColor = false;
            this.btnCategory5.Click += new System.EventHandler(this.btnCategory5_Click);
            // 
            // btnCategory7
            // 
            this.btnCategory7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(197)))), ((int)(((byte)(228)))));
            this.btnCategory7.FlatAppearance.BorderSize = 0;
            this.btnCategory7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(68)))), ((int)(((byte)(117)))));
            this.btnCategory7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategory7.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCategory7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCategory7.Location = new System.Drawing.Point(80, 100);
            this.btnCategory7.Name = "btnCategory7";
            this.btnCategory7.Size = new System.Drawing.Size(80, 50);
            this.btnCategory7.TabIndex = 10;
            this.btnCategory7.Text = "购物";
            this.btnCategory7.UseVisualStyleBackColor = false;
            this.btnCategory7.Click += new System.EventHandler(this.btnCategory7_Click);
            // 
            // btnCategory16
            // 
            this.btnCategory16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(151)))), ((int)(((byte)(201)))));
            this.btnCategory16.FlatAppearance.BorderSize = 0;
            this.btnCategory16.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(68)))), ((int)(((byte)(117)))));
            this.btnCategory16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategory16.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCategory16.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCategory16.Location = new System.Drawing.Point(240, 150);
            this.btnCategory16.Name = "btnCategory16";
            this.btnCategory16.Size = new System.Drawing.Size(80, 50);
            this.btnCategory16.TabIndex = 9;
            this.btnCategory16.Text = "政府机构";
            this.btnCategory16.UseVisualStyleBackColor = false;
            this.btnCategory16.Click += new System.EventHandler(this.btnCategory16_Click);
            // 
            // btnCategory14
            // 
            this.btnCategory14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(151)))), ((int)(((byte)(201)))));
            this.btnCategory14.FlatAppearance.BorderSize = 0;
            this.btnCategory14.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(68)))), ((int)(((byte)(117)))));
            this.btnCategory14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategory14.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCategory14.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCategory14.Location = new System.Drawing.Point(240, 50);
            this.btnCategory14.Name = "btnCategory14";
            this.btnCategory14.Size = new System.Drawing.Size(80, 50);
            this.btnCategory14.TabIndex = 8;
            this.btnCategory14.Text = "学校";
            this.btnCategory14.UseVisualStyleBackColor = false;
            this.btnCategory14.Click += new System.EventHandler(this.btnCategory14_Click);
            // 
            // btnCategory9
            // 
            this.btnCategory9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(151)))), ((int)(((byte)(201)))));
            this.btnCategory9.FlatAppearance.BorderSize = 0;
            this.btnCategory9.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(68)))), ((int)(((byte)(117)))));
            this.btnCategory9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategory9.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCategory9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCategory9.Location = new System.Drawing.Point(160, 0);
            this.btnCategory9.Name = "btnCategory9";
            this.btnCategory9.Size = new System.Drawing.Size(80, 50);
            this.btnCategory9.TabIndex = 7;
            this.btnCategory9.Text = "运动健身";
            this.btnCategory9.UseVisualStyleBackColor = false;
            this.btnCategory9.Click += new System.EventHandler(this.btnCategory9_Click);
            // 
            // btnCategory11
            // 
            this.btnCategory11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(151)))), ((int)(((byte)(201)))));
            this.btnCategory11.FlatAppearance.BorderSize = 0;
            this.btnCategory11.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(68)))), ((int)(((byte)(117)))));
            this.btnCategory11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategory11.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCategory11.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCategory11.Location = new System.Drawing.Point(160, 100);
            this.btnCategory11.Name = "btnCategory11";
            this.btnCategory11.Size = new System.Drawing.Size(80, 50);
            this.btnCategory11.TabIndex = 6;
            this.btnCategory11.Text = "学习培训";
            this.btnCategory11.UseVisualStyleBackColor = false;
            this.btnCategory11.Click += new System.EventHandler(this.btnCategory11_Click);
            // 
            // btnCategory8
            // 
            this.btnCategory8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(151)))), ((int)(((byte)(201)))));
            this.btnCategory8.FlatAppearance.BorderSize = 0;
            this.btnCategory8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(68)))), ((int)(((byte)(117)))));
            this.btnCategory8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategory8.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCategory8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCategory8.Location = new System.Drawing.Point(80, 150);
            this.btnCategory8.Name = "btnCategory8";
            this.btnCategory8.Size = new System.Drawing.Size(80, 50);
            this.btnCategory8.TabIndex = 5;
            this.btnCategory8.Text = "亲子";
            this.btnCategory8.UseVisualStyleBackColor = false;
            this.btnCategory8.Click += new System.EventHandler(this.btnCategory8_Click);
            // 
            // btnCategory6
            // 
            this.btnCategory6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(151)))), ((int)(((byte)(201)))));
            this.btnCategory6.FlatAppearance.BorderSize = 0;
            this.btnCategory6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(68)))), ((int)(((byte)(117)))));
            this.btnCategory6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategory6.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCategory6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCategory6.Location = new System.Drawing.Point(80, 50);
            this.btnCategory6.Name = "btnCategory6";
            this.btnCategory6.Size = new System.Drawing.Size(80, 50);
            this.btnCategory6.TabIndex = 4;
            this.btnCategory6.Text = "丽人";
            this.btnCategory6.UseVisualStyleBackColor = false;
            this.btnCategory6.Click += new System.EventHandler(this.btnCategory6_Click);
            // 
            // btnCategory4
            // 
            this.btnCategory4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(197)))), ((int)(((byte)(228)))));
            this.btnCategory4.FlatAppearance.BorderSize = 0;
            this.btnCategory4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(68)))), ((int)(((byte)(117)))));
            this.btnCategory4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategory4.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCategory4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCategory4.Location = new System.Drawing.Point(0, 150);
            this.btnCategory4.Name = "btnCategory4";
            this.btnCategory4.Size = new System.Drawing.Size(80, 50);
            this.btnCategory4.TabIndex = 3;
            this.btnCategory4.Text = "休闲娱乐";
            this.btnCategory4.UseVisualStyleBackColor = false;
            this.btnCategory4.Click += new System.EventHandler(this.btnCategory4_Click);
            // 
            // btnCategory1
            // 
            this.btnCategory1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(151)))), ((int)(((byte)(201)))));
            this.btnCategory1.FlatAppearance.BorderSize = 0;
            this.btnCategory1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(68)))), ((int)(((byte)(117)))));
            this.btnCategory1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategory1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCategory1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCategory1.Location = new System.Drawing.Point(0, 0);
            this.btnCategory1.Name = "btnCategory1";
            this.btnCategory1.Size = new System.Drawing.Size(80, 50);
            this.btnCategory1.TabIndex = 0;
            this.btnCategory1.Text = "美食";
            this.btnCategory1.UseVisualStyleBackColor = false;
            this.btnCategory1.Click += new System.EventHandler(this.btnCategory1_Click);
            // 
            // btnCategory3
            // 
            this.btnCategory3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(151)))), ((int)(((byte)(201)))));
            this.btnCategory3.FlatAppearance.BorderSize = 0;
            this.btnCategory3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(68)))), ((int)(((byte)(117)))));
            this.btnCategory3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategory3.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCategory3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCategory3.Location = new System.Drawing.Point(0, 100);
            this.btnCategory3.Name = "btnCategory3";
            this.btnCategory3.Size = new System.Drawing.Size(80, 50);
            this.btnCategory3.TabIndex = 2;
            this.btnCategory3.Text = "交通";
            this.btnCategory3.UseVisualStyleBackColor = false;
            this.btnCategory3.Click += new System.EventHandler(this.btnCategory3_Click);
            // 
            // btnCategory2
            // 
            this.btnCategory2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(197)))), ((int)(((byte)(228)))));
            this.btnCategory2.FlatAppearance.BorderSize = 0;
            this.btnCategory2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(68)))), ((int)(((byte)(117)))));
            this.btnCategory2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategory2.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCategory2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCategory2.Location = new System.Drawing.Point(0, 50);
            this.btnCategory2.Name = "btnCategory2";
            this.btnCategory2.Size = new System.Drawing.Size(80, 50);
            this.btnCategory2.TabIndex = 1;
            this.btnCategory2.Text = "酒店";
            this.btnCategory2.UseVisualStyleBackColor = false;
            this.btnCategory2.Click += new System.EventHandler(this.btnCategory2_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.panel7.Controls.Add(this.Exit_Button);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(170, 0);
            this.panel7.Margin = new System.Windows.Forms.Padding(1);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(749, 58);
            this.panel7.TabIndex = 8;
            this.panel7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // search_button
            // 
            this.search_button.BackColor = System.Drawing.Color.Transparent;
            this.search_button.Cursor = System.Windows.Forms.Cursors.Default;
            this.search_button.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.search_button.FlatAppearance.BorderSize = 0;
            this.search_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(188)))), ((int)(((byte)(169)))));
            this.search_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(188)))), ((int)(((byte)(169)))));
            this.search_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.search_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_button.ForeColor = System.Drawing.Color.Black;
            this.search_button.Image = ((System.Drawing.Image)(resources.GetObject("search_button.Image")));
            this.search_button.Location = new System.Drawing.Point(630, 70);
            this.search_button.Margin = new System.Windows.Forms.Padding(1);
            this.search_button.Name = "search_button";
            this.search_button.Size = new System.Drawing.Size(31, 30);
            this.search_button.TabIndex = 13;
            this.search_button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.search_button.UseVisualStyleBackColor = false;
            this.search_button.Click += new System.EventHandler(this.search_button_Click);
            // 
            // bunifuWebClient1
            // 
            this.bunifuWebClient1.AllowReadStreamBuffering = false;
            this.bunifuWebClient1.AllowWriteStreamBuffering = false;
            this.bunifuWebClient1.BaseAddress = "";
            this.bunifuWebClient1.CachePolicy = null;
            this.bunifuWebClient1.Credentials = null;
            this.bunifuWebClient1.Encoding = ((System.Text.Encoding)(resources.GetObject("bunifuWebClient1.Encoding")));
            this.bunifuWebClient1.Headers = ((System.Net.WebHeaderCollection)(resources.GetObject("bunifuWebClient1.Headers")));
            this.bunifuWebClient1.QueryString = ((System.Collections.Specialized.NameValueCollection)(resources.GetObject("bunifuWebClient1.QueryString")));
            this.bunifuWebClient1.UseDefaultCredentials = false;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // bunifuMaterialTextbox1
            // 
            this.bunifuMaterialTextbox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.bunifuMaterialTextbox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuMaterialTextbox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bunifuMaterialTextbox1.HintForeColor = System.Drawing.Color.Empty;
            this.bunifuMaterialTextbox1.HintText = "";
            this.bunifuMaterialTextbox1.isPassword = false;
            this.bunifuMaterialTextbox1.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bunifuMaterialTextbox1.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bunifuMaterialTextbox1.LineMouseHoverColor = System.Drawing.Color.LightSlateGray;
            this.bunifuMaterialTextbox1.LineThickness = 2;
            this.bunifuMaterialTextbox1.Location = new System.Drawing.Point(404, 70);
            this.bunifuMaterialTextbox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bunifuMaterialTextbox1.Name = "bunifuMaterialTextbox1";
            this.bunifuMaterialTextbox1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.bunifuMaterialTextbox1.Size = new System.Drawing.Size(257, 34);
            this.bunifuMaterialTextbox1.TabIndex = 16;
            this.bunifuMaterialTextbox1.Text = "请输入搜索关键词";
            this.bunifuMaterialTextbox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // map_webbrowser
            // 
            this.map_webbrowser.Location = new System.Drawing.Point(192, 112);
            this.map_webbrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.map_webbrowser.Name = "map_webbrowser";
            this.map_webbrowser.ScrollBarsEnabled = false;
            this.map_webbrowser.Size = new System.Drawing.Size(708, 489);
            this.map_webbrowser.TabIndex = 14;
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(93)))), ((int)(((byte)(209)))));
            this.treeView1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView1.ForeColor = System.Drawing.SystemColors.Window;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Margin = new System.Windows.Forms.Padding(2);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.ShowLines = false;
            this.treeView1.Size = new System.Drawing.Size(432, 493);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(197)))), ((int)(((byte)(228)))));
            this.btnReturn.FlatAppearance.BorderSize = 0;
            this.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReturn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReturn.ForeColor = System.Drawing.Color.White;
            this.btnReturn.Image = ((System.Drawing.Image)(resources.GetObject("btnReturn.Image")));
            this.btnReturn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReturn.Location = new System.Drawing.Point(589, 7);
            this.btnReturn.Margin = new System.Windows.Forms.Padding(2);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(100, 50);
            this.btnReturn.TabIndex = 1;
            this.btnReturn.Text = "返回上级";
            this.btnReturn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(241)))), ((int)(((byte)(246)))));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(439, 220);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(274, 267);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(544, 183);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "图片栏";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnShowPicture
            // 
            this.btnShowPicture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(197)))), ((int)(((byte)(228)))));
            this.btnShowPicture.Enabled = false;
            this.btnShowPicture.FlatAppearance.BorderSize = 0;
            this.btnShowPicture.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnShowPicture.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnShowPicture.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnShowPicture.Location = new System.Drawing.Point(449, 7);
            this.btnShowPicture.Margin = new System.Windows.Forms.Padding(2);
            this.btnShowPicture.Name = "btnShowPicture";
            this.btnShowPicture.Size = new System.Drawing.Size(100, 50);
            this.btnShowPicture.TabIndex = 4;
            this.btnShowPicture.Text = "显示图片";
            this.btnShowPicture.UseVisualStyleBackColor = false;
            this.btnShowPicture.Click += new System.EventHandler(this.btnShowPicture_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(434, 122);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(274, 19);
            this.progressBar1.TabIndex = 5;
            this.progressBar1.Visible = false;
            // 
            // textBoxHint
            // 
            this.textBoxHint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(241)))), ((int)(((byte)(246)))));
            this.textBoxHint.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxHint.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxHint.Location = new System.Drawing.Point(436, 102);
            this.textBoxHint.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxHint.Name = "textBoxHint";
            this.textBoxHint.Size = new System.Drawing.Size(272, 19);
            this.textBoxHint.TabIndex = 7;
            this.textBoxHint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panelResult
            // 
            this.panelResult.Controls.Add(this.textBoxHint);
            this.panelResult.Controls.Add(this.progressBar1);
            this.panelResult.Controls.Add(this.btnShowPicture);
            this.panelResult.Controls.Add(this.label2);
            this.panelResult.Controls.Add(this.pictureBox1);
            this.panelResult.Controls.Add(this.btnReturn);
            this.panelResult.Controls.Add(this.treeView1);
            this.panelResult.Location = new System.Drawing.Point(192, 112);
            this.panelResult.Margin = new System.Windows.Forms.Padding(2);
            this.panelResult.Name = "panelResult";
            this.panelResult.Size = new System.Drawing.Size(720, 497);
            this.panelResult.TabIndex = 15;
            this.panelResult.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(241)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(919, 630);
            this.Controls.Add(this.file_slide);
            this.Controls.Add(this.panelResult);
            this.Controls.Add(this.search_button);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.map_webbrowser);
            this.Controls.Add(this.bunifuMaterialTextbox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseEnter += new System.EventHandler(this.file_slide_MouseLeave);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.file_slide.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelResult.ResumeLayout(false);
            this.panelResult.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Exit_Button;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel file_slide;
        private System.Windows.Forms.Button btnCategory3;
        private System.Windows.Forms.Button btnCategory2;
        private System.Windows.Forms.Button btnCategory1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCategory4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button search_button;
        private Bunifu.Framework.UI.BunifuWebClient bunifuWebClient1;
        private System.Windows.Forms.Button btnCategory13;
        private System.Windows.Forms.Button btnCategory15;
        private System.Windows.Forms.Button btnCategory12;
        private System.Windows.Forms.Button btnCategory10;
        private System.Windows.Forms.Button btnCategory5;
        private System.Windows.Forms.Button btnCategory7;
        private System.Windows.Forms.Button btnCategory16;
        private System.Windows.Forms.Button btnCategory14;
        private System.Windows.Forms.Button btnCategory9;
        private System.Windows.Forms.Button btnCategory11;
        private System.Windows.Forms.Button btnCategory8;
        private System.Windows.Forms.Button btnCategory6;
        private System.Windows.Forms.ImageList imageList1;
        private Bunifu.Framework.UI.BunifuMaterialTextbox bunifuMaterialTextbox1;
        private System.Windows.Forms.WebBrowser map_webbrowser;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnShowPicture;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox textBoxHint;
        private System.Windows.Forms.Panel panelResult;
    }
}

