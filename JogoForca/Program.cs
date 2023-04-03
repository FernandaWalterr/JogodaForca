namespace JogoForca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Lista de palavras para escolher
            List<string> palavras = new List<string>()
            {
                "ABACATE", "ABACAXI", "ACEROLA", "AÇAÍ", "ARAÇA", "ABACATE", "BACABA", "BACURI", "BANANA", "CAJÁ",
                "CAJÚ", "CARAMBOLA", "CUPUAÇU", "GRAVIOLA", "GOIABA", "JABUTICABA", "JENIPAPO", "MAÇÃ", "MANGABA", "MANGA",
                "MARACUJÁ", "MURICI", "PEQUI", "PITANGA", "PITAYA", "SAPOTI", "TANGERINA", "UMBU", "UVA", "UVAIA"
            };

            // Escolhe uma palavra aleatória
            Random random = new Random();
            string palavraEscolhida = palavras[random.Next(palavras.Count)];

            // Cria uma string com a mesma quantidade de caracteres da palavra escolhida, mas preenchida com "_"
            string palavraAdivinhada = new string('_', palavraEscolhida.Length);

            // Inicializa o contador de letras erradas
            int letrasErradas = 0;

            // Laço principal do jogo
            while (letrasErradas < 5 && palavraAdivinhada.Contains('_'))
            {
                // Mostra o desenho da forca atual
                DesenharForca(letrasErradas);

                // Mostra a palavra adivinhada até o momento
                Console.WriteLine(palavraAdivinhada);

                // Pede para o usuário chutar uma letra
                Console.Write("Chute uma letra: ");
                char letraChutada = Console.ReadLine()[0];

                // Verifica se a letra chutada está presente na palavra escolhida
                bool letraAcertada = false;
                for (int i = 0; i < palavraEscolhida.Length; i++)
                {
                    if (palavraEscolhida[i] == letraChutada)
                    {
                        palavraAdivinhada = palavraAdivinhada.Remove(i, 1).Insert(i, letraChutada.ToString());
                        letraAcertada = true;
                    }
                }

                // Se a letra não foi acertada, incrementa o contador de letras erradas
                if (!letraAcertada)
                {
                    letrasErradas++;
                }
            }

            // Mostra o resultado do jogo
            if (letrasErradas >= 5)
            {
                DesenharForca(letrasErradas);
                Console.WriteLine("Você perdeu! A palavra era '{0}'", palavraEscolhida);
            }
            else
            {
                Console.WriteLine(palavraAdivinhada);
                Console.WriteLine("Parabéns, você ganhou!");
            }

            Console.ReadLine();
        }

        // Método que desenha a forca de acordo com a quantidade de letras erradas
        private static void DesenharForca(int quantidadeErros)
        {
            // operação ternária
            string cabecaDoBoneco = quantidadeErros >= 1 ? " o " : " ";
            string bracoEsquerdo = quantidadeErros >= 3 ? "/" : " ";
            string tronco = quantidadeErros >= 2 ? "x" : " ";
            string troncoBaixo = quantidadeErros >= 2 ? " x " : " ";
            string bracoDireito = quantidadeErros >= 3 ? @"\" : " ";
            string pernas = quantidadeErros >= 4 ? "/ \\" : " ";

            Console.Clear();
            Console.WriteLine(" ___________        ");
            Console.WriteLine(" |/        |        ");
            Console.WriteLine(" |        {0}       ", cabecaDoBoneco);
            Console.WriteLine(" |        {0}{1}{2} ", bracoEsquerdo, tronco, bracoDireito);
            Console.WriteLine(" |        {0}       ", troncoBaixo);
            Console.WriteLine(" |        {0}       ", pernas);
            Console.WriteLine(" |                  ");
            Console.WriteLine(" |                  ");
            Console.WriteLine("_|____              ");
        }
    }
}