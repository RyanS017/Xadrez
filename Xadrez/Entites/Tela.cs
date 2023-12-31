﻿using Xadrez.Entites.GameXadrez;
using Xadrez.Entites.Tabuleiro;

namespace Xadrez.Entites
{
    internal class Tela
    {

        //Impressão do tabuleiro no console
        public static void ImprimirPartida(PartidaXadrez partida)
        {
            Console.Clear();
            Tela.Tel(partida.tab);
            Console.WriteLine();
            ImprimirPecaCapturadas(partida);
            Console.WriteLine("Turno: " + partida.Turno);
            if (!partida.Estado)
            {
                Console.WriteLine("Aguardando jogada: " + partida.JogadorAtual);
                if (partida.Xeque)
                {
                    Console.WriteLine("XEQUE");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("XEQUE MATE");
                Console.WriteLine("Vencedor: " + partida.JogadorAtual);
            }
        }


        public static void ImprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach(Peca x in conjunto)
            {
                Console.Write(x + " ");
            }
            Console.Write("] ");
        }

        //Impressão do tabuleiro com os movimentos possiveis
        public static void Tel(Tabuleiro.Tabuleiro tab, bool[,] mat)
        {
            ConsoleColor FundoOriginal = Console.BackgroundColor;
            ConsoleColor FundoAlterado = ConsoleColor.DarkGray;
            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Colunas; j++)
                {
                    if (mat[i, j])
                    {
                        Console.BackgroundColor = FundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = FundoOriginal;
                    }
                    ImprimirPeca(tab.Pecas(i, j));
                    Console.BackgroundColor = FundoOriginal;

                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = FundoOriginal;
        }
        // leitura da posição inserida pelo usuario
        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }
        private static void ImprimirPeca(Peca peca)
        {
            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (peca.Cor == Cor.Branco)
                {
                    Console.Write(peca);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
        //Auxiliam na impressão do tabuleiro
        public static void ImprimirPecaCapturadas(PartidaXadrez partida)
        {
            Console.WriteLine("Peças capturadas: ");
            Console.Write("Brancas: ");
            ImprimirConjunto(partida.PecasCaptu(Cor.Branco));
            Console.WriteLine();
            Console.Write("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            ImprimirConjunto(partida.PecasCaptu(Cor.Preta));
            Console.WriteLine();
            Console.ForegroundColor = aux;
        }
        public static void Tel(Tabuleiro.Tabuleiro tab)
        {
            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Colunas; j++)
                {
                    ImprimirPeca(tab.Pecas(i, j));

                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
    }
}
