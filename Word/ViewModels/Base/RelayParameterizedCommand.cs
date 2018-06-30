using System;
using System.Windows.Input;

namespace Word
{
    /// <summary>
    /// A basic command that runs an action with a parameter
    /// </summary>
    public class RelayParameterizedCommand : ICommand
    {
        /// <summary>
        /// The event that is fired when <see cref="CanExecute(object)"/> value has changed
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => { };

        /// <summary>
        /// Whether this command is executable or not
        /// </summary>
        public bool IsExecutable { get; set; }

        /// <summary>
        /// The action to run
        /// </summary>
        private readonly Action<object> action;

        /// <summary>
        /// Default counstructor
        /// </summary>
        /// <param name="action"></param>
        public RelayParameterizedCommand(bool can, Action<object> act)
        {
            IsExecutable = can;
            action = act;
        }

        /// <summary>
        /// Relay command that returns <see cref="IsExecutable"/>
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return IsExecutable;
        }

        /// <summary>
        /// Executes the action
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            action(parameter);
        }
    }
}
