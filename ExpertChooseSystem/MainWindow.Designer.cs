namespace ExpertChooseSystem
{
    partial class MainWindow
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.dcsSetBtn = new System.Windows.Forms.Button();
            this.testBtn = new System.Windows.Forms.Button();
            this.getDcsBtn1 = new System.Windows.Forms.Button();
            this.getDcsBtn2 = new System.Windows.Forms.Button();
            this.judgeMatrixSwitchBtn = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.contentTable = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.levelInfoBtn1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.levelInfoBtn2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.judgeBtnZ = new System.Windows.Forms.Button();
            this.judgeBtnA2 = new System.Windows.Forms.Button();
            this.judgeBtnA4 = new System.Windows.Forms.Button();
            this.judgeBtnA3 = new System.Windows.Forms.Button();
            this.judgeBtnA1 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labelA4 = new System.Windows.Forms.Label();
            this.labelA3 = new System.Windows.Forms.Label();
            this.labelA2 = new System.Windows.Forms.Label();
            this.labelA1 = new System.Windows.Forms.Label();
            this.labelZ = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.contentTable.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanel1.Controls.Add(this.dcsSetBtn);
            this.flowLayoutPanel1.Controls.Add(this.testBtn);
            this.flowLayoutPanel1.Controls.Add(this.getDcsBtn1);
            this.flowLayoutPanel1.Controls.Add(this.getDcsBtn2);
            this.flowLayoutPanel1.Controls.Add(this.judgeMatrixSwitchBtn);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(4, 358);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(577, 33);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // dcsSetBtn
            // 
            this.dcsSetBtn.Location = new System.Drawing.Point(3, 3);
            this.dcsSetBtn.Name = "dcsSetBtn";
            this.dcsSetBtn.Size = new System.Drawing.Size(89, 28);
            this.dcsSetBtn.TabIndex = 0;
            this.dcsSetBtn.Text = "设置决策矩阵";
            this.dcsSetBtn.UseVisualStyleBackColor = true;
            this.dcsSetBtn.Click += new System.EventHandler(this.dcsSetBtn_Click);
            // 
            // testBtn
            // 
            this.testBtn.Location = new System.Drawing.Point(98, 3);
            this.testBtn.Name = "testBtn";
            this.testBtn.Size = new System.Drawing.Size(102, 28);
            this.testBtn.TabIndex = 1;
            this.testBtn.Text = "显示测试信息";
            this.testBtn.UseVisualStyleBackColor = true;
            this.testBtn.Visible = false;
            this.testBtn.Click += new System.EventHandler(this.testBtn_Click);
            // 
            // getDcsBtn1
            // 
            this.getDcsBtn1.Location = new System.Drawing.Point(206, 3);
            this.getDcsBtn1.Name = "getDcsBtn1";
            this.getDcsBtn1.Size = new System.Drawing.Size(100, 30);
            this.getDcsBtn1.TabIndex = 2;
            this.getDcsBtn1.Text = "获得决策值#1";
            this.getDcsBtn1.UseVisualStyleBackColor = true;
            this.getDcsBtn1.Click += new System.EventHandler(this.GetDcsBtnClick);
            // 
            // getDcsBtn2
            // 
            this.getDcsBtn2.Location = new System.Drawing.Point(312, 3);
            this.getDcsBtn2.Name = "getDcsBtn2";
            this.getDcsBtn2.Size = new System.Drawing.Size(87, 30);
            this.getDcsBtn2.TabIndex = 3;
            this.getDcsBtn2.Text = "获得决策值#2";
            this.getDcsBtn2.UseVisualStyleBackColor = true;
            this.getDcsBtn2.Click += new System.EventHandler(this.GetDcsBtnClick);
            // 
            // judgeMatrixSwitchBtn
            // 
            this.judgeMatrixSwitchBtn.Location = new System.Drawing.Point(405, 3);
            this.judgeMatrixSwitchBtn.Name = "judgeMatrixSwitchBtn";
            this.judgeMatrixSwitchBtn.Size = new System.Drawing.Size(75, 28);
            this.judgeMatrixSwitchBtn.TabIndex = 4;
            this.judgeMatrixSwitchBtn.Text = "button1";
            this.judgeMatrixSwitchBtn.UseVisualStyleBackColor = true;
            this.judgeMatrixSwitchBtn.Click += new System.EventHandler(this.judgeMatrixSwitchBtn_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(206, 11);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(173, 12);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "基于层次分析法的专家选择算法";
            // 
            // contentTable
            // 
            this.contentTable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.contentTable.ColumnCount = 1;
            this.contentTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.contentTable.Controls.Add(this.labelTitle, 0, 0);
            this.contentTable.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.contentTable.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.contentTable.Location = new System.Drawing.Point(12, 12);
            this.contentTable.Name = "contentTable";
            this.contentTable.RowCount = 3;
            this.contentTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.contentTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.19668F));
            this.contentTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.80332F));
            this.contentTable.Size = new System.Drawing.Size(585, 395);
            this.contentTable.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.49306F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.50694F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 37);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(577, 314);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(88, 92);
            this.panel2.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "第一层";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.levelInfoBtn1);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(4, 107);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(88, 92);
            this.panel3.TabIndex = 5;
            // 
            // levelInfoBtn1
            // 
            this.levelInfoBtn1.Location = new System.Drawing.Point(4, 27);
            this.levelInfoBtn1.Name = "levelInfoBtn1";
            this.levelInfoBtn1.Size = new System.Drawing.Size(75, 23);
            this.levelInfoBtn1.TabIndex = 1;
            this.levelInfoBtn1.Text = "层次信息";
            this.levelInfoBtn1.UseVisualStyleBackColor = true;
            this.levelInfoBtn1.Click += new System.EventHandler(this.LevelInfoButtonClick);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "第二层";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.levelInfoBtn2);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Location = new System.Drawing.Point(4, 210);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(79, 99);
            this.panel4.TabIndex = 6;
            // 
            // levelInfoBtn2
            // 
            this.levelInfoBtn2.Location = new System.Drawing.Point(4, 25);
            this.levelInfoBtn2.Name = "levelInfoBtn2";
            this.levelInfoBtn2.Size = new System.Drawing.Size(75, 23);
            this.levelInfoBtn2.TabIndex = 1;
            this.levelInfoBtn2.Text = "层次信息";
            this.levelInfoBtn2.UseVisualStyleBackColor = true;
            this.levelInfoBtn2.Click += new System.EventHandler(this.LevelInfoButtonClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "第三层";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.judgeBtnZ);
            this.panel1.Controls.Add(this.judgeBtnA2);
            this.panel1.Controls.Add(this.judgeBtnA4);
            this.panel1.Controls.Add(this.judgeBtnA3);
            this.panel1.Controls.Add(this.judgeBtnA1);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.labelA4);
            this.panel1.Controls.Add(this.labelA3);
            this.panel1.Controls.Add(this.labelA2);
            this.panel1.Controls.Add(this.labelA1);
            this.panel1.Controls.Add(this.labelZ);
            this.panel1.Location = new System.Drawing.Point(99, 4);
            this.panel1.Name = "panel1";
            this.tableLayoutPanel1.SetRowSpan(this.panel1, 3);
            this.panel1.Size = new System.Drawing.Size(474, 305);
            this.panel1.TabIndex = 7;
            // 
            // judgeBtnZ
            // 
            this.judgeBtnZ.Location = new System.Drawing.Point(198, 39);
            this.judgeBtnZ.Name = "judgeBtnZ";
            this.judgeBtnZ.Size = new System.Drawing.Size(92, 23);
            this.judgeBtnZ.TabIndex = 30;
            this.judgeBtnZ.Text = "判断矩阵设置";
            this.judgeBtnZ.UseVisualStyleBackColor = true;
            this.judgeBtnZ.Click += new System.EventHandler(this.JudgeMatrixButtonClick);
            // 
            // judgeBtnA2
            // 
            this.judgeBtnA2.Location = new System.Drawing.Point(124, 141);
            this.judgeBtnA2.Name = "judgeBtnA2";
            this.judgeBtnA2.Size = new System.Drawing.Size(92, 23);
            this.judgeBtnA2.TabIndex = 29;
            this.judgeBtnA2.Text = "判断矩阵设置";
            this.judgeBtnA2.UseVisualStyleBackColor = true;
            this.judgeBtnA2.Click += new System.EventHandler(this.JudgeMatrixButtonClick);
            // 
            // judgeBtnA4
            // 
            this.judgeBtnA4.Location = new System.Drawing.Point(338, 141);
            this.judgeBtnA4.Name = "judgeBtnA4";
            this.judgeBtnA4.Size = new System.Drawing.Size(92, 23);
            this.judgeBtnA4.TabIndex = 28;
            this.judgeBtnA4.Text = "判断矩阵设置";
            this.judgeBtnA4.UseVisualStyleBackColor = true;
            this.judgeBtnA4.Click += new System.EventHandler(this.JudgeMatrixButtonClick);
            // 
            // judgeBtnA3
            // 
            this.judgeBtnA3.Location = new System.Drawing.Point(229, 141);
            this.judgeBtnA3.Name = "judgeBtnA3";
            this.judgeBtnA3.Size = new System.Drawing.Size(92, 23);
            this.judgeBtnA3.TabIndex = 27;
            this.judgeBtnA3.Text = "判断矩阵设置";
            this.judgeBtnA3.UseVisualStyleBackColor = true;
            this.judgeBtnA3.Click += new System.EventHandler(this.JudgeMatrixButtonClick);
            // 
            // judgeBtnA1
            // 
            this.judgeBtnA1.Location = new System.Drawing.Point(21, 141);
            this.judgeBtnA1.Name = "judgeBtnA1";
            this.judgeBtnA1.Size = new System.Drawing.Size(92, 23);
            this.judgeBtnA1.TabIndex = 26;
            this.judgeBtnA1.Text = "判断矩阵设置";
            this.judgeBtnA1.UseVisualStyleBackColor = true;
            this.judgeBtnA1.Click += new System.EventHandler(this.JudgeMatrixButtonClick);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Location = new System.Drawing.Point(383, 206);
            this.label12.MaximumSize = new System.Drawing.Size(25, 2);
            this.label12.MinimumSize = new System.Drawing.Size(2, 90);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(25, 90);
            this.label12.TabIndex = 24;
            this.label12.Text = "B13命中率";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Location = new System.Drawing.Point(321, 206);
            this.label11.MaximumSize = new System.Drawing.Size(25, 2);
            this.label11.MinimumSize = new System.Drawing.Size(2, 90);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(25, 90);
            this.label11.TabIndex = 23;
            this.label11.Text = "B11命中率";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Location = new System.Drawing.Point(410, 206);
            this.label10.MaximumSize = new System.Drawing.Size(25, 2);
            this.label10.MinimumSize = new System.Drawing.Size(2, 90);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 90);
            this.label10.TabIndex = 22;
            this.label10.Text = "B14成功率";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label22.Location = new System.Drawing.Point(46, 206);
            this.label22.MaximumSize = new System.Drawing.Size(20, 2);
            this.label22.MinimumSize = new System.Drawing.Size(2, 90);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(19, 90);
            this.label22.TabIndex = 18;
            this.label22.Text = "B2职称";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label21.Location = new System.Drawing.Point(71, 206);
            this.label21.MaximumSize = new System.Drawing.Size(20, 2);
            this.label21.MinimumSize = new System.Drawing.Size(2, 90);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(19, 90);
            this.label21.TabIndex = 17;
            this.label21.Text = "B3学历";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label20.Location = new System.Drawing.Point(119, 206);
            this.label20.MaximumSize = new System.Drawing.Size(20, 2);
            this.label20.MinimumSize = new System.Drawing.Size(2, 90);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(19, 90);
            this.label20.TabIndex = 16;
            this.label20.Text = "B4h指数";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label19.Location = new System.Drawing.Point(142, 206);
            this.label19.MaximumSize = new System.Drawing.Size(20, 2);
            this.label19.MinimumSize = new System.Drawing.Size(2, 90);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(19, 90);
            this.label19.TabIndex = 15;
            this.label19.Text = "B5科研项目";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label18.Location = new System.Drawing.Point(165, 206);
            this.label18.MaximumSize = new System.Drawing.Size(20, 2);
            this.label18.MinimumSize = new System.Drawing.Size(2, 90);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(19, 90);
            this.label18.TabIndex = 14;
            this.label18.Text = "B6获奖情况";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label17.Location = new System.Drawing.Point(188, 206);
            this.label17.MaximumSize = new System.Drawing.Size(20, 2);
            this.label17.MinimumSize = new System.Drawing.Size(2, 90);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(19, 90);
            this.label17.TabIndex = 13;
            this.label17.Text = "B7获得专利";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label16.Location = new System.Drawing.Point(227, 206);
            this.label16.MaximumSize = new System.Drawing.Size(20, 2);
            this.label16.MinimumSize = new System.Drawing.Size(2, 90);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(19, 90);
            this.label16.TabIndex = 12;
            this.label16.Text = "B8科研道德累计数";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label15.Location = new System.Drawing.Point(252, 206);
            this.label15.MaximumSize = new System.Drawing.Size(20, 2);
            this.label15.MinimumSize = new System.Drawing.Size(2, 90);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(19, 90);
            this.label15.TabIndex = 11;
            this.label15.Text = "B9科研态度";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Location = new System.Drawing.Point(275, 206);
            this.label14.MaximumSize = new System.Drawing.Size(25, 2);
            this.label14.MinimumSize = new System.Drawing.Size(2, 90);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(25, 90);
            this.label14.TabIndex = 10;
            this.label14.Text = "B10工作作风";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Location = new System.Drawing.Point(352, 206);
            this.label13.MaximumSize = new System.Drawing.Size(25, 2);
            this.label13.MinimumSize = new System.Drawing.Size(2, 90);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(25, 90);
            this.label13.TabIndex = 9;
            this.label13.Text = "B12离散率";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Location = new System.Drawing.Point(21, 206);
            this.label9.MaximumSize = new System.Drawing.Size(20, 2);
            this.label9.MinimumSize = new System.Drawing.Size(2, 90);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(19, 90);
            this.label9.TabIndex = 5;
            this.label9.Text = "B1年龄";
            // 
            // labelA4
            // 
            this.labelA4.AutoSize = true;
            this.labelA4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelA4.Location = new System.Drawing.Point(338, 114);
            this.labelA4.Name = "labelA4";
            this.labelA4.Padding = new System.Windows.Forms.Padding(3);
            this.labelA4.Size = new System.Drawing.Size(97, 20);
            this.labelA4.TabIndex = 4;
            this.labelA4.Text = "评价业绩指标A4";
            this.labelA4.Click += new System.EventHandler(this.InfoLabelClick);
            // 
            // labelA3
            // 
            this.labelA3.AutoSize = true;
            this.labelA3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelA3.Location = new System.Drawing.Point(229, 114);
            this.labelA3.Name = "labelA3";
            this.labelA3.Padding = new System.Windows.Forms.Padding(3);
            this.labelA3.Size = new System.Drawing.Size(97, 20);
            this.labelA3.TabIndex = 3;
            this.labelA3.Text = "道德修养指标A3";
            this.labelA3.Click += new System.EventHandler(this.InfoLabelClick);
            // 
            // labelA2
            // 
            this.labelA2.AutoSize = true;
            this.labelA2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelA2.Location = new System.Drawing.Point(124, 114);
            this.labelA2.Name = "labelA2";
            this.labelA2.Padding = new System.Windows.Forms.Padding(3);
            this.labelA2.Size = new System.Drawing.Size(97, 20);
            this.labelA2.TabIndex = 2;
            this.labelA2.Text = "专业能力指标A2";
            this.labelA2.Click += new System.EventHandler(this.InfoLabelClick);
            // 
            // labelA1
            // 
            this.labelA1.AutoSize = true;
            this.labelA1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelA1.Location = new System.Drawing.Point(21, 114);
            this.labelA1.Name = "labelA1";
            this.labelA1.Padding = new System.Windows.Forms.Padding(3);
            this.labelA1.Size = new System.Drawing.Size(97, 20);
            this.labelA1.TabIndex = 1;
            this.labelA1.Text = "基本情况指标A1";
            this.labelA1.Click += new System.EventHandler(this.InfoLabelClick);
            // 
            // labelZ
            // 
            this.labelZ.AutoSize = true;
            this.labelZ.Location = new System.Drawing.Point(216, 24);
            this.labelZ.Name = "labelZ";
            this.labelZ.Size = new System.Drawing.Size(47, 12);
            this.labelZ.TabIndex = 0;
            this.labelZ.Text = "总目标Z";
            this.labelZ.Click += new System.EventHandler(this.InfoLabelClick);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 419);
            this.Controls.Add(this.contentTable);
            this.Name = "MainWindow";
            this.Text = "专家遴选系统";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.contentTable.ResumeLayout(false);
            this.contentTable.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button dcsSetBtn;
        private System.Windows.Forms.Button testBtn;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TableLayoutPanel contentTable;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelA4;
        private System.Windows.Forms.Label labelA3;
        private System.Windows.Forms.Label labelA2;
        private System.Windows.Forms.Label labelA1;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button levelInfoBtn1;
        private System.Windows.Forms.Button levelInfoBtn2;
        private System.Windows.Forms.Label labelZ;
        private System.Windows.Forms.Button judgeBtnZ;
        private System.Windows.Forms.Button judgeBtnA2;
        private System.Windows.Forms.Button judgeBtnA4;
        private System.Windows.Forms.Button judgeBtnA3;
        private System.Windows.Forms.Button judgeBtnA1;
        private System.Windows.Forms.Button getDcsBtn1;
        private System.Windows.Forms.Button getDcsBtn2;
        private System.Windows.Forms.Button judgeMatrixSwitchBtn;

    }
}

