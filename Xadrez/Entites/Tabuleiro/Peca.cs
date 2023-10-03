using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xadrez.Entites.Tabuleiro
{
    internal abstract class Peca
    {
        public Posiçao Posicao { get; set; }
        public Cor Cor { get; set; }

        public int QntMov { get; set; }

        public Tabuleiro Tabuleiro { get; set; }

        public Peca(Cor cor, Tabuleiro tabuleiro)
        {
            Posicao = null;
            Cor = cor;
            Tabuleiro = tabuleiro;
            QntMov = 0;
        }
        public void IncrementarMov()
        {
            QntMov++;
        }

        public bool ExisteMovimentoPossivel()
        {
            bool[,] mat = MovimentosPossiveis();
            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    if (mat[i,j] == true)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool PodeMoverDestino(Posiçao pos)
        {
            return MovimentosPossiveis()[pos.Linha,pos.Coluna];
        }
        public abstract bool[,] MovimentosPossiveis(); 
    }
}
