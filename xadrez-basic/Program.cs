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
                var partidaXadrez = new PartidaDeXadrez();
                
                while(!partidaXadrez.Terminada)
                {
                    try
                    {
                        Console.Clear();
                        Tela.ImprimirTabuleiro(partidaXadrez.Tabuleiro);
                        Console.WriteLine();
                        Console.WriteLine("Turno: " + partidaXadrez.turno);
                        Console.WriteLine("Aguardando jogada: " + partidaXadrez.jogadorAtual);

                        Console.WriteLine();
                        Console.Write("Origem (coluna e linha):");
                        Posicao origem = Tela.LerPosicaoXadrez().toPosicao();

                        partidaXadrez.ValidarPosicaoOrigem(origem);

                        var pecaEscolhida = partidaXadrez.Tabuleiro.ObterPeca(origem);
                        
                        var posicoesPossiveis = pecaEscolhida.MovimentosPossiveis();

                        Console.Clear();
                        Tela.ImprimirTabuleiro(partidaXadrez.Tabuleiro, posicoesPossiveis);

                        Console.WriteLine();
                        Console.Write("Destino (coluna e linha):");
                        Posicao destino = Tela.LerPosicaoXadrez().toPosicao();
                        partidaXadrez.ValidarPosicaoDestino(origem, destino);
                        
                        partidaXadrez.RealizaJogada(origem, destino);
                    }
                    catch(TabuleiroException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                    
                }

            }
            catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
