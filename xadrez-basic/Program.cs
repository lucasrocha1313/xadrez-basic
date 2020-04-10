using System;
using tabuleiro;

namespace xadrez_basic
{
    class Program
    {
        static void Main(string[] args)
        {
            var tab = new Tabuleiro(8,8);

            Tela.ImprimirTabuleiro(tab);

            Console.ReadLine();
        }
    }
}
