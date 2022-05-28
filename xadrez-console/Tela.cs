using TabuleiroXadrez;
using System;

namespace xadrez_console
{
    internal class Tela
    {

        public static void ImprimirTabuleiro(Tabuleiro tab)
        {

            int i, j = 0;

            for (i = 0; i < tab.Linhas; i++)
            {

                Console.Write((tab.Linhas - i) + " ");

                for (j = 0; j < tab.Colunas; j++)
                {
                    if (tab.Pecas[i, j] == null)
                    {
                        Console.Write("- ");
                    }

                    else ImprimirPeca(tab.peca(new Posicao(i,j)));
                    

                }

                Console.WriteLine();


            }
            Console.WriteLine("  a b c d e f g h ");

        }

        public static void ImprimirPeca(Peca p)
        {
            if (p.CorPeca == Cor.Branca)
            {
                
                Console.Write(p+ " ");
            }
            else {

                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(p + " ");
                Console.ForegroundColor = aux;

        }

    }
}

}

