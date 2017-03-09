namespace SchoolSystem.Framework.Factories.Contracts
{
    using Models.Contracts;
    using Models.Enums;

    public interface IStudentFactory
    {
        IStudent CreateStudent(string firstName, string lastName, Grade grade);
    }
}