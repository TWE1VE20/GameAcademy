using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    internal class Sort
    {
        static void DFS(in bool[,] graph, int start, out bool[] visited, out int[] parents)
        {
            visited = new bool[graph.GetLength(0)];
            parents = new int[graph.GetLength(0)];

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                visited[i] = false;
                parents[i] = -1;
            }

            SearchNode(graph, start, visited, parents);
        }

        private static void SearchNode(in bool[,] graph, int start, bool[] visited, int[] parents)
        {
            visited[start] = true;
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                if (graph[start, i] && !visited[i])
                {
                    parents[i] = start;
                    SearchNode(graph, i, visited, parents);
                }
            }
        }


        static void BFS(in bool[,] graph, int start, out bool[] visited, out int[] parents) 
        {
            visited = new bool[graph.GetLength(0)];
            parents = new int[graph.GetLength(0)];

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                visited[i] = false;
                parents[i] = -1;
            }
            visited[start] = true;

            Queue<int> bfsQueue = new Queue<int>();

            bfsQueue.Enqueue(start);
            while (bfsQueue.Count > 0)
            {
                int next = bfsQueue.Dequeue();

                for (int i = 0; i < graph.GetLength(0); i++)
                {
                    if (graph[next, i] && !visited[i])
                    {
                        visited[i] = true;
                        parents[i] = next;
                        bfsQueue.Enqueue(i);
                    }
                }
            }
        }

        static void Main(string[] args) 
        {
            bool[,] matrixGraph1 = new bool[8, 8]
            {
                { false, false, false,  true, true, false, false, false },
                { false, false, false,  true, false,  true,  true, false },
                { false, false, false, false, false, false,  true, false },
                { false,  true, false, false, false,  true, false,  true },
                {  true, false, false, false, false, false,  true, false },
                { false,  true, false,  true, false, false,  true,  true },
                { false, false,  true, false,  true,  true, false,  true },
                { false, false, false,  true, false,  true,  true, false },
            };

            bool[] dfsVisited;
            int[] dfsPath;
            DFS(in matrixGraph1, 0, out dfsVisited, out dfsPath);
            PrintGraphSearch(dfsVisited, dfsPath);
            Console.WriteLine();

            bool[] bfsVisited;
            int[] bfsPath;
            BFS(in matrixGraph1, 0, out bfsVisited, out bfsPath);
            PrintGraphSearch(bfsVisited, bfsPath);
            Console.WriteLine();
        }

        private static void PrintGraphSearch(bool[] visited, int[] path)
        {
            Console.WriteLine($"{"Vertex",8}{"Visit",8}{"Path",8}");

            for (int i = 0; i < visited.Length; i++)
            {
                Console.WriteLine($"{i,8}{visited[i],8}{path[i],8}");
            }
        }
    }
}
