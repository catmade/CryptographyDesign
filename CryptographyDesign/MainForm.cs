using CryptographyDesign.utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CryptographyDesign
{
    public partial class MainForm : Form
    {
        private MyCipher myCipher;

        private MyCipherKeys myCipherKeys = new MyCipherKeys();

        public MainForm()
        {
            InitializeComponent();
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region 点击加密按钮前的准备，获取密钥并判断是否合适

        ///// <summary>
        ///// 初始化加密对象
        ///// </summary>
        ///// <returns>初始化成功则返回true</returns>
        //private bool init()
        //{
        //    if (!isKeysStringOk)
        //    {
        //        MessageBox.Show($"密钥格式错误，请核对密钥格式后再试。或者点击“{this.btnGenRandomKey.Text}”按钮，即可自动生成随机密钥",
        //            "密钥错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }
        //    // 初始化
        //    // 获取维吉尼亚密码的密钥
        //    int[] vigenereKey = StringToIntArray(tbVigenereKey.Text);

        //    // 生成仿射密码的密钥
        //    int affineKeyA = int.Parse(tbAffineKeyA.Text);
        //    int affineKeyB = int.Parse(tbAffineKeyB.Text);
        //    if (!AffineCipher.IsKeyASuitable(affineKeyA))
        //    {
        //        MessageBox.Show("仿射密码的参数a必须要与26互素数，必须为以下值中的一个：\n" +
        //            "1, 3, 5, 7, 9, 11, 15, 17, 19, 21, 23, 25",
        //            "密钥错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }

        //    // 生成希尔密码的加密矩阵
        //    int[,] hillMatrix;
        //    try
        //    {
        //        hillMatrix = StringToIntMatrix(tbHillKey.Text);
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message,
        //            "密钥错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }

        //    // 如果矩阵行列式为 0, 说明没有逆矩阵
        //    if (!new MatrixIntGF26(hillMatrix).HasInverse())
        //    {
        //        MessageBox.Show("希尔密码的加密矩阵错误，加密矩阵必须为可逆矩阵",
        //            "密钥错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }

        //    // 初始化
        //    this.myCipher = new MyCipher(vigenereKey, affineKeyA, affineKeyB, hillMatrix);

        //    return true;
        //}

        private int[] StringToIntArray(string s)
        {
            s = s.Trim();
            Regex regex = new Regex("\\s+");
            var nums = regex.Split(s);
            int[] result = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                result[i] = int.Parse(nums[i]);
            }

            return result;
        }

        private int[,] StringToIntMatrix(string s)
        {
            s = s.Trim();
            Regex regexNewLine = new Regex("\\r\\n|\\n|\\r");
            Regex regexBlank = new Regex("[ ]");

            var lines = regexNewLine.Split(s);
            int column = regexBlank.Split(lines[0]).Length;

            int[,] result = new int[lines.Length, column];

            for (int i = 0; i < lines.Length; i++)
            {
                var items = regexBlank.Split(lines[i]);
                if (items.Length != column)
                {
                    throw new Exception($"矩阵格式错误，并不是每个位置都有数据");
                }
                for (int j = 0; j < items.Length; j++)
                {
                    result[i, j] = int.Parse(items[j]);
                }
            }


            return result;
        }

        #endregion

        #region 按钮的监听事件
        /// <summary>
        /// 加密按钮点击后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            // 如果加密算法初始化失败
            if (!myCipherKeys.AllKeysReady)
            {
                MessageBox.Show("请检查密钥是否符合要求",
                    "出错了", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            myCipher = new MyCipher(myCipherKeys);

            // 判断源文本是否符合要求
            if (!isSourceStringOk || "".Equals(tbSource.Text))
            {
                MessageBox.Show("请检查【明文/密文】输入框中的待处理文本是否符合要求",
                    "出错了", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 将明文转成全小写
            this.tbSource.Text = this.tbSource.Text.ToLower();

            try
            {
                tbTarget.Text = myCipher.Encrypt(tbSource.Text);
            }
            catch (Exception exc)
            {
                MessageBox.Show($"加密信息的过程中出错了，错误信息：{exc.Message}",
                    "出错了", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (ckbCopyToClipBoard.Checked)
            {
                Clipboard.SetDataObject(tbTarget.Text);
            }
        }

        /// <summary>
        /// 解密按钮点击后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            // 如果加密算法初始化失败
            if (!myCipherKeys.AllKeysReady)
            {
                MessageBox.Show("请检查密钥是否符合要求",
                    "出错了", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            myCipher = new MyCipher(myCipherKeys);

            // 判断源文本是否符合要求
            if (!isSourceStringOk || "".Equals(tbSource.Text))
            {
                MessageBox.Show("请检查【明文/密文】输入框中的待处理文本是否符合要求",
                    "出错了", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ckbPasteFromClipBoard.Checked)
            {
                if (!string.Empty.Equals(Clipboard.GetText()))
                {
                    try
                    {
                        tbSource.Text = Clipboard.GetText();
                    }
                    catch (Exception exp)
                    {

                        MessageBox.Show(exp.Message,
                            "出错了", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            try
            {
                tbTarget.Text = myCipher.Decrypt(tbSource.Text);
            }
            catch (Exception exc)
            {
                MessageBox.Show($"解密信息的过程中出错了，错误信息：{exc.Message}",
                    "出错了", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 将密钥保存到本地按钮被点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportKeys_Click(object sender, EventArgs e)
        {
            if (!myCipherKeys.AllKeysReady)
            {
                MessageBox.Show("保存文件出错，错误信息：密钥信息不完整，请重新检查密钥格式", "保存文件出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var s = JsonConvert.SerializeObject(myCipherKeys, Formatting.Indented);
            string fileName = DateTime.Now.ToString("yyyyMMddhhmmss") + ".json";
            //string fileName = DateTime.Now.ToString("'yyyy-MM-dd-hh:mm:ss'") + ".json";
            string path = Path.Combine(Environment.CurrentDirectory, @fileName);

            // 写入文件
            try
            {
                File.WriteAllText(@path, s, Encoding.UTF8);
            }
            catch (Exception exc)
            {
                MessageBox.Show("保存文件出错，错误信息：" + exc.Message, "保存文件出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = MessageBox.Show($"保存文件成功，文件路径：{path}\n\n是否打开此目录", "保存文件成功", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            // 打开目录
            if (result == DialogResult.Yes)
            {
                System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe")
                {
                    Arguments = "/e,/select," + path
                };
                System.Diagnostics.Process.Start(@psi);
            }

        }

        /// <summary>
        /// 从本地读取密钥
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImportKeys_Click(object sender, EventArgs e)
        {
            var a = this.openFileDialog1.ShowDialog();
            if (a != DialogResult.OK)
            {
                return;
            }

            try
            {
                this.myCipherKeys = JsonConvert.DeserializeObject<MyCipherKeys>(
                File.ReadAllText(this.openFileDialog1.FileName,
                Encoding.UTF8));

                // 填充数据
                this.tbVigenereKey.Text = ArrayToString(this.myCipherKeys.VigenereKey);

                if (this.myCipherKeys.AffineKeyA == MyCipherKeys.InvalidIntValue) { this.tbAffineKeyA.Text = String.Empty; }
                else { this.tbAffineKeyA.Text = this.myCipherKeys.AffineKeyA.ToString(); }

                if (this.myCipherKeys.AffineKeyB == MyCipherKeys.InvalidIntValue) { this.tbAffineKeyB.Text = String.Empty; }
                else { this.tbAffineKeyB.Text = this.myCipherKeys.AffineKeyB.ToString(); }

                this.tbHillKey.Text = MatrixToString(this.myCipherKeys.HillMatrix);
            }
            catch (Exception exc)
            {
                MessageBox.Show("读取文件出错，错误信息：" + exc.Message, "读取文件出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region 生成随机密钥

        private void btnGenRandomKey_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            // 生成维吉尼亚密码的密钥
            List<int> vigenereKm = new List<int>();
            for (int i = 0; i < random.Next(3, 15); i++)
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
            int[,] vs = new int[rank, rank];
            while (true)
            {
                for (int i = 0; i < rank; i++)
                {
                    for (int j = 0; j < rank; j++)
                    {
                        vs[i, j] = random.Next(1, 25);
                    }
                }

                if (new MatrixIntGF26(vs).HasInverse())
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
            if (items == null)
            {
                return string.Empty;
            }

            StringBuilder builder = new StringBuilder();
            foreach (var item in items)
            {
                builder.Append(item.ToString().PadLeft(2, '0')).Append(" ");
            }
            return builder.ToString().TrimEnd();
        }

        /// <summary>
        /// 将数组数据转换成字符串，格式为：每个数用空格分开
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        private string ArrayToString(int[] items)
        {
            if (items == null)
            {
                return string.Empty;
            }

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
        private string MatrixToString(int[,] matrix)
        {
            if (matrix == null)
            {
                return string.Empty;
            }

            StringBuilder builder = new StringBuilder();
            int row = matrix.GetLength(0);
            int column = matrix.GetLength(1);

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    // 两位宽度，左对齐
                    builder.Append(matrix[i, j].ToString().PadLeft(2, '0'));
                    if (j != column - 1)
                    {
                        builder.Append(' ');
                    }
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

        /// <summary>
        /// 格式为：
        ///     1.数字格式为：0 ~ 9 或 00 ~ 09 或 10 ~ 19 或 20 ~ 25
        ///     2.每行的数字之间用一个空格分割开
        ///     3.每行的结尾一个换行，换行符为：\n 或 \r 或 \r\n
        /// </summary>
        //private static Regex regexHillKeyText = new Regex("^\\s*(([0-9]|0\\d|1\\d|2[0-5]) )*([0-9]|0\\d|1\\d|2[0-5])$");
        private static string regexSingleLineText = "(([0-9]|0\\d|1\\d|2[0-5])[ ])*([0-9]|0\\d|1\\d|2[0-5])";
        private static Regex regexHillKeyText = new Regex("^(((([0-9]|0\\d|1\\d|2[0-5])[ ])*([0-9]|0\\d|1\\d|2[0-5]))[\\r|\\n|\\r\\n])*(([0-9]|0\\d|1\\d|2[0-5])[ ])*([0-9]|0\\d|1\\d|2[0-5])$");
        // TODO 优先级高，限定

        /// <summary>
        /// 格式为：
        ///    0 ~ 9 或 00 ~ 09 或 10 ~ 19 或 20 ~ 25
        /// </summary>
        private static Regex regexAffineKeyAText = new Regex("^[0-9]|0\\d|1\\d|2[0-5]$");

        /// <summary>
        /// 格式为：
        ///    0 ~ 9 或 00 ~ 09 或 10 ~ 19 或 20 ~ 25
        /// </summary>
        private static Regex regexAffineKeyBText = new Regex("^[0-9]|0\\d|1\\d|2[0-5]$");

        /// <summary>
        /// 格式为：
        ///     1.数字格式为：0 ~ 9 或 00 ~ 09 或 10 ~ 19 或 20 ~ 25
        ///     2.每行的数字之间用一个空格分割开
        /// </summary>
        private static Regex regexVigenereKeyText = new Regex($"^{regexSingleLineText}$");

        public bool isSourceStringOk { get; private set; }

        private void tbSource_TextChanged(object sender, EventArgs e)
        {
            if (!regexSourceText.IsMatch(this.tbSource.Text))
            {
                this.errorProvider1.SetError(this.tbSource,
                    $"数据格式错误，仅接收26个字母，不区分大小写，但是程序会自动全部转成小写");
                isSourceStringOk = false;
                return;
            }

            this.errorProvider1.SetError(this.tbSource, null);
            isSourceStringOk = true;
        }

        private void tbHillKey_TextChanged(object sender, EventArgs e)
        {
            //if (!regexHillKeyText.IsMatch(this.tbHillKey.Text))
            //{
            //    this.errorProvider1.SetError(this.tbHillKey,
            //        $"数据格式错误，矩阵为方阵，每项为0-25的整数，每行的数之间用一个空格分隔");
            //    isKeysStringOk = false;
            //    return;
            //}

            int[,] hillMatrix;
            try
            {
                hillMatrix = StringToIntMatrix(tbHillKey.Text);
            }
            catch (Exception exc)
            {
                this.errorProvider1.SetError(this.tbHillKey, exc.Message);
                this.myCipherKeys.HillMatrix = null;
                return;
            }

            // 如果矩阵行列式为 0, 说明没有逆矩阵
            if (!new MatrixIntGF26(hillMatrix).HasInverse())
            {
                this.errorProvider1.SetError(this.tbHillKey, "希尔密码的加密矩阵错误，加密矩阵必须为可逆矩阵");
                this.myCipherKeys.HillMatrix = null;
                return;
            }

            this.errorProvider1.SetError(this.tbHillKey, null);
            this.myCipherKeys.HillMatrix = hillMatrix;
        }

        private void tbAffineKeyA_TextChanged(object sender, EventArgs e)
        {
            if (!regexAffineKeyAText.IsMatch(this.tbAffineKeyA.Text))
            {
                this.errorProvider1.SetError(this.tbAffineKeyA,
                    $"数据格式错误，数据为0-25之间的整数");
                this.myCipherKeys.AffineKeyA = MyCipherKeys.InvalidIntValue;
                return;
            }

            int affineKeyA = int.Parse(tbAffineKeyA.Text);
            if (!AffineCipher.IsKeyASuitable(affineKeyA, out string message))
            {
                this.errorProvider1.SetError(this.tbAffineKeyA, message);
                this.myCipherKeys.AffineKeyA = MyCipherKeys.InvalidIntValue;
                return;
            }

            this.myCipherKeys.AffineKeyA = affineKeyA;

            this.errorProvider1.SetError(this.tbAffineKeyA, null);
        }

        private void tbAffineKeyB_TextChanged(object sender, EventArgs e)
        {
            if (!regexAffineKeyBText.IsMatch(this.tbAffineKeyB.Text))
            {
                this.errorProvider1.SetError(this.tbAffineKeyB,
                    $"数据格式错误，数据为0-25之间的整数");
                this.myCipherKeys.AffineKeyB = MyCipherKeys.InvalidIntValue;
                return;
            }

            this.myCipherKeys.AffineKeyB = int.Parse(tbAffineKeyB.Text);

            this.errorProvider1.SetError(this.tbAffineKeyB, null);
        }

        private void TbVigenereKey_TextChanged(object sender, EventArgs e)
        {
            if (!regexVigenereKeyText.IsMatch(this.tbVigenereKey.Text))
            {
                this.errorProvider1.SetError(this.tbVigenereKey,
                    $"数据格式错误，格式为：" + System.Environment.NewLine
                    + "1.数字格式为：0 ~ 9 或 00 ~ 09 或 10 ~ 19 或 20 ~ 25" + System.Environment.NewLine
                    + "2.每行的数字之间用一个空格分割开");
                this.myCipherKeys.VigenereKey = null;
                return;
            }

            this.errorProvider1.SetError(this.tbVigenereKey, null);
            this.myCipherKeys.VigenereKey = StringToIntArray(tbVigenereKey.Text);
        }

        #endregion

        private void ckbPasteFromClipBoard_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
