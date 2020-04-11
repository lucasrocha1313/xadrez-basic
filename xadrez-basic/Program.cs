using System;
using tabuleiro;
using xadrez;

namespace xadrez_basic
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                var pos = new PosicaoXadrez('C', 7);
                Console.WriteLine(pos);
                Console.WriteLine(pos.toPosicao());
            }
            catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
