using System;
using System.Globalization;
using Xadrez.Entites;
using Xadrez.Entites.Tabuleiro;
using Xadrez.Entites.GameXadrez;

namespace Xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // AINDA NÃO ESTA COM AS JOGADAS ESPECIAIS, ROQUE GRANDE, ROQUE PEQUENP, PROMOÇÃO ETC

                PartidaXadrez partida = new PartidaXadrez();
                while (!partida.Estado)
                {
                    try
                    {
                        Tela.ImprimirPartida(partida);
                        Console.Write("Origem: ");
                        Posiçao origem = Tela.LerPosicaoXadrez().ToPosicao();
                        partida.OrigemValida(origem);
                        bool[,] posicoesPossiveis = partida.tab.Pecas(origem).MovimentosPossiveis();
                        Console.Clear();
                        Tela.Tel(partida.tab, posicoesPossiveis);
                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posiçao destino = Tela.LerPosicaoXadrez().ToPosicao();
                        partida.DestinoValido(origem, destino);
                        partida.RealizaMovimento(origem, destino);
                    }
                    catch(TabuleiroException ex) { Console.WriteLine(ex.Message); Console.ReadLine(); }
                }
                Console.Clear();
                Tela.ImprimirPartida(partida);
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
