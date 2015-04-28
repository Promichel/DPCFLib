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
                return ProvideMd5ByteArrayAsString(md5.ComputeHash(array));
            }
        }

        public byte[] CalculateAsByte(byte[] array)
        {
            using (var md5 = MD5.Create())
            {
                return md5.ComputeHash(array);
            }
        }

        public static string ProvideMd5ByteArrayAsString(byte[] computedHash)
        {
            return BitConverter.ToString(computedHash).Replace("-", "");
        }
    }
}
