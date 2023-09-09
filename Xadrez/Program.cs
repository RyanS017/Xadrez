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
                Tabuleiro tabuleiro = new Tabuleiro(8, 8);
                tabuleiro.ColocarPeca(new Torre(Cor.Branco, tabuleiro), new Posiçao(0, 4));
                tabuleiro.ColocarPeca(new Torre(Cor.Branco, tabuleiro), new Posiçao(2, 3));
                tabuleiro.ColocarPeca(new Rei(Cor.Branco, tabuleiro), new Posiçao(0, 8));
                Tela.Tel(tabuleiro);
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
