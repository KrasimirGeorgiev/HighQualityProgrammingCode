using Ninject;
using Ninject.Modules;
using SchoolSystem.Cli.Configuration;

namespace SchoolSystem.Cli
{
    using System.IO;
    using System.Reflection;
    using Framework.Core;
    using Framework.Core.Commands;
    using Framework.Core.Commands.Contracts;
    using Framework.Core.Contracts;
    using Framework.Core.Providers;
    using Framework.Data;
    using Framework.Data.Contracts;
    using Framework.Factories.Contracts;
    using Measurements;
    using Ninject.Extensions.Conventions;
    using Ninject.Extensions.Factory;
    using Ninject.Extensions.Interception.Infrastructure.Language;

    public class SchoolSystemModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind(x =>
            {
                x.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .SelectAllClasses()
                .Excluding(typeof(Engine), typeof(Repository<>))
                .BindDefaultInterface();
            });

            this.Bind<IParser>().To<CommandParserProvider>().InSingletonScope();
            this.Bind<IWriter>().To<ConsoleWriterProvider>().InSingletonScope();
            this.Bind<IReader>().To<ConsoleReaderProvider>().InSingletonScope();
            this.Bind<IEngine>().To<Engine>().InSingletonScope();

            this.Bind(typeof(IRepository<>)).To(typeof(Repository<>)).InSingletonScope();

            this.ConfigureCommands();
            this.ConfigureFactories();
        }

        private void ConfigureFactories()
        {
            this.Bind<ITeacherFactory>().ToFactory().InSingletonScope();

            IConfigurationProvider configurationProvider = this.Kernel.Get<IConfigurationProvider>();

            if (configurationProvider.IsTestEnvironment)
            {
                this.TestConfiguration();
            }
            else
            {
                this.ProductionConfiguration();
            }
        }

        private void ProductionConfiguration()
        {
            this.Bind<IStudentFactory>().ToFactory().InSingletonScope();
            this.Bind<IMarkFactory>().ToFactory().InSingletonScope();

            this.Bind<ICommandFactory>()
                .ToFactory(() => new UseFirstArgumentAsNameInstanceProvider()).InSingletonScope();
        }

        private void TestConfiguration()
        {
            this.Bind<IStudentFactory>().ToFactory().InSingletonScope()
                .Intercept().With<PerformanceMeasurementInterceptor>();
            this.Bind<IMarkFactory>().ToFactory().InSingletonScope()
                .Intercept().With<PerformanceMeasurementInterceptor>();

            this.Bind<ICommandFactory>()
                .ToFactory(() => new UseFirstArgumentAsNameInstanceProvider()).InSingletonScope()
                .Intercept().With<PerformanceMeasurementInterceptor>();
        }

        private void ConfigureCommands()
        {
            const string createStudent = "CreateStudent";
            const string createTeacher = "CreateTeacher";
            const string removeStudent = "RemoveStudent";
            const string removeTeacher = "RemoveTeacher";
            const string studentListMarks = "StudentListMarks";
            const string teacherAddMark = "TeacherAddMark";

            this.Bind<ICommand>().To<CreateStudentCommand>().Named(createStudent);
            this.Bind<ICommand>().To<CreateTeacherCommand>().Named(createTeacher);
            this.Bind<ICommand>().To<RemoveStudentCommand>().Named(removeStudent);
            this.Bind<ICommand>().To<RemoveTeacherCommand>().Named(removeTeacher);
            this.Bind<ICommand>().To<StudentListMarksCommand>().Named(studentListMarks);
            this.Bind<ICommand>().To<TeacherAddMarkCommand>().Named(teacherAddMark);
        }
    }
}
