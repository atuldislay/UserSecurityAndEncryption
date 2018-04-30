using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UserSecurityAndEncryption.Commands
{
    public class DelegateCommand : ICommand // Step 1 :- Create command
    {

        private Action WhattoExecute;
        private Func<bool> WhentoExecute;

        public DelegateCommand(Action What, Func<bool> When)
        {
            WhattoExecute = What;
            WhentoExecute = When;
        }

        public bool CanExecute(object parameter) // When he should execute
        {

            return WhentoExecute();

        }


        public void Execute(object parameter) // What to execute
        {
            WhattoExecute();
        }

    

public event EventHandler CanExecuteChanged;
} 
}
