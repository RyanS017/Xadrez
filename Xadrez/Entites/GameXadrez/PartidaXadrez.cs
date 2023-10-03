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
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Estado { get; private set; }

        public PartidaXadrez()
        {
            tab = new Tabuleiro.Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branco;
            ColocarPeca();
            Estado = false;
        }

        public void OrigemValida(Posiçao origem)
        {
            if (tab.Pecas(origem) == null)
            {
                throw new TabuleiroException("Não existe peça nesta posição");
            }
            if(JogadorAtual != tab.Pecas(origem).Cor)
            {
                throw new TabuleiroException("A peça escolhida não é sua: ");
            }
            if (!tab.Pecas(origem).ExisteMovimentoPossivel())
            {
                throw new TabuleiroException("Essa peça não pode ser mexida");
            }
        }
        public void DestinoValido(Posiçao origem, Posiçao destino)
        {
            if (!tab.Pecas(origem).PodeMoverDestino(destino))
            {
                throw new TabuleiroException("Posição de destino inválida");
            }
        }
        public void ExecutaMov(Posiçao origem, Posiçao destino)
        {
            Peca p = tab.RetirarPeca(origem);
            p.IncrementarMov();
            Peca capturadap = tab.RetirarPeca(destino);
            tab.ColocarPeca(p, destino);
        }

        public void RealizaMovimento(Posiçao origem, Posiçao destino)
        {
            ExecutaMov(origem, destino);
            Turno++;
            MudaJogador();
        }

        private void MudaJogador()
        {
            if (JogadorAtual == Cor.Branco)
            {
                JogadorAtual = Cor.Preta;
            }
            else
            {
                JogadorAtual = Cor.Branco;
            }
        }
        private void ColocarPeca()
        {
            tab.ColocarPeca(new Rei(Cor.Preta, tab), new PosicaoXadrez('c',1).ToPosicao());
            tab.ColocarPeca(new Rei(Cor.Branco, tab), new PosicaoXadrez('c', 7).ToPosicao());
        }
    }
    
}
