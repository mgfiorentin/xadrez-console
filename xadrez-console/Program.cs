using System;
using TabuleiroXadrez;
using JogoXadrez;


namespace xadrez_console
{

    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Tabuleiro tab = new Tabuleiro(8, 8);


                tab.ColocarPeca(new Rei(Cor.Preta, tab), new Posicao(0, 4));
                tab.ColocarPeca(new Torre(Cor.Preta, tab), new Posicao(0, 5));

                Tela.ImprimirTabuleiro(tab);
            } 

            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }
    }
}
