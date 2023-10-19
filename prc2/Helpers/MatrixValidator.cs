using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prc2.Helpers
{
    public class MatrixValidator
    {
        internal static void Validate(MyMatrix? left, MyMatrix? right)
        {
            if (left == null || right == null)
            {
                throw new ArgumentNullException("Matrix operands cannot be null.");
            }

            if (left.Height != right.Height || left.Width != right.Width)
            {
                throw new InvalidOperationException("Matrix dimensions must match for addition.");
            }
        }
    }
}
