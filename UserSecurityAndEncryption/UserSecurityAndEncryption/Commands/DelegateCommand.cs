using System;
using System.Windows.Input;

namespace UserSecurityAndEncryption.Commands
{
    public class DelegateCommand<T> : ICommand // Step 1 :- Create command
    {

        private readonly Action<T>  _whattoExecute;
        private readonly Predicate<T> _whentoExecute;

        public DelegateCommand(Action<T> execute)
            : this(execute, null)
        {
        }

        public DelegateCommand(Action<T> execute, Predicate<T> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _whattoExecute = execute;
            _whentoExecute = canExecute;
        }
        public bool CanExecute(object parameter) // When he should execute
        {
            return _whentoExecute == null || _whentoExecute((T)parameter);
        }

        public void Execute(object parameter) // What to execute
        {
            _whattoExecute((T)parameter);
        }

        public event EventHandler CanExecuteChanged;
        //{
        //    add { CommandManager.RequerySuggested += value; }
        //    remove { CommandManager.RequerySuggested -= value; }
        //}
    }
}
