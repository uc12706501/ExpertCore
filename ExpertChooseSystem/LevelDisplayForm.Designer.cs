namespace ExpertChooseSystem
{
    partial class LevelDisplayForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.ciLabel = new System.Windows.Forms.Label();
            this.riLabel = new System.Windows.Forms.Label();
            this.crLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.66078F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 88.33923F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(283, 253);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 108);
            this.label1.TabIndex = 0;
            this.label1.Text = "层次总排序权重向量";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 96);
            this.label2.TabIndex = 1;
            this.label2.Text = "本层次的相关信息";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.ciLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.riLabel, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.crLabel, 0, 2);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(37, 130);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(242, 119);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // ciLabel
            // 
            this.ciLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ciLabel.AutoSize = true;
            this.ciLabel.Location = new System.Drawing.Point(4, 14);
            this.ciLabel.Name = "ciLabel";
            this.ciLabel.Size = new System.Drawing.Size(41, 12);
            this.ciLabel.TabIndex = 0;
            this.ciLabel.Text = "label3";
            // 
            // riLabel
            // 
            this.riLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.riLabel.AutoSize = true;
            this.riLabel.Location = new System.Drawing.Point(4, 53);
            this.riLabel.Name = "riLabel";
            this.riLabel.Size = new System.Drawing.Size(41, 12);
            this.riLabel.TabIndex = 1;
            this.riLabel.Text = "label4";
            // 
            // crLabel
            // 
            this.crLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.crLabel.AutoSize = true;
            this.crLabel.Location = new System.Drawing.Point(4, 92);
            this.crLabel.Name = "crLabel";
            this.crLabel.Size = new System.Drawing.Size(41, 12);
            this.crLabel.TabIndex = 2;
            this.crLabel.Text = "label5";
            // 
            // LevelDisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 277);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "LevelDisplayForm";
            this.Text = "LevelDisplayForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label ciLabel;
        private System.Windows.Forms.Label riLabel;
        private System.Windows.Forms.Label crLabel;
    }
}