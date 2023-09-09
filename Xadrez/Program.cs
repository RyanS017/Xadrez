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

                PosicaoXadrez pos = new PosicaoXadrez(1, 'a');
                Console.WriteLine(pos);
                Console.WriteLine(pos.ToPosicao());

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
