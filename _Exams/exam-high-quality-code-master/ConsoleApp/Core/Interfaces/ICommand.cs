namespace SchoolSystem.ConsoleApp.Core.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Application commands perform actions with the School Data Models
    /// </summary>
    internal interface ICommand
    {
        /// <summary>
        /// Executes the command with the provided command <see cref="arguments"/> and returns the result as text message
        /// </summary>
        /// <param name="arguments">A list of command parameters</param>
        /// <returns>Returns a message representing the result of the command execution</returns>
        string Execute(IList<string> arguments);
    }
}
