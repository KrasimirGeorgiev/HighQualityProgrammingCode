namespace SchoolSystem.Cli.Measurements
{
    using System.Diagnostics;
    using System.Reflection;
    using Framework.Core.Contracts;
    using Ninject.Extensions.Interception;

    public class PerformanceMeasurementInterceptor : IInterceptor
    {
        private const string LogStartTemplate =
            "Calling method {0} of type {1}...";

        private const string LogEndTemplate =
            "Total execution time for method {0} of type {1} is {2} milliseconds.";

        private MethodInfo currentMethod;

        private readonly IWriter logger;
        private readonly Stopwatch stopwatch;

        public PerformanceMeasurementInterceptor(IWriter writer)
        {
            this.logger = writer;
            this.stopwatch = new Stopwatch();
        }

        public void Intercept(IInvocation invocation)
        {
            this.currentMethod = invocation.Request.Method;

            this.StartMeasurements();

            invocation.Proceed();

            this.EndMeasurements();
        }

        private void StartMeasurements()
        {
            this.logger.WriteLine(
                string.Format(
                    LogStartTemplate,
                    this.currentMethod.Name,
                    this.currentMethod.DeclaringType.Name));

            this.stopwatch.Start();
        }

        private void EndMeasurements()
        {
            this.stopwatch.Stop();

            var log = string.Format(
                LogEndTemplate,
                this.currentMethod.Name,
                this.currentMethod.DeclaringType.Name,
                this.stopwatch.ElapsedMilliseconds);

            this.logger.WriteLine(log);
        }
    }
}
