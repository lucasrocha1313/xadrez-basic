using tabuleiro;

namespace xadrez
{
    public class Torre : Peca
    {
        public Torre(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {
        }

        public override bool[,] MovimentosPossiveis()
        {
            var matriz = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao pos = new Posicao(0,0);

            //acima
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            while(Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;

                var pecaNoCaminho = Tabuleiro.ObterPeca(pos);
                if(pecaNoCaminho != null && pecaNoCaminho.Cor != Cor)
                    break;
                
                pos.Linha -= 1;
            }

            //abaixo
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            while(Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;

                var pecaNoCaminho = Tabuleiro.ObterPeca(pos);
                if(pecaNoCaminho != null && pecaNoCaminho.Cor != Cor)
                    break;
                
                pos.Linha += 1;
            }

            //direita
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            while(Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;

                var pecaNoCaminho = Tabuleiro.ObterPeca(pos);
                if(pecaNoCaminho != null && pecaNoCaminho.Cor != Cor)
                    break;
                
                pos.Coluna += 1;
            }

            //direita
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            while(Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;

                var pecaNoCaminho = Tabuleiro.ObterPeca(pos);
                if(pecaNoCaminho != null && pecaNoCaminho.Cor != Cor)
                    break;
                
                pos.Coluna -= 1;
            }

            return matriz;
        }

        public override string ToString()
        {
            return "T";
        }
    }
}