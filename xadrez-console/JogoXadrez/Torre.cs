using TabuleiroXadrez;


namespace JogoXadrez
{
    internal class Torre : Peca
    {
        public Torre(Cor corPeca, Tabuleiro tabPeca) : base(corPeca, tabPeca)
        {


        }

        public override string ToString()
        {
            return "T";
        }
    }
}
