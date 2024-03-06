using Calculator.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Calculator.ViewModel
{
    internal class MainVM : INotifyPropertyChanged   
    {
        readonly ICalc calc = new Calc();

        private ICommand _сancelLastCommand;
                
        public ICommand CancelLastCommand
        {
            get
            {
                _сancelLastCommand = new CancelLastCommand(с => calc.CancelLast());
                return _сancelLastCommand;
            }
        }

        
        public MainVM()
        {
            calc.ChangeResult += Calc_ChangeResult;
        }


        private decimal _result;
        
        public decimal Result
        {
            get 
            { 
                return _result;
            }
            set 
            {
                _result = value;
                OnPropertyChanged(nameof(Result));
            }
        }
        private void Calc_ChangeResult(object? sender, OperandChangedEventArgs e)
        {
            Result = e.Operand;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private string _operatorAndOperand;
        public string OperatorAndOperand
        {
            get { return _operatorAndOperand; }
            set
            {
                bool isParsed = false;
                decimal number = 0;
                value = value.Trim();
                if (value.Length>0 && "+-*/".Contains(value[0]))
                {
                    string numberAsString = value.TrimStart('+', '-', '*', '/').Trim();
                    Console.WriteLine(value);
                    isParsed = decimal.TryParse(numberAsString, out number);
                }
                if (isParsed)
                {
                    Error = "";
                    switch (value[0])
                    {
                        case '+':
                            calc.Sum(number);
                            break;
                        case '-':
                            calc.Substract(number);
                            break;
                        case '*':
                            calc.Multiply(number);
                            break;
                        case '/':
                            calc.Divide(number);
                            break;
                    }
                    _operatorAndOperand = "";
                }
                else
                {
                    _operatorAndOperand = value;
                    Error = "неправильное выражение";
                }
            }
        }
        private string _error = "";
        public string Error 
        {
            get 
            { 
                return _error;
            }
            set
            {
                _error = value;
                OnPropertyChanged(nameof(Error));
            }
        }

        
    }
}
