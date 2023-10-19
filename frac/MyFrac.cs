using System;

namespace frac
{
    public class MyFrac
    {
        private long nom;
        private long denom;

        public MyFrac(long nom_, long denom_)
        {
            nom = nom_;
            denom = denom_;

            FixNumberSign();

            var largestDivider = ReduceFraction(Math.Abs(nom), Math.Abs(denom));

            nom /= largestDivider;
            denom /= largestDivider;
        }

        public override string ToString()
        {
            return $"{nom}/{denom}";
        }

        public double DoubleValue()
        {
            return (double)nom / denom;
        }

        public MyFrac Add(MyFrac other)
        {
            long newNom = (nom * other.denom) + (other.nom * denom);
            long newDenom = denom * other.denom;

            return new MyFrac(newNom, newDenom);
        }

        public MyFrac Subtract(MyFrac other)
        {
            long newNom = (nom * other.denom) - (other.nom * denom);
            long newDenom = denom * other.denom;

            return new MyFrac(newNom, newDenom);
        }

        public MyFrac Multiply(MyFrac other)
        {
            long newNom = nom * other.nom;
            long newDenom = denom * other.denom;

            return new MyFrac(newNom, newDenom);
        }

        public MyFrac Divide(MyFrac other)
        {
            long newNom = nom * other.denom;
            long newDenom = denom * other.nom;

            return new MyFrac(newNom, newDenom);
        }

        public MyFrac CalcSum1(int n)
        {
            MyFrac frac = new MyFrac(0, 1);

            for (int i = 1; (double)frac.nom / frac.denom < (double)n / (n + 1); i++)
            {
                frac = Add(new MyFrac(1, i * (i + 1)));
            }

            return frac;
        }

        public MyFrac CalcSum2(int n)
        {
            MyFrac frac = new MyFrac(1, 1);

            for (int i = 2; ((double)frac.nom / frac.denom > (double)(n + 1) / (2 * n)); i++)
            {
                frac = Multiply(new MyFrac((long)Math.Pow(i, 2) - 1, (long)Math.Pow(i, 2)));
            }

            return frac;
        }

        private long ReduceFraction(long nom, long denom)
        {
            while (denom != 0)
            {
                long remainder = nom % denom;

                nom = denom;

                denom = remainder;
            }

            return nom;
        }

        private void FixNumberSign()
        {
            if (denom < 0)
            {
                denom = Math.Abs(denom);

                if (nom < 0)
                {
                    nom = Math.Abs(nom);
                }
                else
                {
                    nom *= -1;
                }
            }
        }

        public string ToStringWithIntegerPart()
        {
            string result;
            long wholePart = Math.Abs(nom / denom);

            if (Math.Abs(nom) >= Math.Abs(denom))
            {
                if (nom < 0)
                {
                    return $"-({wholePart} + {Math.Abs(nom % denom)}/{denom})";
                }

                return $"{wholePart} + {Math.Abs(nom % denom)}/{denom}";
            }

            return ToString();
        }
    }
}
