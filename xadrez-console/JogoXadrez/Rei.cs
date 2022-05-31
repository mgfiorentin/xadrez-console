using TabuleiroXadrez;


namespace JogoXadrez
{
    internal class Rei : Peca
    {
        public Rei(Cor corPeca, Tabuleiro tabPeca) : base(corPeca, tabPeca)
        {


        }

        private bool PodeMover(Posicao pos)
        {
            Peca p = TabPeca.GetPeca(pos);
            return p == null || p.CorPeca != CorPeca;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[TabPeca.Linhas, TabPeca.Colunas];
            Posicao pos = new Posicao(0, 0);


            //acima

            pos.DefinePosicao(this.PosicaoDaPeca.Linha - 1, this.PosicaoDaPeca.Coluna);
            if (TabPeca.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //nordeste
    
            pos.DefinePosicao(this.PosicaoDaPeca.Linha - 1, this.PosicaoDaPeca.Coluna + 1);
            if (TabPeca.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //direita
            pos.DefinePosicao(this.PosicaoDaPeca.Linha, this.PosicaoDaPeca.Coluna + 1);
            if (TabPeca.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //sudeste

            pos.DefinePosicao(this.PosicaoDaPeca.Linha + 1, this.PosicaoDaPeca.Coluna + 1);
            if (TabPeca.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //abaixo

            pos.DefinePosicao(this.PosicaoDaPeca.Linha + 1, this.PosicaoDaPeca.Coluna);
            if (TabPeca.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //sudoeste

            pos.DefinePosicao(this.PosicaoDaPeca.Linha + 1, this.PosicaoDaPeca.Coluna - 1);
            if (TabPeca.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //esquerda

            pos.DefinePosicao(this.PosicaoDaPeca.Linha, this.PosicaoDaPeca.Coluna - 1);
            if (TabPeca.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //noroeste

            pos.DefinePosicao(this.PosicaoDaPeca.Linha - 1, this.PosicaoDaPeca.Coluna - 1);
            if (TabPeca.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            return mat;
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
