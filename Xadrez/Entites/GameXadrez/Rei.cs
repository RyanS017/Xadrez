using Xadrez.Entites.Tabuleiro;

namespace Xadrez.Entites.GameXadrez
{
    internal class Rei : Peca
    {
        public Rei(Cor cor, Tabuleiro.Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {

        }
        public override string ToString()
        {
            return "R";
        }
    }
}
