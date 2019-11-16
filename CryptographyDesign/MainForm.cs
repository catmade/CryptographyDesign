using CryptographyDesign.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptographyDesign
{
    public partial class MainForm : Form
    {
        private MyCipher myCipher;

        public MainForm()
        {
            InitializeComponent();
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 初始化加密对象
        /// </summary>
        /// <returns>初始化成功则返回true</returns>
        private bool init()
        {
            //try
            //{
                int[,] keys = { { 123, 232, 185, 122 }, { 15, 879, 154, 665 }, { 12, 202, 356, 123 }, { 12, 15, 54, 546 } };
                int[][] key = new int[4][];
                for (int i = 0; i < 4; i++)
                {
                    key[i] = new int[4];
                    for (int j = 0; j < 4; j++)
                    {
                        key[i][j] = keys[i, j];
                    }
                }
                myCipher = new MyCipher(key);
                // 去除字符串前后的空白符
                tbSource.Text = tbSource.Text.Trim();
                return true;
            //}
            //catch (Exception exc)
            //{
            //    MessageBox.Show(exc.Message, "出错了", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return false;
            //}
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (!init())
            {
                return;
            }
            tbTarget.Text = myCipher.Encrypt(tbSource.Text);
            if (ckbCopyToClipBoard.Checked)
            {
                Clipboard.SetDataObject(tbTarget.Text);
            }
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (!init())
            {
                return;
            }

            if (ckbPasteFromClipBoard.Checked)
            {
                if (!string.Empty.Equals(Clipboard.GetText()))
                {
                    tbSource.Text = Clipboard.GetText();
                }
            }
            tbTarget.Text = myCipher.Decrypt(tbSource.Text);
        }
    }
}
