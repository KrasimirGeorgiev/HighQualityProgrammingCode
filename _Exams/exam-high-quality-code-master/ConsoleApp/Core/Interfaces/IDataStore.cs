namespace SchoolSystem.ConsoleApp.Core.Interfaces
{
    using DataModels.Models;

    /// <summary>
    /// Holds repositories for Students and Teachers data
    /// </summary>
    public interface IDataStore
    {
        IRepository<Teacher> Teachers { get; }

        IRepository<Student> Students { get; }
    }
}
