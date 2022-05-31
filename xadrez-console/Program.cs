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
                PartidaXadrez partida = new PartidaXadrez();
                
               
                while(!partida.isMatchOver)
                {
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.Tab);

                    Console.Write("Informe a peça a ser movimentada: ");
                    Posicao origem = Tela.LerPosicaoXadrez().toPosicao();

                    bool[,] posicoesPossiveis = partida.Tab.GetPeca(origem).MovimentosPossiveis();
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.Tab, posicoesPossiveis);

                    Console.Write("Destino: ");
                    Posicao destino = Tela.LerPosicaoXadrez().toPosicao();

                    partida.ExecutarMovimento(origem, destino);

                }

            }




            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }
    }
}
