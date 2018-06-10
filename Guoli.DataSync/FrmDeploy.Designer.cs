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
            this.btnInitUsb = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnInitUsb
            // 
            this.btnInitUsb.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnInitUsb.Location = new System.Drawing.Point(118, 76);
            this.btnInitUsb.Name = "btnInitUsb";
            this.btnInitUsb.Size = new System.Drawing.Size(160, 55);
            this.btnInitUsb.TabIndex = 0;
            this.btnInitUsb.Text = "初始化 U 盘";
            this.btnInitUsb.UseVisualStyleBackColor = true;
            this.btnInitUsb.Click += new System.EventHandler(this.btnInitUsb_Click);
            // 
            // FrmDeploy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 234);
            this.Controls.Add(this.btnInitUsb);
            this.Name = "FrmDeploy";
            this.Text = "U盘部署工具";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInitUsb;
    }
}