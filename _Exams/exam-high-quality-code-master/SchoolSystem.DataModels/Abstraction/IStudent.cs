namespace SchoolSystem.DataModels.Abstraction
{
    using System.Collections.Generic;

    /// <summary>
    /// Student behavior interface
    /// </summary>
    public interface IStudent
    {
        /// <summary>
        /// Adds a mark to the student record
        /// </summary>
        /// <param name="mark"></param>
        void AddMark(IMark mark);

        /// <summary>
        /// Gets the student marks
        /// </summary>
        /// <returns></returns>
        IList<IMark> GetMarks();
    }
}