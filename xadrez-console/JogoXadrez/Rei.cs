using TabuleiroXadrez;


namespace JogoXadrez
{
    internal class Rei : Peca
    {
        public Rei(Cor corPeca, Tabuleiro tabPeca) : base(corPeca, tabPeca)
        {

            
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
