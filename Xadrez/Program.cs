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
                Tela.Tel(partida.tab);
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
