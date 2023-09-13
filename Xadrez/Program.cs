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

                Tabuleiro tab = new Tabuleiro(8, 8);
                tab.ColocarPeca(new Rei(Cor.Preta, tab), new Posiçao(0, 2));
                tab.ColocarPeca(new Torre(Cor.Preta, tab), new Posiçao(0, 4));
                tab.ColocarPeca(new Rei(Cor.Branco, tab), new Posiçao(7, 2));
                Tela.Tel(tab);
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
