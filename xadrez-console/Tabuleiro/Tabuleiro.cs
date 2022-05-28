using System;
using System.Collections.Generic;
using System.Text;
using Exceptions;

namespace TabuleiroXadrez
{
    internal class Tabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }

        public Peca[,] Pecas { get; private set; }

        //Construtor Tabuleiro
        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            Pecas = new Peca[linhas, colunas];
        }

        //Coloca a Peca p na Posicao pos
        public void ColocarPeca(Peca p, Posicao pos)
        {
            if (existePeca(pos))
            {
                throw new TabuleiroException("Já existe peça na posiçao");
            }
            Pecas[pos.Linha, pos.Coluna] = p;
            p.PosicaoDaPeca = pos;
        }

        //Verifica a validade da Posicao pos dependendo do Tabuleiro instanciado
        public bool PosicaoValida(Posicao pos)
        {
            if (pos.Linha < 0 || pos.Coluna < 0 || pos.Linha >= Linhas || pos.Coluna >= Colunas)
            {
                return false;
            }
            else return true;
        }

        //Verifica a validade da Posicao pos e lança exceçao caso for inválida
        public void ValidarPosicao(Posicao pos)
        {
            if (!PosicaoValida(pos))
            {
                throw new TabuleiroException("Posição inválida!");
            }

        }

        //Verifica a existencia de uma Peca na Posicao pos
        public bool existePeca(Posicao pos)
        {
            ValidarPosicao(pos);
            return (peca(pos) != null);

        }

        //Retorna a Peca na Posicao pos 
        public Peca peca(Posicao pos)
        {
            ValidarPosicao(pos);
            return Pecas[pos.Linha, pos.Coluna];
        }




    }
}
