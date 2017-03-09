namespace ChainOfResponsibility.Storages
{
    using System;
    using System.Collections.Generic;
    using ChainOfResponsibility.Requests;

    public class ChinaStorage : Storage, IHandle
    {
        public ChinaStorage()
        {
            this.storage = new List<object>();
            this.Name = "China";
        }

        public override void Handle(StorageRequest request)
        {
            if (request.Type == RequestType.Check)
            {
                this.RequestSeuccess(request);
            }
            else
            {
                base.Handle(request);
            }
        }
    }
}
