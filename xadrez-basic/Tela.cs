using System;
using tabuleiro;

namespace xadrez_basic
{
    public class Tela
    {
        public static void ImprimirTabuleiro(Tabuleiro tab)
        {
            for(int linha = 0; linha < tab.Linhas; linha++)
            {
                for(int coluna = 0; coluna < tab.Colunas; coluna++)
                {
                    if(tab.ObterPeca(linha,coluna) == null)
                        Console.Write("- ");
                    else
                        Console.Write(tab.ObterPeca(linha,coluna));
                }

                Console.WriteLine();
            }
        }
    }
}