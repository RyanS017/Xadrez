using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xadrez.Entites.Tabuleiro
{
    internal class Peca
    {
        public Posiçao Posicao { get; set; }
        public Cor Cor { get; set; }

        public int QntMov { get; set; }

        public Tabuleiro Tabuleiro { get; set; }

        public Peca(Posiçao posicao, Cor cor, Tabuleiro tabuleiro)
        {
            Posicao = posicao;
            Cor = cor;
            Tabuleiro = tabuleiro;
            QntMov = 0;
        }
    }
}
