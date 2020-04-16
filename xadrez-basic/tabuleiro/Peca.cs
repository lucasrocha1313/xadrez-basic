using tabuleiro;

namespace tabuleiro
{
    public abstract class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QtdeMovimento { get; protected set; }
        public Tabuleiro Tabuleiro { get; protected set; }

        public Peca(Tabuleiro tabuleiro, Cor cor)
        {
            Posicao = null;
            Tabuleiro = tabuleiro;
            Cor = cor;
            QtdeMovimento = 0;
        }

        public void IncrementaQtdeMovimentos()
        {
            QtdeMovimento++;
        }

        public bool PodeMover(Posicao posicao)
        {
            var pecaNaPosicao = Tabuleiro.ObterPeca(posicao);

            return pecaNaPosicao == null || pecaNaPosicao.Cor != Cor;
        }

        public abstract bool[,] MovimentosPossiveis();
    }
}