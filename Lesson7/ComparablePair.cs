using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7
{
    public class ComparablePair<T, U> : Pair<T, U>, IComparable<ComparablePair<T, U>> where T : IComparable<T> where U : IComparable<U>
    {
        public ComparablePair() : base(){}

        public ComparablePair(T first, U second) : base(first, second){}

        private static int NullCompareTo<G>(G elem1, G elem2) where G : IComparable<G>
        {
            return elem1?.CompareTo(elem2) ?? -elem2?.CompareTo(elem1) ?? 0;
        }
        public int CompareTo(ComparablePair<T, U>? other)
        {
            if (other == null) return 1;
            int res1 = NullCompareTo(First, other.First);
            if (res1 == 0)
            {
                return NullCompareTo(Second, other.Second);
            }
            return res1;          
        }
    }
}
