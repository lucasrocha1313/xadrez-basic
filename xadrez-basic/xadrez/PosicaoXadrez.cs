using tabuleiro;

namespace xadrez
{
    public class PosicaoXadrez
    {
        public char Coluna { get; set; }
        public int Linha { get; set; }

        public PosicaoXadrez(char coluna, int linha)
        {
            Coluna = coluna;
            Linha = linha;
        }

        public Posicao toPosicao()
        {
            return new Posicao(8 - Linha, char.ToLower(Coluna) - 'a');
        }

        public override string ToString()
        {
            return "" + char.ToUpper(Coluna) + Linha;
        }
    }
}