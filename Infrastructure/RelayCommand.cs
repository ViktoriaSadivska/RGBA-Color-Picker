using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace exam.Infrastructure
{
    class RelayCommand : ICommand
    {
        Action<object> _execute;
        Predicate<object> _canexecute;

        public RelayCommand(Action<object> execute, Predicate<object> canexecute)
        {
            _execute = execute;
            _canexecute = canexecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }        
        }

        public bool CanExecute(object parameter)
        {
            return _canexecute == null ? true : _canexecute.Invoke(parameter);
        }

        public void Execute(object parameter)
        {
            _execute.Invoke(parameter);
        }
    }
}
