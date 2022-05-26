using System;
using System.Collections.Generic;
using System.Text;

namespace TabuleiroXadrez
{
    internal class Peca
    {
        public Posicao PosPeca { get; set; }
        public Cor CorPeca { get; protected set; }
        public int QteMovimentos { get; protected set; }
        public Tabuleiro TabPeca { get; protected set; }

        public Peca(Cor corPeca, Tabuleiro tabPeca)
        {
            PosPeca = null;
            CorPeca = corPeca;
            TabPeca = tabPeca;
            QteMovimentos = 0;
        }
    }
}
