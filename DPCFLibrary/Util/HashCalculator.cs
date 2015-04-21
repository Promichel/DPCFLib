using System;
using System.Security.Cryptography;

namespace DynaStudios.DPCFLib.Util
{
    public class HashCalculator
    {
        public string Calculate(byte[] array)
        {
            using (var md5 = MD5.Create())
            {
                return ProvideMd5AsString(md5.ComputeHash(array));
            }
        }

        private string ProvideMd5AsString(byte[] computedHash)
        {
            return BitConverter.ToString(computedHash).Replace("-", "");
        }
    }
}
