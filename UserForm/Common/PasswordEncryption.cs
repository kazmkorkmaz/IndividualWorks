using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserForm.Common
{
    public class PasswordEncryption
    {
        public string Encode(string password)
        {
            byte[] EncDataByte = new byte[password.Length];
            EncDataByte = System.Text.Encoding.UTF8.GetBytes(password);
            string EncryptedData = Convert.ToBase64String(EncDataByte);
            return EncryptedData;
        }
        public string Decode(string password)
        {
            var encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecodeByte = Convert.FromBase64String(password);
            int charCount = utf8Decode.GetCharCount(todecodeByte, 0, todecodeByte.Length);
            char[] decodedChar = new char[charCount];
            utf8Decode.GetChars(todecodeByte, 0, todecodeByte.Length, decodedChar, 0);
            string result = new String(decodedChar);
            return result;
        }
    }
}
