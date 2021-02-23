using System;
using System.Collections;

namespace IEnumeratorTest
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var x in new FibbonachiFirst(8))
            {
                Console.Write($"{x} ");
            }
            Console.WriteLine();
            foreach (var x in new Fibonachi())
            {
                Console.Write($"{x} ");
            }
        }


        public class FibbonachiFirst : IEnumerable
        {
            private int loopsCount;

            public FibbonachiFirst(int loopsCount)
            {
                this.loopsCount = loopsCount;
            }

            public IEnumerator GetEnumerator()
            {
                int previous = 0;
                int current = 1;
                int loop = 0;

                while (loop <= loopsCount)
                {
                    var helper = previous;
                    previous = current;
                    current = helper + current;
                    loop++;

                    yield return current;
                }
            }
        }

        public class FibonachiSecond : IEnumerator
        {
            private int loopsCount = 1;
            private int loop = 0;
            private int previous = 0;
            private int current = 1;

            public object Current => current;

            public FibonachiSecond(int loopsCount)
            {
                this.loopsCount = loopsCount;
            }

            public bool MoveNext()
            {
                if(loop <= loopsCount)
                {
                    var helper = previous;
                    previous = current;
                    current = helper + current;
                    loop++;
                    return true;
                }
                return false;
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }

        public class Fibonachi : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                return new FibonachiSecond(12);
            }
        }
    }
}
