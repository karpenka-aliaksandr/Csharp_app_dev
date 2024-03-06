using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model
{
    internal class Calc : ICalc
    {
        public event EventHandler<OperandChangedEventArgs> ChangeResult;
        private Stack<decimal> stack = new Stack<decimal>();
        private decimal Result
        {
            get
            {
                return stack.Count() == 0 ? 0 : stack.Peek();
            }
            set
            {
                stack.Push(value);
                RaiseEvent();
            }
        }
        public void RaiseEvent()
        {
            ChangeResult.Invoke(this, new OperandChangedEventArgs(Result));
        }
        public void CancelLast()
        {
            if (stack.Count > 0)
            {
                stack.Pop();
                RaiseEvent();
            }
        }
        public void Divide(decimal numder)
        {
            Result /= numder;
        }

        public void Multiply(decimal numder)
        {
            Result *= numder;
        }

        public void Substract(decimal numder)
        {
            Result -= numder;
        }

        public void Sum(decimal numder)
        {
            Result += numder;
        }

    }
}
