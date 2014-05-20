namespace ExpertChooseSystem
{
    partial class DecisionMatrixForm
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
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.expertAddBtn = new System.Windows.Forms.Button();
            this.expertRmvBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid
            // 
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Location = new System.Drawing.Point(12, 12);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RowTemplate.Height = 23;
            this.dataGrid.Size = new System.Drawing.Size(713, 336);
            this.dataGrid.TabIndex = 0;
            // 
            // expertAddBtn
            // 
            this.expertAddBtn.Location = new System.Drawing.Point(12, 366);
            this.expertAddBtn.Name = "expertAddBtn";
            this.expertAddBtn.Size = new System.Drawing.Size(75, 23);
            this.expertAddBtn.TabIndex = 1;
            this.expertAddBtn.Text = "添加专家";
            this.expertAddBtn.UseVisualStyleBackColor = true;
            this.expertAddBtn.Click += new System.EventHandler(this.expertAddBtn_Click);
            // 
            // expertRmvBtn
            // 
            this.expertRmvBtn.Location = new System.Drawing.Point(112, 366);
            this.expertRmvBtn.Name = "expertRmvBtn";
            this.expertRmvBtn.Size = new System.Drawing.Size(75, 23);
            this.expertRmvBtn.TabIndex = 2;
            this.expertRmvBtn.Text = "移除专家";
            this.expertRmvBtn.UseVisualStyleBackColor = true;
            this.expertRmvBtn.Click += new System.EventHandler(this.expertRmvBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(554, 366);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 3;
            this.saveBtn.Text = "保存";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(650, 366);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 4;
            this.cancelBtn.Text = "取消";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // DecisionMatrixForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 401);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.expertRmvBtn);
            this.Controls.Add(this.expertAddBtn);
            this.Controls.Add(this.dataGrid);
            this.Name = "DecisionMatrixForm";
            this.Text = "DecisionMatrixForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.Button expertAddBtn;
        private System.Windows.Forms.Button expertRmvBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button cancelBtn;
    }
}