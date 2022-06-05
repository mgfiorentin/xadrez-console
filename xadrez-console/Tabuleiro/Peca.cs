using System;
using System.Collections.Generic;
using System.Text;

namespace TabuleiroXadrez
{
    internal abstract class Peca
    {
        public Posicao PosicaoDaPeca { get; set; }
        public Cor CorPeca { get; protected set; }
        public int QteMovimentos { get; protected set; }
        public Tabuleiro TabPeca { get; protected set; }

        public Peca(Cor corPeca, Tabuleiro tabPeca)
        {
            PosicaoDaPeca = null;
            CorPeca = corPeca;
            TabPeca = tabPeca;
            QteMovimentos = 0;
        }

        public bool MovimentoPossivel(Posicao destino)
        {
            return MovimentosPossiveis()[destino.Linha, destino.Coluna];
        }
        public abstract bool[,] MovimentosPossiveis();

        public bool ExisteMvtPossiveis()
        {
            bool[,] mat = MovimentosPossiveis();
            for(int i= 0; i < TabPeca.Linhas; i++)
            {
                for (int j=0; j< TabPeca.Colunas; j++)
                {
                    if (mat[i,j]) return true;
                }
            }
            return false;
        }
        public void IncrementaQteMovt()
        {
            QteMovimentos++;
        }

        public void DecrementaQteMovt()
        {
            QteMovimentos--;
        }
    }
}
