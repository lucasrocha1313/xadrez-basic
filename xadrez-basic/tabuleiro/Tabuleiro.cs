using tabuleiro;

namespace tabuleiro
{
    public class Tabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        public Peca[,] Pecas { get; set; }

        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            Pecas = new Peca[linhas, colunas]; 
        }

        public Peca ObterPeca(int linha, int coluna)
        {
            return Pecas[linha, coluna];
        }

        public Peca ObterPeca(Posicao posicao)
        {
            return Pecas[posicao.Linha, posicao.Coluna];
        }

        public void ColocarPeca(Peca peca, Posicao posicao)
        {
            if(ExistePeca(posicao))
            {
                throw new TabuleiroException("Já existe uma peça nesta posição");
            }
            Pecas[posicao.Linha, posicao.Coluna] = peca;
            peca.Posicao = posicao;
        }

        public Peca RetirarPeca(Posicao posicao)
        {
            if(!ExistePeca(posicao))
                return null;

            var pecaRetorno = ObterPeca(posicao);

            pecaRetorno.Posicao = null;
            Pecas[posicao.Linha, posicao.Coluna] = null;

            return pecaRetorno;

        }

        public bool ExistePeca(Posicao posicao)
        {
            ValidarPosicao(posicao);
            return ObterPeca(posicao) != null;
        }
        public bool PosicaoValida(Posicao posicao)
        {
            if(posicao.Linha < 0 || posicao.Linha > Linhas
                || posicao.Coluna < 0 || posicao.Coluna > Colunas)
            {
                return false;
            }
            
            return true;
        }

        public void ValidarPosicao(Posicao posicao)
        {
            if(!PosicaoValida(posicao))
            {
                throw new TabuleiroException("Posição Inválida");
            }
        }
    }
}