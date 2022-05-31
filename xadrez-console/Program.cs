using System;
using TabuleiroXadrez;
using JogoXadrez;


namespace xadrez_console
{

    internal class Program
    {
        static void Main(string[] args)
        {

            PartidaXadrez partida = new PartidaXadrez();


            while (!partida.isMatchOver)
            {
                try
                {
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.Tab);
                    Console.WriteLine("Turno: " + partida.Turno.ToString());
                    Console.WriteLine("Aguardando jogada: " + partida.JogadorAtual);
                    Console.Write("Informe a peça a ser movimentada: ");
                    Posicao origem = Tela.LerPosicaoXadrez().toPosicao();
                    partida.ValidarPosicaoOrigem(origem);

                    bool[,] posicoesPossiveis = partida.Tab.GetPeca(origem).MovimentosPossiveis();
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.Tab, posicoesPossiveis);
                    
                    Console.WriteLine("Turno: " + partida.Turno.ToString());
                    Console.WriteLine("Aguardando jogada: " + partida.JogadorAtual);
                    Console.Write("Destino: ");
                    Posicao destino = Tela.LerPosicaoXadrez().toPosicao();
                    partida.ValidarPosicaoDestino(origem, destino);
                    partida.RealizarJogada(origem, destino);

                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Pressione enter para jogar novamente");
                    Console.ReadLine();
                }

            }





        }
    }
}
