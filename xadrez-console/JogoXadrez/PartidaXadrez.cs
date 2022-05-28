using System;
using System.Collections.Generic;
using System.Text;
using TabuleiroXadrez;
using xadrez_console;

namespace JogoXadrez
{
    internal class PartidaXadrez
    {
        public Tabuleiro Tab { get; private set; }
        private int Turno;
        private Cor JogadorAtual;
        public bool isMatchOver { get; private set; }

        public PartidaXadrez()
        {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            isMatchOver = false;
            IniciarPecas();
            
        }

        public void ExecutarMovimento(Posicao origem, Posicao destino)
        {
            Peca p = Tab.RetirarPeca(origem);
            p.IncrementaQteMovt();
            
            Peca pCapturada = Tab.RetirarPeca(destino);
            Tab.ColocarPeca(p, destino);
            Turno++;


        }

        public void IniciarPecas()
        {
            Tab.ColocarPeca(new Torre(Cor.Preta, Tab), new PosicaoXadrez('a', 8).toPosicao());
            Tab.ColocarPeca(new Torre(Cor.Preta, Tab), new PosicaoXadrez('h', 8).toPosicao());
            Tab.ColocarPeca(new Torre(Cor.Branca, Tab), new PosicaoXadrez('a', 1).toPosicao());
            Tab.ColocarPeca(new Torre(Cor.Branca, Tab), new PosicaoXadrez('h', 1).toPosicao());
        }

    }
}

