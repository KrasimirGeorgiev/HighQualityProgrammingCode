namespace SchoolSystem.Framework.Factories.Contracts
{
    using Core.Commands.Contracts;

    public interface ICommandFactory
    {
        ICommand CreateCommand(string name);
    }
}