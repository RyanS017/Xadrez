using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xadrez.Entites.Tabuleiro
{
    internal class Posiçao
    {
        public int Linha { get; set; }
        public int Coluna { get; set; }

        public Posiçao() { }
        public Posiçao(int linha, int coluna)
        {
            Linha = linha;
            Coluna = coluna;
        }

        public void DefinirPosicao(int linha, int coluna)
        {
            Linha = linha;
            Coluna = coluna;
        }
        public override string ToString()
        {
            return Linha + ", " + Coluna;
        }
    }
}
