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
            this.notifyMenu.SuspendLayout();
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
            this.btnEncrypt.Location = new System.Drawing.Point(351, 77);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(75, 23);
            this.btnEncrypt.TabIndex = 5;
            this.btnEncrypt.Text = "加密";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(351, 300);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(75, 23);
            this.btnDecrypt.TabIndex = 6;
            this.btnDecrypt.Text = "解密";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // ckbCopyToClipBoard
            // 
            this.ckbCopyToClipBoard.AutoSize = true;
            this.ckbCopyToClipBoard.Location = new System.Drawing.Point(351, 106);
            this.ckbCopyToClipBoard.Name = "ckbCopyToClipBoard";
            this.ckbCopyToClipBoard.Size = new System.Drawing.Size(96, 16);
            this.ckbCopyToClipBoard.TabIndex = 7;
            this.ckbCopyToClipBoard.Text = "复制到剪切板";
            this.toolTip1.SetToolTip(this.ckbCopyToClipBoard, "当勾选此项时，点击加密按钮后，\r\n会将加密结果复制到系统剪切板中");
            this.ckbCopyToClipBoard.UseVisualStyleBackColor = true;
            // 
            // ckbPasteFromClipBoard
            // 
            this.ckbPasteFromClipBoard.AutoSize = true;
            this.ckbPasteFromClipBoard.Location = new System.Drawing.Point(351, 329);
            this.ckbPasteFromClipBoard.Name = "ckbPasteFromClipBoard";
            this.ckbPasteFromClipBoard.Size = new System.Drawing.Size(96, 16);
            this.ckbPasteFromClipBoard.TabIndex = 8;
            this.ckbPasteFromClipBoard.Text = "从剪切板粘贴";
            this.toolTip1.SetToolTip(this.ckbPasteFromClipBoard, "当勾选此项时，点击解密按钮后，\r\n将会读取剪切板中的文本，并将作为密文解密");
            this.ckbPasteFromClipBoard.UseVisualStyleBackColor = true;
            // 
            // tbSource
            // 
            this.tbSource.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbSource.Location = new System.Drawing.Point(24, 69);
            this.tbSource.Multiline = true;
            this.tbSource.Name = "tbSource";
            this.tbSource.Size = new System.Drawing.Size(286, 283);
            this.tbSource.TabIndex = 9;
            // 
            // tbTarget
            // 
            this.tbTarget.Location = new System.Drawing.Point(476, 69);
            this.tbTarget.Multiline = true;
            this.tbTarget.Name = "tbTarget";
            this.tbTarget.Size = new System.Drawing.Size(286, 283);
            this.tbTarget.TabIndex = 9;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tbTarget);
            this.Controls.Add(this.tbSource);
            this.Controls.Add(this.ckbPasteFromClipBoard);
            this.Controls.Add(this.ckbCopyToClipBoard);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.btnEncrypt);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "剪切板内容加解密工具";
            this.notifyMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}

