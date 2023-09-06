using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xadrez.Entites.Tabuleiro;

namespace Xadrez.Entites
{
    internal class Tela
    {
        public static void Tel(Tabuleiro.Tabuleiro tab)
        {
            for (int i = 0; i < tab.Linhas; i++)
            {
                for (int j = 0; j < tab.Colunas; j++)
                {
                    if (tab.Pecas(i,j) == null )
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(tab.Pecas + " ");
                    }
                    
                }
                Console.WriteLine();
            }
        }
    }
}
