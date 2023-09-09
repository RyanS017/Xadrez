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
            Tabuleiro tabuleiro = new Tabuleiro(8,8);
            tabuleiro.ColocarPeca(new Torre(Cor.Branco, tabuleiro), new Posiçao(0, 4));
            tabuleiro.ColocarPeca(new Torre(Cor.Branco, tabuleiro), new Posiçao(2, 3));
            tabuleiro.ColocarPeca(new Rei(Cor.Branco, tabuleiro), new Posiçao(0, 2));
            Tela.Tel(tabuleiro);
        }
    }
}
