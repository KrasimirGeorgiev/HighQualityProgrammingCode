namespace SchoolSystem.DataModels.Abstraction
{
    /// <summary>
    /// The teacher behavior interface
    /// </summary>
    public interface ITeacher
    {
        /// <summary>
        /// Creates a mark in the given student record
        /// </summary>
        /// <param name="student">A student instance</param>
        /// <param name="value">The mark value</param>
        void AddMark(IStudent student, float value);
    }
}