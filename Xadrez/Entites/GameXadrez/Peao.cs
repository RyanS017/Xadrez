using Xadrez.Entites.Tabuleiro;

namespace Xadrez.Entites.GameXadrez
{
    internal class Peao: Peca
    {
        public Peao(Cor cor, Tabuleiro.Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {

        }
        public override string ToString()
        {
            return "P";
        }
        private bool ExisteInimigo(Posiçao pos)
        {
            Peca p = Tabuleiro.Pecas(pos);
            if (p != null && p.Cor != Cor)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool Livre(Posiçao pos)
        {
            if (Tabuleiro.Pecas(pos) == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posiçao pos = new Posiçao(0, 0);

            if (Cor == Cor.Branco)
            {
                pos.DefinirPosicao(Posicao.Linha - 1, Posicao.Coluna - 1);
                if (Tabuleiro.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirPosicao(Posicao.Linha - 1, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(pos) && Livre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirPosicao(Posicao.Linha - 2, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(pos) && Livre(pos) && QntMov == 0 && Livre(new Posiçao(Posicao.Linha - 1, Posicao.Coluna)))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirPosicao(Posicao.Linha - 1, Posicao.Coluna + 1);
                if (Tabuleiro.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
            }
            else
            {
                pos.DefinirPosicao(Posicao.Linha + 1, Posicao.Coluna - 1);
                if (Tabuleiro.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirPosicao(Posicao.Linha + 1, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(pos) && Livre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirPosicao(Posicao.Linha + 2, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(pos) && Livre(pos) && QntMov == 0 && Livre(new Posiçao(Posicao.Linha + 1, Posicao.Coluna)))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirPosicao(Posicao.Linha + 1, Posicao.Coluna + 1);
                if (Tabuleiro.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
            }
            return mat;
        }
    }
}
