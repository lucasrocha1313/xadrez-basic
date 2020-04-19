using System.Collections.Generic;
using tabuleiro;

namespace xadrez
{
    public class PartidaDeXadrez
    {
        public Tabuleiro Tabuleiro {get; private set;}
        public int turno {get; private set;}
        public Cor jogadorAtual {get; private set;}
        public bool Terminada { get; private set; }
        private HashSet<Peca> PecasPartida;
        private HashSet<Peca> PecasCapturadas;

        public PartidaDeXadrez()
        {
            Tabuleiro = new Tabuleiro(8,8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            PecasPartida = new HashSet<Peca>();
            PecasCapturadas = new HashSet<Peca>();
            ColocarPecas();
        }

        public void ExecutarMovimento(Posicao origem, Posicao destino)
        {
            var pecaEmMovimento = Tabuleiro.RetirarPeca(origem);
            pecaEmMovimento.IncrementaQtdeMovimentos();
            var pecaCapturada = Tabuleiro.RetirarPeca(destino);
            Tabuleiro.ColocarPeca(pecaEmMovimento, destino);

            if(pecaCapturada != null)
                PecasCapturadas.Add(pecaCapturada);
        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            ExecutarMovimento(origem, destino);
            turno++;
            MudaJogador();
        }

        public void MudaJogador()
        {
            if(jogadorAtual == Cor.Branca)
                jogadorAtual = Cor.Preta;
            else
                jogadorAtual = Cor.Branca;
        }

        public void ValidarPosicaoOrigem(Posicao origem)
        {
            if(Tabuleiro.ObterPeca(origem) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }

            if(jogadorAtual != Tabuleiro.ObterPeca(origem).Cor)
            {
                throw new TabuleiroException("A peça escolhida não é sua!");
            }

            if(!Tabuleiro.ObterPeca(origem).ExistemMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possíveis para a peça escolhida!");
            }
        }

        public void ValidarPosicaoDestino(Posicao origem, Posicao destino)
        {
            if(!Tabuleiro.ObterPeca(origem).PodeMoverPara(destino))
            {
                throw new TabuleiroException("Posicao de destino inválida");
            }
        }

        public HashSet<Peca> ObterPecasCapturadas(Cor cor)
        {
            var pecasCapturadasPorCor = new  HashSet<Peca>();

            foreach(var peca in PecasCapturadas)
            {
                if(peca.Cor == cor)
                    pecasCapturadasPorCor.Add(peca);
            }

            return pecasCapturadasPorCor;
        }

        public HashSet<Peca> ObterPecasEmJogo(Cor cor)
        {
            var pecasEmJogo = new  HashSet<Peca>();

            foreach(var peca in PecasPartida)
            {
                if(peca.Cor == cor)
                    pecasEmJogo.Add(peca);
            }

            pecasEmJogo.ExceptWith(ObterPecasCapturadas(cor));

            return pecasEmJogo;
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Tabuleiro.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            PecasPartida.Add(peca);
        }

        public void ColocarPecas()
        {
            ColocarNovaPeca('c', 1, new Torre(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('d', 1, new Rei(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('e', 1, new Torre(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('c', 2, new Torre(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('d', 2, new Torre(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('e', 2, new Torre(Tabuleiro, Cor.Branca));

            ColocarNovaPeca('c', 8, new Torre(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('d', 8, new Rei(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('e', 8, new Torre(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('c', 7, new Torre(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('d', 7, new Torre(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('e', 7, new Torre(Tabuleiro, Cor.Preta));
        }
    }
}