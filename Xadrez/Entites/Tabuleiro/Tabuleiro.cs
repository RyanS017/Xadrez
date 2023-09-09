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

        public Peca Pecas(int linha, int coluna)
        {
            return Peca[linha, coluna];
        }

        public void ColocarPeca(Peca p, Posiçao pos)
        {
            Peca[pos.Linha, pos.Coluna] = p;
            p.Posicao = pos;
        }
    }
}
