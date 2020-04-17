﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace lab_1C.ViewModel
{
    public class VMRelayCommand : ICommand
    {
        #region Pola
        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;
        #endregion

        #region Konstruktor        
        public VMRelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));
            else
                _execute = execute;
            _canExecute = canExecute;
        }
        #endregion        

        #region Składowe interfejsu ICommand
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {           
            add
            {
                if (_canExecute != null) CommandManager.RequerySuggested += value;
            }
            remove
            {
                if (_canExecute != null) CommandManager.RequerySuggested -= value;
            }
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
        #endregion
    }
}
