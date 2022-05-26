using TabuleiroXadrez;
using System;

namespace xadrez_console
{
    internal class Tela
    {

        public static void ImprimeTela(Tabuleiro tab)
        {

            int i, j = 0;

            for (i=0; i<tab.Linhas; i++)
            {

                for (j=0; j<tab.Colunas; j++)
                {
                    if (tab.Pecas[i, j] == null)
                    {
                        Console.Write(" -");
                    }


                    else Console.Write(tab.Pecas[i, j] + " ");

                }

                Console.WriteLine();


            }

        }

    }
}
