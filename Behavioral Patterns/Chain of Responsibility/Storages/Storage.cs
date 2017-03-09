namespace ChainOfResponsibility.Storages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ChainOfResponsibility.Requests;

    public abstract class Storage : IHandle
    {
        protected List<object> storage;

        public string Name { get; set; }

        public bool Check(object item)
        {
            return this.storage.Any(x => x.ToString().ToLower() == item.ToString().ToLower());
        }

        public virtual void Add(object item)
        {
            this.storage.Add(item);
        }

        public bool Remove(object item)
        {
            return this.storage.Remove(item);
        }

        public virtual void Handle(StorageRequest request)
        {
            try
            {
                switch (request.Type)
                {
                    case RequestType.Add:
                        this.Add(request.Body);
                        this.RequestSeuccess(request);

                        break;
                    case RequestType.Check:
                        if (this.Check(request.Body))
                        {
                            this.RequestSeuccess(request);
                        }
                        else
                        {
                            this.RequestFailure(request, 404, "Not Found");
                        }

                        break;
                    case RequestType.Buy:
                        if (this.Remove(request.Body))
                        {
                            this.RequestSeuccess(request);
                        }
                        else
                        {
                            this.RequestFailure(request, 404, "Not Found");
                        }

                        break;
                    default:
                        break;
                }
            }
            catch (ApplicationException ex)
            {
                this.RequestFailure(request, 403, ex.Message);
            }
        }

        protected virtual void RequestSeuccess(StorageRequest request)
        {
            request.Result = true;
            request.StatusCode = 200;
            request.Message = "OK";
            request.HandledBy = this.Name;
        }

        protected virtual void RequestFailure(StorageRequest request, int code, string message)
        {
            request.Result = false;
            request.StatusCode = code;
            request.Message = message;
            request.HandledBy = this.Name;
        }
    }
}
