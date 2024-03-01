using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem03
{
    internal class CustomIEnumerator : IEnumerator<int>
    {
        public int Current { get; private set; } = -1;
        object IEnumerator.Current => 0;

        public void Dispose()
        {
            
        }

        public bool MoveNext()
        {   
            Current++;
            if (Current < 10) return true; 
            else return false;
        }

        public void Reset()
        {
            Current = -1;
        }
    }
}
