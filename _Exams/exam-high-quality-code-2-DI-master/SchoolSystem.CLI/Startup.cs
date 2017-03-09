namespace SchoolSystem.Cli
{
    using Framework.Core.Contracts;
    using Framework.Data.Contracts;
    using Framework.Models.Contracts;
    using Ninject;

    public class Startup
    {
        public static void Main()
        {
            var kernel = new StandardKernel(new SchoolSystemModule());

            var rep = kernel.Get<IRepository<IStudent>>();
            var engine = kernel.Get<IEngine>();
            engine.Start();
        }
    }
}