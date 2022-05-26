﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TabuleiroXadrez
{
    internal class Tabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }

        public Peca[,] Pecas { get; private set; }


        public Tabuleiro(int linhas, int colunas) { 
        Linhas = linhas;
            Colunas = colunas;
            Pecas = new Peca[linhas, colunas];
        }

        public void ColocarPeca(Peca p, Posicao pos)
        {
            Pecas[pos.Linha, pos.Coluna] = p;
            p.PosPeca= pos;
        }



    }
}
