namespace SchoolSystem.Cli.Configuration
{
    using System.Linq;
    using Ninject.Extensions.Factory;

    /// <summary>
    /// Uses first method argument to match construction instance type name
    /// </summary>
    public class UseFirstArgumentAsNameInstanceProvider : StandardInstanceProvider
    {
        protected override string GetName(System.Reflection.MethodInfo methodInfo, object[] arguments)
        {
            return (string)arguments[0];
        }

        protected override Ninject.Parameters.IConstructorArgument[] GetConstructorArguments(System.Reflection.MethodInfo methodInfo, object[] arguments)
        {
            return base.GetConstructorArguments(methodInfo, arguments).Skip(1).ToArray();
        }
    }
}