namespace SchoolSystem.Framework.Models.Contracts
{
    /// <summary>
    /// Represents a Person with the basic attributes FirstName and LastName
    /// </summary>
    public interface IPerson : IEntity
    {
        string FirstName { get; }

        string LastName { get; }
    }
}
