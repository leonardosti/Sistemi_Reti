using System;

namespace BinInt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool[] b = new bool[32];
            int[] dp = new int[4];
            string bit = "";
            int cnt = 0;

            // Conversione binario a intero
            Console.WriteLine("Inserire il numero in binario (max 32 bit)");
            bit = Console.ReadLine();
            for (int i = 32 - bit.Length; i < b.Length; i++)
            {
                if (bit[cnt] == '1')
                {
                    b[i] = true;
                }
                cnt++;
            }
            Console.WriteLine($"Numero intero: {Convert_Binario_To_Intero(b)}");
            // Conversione decimale puntato a intero
            Console.WriteLine("Inserire il numero decimale puntato (max 4 cifre)");
            bit = Console.ReadLine();
            string[] vet = bit.Split('.');
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = Convert.ToInt32(vet[i]);
            }
            Console.WriteLine($"Numero intero: {Convert_Decimale_Puntato_To_Intero(dp)}");
            Console.ReadLine();
        }
        static int Convert_Binario_To_Intero(bool[] b)
        {
            int risultato = 0, potenza = 0;
            for (int i = b.Length - 1; i >= 0; i--)
            {
                risultato += Convert.ToInt32(b[i]) * (int)Math.Pow(2, potenza);
                potenza++;
            }
            return risultato;
        }
        static long Convert_Decimale_Puntato_To_Intero(int[] dp)
        {
            long risultato = 0;
            int potenza = 0;
            for (int i = dp.Length - 1; i >= 0; i--)
            {
                risultato += Convert.ToInt32(dp[i]) * (long)Math.Pow(256, potenza);
                potenza++;
            }
            return risultato;
        }
    }
}
