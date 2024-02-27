using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bits
{
    /*
     * Спроектируйте интерфейс для класса способного устанавливать и получать
     * значения отдельных бит в  заданном числе.
     * */
    internal interface IBits
    {
        public bool GetBits(int index);

        public void SetBits(int index, bool value);

    }
}
