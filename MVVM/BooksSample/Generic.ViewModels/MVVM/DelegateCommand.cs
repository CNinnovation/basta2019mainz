using System;
using System.Windows.Input;

namespace GenericViewModels.MVVM
{
    public class DelegateCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private Action _execute;
        private Func<bool>? _canExecute;

        public DelegateCommand(Action execute)
            : this(execute, null) { }

        public DelegateCommand(Action execute, Func<bool>? canExecute)
            => (_execute, _canExecute) = (execute, canExecute);

        public bool CanExecute(object parameter) 
            => _canExecute?.Invoke() ?? true;

        public void Execute(object parameter) 
            => _execute();

        public void RaiseCanExecuteChanged() 
            => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
