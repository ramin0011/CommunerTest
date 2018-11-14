using System;
using System.Windows.Input;

namespace Communer.Core.Models.Mvvm
{
    public class CommandHandler : ICommand
    {
        private Action _action;
        private Action<object> _actionWithParams;
        private bool _canExecute;
        public CommandHandler(Action action, bool canExecute=true)
        {
            _action = action;
            _canExecute = canExecute;
        }
        public CommandHandler(Action<object> action, bool canExecute=true)
        {
            _actionWithParams = action;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            if(parameter==null)
            _action();
            else
            _actionWithParams(parameter);
        }
    }
}
