namespace ExpertChoose.AHP.WinformSystem
{
    partial class ApprovedGenForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.saveBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.sortLabel = new System.Windows.Forms.Label();
            this.factorPanel = new System.Windows.Forms.Panel();
            this.factorsLabel = new System.Windows.Forms.Label();
            this.sortsDataGridView = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.factorPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sortsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.61972F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.38028F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.sortLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.factorPanel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.sortsDataGridView, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.83333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 69.16666F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(355, 281);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.saveBtn);
            this.panel1.Location = new System.Drawing.Point(4, 244);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(347, 33);
            this.panel1.TabIndex = 0;
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(269, 0);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 30);
            this.saveBtn.TabIndex = 0;
            this.saveBtn.Text = "保存";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "被影响的因素";
            // 
            // sortLabel
            // 
            this.sortLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sortLabel.AutoSize = true;
            this.sortLabel.Location = new System.Drawing.Point(15, 151);
            this.sortLabel.Name = "sortLabel";
            this.sortLabel.Size = new System.Drawing.Size(29, 12);
            this.sortLabel.TabIndex = 2;
            this.sortLabel.Text = "排序";
            // 
            // factorPanel
            // 
            this.factorPanel.AutoSize = true;
            this.factorPanel.Controls.Add(this.factorsLabel);
            this.factorPanel.Location = new System.Drawing.Point(63, 4);
            this.factorPanel.Name = "factorPanel";
            this.factorPanel.Size = new System.Drawing.Size(7, 21);
            this.factorPanel.TabIndex = 3;
            // 
            // factorsLabel
            // 
            this.factorsLabel.AutoSize = true;
            this.factorsLabel.Location = new System.Drawing.Point(4, 9);
            this.factorsLabel.Name = "factorsLabel";
            this.factorsLabel.Size = new System.Drawing.Size(0, 12);
            this.factorsLabel.TabIndex = 0;
            // 
            // sortsDataGridView
            // 
            this.sortsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.sortsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sortsDataGridView.Location = new System.Drawing.Point(63, 78);
            this.sortsDataGridView.Name = "sortsDataGridView";
            this.sortsDataGridView.RowTemplate.Height = 23;
            this.sortsDataGridView.Size = new System.Drawing.Size(285, 159);
            this.sortsDataGridView.TabIndex = 4;
            // 
            // ApprovedGenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 293);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ApprovedGenForm";
            this.Text = "ApprovedGenForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.factorPanel.ResumeLayout(false);
            this.factorPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sortsDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label sortLabel;
        private System.Windows.Forms.Panel factorPanel;
        private System.Windows.Forms.Label factorsLabel;
        private System.Windows.Forms.DataGridView sortsDataGridView;
    }
}