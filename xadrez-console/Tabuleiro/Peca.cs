using System;
using System.Collections.Generic;
using System.Text;

namespace TabuleiroXadrez
{
    internal class Peca
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
    }
}
