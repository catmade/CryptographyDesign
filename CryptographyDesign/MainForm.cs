using CryptographyDesign.utils;
using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptographyDesign
{
    public partial class MainForm : Form
    {
        private MyCipher myCipher;

        private bool isKeysOk = false;

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

        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (!init() || !checkSourceTextNoError())
            {
                return;
            }
            // 将明文转成全小写
            this.tbSource.Text = this.tbSource.Text.ToLower();

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


        /// <summary>
        /// 检查输入的待加密的数据格式符合要求
        /// </summary>
        /// <returns>如果符合要求，返回true，否则返回false</returns>
        private bool checkSourceTextNoError()
        {
            return false;
        }

        private void btnSaveKeyToLocal_Click(object sender, EventArgs e)
        {

        }

        #region 生成随机密钥
        private readonly int maxHillKeyItem = 25;
        private readonly int minHillKeyItem = 1;

        private void btnRandomGenKey_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            // 生成维吉尼亚密码的密钥
            List<int> vigenereKm = new List<int>();
            for (int i = 0; i < random.Next(1, 10); i++)
            {
                vigenereKm.Add(random.Next(0, 25));
            }
            this.tbVigenereKey.Text = this.ListToString(vigenereKm);

            // 生成仿射密码的密钥
            int[] aas = new int[] { 1, 3, 5, 7, 9, 11, 15, 17, 19, 21, 23, 25 }; // a的取值范围
            int a = aas[random.Next(0, aas.Length - 1)];
            int b = random.Next(0, 25);
            this.tbAffineKeyA.Text = a.ToString();
            this.tbAffineKeyB.Text = b.ToString();

            // 生成希尔密码的加密矩阵
            int rank = random.Next(5, 10); // 矩阵的阶数
            double[,] vs = new double[rank,rank];
            while (true)
            {
                for (int i = 0; i < rank; i++)
                {
                    for (int j = 0; j < rank; j++)
                    {
                        vs[i, j] = random.Next(1, 25);
                    }
                }
                // 如果矩阵行列式不为 0, 说明有逆矩阵，则跳出循环
                if (CreateMatrix.DenseOfArray(vs).Determinant() != 0)
                {
                    break;
                }
            }
            this.tbHillKey.Text = MatrixToString(vs);
        }

        /// <summary>
        /// 将链表数据转换成字符串，格式为：每个数用空格分开
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        private string ListToString(List<int> items)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var item in items)
            {
                builder.Append(item.ToString().PadLeft(2, '0')).Append(" ");
            }
            return builder.ToString().TrimEnd();
        }

        /// <summary>
        /// 将矩阵转换成字符串，格式为：每个数用空格分割开
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        private string MatrixToString(double[,] matrix)
        {
            StringBuilder builder = new StringBuilder();
            int row = matrix.GetLength(0);
            int column = matrix.GetLength(1);

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    // 两位宽度，左对齐
                    builder.Append(matrix[i, j].ToString().PadLeft(2, '0')).Append(' '); 
                }
                builder.Append(System.Environment.NewLine);
            }

            return builder.ToString().TrimEnd();
        }

        #endregion

        #region 动态限制输入框内容

        /// <summary>
        /// 限制输入的明文和密文的格式
        /// </summary>
        private static Regex regexSourceText = new Regex("^[a-zA-Z]*$");
        private static Regex regexHillKeyText = new Regex("[0-9]+[\\s+]");
        private static Regex regexAffineKeyAText = new Regex("[0-9]+[\\s+]");
        private static Regex regexAffineKeyBText = new Regex("[0-9]+[\\s+]");
        private static Regex regexVigenereKeyText = new Regex("[0-9]+[\\s+]");

        private void tbSource_TextChanged(object sender, EventArgs e)
        {
            if (!regexSourceText.IsMatch(this.tbSource.Text))
            {
                this.errorProvider1.SetError(this.tbSource,
                    $"数据格式错误，仅接收26个字母，不区分大小写，但是程序会自动全部转成小写");
                isKeysOk = false;
            }

            this.errorProvider1.SetError(this.tbSource, null);
            isKeysOk = true;
        }

        private void tbHillKey_TextChanged(object sender, EventArgs e)
        {
            if (!regexSourceText.IsMatch(this.tbHillKey.Text))
            {
                this.errorProvider1.SetError(this.tbSource,
                    $"数据格式错误，矩阵为方阵，且每项为0-25的整数，中间用空格或换行隔开");
                isKeysOk = false;
            }

            this.errorProvider1.SetError(this.tbHillKey, null);
            isKeysOk = true;
        }

        private void tbAffineKeyA_TextChanged(object sender, EventArgs e)
        {
            if (!regexSourceText.IsMatch(this.tbAffineKeyA.Text))
            {
                this.errorProvider1.SetError(this.tbSource,
                    $"数据格式错误，数据为1-25之间的整数");
                isKeysOk = false;
            }

            this.errorProvider1.SetError(this.tbAffineKeyA, null);
            isKeysOk = true;
        }

        private void tbAffineKeyB_TextChanged(object sender, EventArgs e)
        {
            if (!regexSourceText.IsMatch(this.tbSource.Text))
            {
                this.errorProvider1.SetError(this.tbSource,
                    $"数据格式错误，仅接收26个字母，不区分大小写，但是程序会自动全部转成小写");
                isKeysOk = false;
            }

            this.errorProvider1.SetError(this.tbSource, null);
            isKeysOk = true;
        }

        private void tbVigenereKey_TextChanged(object sender, EventArgs e)
        {
            if (!regexSourceText.IsMatch(this.tbSource.Text))
            {
                this.errorProvider1.SetError(this.tbSource,
                    $"数据格式错误，仅接收26个字母，不区分大小写，但是程序会自动全部转成小写");
                isKeysOk = false;
            }

            this.errorProvider1.SetError(this.tbSource, null);
            isKeysOk = true;
        }

        #endregion
    }
}
