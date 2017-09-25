namespace Guoli.Import
{
    partial class FrmInit
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
            this.components = new System.ComponentModel.Container();
            this.labServer = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.labAccount = new System.Windows.Forms.Label();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.labPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.labDb = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.cbDbList = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // labServer
            // 
            this.labServer.AutoSize = true;
            this.labServer.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labServer.Location = new System.Drawing.Point(78, 52);
            this.labServer.Name = "labServer";
            this.labServer.Size = new System.Drawing.Size(72, 16);
            this.labServer.TabIndex = 0;
            this.labServer.Text = "服务器：";
            // 
            // txtServer
            // 
            this.txtServer.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtServer.Location = new System.Drawing.Point(156, 49);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(241, 26);
            this.txtServer.TabIndex = 1;
            this.txtServer.Text = "127.0.0.1";
            // 
            // labAccount
            // 
            this.labAccount.AutoSize = true;
            this.labAccount.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labAccount.Location = new System.Drawing.Point(78, 105);
            this.labAccount.Name = "labAccount";
            this.labAccount.Size = new System.Drawing.Size(72, 16);
            this.labAccount.TabIndex = 0;
            this.labAccount.Text = "登录名：";
            // 
            // txtAccount
            // 
            this.txtAccount.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAccount.Location = new System.Drawing.Point(156, 102);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(241, 26);
            this.txtAccount.TabIndex = 1;
            this.txtAccount.Text = "sa";
            // 
            // labPassword
            // 
            this.labPassword.AutoSize = true;
            this.labPassword.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labPassword.Location = new System.Drawing.Point(78, 161);
            this.labPassword.Name = "labPassword";
            this.labPassword.Size = new System.Drawing.Size(72, 16);
            this.labPassword.TabIndex = 0;
            this.labPassword.Text = "密  码：";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPassword.Location = new System.Drawing.Point(156, 158);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(241, 26);
            this.txtPassword.TabIndex = 1;
            // 
            // btnTest
            // 
            this.btnTest.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTest.Location = new System.Drawing.Point(81, 279);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(139, 40);
            this.btnTest.TabIndex = 2;
            this.btnTest.Text = "测试连接";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLogin.Location = new System.Drawing.Point(258, 279);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(139, 40);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "确  定";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // labDb
            // 
            this.labDb.AutoSize = true;
            this.labDb.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labDb.Location = new System.Drawing.Point(78, 215);
            this.labDb.Name = "labDb";
            this.labDb.Size = new System.Drawing.Size(72, 16);
            this.labDb.TabIndex = 0;
            this.labDb.Text = "数据库：";
            // 
            // cbDbList
            // 
            this.cbDbList.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbDbList.FormattingEnabled = true;
            this.cbDbList.Location = new System.Drawing.Point(156, 212);
            this.cbDbList.Name = "cbDbList";
            this.cbDbList.Size = new System.Drawing.Size(241, 24);
            this.cbDbList.TabIndex = 4;
            // 
            // FrmInit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 399);
            this.Controls.Add(this.cbDbList);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.labDb);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.labPassword);
            this.Controls.Add(this.txtAccount);
            this.Controls.Add(this.labAccount);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.labServer);
            this.Name = "FrmInit";
            this.Text = "连接数据库";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labServer;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label labAccount;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.Label labPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label labDb;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.ComboBox cbDbList;
    }
}