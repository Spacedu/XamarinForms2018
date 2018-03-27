using System;
using System.Collections.Generic;
using System.Text;
using App1_Mimica.Model;

namespace App1_Mimica.Armazenamento
{
    public class Armazenamento
    {
        public static Jogo Jogo { get; set; }
        public static short RodadaAtual { get; set; }

        public static string[][] Palavras = {
            //Fac. Pontuação 1
            new string[] { "Olho", "Língua", "Chinelo", "Milho", "Penalti", "Bola", "Ping-pong" },

            //Med. Pontuação 3
            new string[] { "Carpinteiro", "Amerelo", "Limão", "Abelha" },

            //Dif. Pontuação 5
            new string[] { "Cisterna", "Lanterna", "Batman vs Superman", "Notebook" },
        };
    }
}
