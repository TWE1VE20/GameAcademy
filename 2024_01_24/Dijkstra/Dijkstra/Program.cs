namespace Dijkstra
{
    internal class Program
    {
        const int INF = 99999;

        public static void ShortestPath(in int[,] graph, in int start, out int[] distance, out int[] path)
        {
            int size = graph.GetLength(0);
            bool[] visited = new bool[size];
            distance = new int[size];
            path = new int[size];

            for (int i = 0; i < size; i++)
            {
                distance[i] = INF;
                path[i] = -1;
                visited[i] = false;
            }
            distance[start] = 0;

            for (int i = 0; i < size; i++)
            {
                int next = -1;
                int minCost = INF;
                for (int j = 0; j < size; j++)
                {
                    if (!visited[j] &&
                        distance[j] < minCost)
                    {
                        next = j;
                        minCost = distance[j];
                    }
                }
                if (next < 0)
                    break;

                for (int j = 0; j < size; j++)
                {
                    if (distance[j] > distance[next] + graph[next, j])
                    {
                        distance[j] = distance[next] + graph[next, j];
                        path[j] = next;
                    }
                }
                visited[next] = true;
            }
        }

        private static void PrintDijkstra(int[] distance, int[] path)
        {
            Console.WriteLine($"{"Vertex",8}{"Visit",8}{"Path",8}");

            for (int i = 0; i < distance.Length; i++)
            {
                Console.Write($"{i,8}");

                if (distance[i] >= INF)
                    Console.Write($"{"INF",8}");
                else
                    Console.Write($"{distance[i],8}");

                if (path[i] < 0)
                    Console.WriteLine($"{"X",8}");
                else
                    Console.WriteLine($"{path[i],8}");
            }
        }

        static void Main(string[] args)
        {
            int[,] graph = new int[18, 18]
            {
                {   0,   6,   6, INF, INF, INF, INF,   7, INF, INF, INF, INF, INF, INF, INF, INF, INF, INF},
                {   6,   0, INF, INF, INF,   9, INF, INF, INF, INF, INF, INF, INF, INF, INF, INF, INF, INF},
                {   6, INF,   0,   7, INF, INF,   8, INF, INF, INF, INF, INF, INF, INF, INF, INF, INF, INF},
                { INF, INF,   7,   0, INF, INF,   8, INF, INF, INF, INF, INF, INF, INF, INF, INF, INF,   3},
                { INF, INF, INF, INF,   0,   2, INF,   7,   8, INF, INF, INF, INF, INF, INF, INF, INF, INF},
                { INF,   9, INF, INF,   2,   0,   1, INF, INF,   2, INF, INF, INF, INF, INF, INF, INF, INF},
                { INF, INF,   8,   8, INF,   1,   0, INF, INF,   2,   8, INF, INF, INF, INF, INF, INF, INF},
                {   7, INF, INF, INF,   7, INF, INF,   0,   4, INF, INF, INF, INF, INF,   5, INF, INF, INF},
                { INF, INF, INF, INF,   8, INF, INF,   4,   0,   3, INF, INF,   4, INF, INF, INF, INF, INF},
                { INF, INF, INF, INF, INF,   2,   2, INF,   3,   0,   5, INF,   1, INF, INF, INF, INF, INF},
                { INF, INF, INF, INF, INF, INF,   8, INF, INF,   5,   0, INF, INF, INF, INF, INF, INF,   7},
                { INF, INF, INF, INF, INF, INF, INF,   5, INF, INF, INF,   0, INF, INF,   3, INF, INF, INF},
                { INF, INF, INF, INF, INF, INF, INF, INF,   4,   1, INF, INF,   0, INF, INF,   4,   7, INF},
                { INF, INF, INF, INF, INF, INF, INF, INF, INF, INF, INF, INF, INF,   0, INF, INF,   1, INF},
                { INF, INF, INF, INF, INF, INF, INF,   5, INF, INF, INF,   3, INF, INF,   0,   2, INF, INF},
                { INF, INF, INF, INF, INF, INF, INF, INF, INF, INF, INF, INF,   4, INF,   2,   0,   3,   6},
                { INF, INF, INF, INF, INF, INF, INF, INF, INF, INF, INF, INF,   7,   1, INF,   3,   0, INF},
                { INF, INF, INF,   3, INF, INF, INF, INF, INF, INF,   7, INF, INF, INF, INF,   6, INF,   0},
            };

            ShortestPath(in graph, 0, out int[] distance, out int[] path);

            Console.WriteLine("<Dijkstra>");
            PrintDijkstra(distance, path);
        }
    }
}
