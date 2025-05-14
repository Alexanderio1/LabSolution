namespace DemoApp
{
    partial class LoginForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblVersionBar = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.picKey = new System.Windows.Forms.PictureBox();
            this.panelHint = new System.Windows.Forms.Panel();
            this.lblHint = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.sslLang = new System.Windows.Forms.ToolStripStatusLabel();
            this.sslSpacer = new System.Windows.Forms.ToolStripStatusLabel();
            this.sslCaps = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picKey)).BeginInit();
            this.panelHint.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(120, 430);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(180, 52);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Вход";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(584, 430);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(180, 52);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(400, 274);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(400, 31);
            this.txtUser.TabIndex = 2;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(400, 344);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(400, 31);
            this.txtPass.TabIndex = 3;
            this.txtPass.UseSystemPasswordChar = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblVersion);
            this.panel1.Controls.Add(this.lblVersionBar);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Controls.Add(this.picKey);
            this.panel1.Location = new System.Drawing.Point(20, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(844, 170);
            this.panel1.TabIndex = 4;
            // 
            // lblVersion
            // 
            this.lblVersion.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblVersion.Location = new System.Drawing.Point(602, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.lblVersion.Size = new System.Drawing.Size(240, 168);
            this.lblVersion.TabIndex = 3;
            this.lblVersion.Text = "Версия 1.0.0.0";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblVersionBar
            // 
            this.lblVersionBar.BackColor = System.Drawing.Color.Gold;
            this.lblVersionBar.Location = new System.Drawing.Point(160, 76);
            this.lblVersionBar.Name = "lblVersionBar";
            this.lblVersionBar.Size = new System.Drawing.Size(668, 40);
            this.lblVersionBar.TabIndex = 2;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(160, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(668, 40);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "АИС Отдел кадров";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // picKey
            // 
            this.picKey.Image = ((System.Drawing.Image)(resources.GetObject("picKey.Image")));
            this.picKey.Location = new System.Drawing.Point(12, 22);
            this.picKey.Name = "picKey";
            this.picKey.Size = new System.Drawing.Size(128, 128);
            this.picKey.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picKey.TabIndex = 0;
            this.picKey.TabStop = false;
            // 
            // panelHint
            // 
            this.panelHint.BackColor = System.Drawing.SystemColors.Control;
            this.panelHint.Controls.Add(this.lblHint);
            this.panelHint.Location = new System.Drawing.Point(20, 198);
            this.panelHint.Name = "panelHint";
            this.panelHint.Size = new System.Drawing.Size(844, 46);
            this.panelHint.TabIndex = 4;
            // 
            // lblHint
            // 
            this.lblHint.AutoSize = true;
            this.lblHint.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblHint.Location = new System.Drawing.Point(466, 0);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(378, 25);
            this.lblHint.TabIndex = 0;
            this.lblHint.Text = "Введите имя пользователя и пароль";
            this.lblHint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(60, 280);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(197, 25);
            this.lblUser.TabIndex = 5;
            this.lblUser.Text = "Имя пользователя";
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(60, 350);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(86, 25);
            this.lblPass.TabIndex = 6;
            this.lblPass.Text = "Пароль";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sslLang,
            this.sslSpacer,
            this.sslCaps});
            this.statusStrip1.Location = new System.Drawing.Point(0, 507);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(858, 42);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // sslLang
            // 
            this.sslLang.Name = "sslLang";
            this.sslLang.Size = new System.Drawing.Size(21, 32);
            this.sslLang.Text = " ";
            this.sslLang.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sslSpacer
            // 
            this.sslSpacer.Name = "sslSpacer";
            this.sslSpacer.Size = new System.Drawing.Size(801, 32);
            this.sslSpacer.Spring = true;
            this.sslSpacer.Text = " ";
            // 
            // sslCaps
            // 
            this.sslCaps.Name = "sslCaps";
            this.sslCaps.Size = new System.Drawing.Size(21, 32);
            this.sslCaps.Text = " ";
            this.sslCaps.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(858, 549);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.panelHint);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Вход";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picKey)).EndInit();
            this.panelHint.ResumeLayout(false);
            this.panelHint.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picKey;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblVersionBar;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Panel panelHint;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel sslLang;
        private System.Windows.Forms.ToolStripStatusLabel sslSpacer;
        private System.Windows.Forms.ToolStripStatusLabel sslCaps;
    }
}

