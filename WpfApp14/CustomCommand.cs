using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp14
{
    public class CustomCommand<T> : ICommand where T: class
    {
        Action<T> action;
        Func<T, bool> canExecute;

        public CustomCommand(Action<T> action, Func<T, bool> canExecute)
        {
            this.action = action;
            this.canExecute = canExecute;
        }

        public event EventHandler? CanExecuteChanged
        { 
            add { CommandManager.RequerySuggested += value;  }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            if (parameter != null)
                return canExecute.Invoke((T)parameter);
            else
                return canExecute.Invoke(null);
        }

        public void Execute(object? parameter)
        {
            if (parameter != null)
                action.Invoke((T)parameter);
            else
                action.Invoke(null);
        }
    }

    public class CustomCommand : ICommand
    {
        Action action;

        public CustomCommand(Action action)
        {
            this.action = action;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            action.Invoke();
        }
    }
}
