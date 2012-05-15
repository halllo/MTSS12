using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace BuildSaveUi
{
    public class ActionCommand : ICommand
    {
        public Action CommandAction { get; set; }

        public ActionCommand(Action cmd)
        {
            CommandAction = cmd;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            CommandAction();
        }
    }
}
