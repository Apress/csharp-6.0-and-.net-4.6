using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Commands.Cmds.BaseClasses
{
    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> _execute;
        private readonly Func<T, bool> _canExecute;
        public RelayCommand(Action<T> execute) : this(execute, null) { }

        public RelayCommand(Action<T> execute, Func<T, bool> canExecute)
        {
            if (execute == null) throw new ArgumentNullException(nameof(execute));
            _execute = execute;
            _canExecute = canExecute;
        }
        public bool CanExecute(object parameter) => _canExecute == null || _canExecute((T)parameter);
        public void Execute(object parameter) { _execute((T)parameter); }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
