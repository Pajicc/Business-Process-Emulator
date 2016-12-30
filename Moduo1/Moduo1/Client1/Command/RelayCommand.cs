using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client1.Command
{
    public class RelayCommand : RelayCommand<object>    // Abstraktna komanda, execute-canExecute
    {
        #region Constructors

        public RelayCommand(Action<object> execute)
            : base(execute, null)
        {
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
            : base(execute, canExecute)
        {
        }

        #endregion
    }

    public class RelayCommand<T> : ICommand, ICommandActive
    {
        #region Fields

        private readonly Action<T> execute;
        private readonly Predicate<T> canExecute;
        private bool isActive;

        #endregion

        #region Constructors

        public RelayCommand(Action<T> execute)
            : this(execute, null)
        {
        }

        public RelayCommand(Action<T> execute, Predicate<T> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }

            this.execute = execute;
            this.canExecute = canExecute;
        }


        #endregion // Constructors

        #region Events
        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (canExecute != null)
                {
                    CommandManager.RequerySuggested += value;
                }
            }

            remove
            {
                if (canExecute != null)
                {
                    CommandManager.RequerySuggested -= value;
                }

            }
        }

        /// <summary>
        /// Fired if the <see cref="IsActive"/> property changes.
        /// </summary>
        public event EventHandler IsActiveChanged;
        #endregion // Events

        #region Properties
        public bool IsActive
        {
            get
            {
                return isActive;
            }

            set
            {
                if (isActive != value)
                {
                    isActive = value;
                    OnIsActiveChanged();
                }
            }
        }
        #endregion

        #region ICommand Members

        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return this.canExecute == null ? true : this.canExecute((T)parameter);
        }

        public void Execute(object parameter)
        {
            this.execute((T)parameter);
        }

        #endregion // za ICommande

        #region IActiveAware members

        /// <summary>
        /// This raises the <see cref="IsActiveChanged"/> event.
        /// </summary>
        protected virtual void OnIsActiveChanged()
        {
            EventHandler isActiveChangedHandler = IsActiveChanged;
            if (isActiveChangedHandler != null)
            {
                isActiveChangedHandler(this, EventArgs.Empty);
            }
        }

        #endregion

    }
}
