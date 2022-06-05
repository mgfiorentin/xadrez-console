using TabuleiroXadrez;


namespace JogoXadrez
{
    internal class Peao : Peca
    {
        public Peao(Cor corPeca, Tabuleiro tabPeca) : base(corPeca, tabPeca)
        {


        }

        private bool PodeMover(Posicao pos)
        {
            Peca p = TabPeca.GetPeca(pos);
            return p == null || p.CorPeca != CorPeca;
        }

        private bool ExisteInimigo(Posicao pos)
        {
            Peca p = TabPeca.GetPeca(pos);
            return (p != null && p.CorPeca != this.CorPeca);
        }

        private bool PosicaoLivre(Posicao pos)
        {
            return TabPeca.GetPeca(pos) == null;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[TabPeca.Linhas, TabPeca.Colunas];
            Posicao pos = new Posicao(0, 0);


            //acima
            if (CorPeca == Cor.Branca)
            {
                pos.DefinePosicao(PosicaoDaPeca.Linha - 1, PosicaoDaPeca.Coluna);
                if (TabPeca.PosicaoValida(pos) && PosicaoLivre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinePosicao(PosicaoDaPeca.Linha - 2, PosicaoDaPeca.Coluna);
                if (TabPeca.PosicaoValida(pos) && PosicaoLivre(pos) && QteMovimentos == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinePosicao(PosicaoDaPeca.Linha - 1, PosicaoDaPeca.Coluna-1);
                if (TabPeca.PosicaoValida(pos) && ExisteInimigo(pos) && QteMovimentos == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinePosicao(PosicaoDaPeca.Linha - 1, PosicaoDaPeca.Coluna + 1);
                if (TabPeca.PosicaoValida(pos) && ExisteInimigo(pos) && QteMovimentos == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

            }

            //abaixo
            else
            {
                pos.DefinePosicao(PosicaoDaPeca.Linha + 1, PosicaoDaPeca.Coluna);
                if (TabPeca.PosicaoValida(pos) && PosicaoLivre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinePosicao(PosicaoDaPeca.Linha + 2, PosicaoDaPeca.Coluna);
                if (TabPeca.PosicaoValida(pos) && PosicaoLivre(pos) && QteMovimentos == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinePosicao(PosicaoDaPeca.Linha + 1, PosicaoDaPeca.Coluna - 1);
                if (TabPeca.PosicaoValida(pos) && ExisteInimigo(pos) && QteMovimentos == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinePosicao(PosicaoDaPeca.Linha +1, PosicaoDaPeca.Coluna + 1);
                if (TabPeca.PosicaoValida(pos) && ExisteInimigo(pos) && QteMovimentos == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }


            }
            





            return mat;
        }

        public override string ToString()
        {
            return "P";
        }
    }
}
