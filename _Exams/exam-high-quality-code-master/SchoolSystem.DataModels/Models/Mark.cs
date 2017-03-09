namespace SchoolSystem.DataModels.Models
{
    using Abstraction;
    using Enums;

    public class Mark : IMark
    {
        public Mark(Subject sbj, float va)
        {
            this.Subject = sbj;
            this.Value = va;
        }

        public float Value { get; }

        public Subject Subject { get; }
    }
}
