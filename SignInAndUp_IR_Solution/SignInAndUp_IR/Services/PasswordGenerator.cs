using System.Collections;
using System.Security.Cryptography;
using System.Text;

namespace SignInAndUp_IR.Services
{
    public interface IPasswordGenerator
    {
        string GetRandomPassword();
    }

    public class PasswordGenerator : IPasswordGenerator
    {
        const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789+-";
        const int length = 10;

        public string GetRandomPassword()
        {
            StringBuilder result = new StringBuilder();

            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                var test = chars.Length;

                for (int i = 0; i < length; i++)
                {
                    byte[] rndByte = new byte[1];

                    rng.GetBytes(rndByte);
                    BitArray bitArr = new BitArray(rndByte);
                    bitArr.Set(7, false);
                    bitArr.Set(6, false);
                    bitArr.CopyTo(rndByte, 0);
                    int rndInt = rndByte[0];

                    result.Append(chars[rndInt]);
                }
            }

            return result.ToString();
        }
    }
}
