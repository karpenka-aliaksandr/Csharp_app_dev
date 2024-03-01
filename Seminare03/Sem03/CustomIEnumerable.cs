using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem03
{
    internal class CustomIEnumerable : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            return new CustomIEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new CustomIEnumerator();
        }
    }
}
