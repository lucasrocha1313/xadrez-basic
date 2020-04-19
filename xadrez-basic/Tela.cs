using System;
using System.Collections.Generic;
using tabuleiro;
using xadrez;

namespace xadrez_basic
{
    public class Tela
    {

        public static void ImprimirPartida(PartidaDeXadrez partida)
        {
            ImprimirTabuleiro(partida.Tabuleiro);
            Console.WriteLine();
            ImprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.turno);
            Console.WriteLine("Aguardando jogada: " + partida.jogadorAtual);
        }

        public static void ImprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            Console.WriteLine("Pecas Capturadas:");
            Console.Write("Bracas:");
            ImprimirConjuntoPecas(partida.ObterPecasCapturadas(Cor.Branca));
            Console.WriteLine();
            Console.Write("Pretas:");

            var corOriginal = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            ImprimirConjuntoPecas(partida.ObterPecasCapturadas(Cor.Preta));
            Console.ForegroundColor = corOriginal;
        }

        public static void ImprimirConjuntoPecas(HashSet<Peca> pecas)
        {
            Console.Write("[");

            foreach(var peca in pecas)
            {
                Console.Write(peca + " ");
            }
            Console.Write("]");
        }
        public static void ImprimirTabuleiro(Tabuleiro tab)
        {
            for(int linha = 0; linha < tab.Linhas; linha++)
            {
                Console.Write(8 - linha + " ");
                for(int coluna = 0; coluna < tab.Colunas; coluna++)
                {
                    ImprimirPeca(tab.ObterPeca(linha, coluna));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static void ImprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
        {
            var fundoOriginal = Console.BackgroundColor;
            var fundoAlterado = ConsoleColor.DarkGray;

            for(int linha = 0; linha < tab.Linhas; linha++)
            {
                Console.Write(8 - linha + " ");
                for(int coluna = 0; coluna < tab.Colunas; coluna++)
                {
                    if(posicoesPossiveis[linha,coluna])
                        Console.BackgroundColor = fundoAlterado;
                    else
                        Console.BackgroundColor = fundoOriginal;

                    ImprimirPeca(tab.ObterPeca(linha, coluna));
                }
                Console.BackgroundColor = fundoOriginal;
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
            Console.BackgroundColor = fundoOriginal;
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
            if(peca == null)
            {
                Console.Write("- ");
            }
            else
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
                Console.Write(" ");
            }
            
        }
    }
}