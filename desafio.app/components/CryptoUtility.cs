using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace desafio.app
{
    public class CryptoUtility
    {
       public static string GetMD5Hash(string input)
       {
            using (System.Security.Cryptography.MD5 md5 = 
            System.Security.Cryptography.MD5.Create())
            {
                byte[] retVal = md5.ComputeHash(Encoding.Unicode.GetBytes(input));
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
                
                return sb.ToString();
            }
       }
    }
}