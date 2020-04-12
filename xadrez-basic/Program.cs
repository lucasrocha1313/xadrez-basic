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
                var tabuleiro = new Tabuleiro(8,8);
                tabuleiro.ColocarPeca(new Torre(tabuleiro, Cor.Preta), new Posicao(0,0));
                tabuleiro.ColocarPeca(new Torre(tabuleiro, Cor.Preta), new Posicao(1,3));
                tabuleiro.ColocarPeca(new Rei(tabuleiro, Cor.Preta), new Posicao(1,0));

                tabuleiro.ColocarPeca(new Torre(tabuleiro, Cor.Branca), new Posicao(7,7));
                tabuleiro.ColocarPeca(new Torre(tabuleiro, Cor.Branca), new Posicao(5,5));
                tabuleiro.ColocarPeca(new Rei(tabuleiro, Cor.Branca), new Posicao(7,0));

                Tela.ImprimirTabuleiro(tabuleiro);
            }
            catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
