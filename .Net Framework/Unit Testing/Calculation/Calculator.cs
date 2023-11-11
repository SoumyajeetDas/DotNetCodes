using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation
{
    public class Calculator : IDisposable
    {
        public int Addition(int x , int y)
        {
            return x + y;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);

        }

        public int substraction(int x , int y)
        {
            if (x < y)
                throw new ArgumentException("1st no is greater than the second");
            return x - y;
        }

        
    }
}
