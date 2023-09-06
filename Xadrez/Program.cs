using System;
using System.Globalization;
using Xadrez.Entites;
using Xadrez.Entites.Tabuleiro;

namespace Xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tabuleiro = new Tabuleiro(8,8);

            Tela.Tel(tabuleiro);
        }
    }
}
