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
        private HashSet<Peca> Pecas;
        private HashSet<Peca> PecasCapturadas;

        public PartidaXadrez()
        {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            isMatchOver = false;
            Pecas = new HashSet<Peca>();
            PecasCapturadas = new HashSet<Peca>();
            IniciarPecas();

        }
        //Método que ir[a executar um movimentado de uma peça da origem para o destino
        public void ExecutarMovimento(Posicao origem, Posicao destino)
        {
            Peca p = Tab.RetirarPeca(origem);
            p.IncrementaQteMovt();

            Peca pCapturada = Tab.RetirarPeca(destino);
            Tab.ColocarPeca(p, destino);

            if (pCapturada != null)
            {
                PecasCapturadas.Add(pCapturada);
            }
        }
        //Método que busca e retorna as peças capturadas de uma dada cor
        public HashSet<Peca> GetPecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();

            foreach (Peca p in PecasCapturadas)
            {
                if (p.CorPeca == cor) aux.Add(p);
            }

            return aux;
        }

        //Método para retornar apenas peças em jogo
        public HashSet<Peca> GetPecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();

            foreach (Peca p in Pecas)
            {
                if (p.CorPeca == cor) aux.Add(p);
            }
            //retira peças capturadas de uma dada cor

            aux.ExceptWith(GetPecasCapturadas(cor));
            
            return aux;
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

        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Tab.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            Pecas.Add(peca);

        }

        public void IniciarPecas()
        {
            ColocarNovaPeca('c', 1, new Torre(Cor.Branca, Tab));
            ColocarNovaPeca('c', 2, new Torre(Cor.Branca, Tab));
            ColocarNovaPeca('c', 3, new Torre(Cor.Branca, Tab));
            ColocarNovaPeca('h', 3, new Torre(Cor.Preta, Tab));
            ColocarNovaPeca('h', 2, new Torre(Cor.Preta, Tab));
        }

    }
}

