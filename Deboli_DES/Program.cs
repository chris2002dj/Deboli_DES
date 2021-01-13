using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Deboli_DES
{
    class Program
    {
        static void Main(string[] args)
        {
            // Parametri di cifratura
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] key = new byte[8] { 49, 50, 51, 52, 53, 54, 55, 56 };
            des.Key = key;
            des.IV = key;

            /*
            string pw;
            byte[] key = Encoding.ASCII.GetBytes(pw);
            des.Key = key;
            des.IV = key;
            */

            // Processo di cifratura
            Console.WriteLine("Inserisci un testo da cifrare:");
            string plaintText = Console.ReadLine();

            byte[] plainData = Encoding.ASCII.GetBytes(plaintText);
            ICryptoTransform enc = des.CreateEncryptor();
            byte[] encData = enc.TransformFinalBlock(plainData, 0, plainData.Length);

            foreach (var item in encData)
            {
                Console.Write(item + "-");
            }

            Console.WriteLine();

            // Processo di decifratura
            ICryptoTransform dec = des.CreateDecryptor();
            byte[] decData = dec.TransformFinalBlock(encData, 0, encData.Length);
            string decText = Encoding.ASCII.GetString(decData);

            Console.WriteLine("Testo decifrato: " + decText);

            Console.ReadLine();
        }
    }
}
