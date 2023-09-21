using Xadrez.Entites.Tabuleiro;

namespace Xadrez.Entites.GameXadrez
{
    internal class PosicaoXadrez
    {
        public int Linha { get; set; }
        public char Coluna { get; set; }

        public PosicaoXadrez(char coluna, int linha)
        {
            Linha = linha;
            Coluna = coluna;
        }
        public Posiçao ToPosicao()
        {
            return new Posiçao(8 - Linha, Coluna - 'a');
        }

        public override string ToString()
        {
            return "" + Coluna + Linha;
        }
    }
}
