using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xadrez.Entites.Tabuleiro
{
    internal class Tabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }

        private Peca[,] Peca;

        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            Peca = new Peca[Linhas, Colunas];
        }
        public bool ExistePeca(Posiçao pos)
        {
            ValidarPosicao(pos);
            return Pecas(pos) != null;
        }
        public Peca Pecas(int linha, int coluna)
        {
            return Peca[linha, coluna];
        }
        public Peca Pecas(Posiçao pos)
        {
            return Pecas(pos.Linha, pos.Coluna);
        }
        public void ColocarPeca(Peca p, Posiçao pos)
        {
            if (ExistePeca(pos)){
                throw new TabuleiroException("Existe uam peça nessa posição!");
            }
            Peca[pos.Linha, pos.Coluna] = p;
            p.Posicao = pos;
        }

        public bool PosicaoValida(Posiçao pos)
        {
            if (pos.Coluna >= Colunas || pos.Linha >= Linhas || pos.Linha < 0 || pos.Coluna < 0)
            {
                return false;
            }
            return true;
        }

        public void ValidarPosicao(Posiçao pos)
        {
            if (!PosicaoValida(pos))
            {
                throw new TabuleiroException("Posição invalída!");
            }
        }
    }
}
