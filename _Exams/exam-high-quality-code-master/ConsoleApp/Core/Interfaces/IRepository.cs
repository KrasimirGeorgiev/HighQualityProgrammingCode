namespace SchoolSystem.ConsoleApp.Core.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Repository for data objects
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T>
        where T : class
    {
        /// <summary>
        /// Gets an object by it's assinged id
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="KeyNotFoundException">Throws an exception if the object cannot be found</exception>
        /// <returns>Returns the found object</returns>
        T Get(int id);

        /// <summary>
        /// Adds object to the repository and returns it's assinged ID
        /// </summary>
        /// <param name="entity">Object to be added</param>
        /// <returns>Returns the assigned id</returns>
        int Add(T entity);

        /// <summary>
        /// Removes an object by it's id
        /// </summary>
        /// <param name="id">The target object ID</param>
        /// <exception cref="KeyNotFoundException">Throws an exception if the object cannot be found</exception>
        void Remove(int id);

        /// <summary>
        /// Gets all objects in the repository
        /// </summary>
        /// <returns>Returns a list of all objects</returns>
        IList<T> All();
    }
}
