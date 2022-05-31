using System;
using System.Collections.Generic;
using System.Text;
using TabuleiroXadrez;
using xadrez_console;
using Exceptions;

namespace JogoXadrez
{
    internal class PartidaXadrez
    {
        public Tabuleiro Tab { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
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
        }

        public void RealizarJogada(Posicao origem, Posicao destino)
        {

            ExecutarMovimento(origem, destino);
            Turno++;
            mudaJogador();
        }

        public void ValidarPosicaoOrigem(Posicao origem)
        {
            if (Tab.GetPeca(origem) == null)
            {
                throw new TabuleiroException("Não existe peça na posição informada");
            }
            if (JogadorAtual != Tab.GetPeca(origem).CorPeca)
            {
                throw new TabuleiroException("Peça de cor inválida");
            }

            if (Tab.GetPeca(origem).ExisteMvtPossiveis() == false)
            {
                throw new TabuleiroException("Não existem movimentos possíveis para a peça");
            }
        }

        public void ValidarPosicaoDestino(Posicao origem, Posicao destino)
        {
            if (!Tab.GetPeca(origem).PodeMoverPara(destino))
            {
                throw new TabuleiroException("Posicão de destino inválida");
            }
        }

        private void mudaJogador()
        {
            if (JogadorAtual == Cor.Branca)
            {
                JogadorAtual = Cor.Preta;
            }
            else JogadorAtual = Cor.Branca;
        }

        public void IniciarPecas()
        {
            Tab.ColocarPeca(new Torre(Cor.Preta, Tab), new PosicaoXadrez('a', 8).toPosicao());
            Tab.ColocarPeca(new Torre(Cor.Preta, Tab), new PosicaoXadrez('h', 8).toPosicao());
            Tab.ColocarPeca(new Torre(Cor.Branca, Tab), new PosicaoXadrez('a', 1).toPosicao());
            Tab.ColocarPeca(new Torre(Cor.Branca, Tab), new PosicaoXadrez('h', 1).toPosicao());
            Tab.ColocarPeca(new Torre(Cor.Branca, Tab), new PosicaoXadrez('d', 4).toPosicao());
        }

    }
}

