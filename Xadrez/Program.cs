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
                    Console.Clear();
                    Tela.Tel(partida.tab);
                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Posiçao origem = Tela.LerPosicaoXadrez().ToPosicao();
                    bool[,] posicoesPossiveis = partida.tab.Pecas(origem).MovimentosPossiveis();
                    Console.Clear();
                    Tela.Tel(partida.tab, posicoesPossiveis);
                    Console.WriteLine();
                    Console.Write("Destino: ");
                    Posiçao destino = Tela.LerPosicaoXadrez().ToPosicao();
                    partida.ExecutaMov(origem, destino);
                }
            }
            catch (TabuleiroException e) 
            {
                Console.WriteLine(e.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
