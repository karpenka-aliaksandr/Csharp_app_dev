using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Calculator.Model
{
    internal class CancelLastCommand(Action<object> execute) : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? param)
        {
            return true;
        }

        public void Execute(object? param)
        {
            execute(param);
        }
    }
}
