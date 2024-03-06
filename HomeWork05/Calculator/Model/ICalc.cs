using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model
{
    internal interface ICalc
    {
        void Sum(decimal x);
        void Substract(decimal x);
        void Divide(decimal x);
        void Multiply(decimal x);
        void CancelLast();

        event EventHandler<OperandChangedEventArgs> ChangeResult;

    }
}
