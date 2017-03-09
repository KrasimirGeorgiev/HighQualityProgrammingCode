namespace SchoolSystem.Framework.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using Framework.Data.Contracts;
    using Models.Contracts;

    public class Repository<T> : IRepository<T>
        where T : class, IEntity
    {
        private readonly IDictionary<int, T> entities;
        private int nextId;

        public Repository()
        {
            this.entities = new Dictionary<int, T>();
            this.nextId = 0;
        }

        public T Get(int id)
        {
            return this.entities[id];
        }

        public int Add(T entity)
        {
            int id = this.nextId;
            this.entities.Add(id, entity);
            entity.SetId(id);

            this.nextId++;
            return id;
        }

        public void Remove(int id)
        {
            bool isRemoved = this.entities.Remove(id);
            if (isRemoved == false)
            {
                throw new KeyNotFoundException($"Failed to match id: `{id}`");
            }
        }

        public IList<T> All()
        {
            return this.entities.Values.ToList();
        }
    }
}