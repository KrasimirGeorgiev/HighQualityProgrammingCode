namespace SchoolSystem.ConsoleApp.Core
{
    using DataModels.Models;
    using Interfaces;

    public class DataStore : IDataStore
    {
        public DataStore()
            : this(new Repository<Teacher>(), new Repository<Student>())
        {
        }

        public DataStore(IRepository<Teacher> teachers, IRepository<Student> students)
        {
            this.Teachers = teachers;
            this.Students = students;
        }

        public IRepository<Teacher> Teachers { get; }

        public IRepository<Student> Students { get; }
    }
}
