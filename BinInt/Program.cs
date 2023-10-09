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
            long numero = 0;
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

            Console.WriteLine($"Numero intero: {Convert_Binario_To_Decimale_Puntato(b)}");

            Console.WriteLine($"Numero intero: {Convert_Decimale_Puntato_To_Binario(dp)}");

            Console.WriteLine("Inserire numero");
            numero = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine($"Numero intero: {Convert_Numero_Decimale_To_Binario(numero)}");

            Console.WriteLine("Inserire numero");
            numero = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine($"Numero intero: {Convert_Numero_Decimale_To_Decimale_Puntato(numero)}");

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
        static int[] Convert_Binario_To_Decimale_Puntato(bool[] b)
        {
            int[] risultato = new int[4];
            int indice = b.Length - 1;
            double n = 0;
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 8; i++)
                {
                    if (b[indice])
                    {
                        n += (1 * Math.Pow(2, i));
                        indice--;
                    }
                }
                risultato[j] = Convert.ToInt32(n);
                n = 0;
            }
            return risultato;
        }
        static bool[] Convert_Decimale_Puntato_To_Binario(int[] dp)
        {
            bool[] risultato = new bool[32];
            int resto, indice = risultato.Length - 1;
            for (int i = 0; i < 4; i++)
            {
                do
                {
                    resto = dp[i] % 2;
                    if (resto == 1)
                    {
                        risultato[indice] = true;
                    }
                    indice--;
                    dp[i] = dp[i] / 2;
                } while (dp[i] > 0);

            }
            return risultato;
        }
        static bool[] Convert_Numero_Decimale_To_Binario(long numero)
        {
            long resto;
            bool[] risultato = new bool[32];
            int indice = risultato.Length - 1;
            do
            {
                resto = numero % 2;
                if (resto == 1)
                {
                    risultato[indice] = true;
                }
                indice--;
                numero = numero / 2;
            } while (numero > 0);
            return risultato;
        }
        static int[] Convert_Numero_Decimale_To_Decimale_Puntato(long numero)
        {
            int[] risultato = new int[4];
            int indice = 0;
            long resto;
            do
            {
                resto = numero % 256;
                risultato[indice] = Convert.ToInt32(resto);
                numero = numero / 256;
                indice++;

            } while (numero > 0);
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(risultato[i]);
            }
            return risultato;

        }
    }
}
