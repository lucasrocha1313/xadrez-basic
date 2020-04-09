using System;
using tabuleiro;

namespace xadrez_basic
{
    class Program
    {
        static void Main(string[] args)
        {
            var posicao = new Posicao(3,4);

            Console.WriteLine("Posicao " + posicao);

            Console.ReadLine();
        }
    }
}
