
using System.Security.Cryptography;
using System.Text;

namespace NetCRUD2.Utils 
{
    public class Crytography 
    {
        public static string GetHash(HashAlgorithm hashAlgorithm, string input)
        {
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));
            var sBuider = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuider.Append(data[i].ToString("x2"));
            }
            return sBuider.ToString();
        }
        public static bool VerifyHash(HashAlgorithm hashAlgorithm, string input, string hash)
        {
            var hashOfInput = GetHash(hashAlgorithm, input);
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            return comparer.Compare(hashOfInput, hash) == 0;
        }
    }
    

}

