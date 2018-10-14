namespace Guoli.DataSync
{
    partial class FrmDeploy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDeploy));
            this.btnInitUsb = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnInitUsb
            // 
            this.btnInitUsb.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnInitUsb.Location = new System.Drawing.Point(157, 95);
            this.btnInitUsb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnInitUsb.Name = "btnInitUsb";
            this.btnInitUsb.Size = new System.Drawing.Size(213, 69);
            this.btnInitUsb.TabIndex = 0;
            this.btnInitUsb.Text = "初始化 U 盘";
            this.btnInitUsb.UseVisualStyleBackColor = true;
            this.btnInitUsb.Click += new System.EventHandler(this.btnInitUsb_Click);
            // 
            // FrmDeploy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 292);
            this.Controls.Add(this.btnInitUsb);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmDeploy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "U盘部署工具";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInitUsb;
    }
}