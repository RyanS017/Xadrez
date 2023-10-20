using Xadrez.Entites.Tabuleiro;

namespace Xadrez.Entites.GameXadrez
{
    internal class Dama: Peca
    {
        public Dama(Cor cor, Tabuleiro.Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {

        }
        public override string ToString()
        {
            return "D";
        }
        private bool PodeMover(Posiçao pos)
        {
            Peca p = Tabuleiro.Pecas(pos);
            return p == null || p.Cor != Cor;
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posiçao pos = new Posiçao(0, 0);

            // Cima esquerda
            pos.DefinirPosicao(Posicao.Linha - 1, Posicao.Coluna - 1);
            while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.Pecas(pos) != null && Tabuleiro.Pecas(pos).Cor != Cor)
                {
                    break;
                }
                pos.Linha -= 1;
                pos.Coluna -= 1;
            }

            //Cima direita
            pos.DefinirPosicao(Posicao.Linha - 1, Posicao.Coluna + 1);
            while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.Pecas(pos) != null && Tabuleiro.Pecas(pos).Cor != Cor)
                {
                    break;
                }
                pos.Linha -= 1;
                pos.Coluna += 1;
            }

            //baixo esquerda
            pos.DefinirPosicao(Posicao.Linha + 1, Posicao.Coluna - 1);
            while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.Pecas(pos) != null && Tabuleiro.Pecas(pos).Cor != Cor)
                {
                    break;
                }
                pos.Linha += 1;
                pos.Coluna -= 1;
            }

            //baixo direita

            pos.DefinirPosicao(Posicao.Linha + 1, Posicao.Coluna + 1);
            while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.Pecas(pos) != null && Tabuleiro.Pecas(pos).Cor != Cor)
                {
                    break;
                }
                pos.Linha += 1;
                pos.Coluna += 1;
            }
            //cima
            pos.DefinirPosicao(Posicao.Linha - 1, Posicao.Coluna);
            while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.Pecas(pos) != null && Tabuleiro.Pecas(pos).Cor != Cor)
                {
                    break;
                }
                pos.Linha = pos.Linha - 1;
            }
            //baixo
            pos.DefinirPosicao(Posicao.Linha + 1, Posicao.Coluna);
            while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.Pecas(pos) != null && Tabuleiro.Pecas(pos).Cor != Cor)
                {
                    break;
                }
                pos.Linha = pos.Linha + 1;
            }
            //direita
            pos.DefinirPosicao(Posicao.Linha, Posicao.Coluna + 1);
            while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.Pecas(pos) != null && Tabuleiro.Pecas(pos).Cor != Cor)
                {
                    break;
                }
                pos.Coluna = pos.Coluna + 1;
            }
            //esquerda
            pos.DefinirPosicao(Posicao.Linha, Posicao.Coluna - 1);
            while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.Pecas(pos) != null && Tabuleiro.Pecas(pos).Cor != Cor)
                {
                    break;
                }
                pos.Coluna = pos.Coluna - 1;
            }
            return mat;
        }
    }
}
