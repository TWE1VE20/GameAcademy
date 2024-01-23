namespace Graph
{
    internal class Program
    {
        static void Main1(string[] args)
        {
            List<List<int>> listGraph1;
            listGraph1 = new List<List<int>>();

            for (int i = 0; i < 5; i++)
                listGraph1.Add(new List<int>());

            // Graph 1
            listGraph1[0].Add(2);
            listGraph1[0].Add(4);
            listGraph1[1].Add(2);
            listGraph1[1].Add(5);
            listGraph1[2].Add(1);
            listGraph1[2].Add(5);
            listGraph1[2].Add(6);
            listGraph1[3].Add(7);
            listGraph1[4].Add(0);
            listGraph1[4].Add(7);
            listGraph1[5].Add(1);
            listGraph1[5].Add(2);
            listGraph1[6].Add(2);
            listGraph1[7].Add(3);
            listGraph1[7].Add(4);

            bool[,] matrixGraph1 = new bool[8, 8]
            {
                { false, false, true, false, true, false, false, false },
                { false, false, true, false, false, true, false, false },
                { false, true, false, false, false, true, true, false },
                { false, false, false, false, false, false, false, true },
                { true, false, false, false, false, false, false, true },
                { false, true, true, false, false, false, false, false },
                { false, false, true, false, false, false, false, false },
                { false, false, false, true, true, false, false, false },
            };

            // Graph 2
            bool[,] matrixGraph2 = new bool[8, 8]
            {
                { false, false, false, false, false, false, false, false },
                { false, false, false, false, false, false, false, false },
                { false, false, false, false, true, true, false, false },
                { false, true, false, false, false, false, false, false },
                { false, false, false, false, false, false, false, false },
                { false, true, false, false, false, false, false, false },
                { false, false, true, false, false, true, false, false },
                { false, false, false, false, false, false, true, false },
            };

            const int INF = int.MaxValue;

            // Graph 3
            int[,] matrixGraph3 = new int[8, 8]
            {
                {   0,   4, INF, INF,   6, INF, INF, INF },
                {   4,   0,   5, INF,   4,   8, INF, INF },
                { INF,   5,   0, INF,   9, INF, INF, INF },
                {   0,   4, INF,   0, INF, INF, INF, INF },
                {   6, INF,   9, INF,   0, INF,   5, INF },
                { INF,   8, INF, INF, INF,   0, INF,   1 },
                { INF,   2, INF, INF,   5, INF,   0, INF },
                { INF, INF, INF, INF, INF,   1, INF,   0 },
            };
        }
    }
}
