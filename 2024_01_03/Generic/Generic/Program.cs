namespace Generic
{
    internal class Program
    {

        public static void ArrayCopy<T>(T[] source, T[] output)
        {
            for (int i = 0; i < source.Length; i++) { output[i] = source[i]; }
        }

        static void Main(string[] args)
        {
            int[] iSrc = { 1, 2, 3, 4, 5 };
            float[] fSrc = { 1f, 2f, 3f, 4f, 5f };
            double[] dSrc = { 1d, 2d, 3d, 4d, 5d };

            int[] iDst = new int[iSrc.Length];
            float[] fDst = new float[fSrc.Length];
            double[] dDst = new double[dSrc.Length];

            ArrayCopy<int>(iSrc, iDst);
            ArrayCopy<float>(fSrc, fDst);
            ArrayCopy<double>(dSrc, dDst);

            foreach (var item in iDst)
            {
                Console.Write($"{item}");
            }
            Console.WriteLine();
            foreach (var item in iSrc)
            {
                Console.Write($"{item}");
            }
            Console.WriteLine();
            foreach (var item in dSrc)
            {
                Console.Write($"{item}");
            }
        }
    }
}
