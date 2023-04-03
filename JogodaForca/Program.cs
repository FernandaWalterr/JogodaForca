using System.Runtime.Intrinsics.X86;
using System;

namespace JogodaForca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] palavras = { "ABACATE", "ABACAXI", "ACEROLA", "AÇAÍ", "ARAÇA", "ABACATE", "BACABA", "BACURI", "BANANA", "CAJÁ", "CAJÚ", "CARAMBOLA", "CUPUAÇU", "GRAVIOLA", "GOIABA", "JABUTICABA", "JENIPAPO", "MAÇÃ", "MANGABA", "MANGA", "MARACUJÁ", "MURICI", "PEQUI", "PITANGA", "PITAYA", "SAPOTI", "TANGERINA", "UMBU", "UVA", "UVAIA" };

            Random random = new Random();
            string palavra = palavras[random.Next(palavras.Length)];
            char[] letras = palavra.ToCharArray();
            char[] letrasDescobertas = new char[letras.Length];
            for (int i = 0; i < letrasDescobertas.Length; i++)
            {
                letrasDescobertas[i] = '_';
            }

            int tentativasRestantes = 5;
            while (tentativasRestantes > 0 && Array.IndexOf(letrasDescobertas, '_') >= 0)
            {
                Console.WriteLine("Palavra: " + String.Join(" ", letrasDescobertas));
                Console.WriteLine("Tentativas restantes: " + tentativasRestantes);
                Console.Write("Digite uma letra: ");
                char letra = Console.ReadLine().ToUpper()[0];

                bool acertou = false;
                for (int i = 0; i < letras.Length; i++)
                {
                    if (letras[i] == letra)
                    {
                        letrasDescobertas[i] = letra;
                        acertou = true;
                    }
                }

                if (!acertou)
                {
                    tentativasRestantes--;
                }
            }

            if (tentativasRestantes == 0)
            {
                Console.WriteLine("Você perdeu! A palavra era " + palavra + ".");
            }
            else
            {
                Console.WriteLine("Parabéns, você ganhou! A palavra era " + palavra + ".");
            }
        }
    }