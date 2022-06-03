using System;
using System.Collections.Generic;
using System.Text;
using TabuleiroXadrez;
using XadrezConsole;
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
        public bool Xeque { get; private set; }
        private bool ChecandoXeque;

        public PartidaXadrez()
        {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            isMatchOver = false;
            Pecas = new HashSet<Peca>();
            PecasCapturadas = new HashSet<Peca>();
            IniciarPecas();
            Xeque = false;

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

        //Método que ir[a executar um movimentado de uma peça da origem para o destino
        public Peca ExecutarMovimento(Posicao origem, Posicao destino)
        {
            Peca p = Tab.RetirarPeca(origem);
            p.IncrementaQteMovt();

            Peca pCapturada = Tab.RetirarPeca(destino);
            Tab.ColocarPeca(p, destino);

            if (pCapturada != null)
            {
                PecasCapturadas.Add(pCapturada);
            }

            return pCapturada;
        }

        public void DesfazerMovimento(Posicao origem, Posicao destino, Peca pCapturada)
        {
            Peca p = Tab.RetirarPeca(destino);

            p.DecrementaQteMovt();

            if (pCapturada != null)
            {
                Tab.ColocarPeca(pCapturada, destino);
                PecasCapturadas.Remove(pCapturada);
            }
            Tab.ColocarPeca(p, origem);
        }

        public void RealizarJogada(Posicao origem, Posicao destino)
        {

            Peca pCapturada = ExecutarMovimento(origem, destino);

            if (EstaEmXeque(JogadorAtual))
            {
                DesfazerMovimento(origem, destino, pCapturada);
                throw new TabuleiroException("Você está em xeque!");
            }
            if (EstaEmXeque(CorAdversaria(JogadorAtual)))
            {
                Xeque = true;
            }
            else Xeque = false;

            if (TesteXequeMate(CorAdversaria(JogadorAtual)))
            {
                isMatchOver = true;
            }
            else {
                Turno++;
                mudaJogador();
            }


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

        private Cor CorAdversaria(Cor cor)
        {
            if (cor == Cor.Branca) return Cor.Preta;
            return Cor.Branca;
        }

        private Peca GetRei(Cor cor)
        {
            foreach (Peca p in GetPecasEmJogo(cor))
            {
                if (p is Rei) return p;
            }
            return null;
        }

        public bool EstaEmXeque(Cor cor)
        {
            Peca rei = GetRei(cor);
            if (rei == null) throw new TabuleiroException("Não existe rei da cor " + cor);

            foreach (Peca p in GetPecasEmJogo(CorAdversaria(cor)))
            {
                bool[,] mat = p.MovimentosPossiveis();
                if (mat[rei.PosicaoDaPeca.Linha, rei.PosicaoDaPeca.Coluna])
                    return true;
            }
            return false;
        }

        public bool TesteXequeMate(Cor cor)
        {
            if (!EstaEmXeque(cor)) return false;
            foreach (Peca p in GetPecasEmJogo(cor))
            {
                bool[,] mat = p.MovimentosPossiveis();
                for (int i = 0; i < Tab.Linhas; i++)
                {
                    for (int j = 0; j < Tab.Colunas; j++)
                    {
                        if (mat[i, j])
                        {
                            Posicao origem = p.PosicaoDaPeca;
                            Posicao destino = new Posicao(i, j);
                            Peca pecaCapturada = ExecutarMovimento(origem, destino);
                            bool testeXeque = EstaEmXeque(cor);
                            DesfazerMovimento(origem, destino, pecaCapturada);

                            if (!testeXeque) return false;
                        }
                    }
                }

            }

            return true;

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
            ColocarNovaPeca('h', 7, new Torre(Cor.Branca, Tab));
            ColocarNovaPeca('d', 1, new Rei(Cor.Branca, Tab));

            ColocarNovaPeca('a',8, new Rei(Cor.Preta, Tab));
            ColocarNovaPeca('b', 8, new Torre(Cor.Preta, Tab));
        }

    }
}

