namespace ExpertChooseSystem
{
    partial class JudgeMatrixDisplayForm
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
            this.ciLabel = new System.Windows.Forms.Label();
            this.riLabel = new System.Windows.Forms.Label();
            this.crLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.judgeMatrixPanel = new System.Windows.Forms.Panel();
            this.wightVectPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 302F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.judgeMatrixPanel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.wightVectPanel, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(360, 354);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.crLabel);
            this.panel1.Controls.Add(this.riLabel);
            this.panel1.Controls.Add(this.ciLabel);
            this.panel1.Location = new System.Drawing.Point(4, 296);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(352, 54);
            this.panel1.TabIndex = 0;
            // 
            // ciLabel
            // 
            this.ciLabel.AutoSize = true;
            this.ciLabel.Location = new System.Drawing.Point(3, 0);
            this.ciLabel.Name = "ciLabel";
            this.ciLabel.Size = new System.Drawing.Size(41, 12);
            this.ciLabel.TabIndex = 0;
            this.ciLabel.Text = "label1";
            // 
            // riLabel
            // 
            this.riLabel.AutoSize = true;
            this.riLabel.Location = new System.Drawing.Point(4, 16);
            this.riLabel.Name = "riLabel";
            this.riLabel.Size = new System.Drawing.Size(41, 12);
            this.riLabel.TabIndex = 1;
            this.riLabel.Text = "label2";
            // 
            // crLabel
            // 
            this.crLabel.AutoSize = true;
            this.crLabel.Location = new System.Drawing.Point(6, 32);
            this.crLabel.Name = "crLabel";
            this.crLabel.Size = new System.Drawing.Size(41, 12);
            this.crLabel.TabIndex = 2;
            this.crLabel.Text = "label3";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 61);
            this.label1.MaximumSize = new System.Drawing.Size(35, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "判断矩阵";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 48);
            this.label2.TabIndex = 2;
            this.label2.Text = "各个影响因素的单排序向量";
            // 
            // judgeMatrixPanel
            // 
            this.judgeMatrixPanel.Location = new System.Drawing.Point(60, 4);
            this.judgeMatrixPanel.Name = "judgeMatrixPanel";
            this.judgeMatrixPanel.Size = new System.Drawing.Size(296, 139);
            this.judgeMatrixPanel.TabIndex = 3;
            // 
            // wightVectPanel
            // 
            this.wightVectPanel.Location = new System.Drawing.Point(60, 150);
            this.wightVectPanel.Name = "wightVectPanel";
            this.wightVectPanel.Size = new System.Drawing.Size(296, 139);
            this.wightVectPanel.TabIndex = 4;
            // 
            // JudgeMatrixDisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 378);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "JudgeMatrixDisplayForm";
            this.Text = "JudgeMatrixDisplayForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label crLabel;
        private System.Windows.Forms.Label riLabel;
        private System.Windows.Forms.Label ciLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel judgeMatrixPanel;
        private System.Windows.Forms.Panel wightVectPanel;


    }
}