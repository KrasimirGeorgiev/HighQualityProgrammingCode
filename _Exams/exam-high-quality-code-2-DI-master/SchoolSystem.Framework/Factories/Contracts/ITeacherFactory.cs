namespace SchoolSystem.Framework.Factories.Contracts
{
    using Models.Contracts;
    using Models.Enums;

    public interface ITeacherFactory
    {
        ITeacher CreateTeacher(string firstName, string lastName, Subject subject, IMarkFactory markFactory);
    }
}