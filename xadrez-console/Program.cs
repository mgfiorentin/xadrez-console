using System;
using TabuleiroXadrez;
using JogoXadrez;


namespace xadrez_console
{

    internal class Program
    {
        static void Main(string[] args)
        {
           
            Tabuleiro tab = new Tabuleiro(8,8);

            tab.ColocarPeca(new Rei(Cor.Preta, tab), new Posicao(0, 3));
            

            Tela.ImprimirTabuleiro(tab);
            

        }
    }
}
