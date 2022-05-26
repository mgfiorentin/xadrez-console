using System;
using TabuleiroXadrez;


namespace xadrez_console
{

    internal class Program
    {
        static void Main(string[] args)
        {
           
            Tabuleiro tab = new Tabuleiro(8,8);

            Tela.ImprimeTela(tab);
            

        }
    }
}
