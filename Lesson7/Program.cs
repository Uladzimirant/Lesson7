namespace Lesson7
{
    public class Program
    {
        public static void PrintComp<T>(T e1, T? e2) where T : IComparable<T>
        {
            const string n = "<null>";
            string str = e2?.ToString() ?? n;
            Console.WriteLine($"{e1} compareTo {str} = {e1.CompareTo(e2)}");
        }
        public static void Main(string[] args)
        {
            Pair<string, int>[] none = { new Pair<string, int>(), new Pair<string, int>("first", 3) };
            ComparablePair<decimal, string>[] dc = {
                new ComparablePair<decimal, string>(3.8m, "dec"),
                new ComparablePair<decimal, string>(4.7m, "done"),
                new ComparablePair<decimal, string>(2m, "first"),
                new ComparablePair<decimal, string>(2m, "second"),
            };
            ComparablePair<ComparablePair<int, int>, int>[] complex = {
                new ComparablePair<ComparablePair<int, int>, int>(new ComparablePair<int, int>(1, 2), 3),
                new ComparablePair<ComparablePair<int, int>, int>(new ComparablePair<int, int>(1, 2), 3),
                new ComparablePair<ComparablePair<int, int>, int>(new ComparablePair<int, int>(1, 2), 2),
                new ComparablePair<ComparablePair<int, int>, int>(new ComparablePair<int, int>(1, 3), 3),
                new ComparablePair<ComparablePair<int, int>, int>(new ComparablePair<int, int>(2, 3), 5),
                new ComparablePair<ComparablePair<int, int>, int>(null, 5),
            };
            Console.WriteLine("Elements");
            none.Concat<object>(dc).Concat(complex).ToList().ForEach(Console.WriteLine);
            Console.WriteLine("Results:");
            PrintComp(dc[0], dc[1]);
            PrintComp(dc[2], dc[3]);
            for (int i = 1; i < complex.Length; i++)
            {
                PrintComp(complex[0], complex[i]);
            }
        }
    }
}