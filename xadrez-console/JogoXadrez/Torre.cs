using TabuleiroXadrez;


namespace JogoXadrez
{
    internal class Torre : Peca
    {
        public Torre(Cor corPeca, Tabuleiro tabPeca) : base(corPeca, tabPeca)
        {


        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[TabPeca.Linhas, TabPeca.Colunas];

            return mat
        }
        public override string ToString()
        {
            return "T";
        }
    }
}
