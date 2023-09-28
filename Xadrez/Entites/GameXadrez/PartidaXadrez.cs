using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xadrez.Entites.Tabuleiro;
namespace Xadrez.Entites.GameXadrez
{
    internal class PartidaXadrez
    {
        public Tabuleiro.Tabuleiro tab { get; private set; }
        private int Turno;
        private Cor JogadorAtual;
        public bool Estado { get; private set; }

        public PartidaXadrez()
        {
            tab = new Tabuleiro.Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branco;
            ColocarPeca();
            Estado = false;
        }
        public void ExecutaMov(Posiçao origem, Posiçao destino)
        {
            Peca p = tab.RetirarPeca(origem);
            p.IncrementarMov();
            Peca capturadap = tab.RetirarPeca(destino);
            tab.ColocarPeca(p, destino);
        }
        private void ColocarPeca()
        {
            tab.ColocarPeca(new Rei(Cor.Preta, tab), new PosicaoXadrez('c',1).ToPosicao());
            tab.ColocarPeca(new Rei(Cor.Branco, tab), new PosicaoXadrez('c', 7).ToPosicao());
        }
    }
    
}
