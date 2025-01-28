using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQueen
{
    internal class Board
    {
        private int[] state;
        private int intersections = 0;

        public Board(int[] newState) 
        {
            state = newState;
            intersections = CalcIntersections();
        }

        public int GetIntersections() { return intersections; }
        public int[] GetState() { return state; }

        // Calculates diagonal intersections for all queens.
        private int CalcIntersections()
        {
            int count = 0;

            for (int i = 0; i < state.Length-1; i++)
            {
                int columnOrigin = state[i];

                for (int j = i + 1; j < state.Length; j++)
                {
                    int targetColumn = state[j];
                    if (targetColumn-j+i == columnOrigin || 
                        targetColumn+j-i == columnOrigin)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public override string ToString(){
            string s = "[ ";
            for(int i = 0; i < state.Length; i++){
                s += state[i] + " ";
            }
            s += "]";
            return s;
        }

        /*
           Prints a chess board with only (n) queens using 
           algebraic notation along the edges of the board.
           Example of n = 8:
            _____ _____ _____ _____ _____ _____ _____ _____
           |     |     |     |     |     |     |     |     |
         8 |     |     |     |     |     |     |     |  Q  |
           |_____|_____|_____|_____|_____|_____|_____|_____|
           |     |     |     |     |     |     |     |     |
         7 |     |     |     |     |     |     |  Q  |     |
           |_____|_____|_____|_____|_____|_____|_____|_____|
           |     |     |     |     |     |     |     |     |
         6 |     |     |     |     |     |  Q  |     |     |
           |_____|_____|_____|_____|_____|_____|_____|_____|
           |     |     |     |     |     |     |     |     |
         5 |     |     |     |     |  Q  |     |     |     |
           |_____|_____|_____|_____|_____|_____|_____|_____|
           |     |     |     |     |     |     |     |     |
         4 |     |     |     |  Q  |     |     |     |     |
           |_____|_____|_____|_____|_____|_____|_____|_____|
           |     |     |     |     |     |     |     |     |
         3 |     |     |  Q  |     |     |     |     |     |
           |_____|_____|_____|_____|_____|_____|_____|_____|
           |     |     |     |     |     |     |     |     |
         2 |     |  Q  |     |     |     |     |     |     |
           |_____|_____|_____|_____|_____|_____|_____|_____|
           |     |     |     |     |     |     |     |     |
         1 |  Q  |     |     |     |     |     |     |     |
           |_____|_____|_____|_____|_____|_____|_____|_____|
              a     b     c     d     e     f     g     h
        */

        public string PrintBoard()
        {
            string AlphabetCounter(int count)
            {
                char[] chars = 
                { 
                    ' ', 'a', 'b', 'c', 'd', 'e', 'f', 'g',
                    'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o',
                    'p', 'q', 'r', 's', 't', 'u', 'v', 'w',
                    'x', 'y', 'z'
                };
                const int alphabet = 26;

                char[] notation = new char[3]{' ', ' ', ' '};

                if (count < alphabet)
                {
                    notation[1] = chars[(count % alphabet) + 1];
                }
                else if (count < Math.Pow(alphabet,2))
                {
                    notation[0] = chars[(count / alphabet)];
                    notation[1] = chars[(count % alphabet) + 1];
                }
                else if (count < Math.Pow(alphabet, 3))
                {
                    notation[1] = chars[(count / (alphabet * alphabet))];
                    notation[1] = chars[(count / alphabet)];
                    notation[2] = chars[(count % alphabet) + 1];
                }
                return "" + notation[0] + notation[1] + notation[2];
            }

            string NumberCounter(int count)
            {
                if (count < 10)
                    return "   " + count;
                else if(count < 100)
                    return "  " + count;
                else if (count < 1000)
                    return " " + count;
                else if (count < 10000)
                    return "" + count;
                return "????";
            }

            const string queenSymbol = "Q";
            const string padding = "      ";
            string ss = padding;

            for (int i = 0; i < state.Length; i++)
            {
                ss += " _____";
            }
            ss += "\n" + padding;

            for (int i = 0; i < state.Length; i++)
            {
                for (int j = 0; j < state.Length; j++)
                {
                    ss += "|     ";
                }

                ss += "|\n " + NumberCounter(state.Length - i) + " ";

                for (int j = 0; j < state.Length; j++)
                {
                    string centerSquare = " ";
                    if (state[i] == j)
                        centerSquare = queenSymbol;
                    ss += "|  " + centerSquare + "  ";
                }

                ss += "|\n" + padding;

                for (int j = 0; j < state.Length; j++)
                {
                    ss += "|_____";
                }

                ss += "|\n" + padding;
            }

            for (int i = 0; i < state.Length; i++)
            {
                ss += "  " + AlphabetCounter(i) + " ";
            }
            ss += "\n";
            return ss;
        }
    }
}
