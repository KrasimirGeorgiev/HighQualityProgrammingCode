namespace SchoolSystem.Framework.Factories.Contracts
{
    using Models.Contracts;
    using Models.Enums;

    public interface IMarkFactory
    {
        IMark CreateMark(Subject subject, float value);
    }
}