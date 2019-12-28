namespace CryptographyDesign.Cipher
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="Plain">明文类型</typeparam>
    /// <typeparam name="Cipher">密文类型</typeparam>
    interface ICipher<Plain, Cipher>
    {
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="plain"></param>
        /// <returns></returns>
        Cipher Encrypt(Plain plain);

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="cipher"></param>
        /// <returns></returns>
        Plain Decrypt(Cipher cipher);

        /// <summary>
        /// 判断明文格式是否正确
        /// </summary>
        /// <param name="plain">明文</param>
        /// <param name="message">信息，如果不正确，则返回错误信息</param>
        /// <param name="sender">信息的来源，显示信息是从哪个类中返回的</param>
        /// <returns>格式是否正确</returns>
        bool IsPlainSuitable(Plain plain, out string message, out string sender);

        /// <summary>
        /// 判断密文格式是否正确
        /// </summary>
        /// <param name="cipher">密文</param>
        /// <param name="message">信息，如果不正确，则返回错误信息</param>
        /// <param name="sender">信息的来源，显示信息是从哪个类中返回的</param>
        /// <returns>格式是否正确</returns>
        bool IsCipherSuitable(Cipher cipher, out string message, out string sender);
    }
}
