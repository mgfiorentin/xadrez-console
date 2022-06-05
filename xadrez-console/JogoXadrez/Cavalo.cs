using System;
using System.Collections.Generic;
using System.Text;
using TabuleiroXadrez;

namespace JogoXadrez
{
    internal class Cavalo : Peca
    {

        public Cavalo(Cor corPeca, Tabuleiro tabPeca) : base(corPeca, tabPeca)
        {


        }

        private bool PodeMover(Posicao pos)
        {
            Peca p = TabPeca.GetPeca(pos);
            return p == null || p.CorPeca != this.CorPeca;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[TabPeca.Linhas, TabPeca.Colunas];

            Posicao pos = new Posicao(0, 0);


            pos.DefinePosicao(PosicaoDaPeca.Linha - 2, PosicaoDaPeca.Coluna - 1);
            if (TabPeca.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            pos.DefinePosicao(PosicaoDaPeca.Linha - 1, PosicaoDaPeca.Coluna - 2);
            if (TabPeca.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            pos.DefinePosicao(PosicaoDaPeca.Linha +1, PosicaoDaPeca.Coluna - 2);
            if (TabPeca.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            pos.DefinePosicao(PosicaoDaPeca.Linha + 2, PosicaoDaPeca.Coluna - 1);
            if (TabPeca.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            pos.DefinePosicao(PosicaoDaPeca.Linha + 2, PosicaoDaPeca.Coluna + 1);
            if (TabPeca.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            pos.DefinePosicao(PosicaoDaPeca.Linha + 1, PosicaoDaPeca.Coluna +2);
            if (TabPeca.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            pos.DefinePosicao(PosicaoDaPeca.Linha - 1, PosicaoDaPeca.Coluna + 2);
            if (TabPeca.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            pos.DefinePosicao(PosicaoDaPeca.Linha - 2, PosicaoDaPeca.Coluna + 1);
            if (TabPeca.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }



            return mat;

        }
        public override string ToString()
        {
            return "C";
        }

    }
}
