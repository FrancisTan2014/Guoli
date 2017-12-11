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
            this.gpbInitial = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTestChangeConfig = new System.Windows.Forms.Button();
            this.btnImport2 = new System.Windows.Forms.Button();
            this.groupKeywords = new System.Windows.Forms.GroupBox();
            this.btnDistinct = new System.Windows.Forms.Button();
            this.btnBaiduAnalysiser = new System.Windows.Forms.Button();
            this.btnDistinct2 = new System.Windows.Forms.Button();
            this.gpbInitial.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupKeywords.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStations
            // 
            this.btnStations.Location = new System.Drawing.Point(15, 56);
            this.btnStations.Name = "btnStations";
            this.btnStations.Size = new System.Drawing.Size(165, 67);
            this.btnStations.TabIndex = 0;
            this.btnStations.Text = "车站-线路-车次导入";
            this.btnStations.UseVisualStyleBackColor = true;
            this.btnStations.Click += new System.EventHandler(this.btnStations_Click);
            // 
            // btnMigration
            // 
            this.btnMigration.Location = new System.Drawing.Point(217, 59);
            this.btnMigration.Name = "btnMigration";
            this.btnMigration.Size = new System.Drawing.Size(258, 64);
            this.btnMigration.TabIndex = 1;
            this.btnMigration.Text = "从运安数据库同步人员信息（人员、职位、部门等）";
            this.btnMigration.UseVisualStyleBackColor = true;
            this.btnMigration.Click += new System.EventHandler(this.btnMigration_Click);
            // 
            // btnAdmin
            // 
            this.btnAdmin.Location = new System.Drawing.Point(518, 59);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(268, 64);
            this.btnAdmin.TabIndex = 2;
            this.btnAdmin.Text = "添加后台管理员账号(admin-123456)";
            this.btnAdmin.UseVisualStyleBackColor = true;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(15, 61);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(187, 63);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "清空基础数据（车站、线路、车次）";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // gpbInitial
            // 
            this.gpbInitial.Controls.Add(this.btnAdmin);
            this.gpbInitial.Controls.Add(this.btnStations);
            this.gpbInitial.Controls.Add(this.btnMigration);
            this.gpbInitial.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gpbInitial.Location = new System.Drawing.Point(12, 12);
            this.gpbInitial.Name = "gpbInitial";
            this.gpbInitial.Size = new System.Drawing.Size(792, 179);
            this.gpbInitial.TabIndex = 4;
            this.gpbInitial.TabStop = false;
            this.gpbInitial.Text = "系统部署时的初始化操作";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnTestChangeConfig);
            this.groupBox1.Controls.Add(this.btnImport2);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(12, 234);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(786, 184);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "当铁路总公司通知变图时（针对基础数据需要先清空，再重新导入新的基础数据）";
            // 
            // btnTestChangeConfig
            // 
            this.btnTestChangeConfig.Location = new System.Drawing.Point(446, 61);
            this.btnTestChangeConfig.Name = "btnTestChangeConfig";
            this.btnTestChangeConfig.Size = new System.Drawing.Size(197, 63);
            this.btnTestChangeConfig.TabIndex = 0;
            this.btnTestChangeConfig.Text = "测试改变配置文件";
            this.btnTestChangeConfig.UseVisualStyleBackColor = true;
            this.btnTestChangeConfig.Click += new System.EventHandler(this.btnTestChangeConfig_Click);
            // 
            // btnImport2
            // 
            this.btnImport2.Location = new System.Drawing.Point(228, 61);
            this.btnImport2.Name = "btnImport2";
            this.btnImport2.Size = new System.Drawing.Size(197, 63);
            this.btnImport2.TabIndex = 0;
            this.btnImport2.Text = "车站-线路-车次导入";
            this.btnImport2.UseVisualStyleBackColor = true;
            this.btnImport2.Click += new System.EventHandler(this.btnStations_Click);
            // 
            // groupKeywords
            // 
            this.groupKeywords.Controls.Add(this.btnDistinct2);
            this.groupKeywords.Controls.Add(this.btnDistinct);
            this.groupKeywords.Controls.Add(this.btnBaiduAnalysiser);
            this.groupKeywords.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupKeywords.Location = new System.Drawing.Point(12, 461);
            this.groupKeywords.Name = "groupKeywords";
            this.groupKeywords.Size = new System.Drawing.Size(786, 179);
            this.groupKeywords.TabIndex = 6;
            this.groupKeywords.TabStop = false;
            this.groupKeywords.Text = "关键词处理";
            // 
            // btnDistinct
            // 
            this.btnDistinct.Location = new System.Drawing.Point(228, 68);
            this.btnDistinct.Name = "btnDistinct";
            this.btnDistinct.Size = new System.Drawing.Size(186, 59);
            this.btnDistinct.TabIndex = 1;
            this.btnDistinct.Text = "去除重复的关键字";
            this.btnDistinct.UseVisualStyleBackColor = true;
            this.btnDistinct.Click += new System.EventHandler(this.btnDistinct_Click);
            // 
            // btnBaiduAnalysiser
            // 
            this.btnBaiduAnalysiser.Location = new System.Drawing.Point(15, 68);
            this.btnBaiduAnalysiser.Name = "btnBaiduAnalysiser";
            this.btnBaiduAnalysiser.Size = new System.Drawing.Size(187, 59);
            this.btnBaiduAnalysiser.TabIndex = 0;
            this.btnBaiduAnalysiser.Text = "百度分词工具";
            this.btnBaiduAnalysiser.UseVisualStyleBackColor = true;
            this.btnBaiduAnalysiser.Click += new System.EventHandler(this.btnBaiduAnalysiser_Click);
            // 
            // btnDistinct2
            // 
            this.btnDistinct2.Location = new System.Drawing.Point(446, 68);
            this.btnDistinct2.Name = "btnDistinct2";
            this.btnDistinct2.Size = new System.Drawing.Size(197, 59);
            this.btnDistinct2.TabIndex = 2;
            this.btnDistinct2.Text = "处理重复关键字导致的搜索结果";
            this.btnDistinct2.UseVisualStyleBackColor = true;
            this.btnDistinct2.Click += new System.EventHandler(this.btnDistinct2_Click);
            // 
            // frmImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 696);
            this.Controls.Add(this.groupKeywords);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gpbInitial);
            this.Name = "frmImport";
            this.Text = "部署工具";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmImport_FormClosed);
            this.gpbInitial.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupKeywords.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStations;
        private System.Windows.Forms.Button btnMigration;
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox gpbInitial;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnImport2;
        private System.Windows.Forms.Button btnTestChangeConfig;
        private System.Windows.Forms.GroupBox groupKeywords;
        private System.Windows.Forms.Button btnBaiduAnalysiser;
        private System.Windows.Forms.Button btnDistinct;
        private System.Windows.Forms.Button btnDistinct2;
    }
}

