using TabuleiroXadrez;


namespace JogoXadrez
{
    internal class Dama : Peca
    {
        public Dama(Cor corPeca, Tabuleiro tabPeca) : base(corPeca, tabPeca)
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

            //acima
            pos.DefinePosicao(PosicaoDaPeca.Linha - 1, PosicaoDaPeca.Coluna);
            while (TabPeca.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (TabPeca.GetPeca(pos) != null && TabPeca.GetPeca(pos).CorPeca != this.CorPeca)
                {
                    break;
                }
                pos.Linha--;
            }

            //abaixo
            pos.DefinePosicao(PosicaoDaPeca.Linha+1, PosicaoDaPeca.Coluna);
            while (TabPeca.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (TabPeca.GetPeca(pos) != null && TabPeca.GetPeca(pos).CorPeca != this.CorPeca)
                {
                    break;
                }
                pos.Linha++;
            }

            //esquerda
            pos.DefinePosicao(PosicaoDaPeca.Linha, PosicaoDaPeca.Coluna-1);
            while (TabPeca.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (TabPeca.GetPeca(pos) != null && TabPeca.GetPeca(pos).CorPeca != this.CorPeca)
                {
                    break;
                }
                pos.Coluna--;
            }

            //direita
            pos.DefinePosicao(PosicaoDaPeca.Linha, PosicaoDaPeca.Coluna + 1);
            while (TabPeca.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (TabPeca.GetPeca(pos) != null && TabPeca.GetPeca(pos).CorPeca != this.CorPeca)
                {
                    break;
                }
                pos.Coluna++;
            }

            //nordeste
            pos.DefinePosicao(PosicaoDaPeca.Linha + 1, PosicaoDaPeca.Coluna + 1);
            while (TabPeca.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (TabPeca.GetPeca(pos) != null && TabPeca.GetPeca(pos).CorPeca != this.CorPeca)
                {
                    break;
                }
                pos.DefinePosicao(pos.Linha + 1, pos.Coluna + 1);

            }

            //noroeste
            pos.DefinePosicao(PosicaoDaPeca.Linha + 1, PosicaoDaPeca.Coluna - 1);
            while (TabPeca.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (TabPeca.GetPeca(pos) != null && TabPeca.GetPeca(pos).CorPeca != this.CorPeca)
                {
                    break;
                }
                pos.DefinePosicao(pos.Linha + 1, pos.Coluna - 1);

            }

            //sudoeste
            pos.DefinePosicao(PosicaoDaPeca.Linha - 1, PosicaoDaPeca.Coluna - 1);
            while (TabPeca.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (TabPeca.GetPeca(pos) != null && TabPeca.GetPeca(pos).CorPeca != this.CorPeca)
                {
                    break;
                }
                pos.DefinePosicao(pos.Linha - 1, pos.Coluna - 1);

            }

            //sudeste
            pos.DefinePosicao(PosicaoDaPeca.Linha - 1, PosicaoDaPeca.Coluna + 1);
            while (TabPeca.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (TabPeca.GetPeca(pos) != null && TabPeca.GetPeca(pos).CorPeca != this.CorPeca)
                {
                    break;
                }
                pos.DefinePosicao(pos.Linha - 1, pos.Coluna + 1);

            }



            return mat;

        }
        public override string ToString()
        {
            return "D";
        }

    }
   
}

