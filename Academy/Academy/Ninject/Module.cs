using Academy.Commands.Adding;
using Academy.Commands.Contracts;
using Academy.Commands.Creating;
using Academy.Commands.Decorators;
using Academy.Commands.Listing;
using Academy.Core;
using Academy.Core.Contracts;
using Academy.Core.Factories;
using Academy.Core.Providers;
using Ninject;
using Ninject.Modules;

namespace Academy.Ninject
{
    class Module : NinjectModule
    {
        public const string addStudentToCourse = "AddStudentToCourse";
        public const string addStudentToSeason = "AddStudentToSeason";
        public const string addTrainerToSeason = "AddTrainerToSeason";

        //decorated
        public const string createCourseWithDecorator = "CreateCourse";
        public const string createCourseResultWithDecorator = "CreateCourseResult";
        public const string createSeasonWithDecorator = "CreateSeason";
        public const string createLectureWithDecorator = "CreateLecture";
        public const string createStudentWithDecorator = "CreateStudent";
        public const string createTrainerWithDecorator = "CreateTrainer";

        public const string createCourse = "createCourseWithoutDec";
        public const string createCourseResult = "createCourseResultWithoutDec";
        public const string createSeason = "createSeasonWithoutDec";
        public const string createLecture = "createLectureWithoutDec";
        public const string createStudent = "createStudentWithoutDec";
        public const string createTrainer = "createTrainerWithoutDec";

        public const string listCoursesInSeason = "ListCoursesInSeason";
        public const string listUsers = "ListUsers";
        public const string listUsersInSeason = "ListUsersInSeason";

        public override void Load()
        {
            this.Bind<IEngine>().To<Engine>().InSingletonScope();
            this.Bind<IWriter>().To<ConsoleWriter>();
            this.Bind<IReader>().To<ConsoleReader>();
            this.Bind<IParser>().To<CommandParser>();
            this.Bind<IDatabase>().To<Database>();

            this.Bind<ICommandFactory>().To<CommandFactory>();
            this.Bind<IAcademyFactory>().To<AcademyFactory>().InSingletonScope();

            //add command
            this.Bind<ICommand>().To<AddStudentToCourseCommand>().Named(addStudentToCourse);
            this.Bind<ICommand>().To<AddStudentToSeasonCommand>().Named(addStudentToSeason);
            this.Bind<ICommand>().To<AddTrainerToSeasonCommand>().Named(addTrainerToSeason);

            //creating command && decorated
            this.Bind<ICommand>().To<CreateCourseCommand>().Named(createCourse);
            this.Bind<ICommand>().To<DateCommandDecorator>().Named(createCourseWithDecorator)
                .WithConstructorArgument(this.Kernel.Get<ICommand>(createCourse));

            this.Bind<ICommand>().To<CreateCourseResultCommand>().Named(createCourseResult);
            this.Bind<ICommand>().To<DateCommandDecorator>().Named(createCourseResultWithDecorator)
                .WithConstructorArgument(this.Kernel.Get<ICommand>(createCourseResult));

            this.Bind<ICommand>().To<CreateSeasonCommand>().Named(createSeason);
            this.Bind<ICommand>().To<DateCommandDecorator>().Named(createSeasonWithDecorator)
                .WithConstructorArgument(this.Kernel.Get<ICommand>(createSeason));

            this.Bind<ICommand>().To<CreateLectureCommand>().Named(createLecture);
            this.Bind<ICommand>().To<DateCommandDecorator>().Named(createLectureWithDecorator)
                .WithConstructorArgument(this.Kernel.Get<ICommand>(createLecture));

            this.Bind<ICommand>().To<CreateStudentCommand>().Named(createStudent);
            this.Bind<ICommand>().To<DateCommandDecorator>().Named(createStudentWithDecorator)
                .WithConstructorArgument(this.Kernel.Get<ICommand>(createStudent));

            this.Bind<ICommand>().To<CreateTrainerCommand>().Named(createTrainer);
            this.Bind<ICommand>().To<DateCommandDecorator>().Named(createTrainerWithDecorator)
                .WithConstructorArgument(this.Kernel.Get<ICommand>(createTrainer));

            //listing command
            this.Bind<ICommand>().To<ListCoursesInSeasonCommand>().Named(listCoursesInSeason);
            this.Bind<ICommand>().To<ListUsersCommand>().Named(listUsers);
            this.Bind<ICommand>().To<ListUsersInSeasonCommand>().Named(listUsersInSeason);
        }
    }
}
