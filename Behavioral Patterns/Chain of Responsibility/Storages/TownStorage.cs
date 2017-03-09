namespace ChainOfResponsibility.Storages
{
    using System;
    using System.Collections.Generic;

    public class TownStorage : Storage, IHandle
    {
        public const int StorageLimit = 1;

        public TownStorage()
        {
            this.storage = new List<object>(StorageLimit);
            this.Name = "Town";
        }

        public override void Add(object item)
        {
            if (this.storage.Count < StorageLimit)
            {
                base.Add(item);
            }
            else
            {
                throw new ApplicationException("Storage is Full");
            }   
        }
    }
}
