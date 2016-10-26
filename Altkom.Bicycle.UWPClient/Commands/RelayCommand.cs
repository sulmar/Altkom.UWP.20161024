using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Altkom.Bicycle.UWPClient.Commands
{
    public class RelayCommand : ICommand
    {

        private readonly Action execute;

        private readonly Func<bool> canExecute;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(); 
        }

        public void Execute(object parameter)
        {
            this.execute();
        }
    }
}
