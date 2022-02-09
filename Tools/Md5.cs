using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace EDPFinal.Tools
{
    public class Md5
    {


        public static string GetMD5(string myString)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            byte[] fromData = System.Text.Encoding.UTF8.GetBytes(myString);//
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {

                byte2String = byte2String + targetData[i].ToString("x2");
            }

            return byte2String;
        }
    }
}
