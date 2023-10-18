using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Runtime.CompilerServices;
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
        public bool Xeque { get; private set; }
        public HashSet<Peca> PecasCapturadas { get; private set; }
        public HashSet<Peca> PecasS { get; private set; }

        public PartidaXadrez()
        {
            tab = new Tabuleiro.Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branco;
            PecasS = new HashSet<Peca>();
            PecasCapturadas = new HashSet<Peca>();
            ColocarPeca();
            Estado = false;
            Xeque = false;
        }

        public void OrigemValida(Posiçao origem)
        {
            if (tab.Pecas(origem) == null)
            {
                throw new TabuleiroException("Não existe peça nesta posição");
            }
            if (JogadorAtual != tab.Pecas(origem).Cor)
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
        public Peca ExecutaMov(Posiçao origem, Posiçao destino)
        {
            Peca p = tab.RetirarPeca(origem);
            p.IncrementarMov();
            Peca capturadap = tab.RetirarPeca(destino);
            tab.ColocarPeca(p, destino);
            if (capturadap != null)
            {
                PecasCapturadas.Add(capturadap);
            }
            return capturadap;
        }
        public void DesfazMovimento(Posiçao origem, Posiçao destino, Peca capturadap)
        {
            Peca p = tab.RetirarPeca(destino);
            p.DecrementarMov();
            if (capturadap != null)
            {
                tab.ColocarPeca(capturadap, destino);
                PecasCapturadas.Remove(capturadap);
            }
            tab.ColocarPeca(p, origem);
        }
        public void RealizaMovimento(Posiçao origem, Posiçao destino)
        {
            Peca capturadap = ExecutaMov(origem, destino);
            if (EstarXeque(JogadorAtual))
            {
                DesfazMovimento(origem, destino, capturadap);
                throw new TabuleiroException("Você não pode se colocar em xeque");
            }
            if (EstarXeque(Adversario(JogadorAtual)))
            {
                Xeque = true;
            }
            else
            {
                Xeque = false;
            }
            if (TesteXequeMate(Adversario(JogadorAtual)))
            {
                Estado = true;
            }
            else
            {
                Turno++;
                MudaJogador();
            }
        }
        private Cor Adversario(Cor cor)
        {
            if (cor == Cor.Branco)
            {
                return Cor.Preta;
            }
            else
            {
                return Cor.Branco;
            }
        }
        private Peca Rei(Cor cor)
        {
            foreach (Peca x in PecasEmjogo(cor))
            {
                if (x is Rei)
                {
                    return x;
                }
            }
            return null;
        }

        public bool EstarXeque(Cor cor)
        {
            Peca R = Rei(cor);
            if (R == null)
            {
                throw new TabuleiroException("Não existe Rei da Cor" + cor + "no tabuleiro");
            }
            foreach (Peca x in PecasEmjogo(Adversario(cor)))
            {
                bool[,] mat = x.MovimentosPossiveis();
                if (mat[R.Posicao.Linha, R.Posicao.Coluna])
                {
                    return true;
                }
            }
            return false;
        }
        public bool TesteXequeMate(Cor cor)
        {
            if (!EstarXeque(cor))
            {
                return false;
            }
            foreach(Peca x in PecasEmjogo(cor))
            {
                bool[,] mat = x.MovimentosPossiveis();
                for(int i = 0; i < tab.Linhas; i++)
                {
                    for(int j = 0; j < tab.Colunas; j++)
                    {
                        if (mat[i, j])
                        {
                            Posiçao origem = x.Posicao;
                            Posiçao destino = new Posiçao(i, j);
                            Peca capturada = ExecutaMov(origem, destino);
                            bool testeXeque = EstarXeque(cor);
                            DesfazMovimento(origem, destino, capturada);
                            if (!testeXeque)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
        public HashSet<Peca> PecasCaptu(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in PecasCapturadas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }
        public HashSet<Peca> PecasEmjogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in PecasS)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(PecasCaptu(cor));
            return aux;
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
        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            tab.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            PecasS.Add(peca);
        }
        private void ColocarPeca()
        {
            ColocarNovaPeca('a', 1, new Torre(Cor.Branco, tab));
            ColocarNovaPeca('b', 1, new Cavalo(Cor.Branco, tab));
            ColocarNovaPeca('c', 1, new Bispo(Cor.Branco, tab));
            ColocarNovaPeca('d', 1, new Dama(Cor.Branco, tab));
            ColocarNovaPeca('e', 1, new Rei(Cor.Branco, tab));
            ColocarNovaPeca('f', 1, new Bispo(Cor.Branco, tab));
            ColocarNovaPeca('g', 1, new Cavalo(Cor.Branco, tab));
            ColocarNovaPeca('h', 1, new Torre(Cor.Branco, tab));
            ColocarNovaPeca('a', 2, new Peao(Cor.Branco, tab));
            ColocarNovaPeca('b', 2, new Peao(Cor.Branco, tab));
            ColocarNovaPeca('c', 2, new Peao(Cor.Branco, tab));
            ColocarNovaPeca('d', 2, new Peao(Cor.Branco, tab));
            ColocarNovaPeca('e', 2, new Peao(Cor.Branco, tab));
            ColocarNovaPeca('f', 2, new Peao(Cor.Branco, tab));
            ColocarNovaPeca('g', 2, new Peao(Cor.Branco, tab));
            ColocarNovaPeca('h', 2, new Peao(Cor.Branco, tab));

            ColocarNovaPeca('a', 8, new Torre(Cor.Preta, tab));
            ColocarNovaPeca('b', 8, new Cavalo(Cor.Preta, tab));
            ColocarNovaPeca('c', 8, new Bispo(Cor.Preta, tab));
            ColocarNovaPeca('d', 8, new Dama(Cor.Preta, tab));
            ColocarNovaPeca('e', 8, new Rei(Cor.Preta, tab));
            ColocarNovaPeca('f', 8, new Bispo(Cor.Preta, tab));
            ColocarNovaPeca('g', 8, new Cavalo(Cor.Preta, tab));
            ColocarNovaPeca('h', 8, new Torre(Cor.Preta, tab));
            ColocarNovaPeca('a', 7, new Peao(Cor.Preta, tab));
            ColocarNovaPeca('b', 7, new Peao(Cor.Preta, tab));
            ColocarNovaPeca('c', 7, new Peao(Cor.Preta, tab));
            ColocarNovaPeca('d', 7, new Peao(Cor.Preta, tab));
            ColocarNovaPeca('e', 7, new Peao(Cor.Preta, tab));
            ColocarNovaPeca('f', 7, new Peao(Cor.Preta, tab));
            ColocarNovaPeca('g', 7, new Peao(Cor.Preta, tab));
            ColocarNovaPeca('h', 7, new Peao(Cor.Preta, tab));

        }
    }

}
