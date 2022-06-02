using TabuleiroXadrez;
using System;
using JogoXadrez;
using System.Collections.Generic;

namespace xadrez_console
{
    internal class Tela
    {
        public static void ImprimirPartida(PartidaXadrez partida)
        {
            Console.Clear();
            ImprimirTabuleiro(partida.Tab);
            Console.WriteLine("Peças capturadas:");
            ImprimirPecasCapturadas(partida);
            Console.WriteLine("Turno: " + partida.Turno.ToString());
            Console.WriteLine("Aguardando jogada: " + partida.JogadorAtual);
            Console.Write("\nInforme a peça a ser movimentada: ");
        }


        public static void ImprimirPecasCapturadas(PartidaXadrez partida)
        {
            Console.Write("Brancas: [ ");
            ImprimirConjunto(partida.GetPecasCapturadas(Cor.Branca));
            Console.WriteLine("]");

            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Pretas: [ ");
            ImprimirConjunto(partida.GetPecasCapturadas(Cor.Preta));
            Console.WriteLine("]");
            Console.WriteLine();
            Console.ForegroundColor = aux;
        }

        public static void ImprimirConjunto(HashSet<Peca> pecas)
        {
            foreach (Peca p in pecas)
            {
                Console.Write(p + " ");
            }
        }


        //Percorre todo o tabuleiro imprimindo cada peça
        public static void ImprimirTabuleiro(Tabuleiro tab)
        {
            int i, j = 0;
            for (i = 0; i < tab.Linhas; i++)
            {
                Console.Write((tab.Linhas - i) + " ");
                for (j = 0; j < tab.Colunas; j++)
                {
                    ImprimirPeca(tab.GetPeca(new Posicao(i, j)));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h \n");
        }

        public static void ImprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            int i, j = 0;
            for (i = 0; i < tab.Linhas; i++)
            {
                Console.BackgroundColor = fundoOriginal;
                Console.Write((tab.Linhas - i) + " ");
                for (j = 0; j < tab.Colunas; j++)
                {
                    if (posicoesPossiveis[i, j] == true)
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else Console.BackgroundColor = fundoOriginal;
                    ImprimirPeca(tab.GetPeca(new Posicao(i, j)));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = fundoOriginal;
            Console.WriteLine("  a b c d e f g h ");
        }

        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }

        //Imprime a Peca p com a cor designada
        public static void ImprimirPeca(Peca p)
        {
            if (p == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (p.CorPeca == Cor.Branca)
                {

                    Console.Write(p + " ");
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(p + " ");
                    Console.ForegroundColor = aux;
                }
            }
        }
    }
}

