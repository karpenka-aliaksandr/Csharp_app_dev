using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model
{
    public class OperandChangedEventArgs(decimal operand) : EventArgs
    {
        public decimal Operand => operand;
    }
}
