using System;
using tabuleiro;
using xadrez;

namespace xadrez_basic
{
    public class Tela
    {
        public static void ImprimirTabuleiro(Tabuleiro tab)
        {
            for(int linha = 0; linha < tab.Linhas; linha++)
            {
                Console.Write(8 - linha + " ");
                for(int coluna = 0; coluna < tab.Colunas; coluna++)
                {
                    if(tab.ObterPeca(linha,coluna) == null)
                        Console.Write("- ");
                    else
                    {
                        ImprimirPeca(tab.ObterPeca(linha, coluna));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static PosicaoXadrez LerPosicaoXadrez()
        {
            var entradaUsuario = Console.ReadLine();
            char coluna = entradaUsuario[0];
            int linha = int.Parse(entradaUsuario[1] + "");

            return new PosicaoXadrez(coluna, linha);
        }
        public static void ImprimirPeca(Peca peca)
        {
            if(peca.Cor == Cor.Branca)
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
        }
    }
}