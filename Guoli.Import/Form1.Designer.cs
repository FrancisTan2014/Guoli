namespace Guoli.Import
{
    partial class frmImport
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
            this.btnStations = new System.Windows.Forms.Button();
            this.btnMigration = new System.Windows.Forms.Button();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStations
            // 
            this.btnStations.Location = new System.Drawing.Point(51, 52);
            this.btnStations.Name = "btnStations";
            this.btnStations.Size = new System.Drawing.Size(165, 67);
            this.btnStations.TabIndex = 0;
            this.btnStations.Text = "车站-线路-车次导入";
            this.btnStations.UseVisualStyleBackColor = true;
            this.btnStations.Click += new System.EventHandler(this.btnStations_Click);
            // 
            // btnMigration
            // 
            this.btnMigration.Location = new System.Drawing.Point(253, 55);
            this.btnMigration.Name = "btnMigration";
            this.btnMigration.Size = new System.Drawing.Size(166, 64);
            this.btnMigration.TabIndex = 1;
            this.btnMigration.Text = "运安数据库同步";
            this.btnMigration.UseVisualStyleBackColor = true;
            this.btnMigration.Click += new System.EventHandler(this.btnMigration_Click);
            // 
            // btnAdmin
            // 
            this.btnAdmin.Location = new System.Drawing.Point(452, 55);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(131, 64);
            this.btnAdmin.TabIndex = 2;
            this.btnAdmin.Text = "添加管理员账号";
            this.btnAdmin.UseVisualStyleBackColor = true;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(51, 150);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(165, 64);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "清空基础数据（车站、线路、车次）";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // frmImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 586);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnAdmin);
            this.Controls.Add(this.btnMigration);
            this.Controls.Add(this.btnStations);
            this.Name = "frmImport";
            this.Text = "基础数据导入";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStations;
        private System.Windows.Forms.Button btnMigration;
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.Button btnClear;
    }
}

