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

                var tab = new Tabuleiro(8,8);

                tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(0,0));
                tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(1,9));
                tab.ColocarPeca(new Rei(tab, Cor.Preta), new Posicao(0,1));

                Tela.ImprimirTabuleiro(tab);

                Console.ReadLine();
            }
            catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
