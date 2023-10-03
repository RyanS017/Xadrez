using System;
using System.Globalization;
using Xadrez.Entites;
using Xadrez.Entites.Tabuleiro;
using Xadrez.Entites.GameXadrez;
using System.Reflection.Metadata;

namespace Xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                PartidaXadrez partida = new PartidaXadrez();
                while (!partida.Estado)
                {
                    try
                    {
                        Console.Clear();
                        Tela.Tel(partida.tab);
                        Console.WriteLine();
                        Console.WriteLine("Turno: " + partida.Turno);
                        Console.WriteLine("Aguardando jogada: " + partida.JogadorAtual);
                        Console.WriteLine();
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
