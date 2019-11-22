namespace CryptographyDesign
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.notify = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.ckbCopyToClipBoard = new System.Windows.Forms.CheckBox();
            this.ckbPasteFromClipBoard = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tbSource = new System.Windows.Forms.TextBox();
            this.tbTarget = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tbHillKey = new System.Windows.Forms.TextBox();
            this.tbVigenereKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnImportKeys = new System.Windows.Forms.Button();
            this.btnExportKeys = new System.Windows.Forms.Button();
            this.btnGenRandomKey = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbAffineKeyB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbAffineKeyA = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.notifyMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // notify
            // 
            this.notify.ContextMenuStrip = this.notifyMenu;
            this.notify.Icon = ((System.Drawing.Icon)(resources.GetObject("notify.Icon")));
            this.notify.Text = "notifyIcon1";
            this.notify.Visible = true;
            // 
            // notifyMenu
            // 
            this.notifyMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于ToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitMenuItem});
            this.notifyMenu.Name = "contextMenuStrip1";
            this.notifyMenu.Size = new System.Drawing.Size(101, 54);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.关于ToolStripMenuItem.Text = "关于";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(97, 6);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(100, 22);
            this.exitMenuItem.Text = "退出";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.btnEncrypt.Location = new System.Drawing.Point(6, 204);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(75, 31);
            this.btnEncrypt.TabIndex = 2;
            this.btnEncrypt.Text = "加密";
            this.btnEncrypt.UseVisualStyleBackColor = false;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.BackColor = System.Drawing.Color.Tomato;
            this.btnDecrypt.Location = new System.Drawing.Point(96, 204);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(75, 31);
            this.btnDecrypt.TabIndex = 3;
            this.btnDecrypt.Text = "解密";
            this.btnDecrypt.UseVisualStyleBackColor = false;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // ckbCopyToClipBoard
            // 
            this.ckbCopyToClipBoard.AutoSize = true;
            this.ckbCopyToClipBoard.Location = new System.Drawing.Point(336, 222);
            this.ckbCopyToClipBoard.Name = "ckbCopyToClipBoard";
            this.ckbCopyToClipBoard.Size = new System.Drawing.Size(135, 21);
            this.ckbCopyToClipBoard.TabIndex = 4;
            this.ckbCopyToClipBoard.Text = "将结果复制到剪切板";
            this.toolTip1.SetToolTip(this.ckbCopyToClipBoard, "当勾选此项时，点击加密按钮后，\r\n会将加密结果复制到系统剪切板中");
            this.ckbCopyToClipBoard.UseVisualStyleBackColor = true;
            // 
            // ckbPasteFromClipBoard
            // 
            this.ckbPasteFromClipBoard.AutoSize = true;
            this.ckbPasteFromClipBoard.Location = new System.Drawing.Point(336, 197);
            this.ckbPasteFromClipBoard.Name = "ckbPasteFromClipBoard";
            this.ckbPasteFromClipBoard.Size = new System.Drawing.Size(123, 21);
            this.ckbPasteFromClipBoard.TabIndex = 5;
            this.ckbPasteFromClipBoard.Text = "从剪切板获取文本";
            this.toolTip1.SetToolTip(this.ckbPasteFromClipBoard, "当勾选此项时，点击解密按钮后，\r\n将会读取剪切板中的文本，并将作为密文解密");
            this.ckbPasteFromClipBoard.UseVisualStyleBackColor = true;
            // 
            // tbSource
            // 
            this.tbSource.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbSource.ForeColor = System.Drawing.SystemColors.WindowText;
            this.errorProvider1.SetIconAlignment(this.tbSource, System.Windows.Forms.ErrorIconAlignment.BottomRight);
            this.tbSource.Location = new System.Drawing.Point(6, 20);
            this.tbSource.Multiline = true;
            this.tbSource.Name = "tbSource";
            this.tbSource.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbSource.Size = new System.Drawing.Size(467, 171);
            this.tbSource.TabIndex = 1;
            this.tbSource.TextChanged += new System.EventHandler(this.tbSource_TextChanged);
            // 
            // tbTarget
            // 
            this.tbTarget.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.errorProvider1.SetIconAlignment(this.tbTarget, System.Windows.Forms.ErrorIconAlignment.BottomLeft);
            this.tbTarget.Location = new System.Drawing.Point(6, 249);
            this.tbTarget.Multiline = true;
            this.tbTarget.Name = "tbTarget";
            this.tbTarget.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbTarget.Size = new System.Drawing.Size(467, 171);
            this.tbTarget.TabIndex = 6;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // tbHillKey
            // 
            this.tbHillKey.Font = new System.Drawing.Font("Consolas", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpProvider1.SetHelpString(this.tbHillKey, "可逆方阵");
            this.errorProvider1.SetIconAlignment(this.tbHillKey, System.Windows.Forms.ErrorIconAlignment.TopRight);
            this.tbHillKey.Location = new System.Drawing.Point(52, 202);
            this.tbHillKey.MaxLength = 10000;
            this.tbHillKey.Multiline = true;
            this.tbHillKey.Name = "tbHillKey";
            this.tbHillKey.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.helpProvider1.SetShowHelp(this.tbHillKey, true);
            this.tbHillKey.Size = new System.Drawing.Size(190, 154);
            this.tbHillKey.TabIndex = 4;
            this.tbHillKey.WordWrap = false;
            this.tbHillKey.TextChanged += new System.EventHandler(this.tbHillKey_TextChanged);
            // 
            // tbVigenereKey
            // 
            this.tbVigenereKey.Font = new System.Drawing.Font("Consolas", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpProvider1.SetHelpNavigator(this.tbVigenereKey, System.Windows.Forms.HelpNavigator.TopicId);
            this.helpProvider1.SetHelpString(this.tbVigenereKey, "数组，0~25，用空格分开");
            this.tbVigenereKey.Location = new System.Drawing.Point(53, 63);
            this.tbVigenereKey.MaxLength = 100;
            this.tbVigenereKey.Name = "tbVigenereKey";
            this.tbVigenereKey.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.helpProvider1.SetShowHelp(this.tbVigenereKey, true);
            this.tbVigenereKey.Size = new System.Drawing.Size(190, 24);
            this.tbVigenereKey.TabIndex = 1;
            this.tbVigenereKey.TextChanged += new System.EventHandler(this.tbVigenereKey_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "维吉尼亚密码：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.btnImportKeys);
            this.groupBox1.Controls.Add(this.btnExportKeys);
            this.groupBox1.Controls.Add(this.btnGenRandomKey);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbAffineKeyB);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbHillKey);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbAffineKeyA);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbVigenereKey);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(12, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(270, 426);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "1. 密钥配置";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(18, 202);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 14);
            this.label10.TabIndex = 20;
            this.label10.Text = "K =";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(86, 183);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 14);
            this.label9.TabIndex = 19;
            this.label9.Text = "e(x) = xK";
            // 
            // btnImportKeys
            // 
            this.btnImportKeys.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnImportKeys.Location = new System.Drawing.Point(134, 388);
            this.btnImportKeys.Name = "btnImportKeys";
            this.btnImportKeys.Size = new System.Drawing.Size(65, 32);
            this.btnImportKeys.TabIndex = 6;
            this.btnImportKeys.Text = "导入密钥";
            this.btnImportKeys.UseVisualStyleBackColor = false;
            this.btnImportKeys.Click += new System.EventHandler(this.btnImportKeys_Click);
            // 
            // btnExportKeys
            // 
            this.btnExportKeys.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnExportKeys.Location = new System.Drawing.Point(205, 388);
            this.btnExportKeys.Name = "btnExportKeys";
            this.btnExportKeys.Size = new System.Drawing.Size(65, 32);
            this.btnExportKeys.TabIndex = 6;
            this.btnExportKeys.Text = "保存密钥";
            this.btnExportKeys.UseVisualStyleBackColor = false;
            this.btnExportKeys.Click += new System.EventHandler(this.btnExportKeys_Click);
            // 
            // btnGenRandomKey
            // 
            this.btnGenRandomKey.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnGenRandomKey.Location = new System.Drawing.Point(28, 388);
            this.btnGenRandomKey.Name = "btnGenRandomKey";
            this.btnGenRandomKey.Size = new System.Drawing.Size(100, 32);
            this.btnGenRandomKey.TabIndex = 5;
            this.btnGenRandomKey.Text = "生成随机密钥";
            this.btnGenRandomKey.UseVisualStyleBackColor = false;
            this.btnGenRandomKey.Click += new System.EventHandler(this.btnGenRandomKey_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(18, 136);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 14);
            this.label8.TabIndex = 17;
            this.label8.Text = "a =";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(110, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 14);
            this.label7.TabIndex = 16;
            this.label7.Text = "b =";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 14);
            this.label6.TabIndex = 15;
            this.label6.Text = "Km =";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(224, 14);
            this.label5.TabIndex = 14;
            this.label5.Text = "e(x1..xm) = (x1 + k1...xm + km)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(67, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 14);
            this.label4.TabIndex = 13;
            this.label4.Text = "e(x) = (ax + b) mod 26";
            // 
            // tbAffineKeyB
            // 
            this.tbAffineKeyB.Font = new System.Drawing.Font("Consolas", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAffineKeyB.Location = new System.Drawing.Point(144, 130);
            this.tbAffineKeyB.MaxLength = 2;
            this.tbAffineKeyB.Name = "tbAffineKeyB";
            this.tbAffineKeyB.Size = new System.Drawing.Size(39, 24);
            this.tbAffineKeyB.TabIndex = 3;
            this.tbAffineKeyB.TextChanged += new System.EventHandler(this.tbAffineKeyB_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(6, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "希尔密码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(6, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "仿射密码：";
            // 
            // tbAffineKeyA
            // 
            this.tbAffineKeyA.Font = new System.Drawing.Font("Consolas", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAffineKeyA.Location = new System.Drawing.Point(52, 130);
            this.tbAffineKeyA.MaxLength = 2;
            this.tbAffineKeyA.Name = "tbAffineKeyA";
            this.tbAffineKeyA.Size = new System.Drawing.Size(39, 24);
            this.tbAffineKeyA.TabIndex = 2;
            this.tbAffineKeyA.TextChanged += new System.EventHandler(this.tbAffineKeyA_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.btnEncrypt);
            this.groupBox2.Controls.Add(this.btnDecrypt);
            this.groupBox2.Controls.Add(this.ckbCopyToClipBoard);
            this.groupBox2.Controls.Add(this.ckbPasteFromClipBoard);
            this.groupBox2.Controls.Add(this.tbSource);
            this.groupBox2.Controls.Add(this.tbTarget);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(288, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(500, 426);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "2. 加解密";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(417, 390);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 28);
            this.label12.TabIndex = 7;
            this.label12.Text = "结果";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(396, 160);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 28);
            this.label11.TabIndex = 7;
            this.label11.Text = "数据源";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "剪切板内容加解密工具";
            this.notifyMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notify;
        private System.Windows.Forms.ContextMenuStrip notifyMenu;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.CheckBox ckbCopyToClipBoard;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox ckbPasteFromClipBoard;
        private System.Windows.Forms.TextBox tbSource;
        private System.Windows.Forms.TextBox tbTarget;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbVigenereKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbHillKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbAffineKeyA;
        private System.Windows.Forms.Button btnGenRandomKey;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbAffineKeyB;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnExportKeys;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnImportKeys;
    }
}

