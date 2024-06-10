using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQueen
{
    internal class Solver
    {
        private Random rand = new Random();
        const int populationSize = 100;
        public Solver(int nQueens) 
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            // --- START TIMER ---
            List<Board> strongestPair = FindStrongestPair(InitializePopulation(nQueens));
            int generation = 1;

            while (strongestPair[0].GetIntersections() != 0)
            {
                strongestPair = FindStrongestPair(CreateNextGeneration(strongestPair));
                generation++;
            }
            // --- END TIMER ---
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);

            if (nQueens > 100)
            {
                Console.WriteLine("Too big to print.\nGenrations: " + generation + "\nElapsed Time (h:m:s:ms): " + elapsedTime);
            }
            else
            {
                Console.WriteLine(strongestPair[0] + "Genrations: " + generation + "\nElapsed Time (h:m:s:ms): " + elapsedTime);
            }
        }

        // Initializses a population of (populationSize) random board states.
        private List<Board> InitializePopulation(int nQueens)
        {
            List<Board> population = new List<Board>();

            for (int i = 0; i < populationSize; i++)
            {
                population.Add(new Board(GenerateRandomBoard(nQueens)));
            }

            return population;
        }

        // Generates a random state state of n queens.
        // One queen per row and column.
        private int[] GenerateRandomBoard(int nQueens)
        {
            List<int> availableIndex = new List<int>();
            for (int i = 0; i < nQueens; i++)
            {
                availableIndex.Add(i);
            }

            int[] newState = new int[nQueens];
            for (int i = 0; i < nQueens; i++)
            {
                int randomIndex = rand.Next(availableIndex.Count);
                newState[i] = availableIndex[randomIndex];
                availableIndex.RemoveAt(randomIndex);
            }
            return newState;
        }

        // Find the strongest two board states.
        // Uses a hash map to sperate the best from the worst.
        public List<Board> FindStrongestPair(List<Board> population)
        {
            int maxKey = 0;
            Dictionary<int, List<Board>> hashMap = new Dictionary<int, List<Board>>();
            foreach (Board board in population)
            {
                int key = board.GetIntersections();
                if(key > maxKey)
                    maxKey = key;

                if (hashMap.ContainsKey(key))
                    hashMap[key].Add(board);
                else
                    hashMap.Add(key, new List<Board>() { board });
            }

            const int maxBoards = 2;
            List<Board> strongestBoards = new List<Board>();

            for (int i = 0; i < maxKey+1; i++)
            {
                if (hashMap.ContainsKey(i))
                {
                    List<Board> currentList = hashMap[i];
                    foreach (Board board in currentList)
                    {
                        strongestBoards.Add(board);
                        if (strongestBoards.Count == maxBoards)
                            return strongestBoards;
                    }
                }
            }
            return strongestBoards;
        }

        // Takes two board states and combinds there genentic
        // information randomly to create a new population. 
        private List<Board> CreateNextGeneration(List<Board> parents)
        {
            int[] Mutation(int[] state)
            {
                if (rand.Next(2) == 0)
                {
                    List<int> availableIndex = new List<int>();
                    for (int i = 0; i < state.Length; i++)
                    {
                        availableIndex.Add(i);
                    }
                    int randomIndex1 = rand.Next(availableIndex.Count);
                    availableIndex.RemoveAt(randomIndex1);
                    int randomIndex2 = rand.Next(availableIndex.Count);

                    int temp = state[randomIndex1];
                    state[randomIndex1] = state[randomIndex2];
                    state[randomIndex2] = temp;
                }

                return state;
            }

            List<int[]> Crossover(List<Board> parents)
            {
                List<int[]> children = new List<int[]>();

                for (int i = 0; i < parents.Count; i++)
                {
                    children.Add(new int[parents[i].GetState().Length]);
                }

                foreach (int[] state in children)
                {
                    for (int i = 0; i < state.Length; i++)
                    {
                        state[i] = -1;
                    }
                }

                foreach (int[] child in children)
                {
                    List<int> availableElements = new List<int>();
                    for (int i = 0; i < child.Length; i++)
                    {
                        // If both parents share genetic information,
                        // keep it the same. Otherwise, keep a list of
                        // availabl elemnts to swap.
                        if (parents[0].GetState()[i] == parents[1].GetState()[i])
                        {
                            child[i] = parents[0].GetState()[i];
                        }
                        else
                        {
                            availableElements.Add(parents[0].GetState()[i]);
                        }
                    }

                    for (int i = 0; i < child.Length; i++)
                    {
                        if (child[i] == -1)
                        {
                            int randomIndex = rand.Next(availableElements.Count);
                            child[i] = availableElements[randomIndex];
                            availableElements.RemoveAt(randomIndex);
                        }
                    }
                }
                return children;
            }

            List<Board> population = new List<Board>();

            for (int i = 0; i < populationSize/2; i++)
            {
                List<int[]> children = Crossover(parents);
                population.Add(new Board(Mutation(children[0])));
                population.Add(new Board(Mutation(children[1])));
            }
            return population;
        }
    }
}
