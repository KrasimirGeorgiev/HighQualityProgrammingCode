namespace SchoolSystem.DataModels.Abstraction
{
    using Enums;

    /// <summary>
    /// Defines the mark data object
    /// </summary>
    public interface IMark
    {
        float Value { get; }

        Subject Subject { get; }
    }
}