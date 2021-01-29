using System;
using System.Data.SQLite;
using System.Diagnostics.CodeAnalysis;
using Coded.Core.Data;
using Coded.Core.Events;
using Coded.Core.Handler;
using Coded.Core.Mapping;
using Coded.Core.Query;
using Coded.Core.Validation;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Internal;
using Nevo.Business;
using SimpleInjector;

namespace Nevo.Api
{
    /// <summary>
    ///     Bootstraps the simple-injector DI container.
    /// </summary>
    public static class Bootstrapper
    {
        /// <summary>
        ///     Setup the container.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="configuration">The configuration.</param>
        /// <exception cref="ArgumentNullException">If container is null.</exception>
        public static void Bootstrap([DisallowNull] Container container, IConfiguration configuration)
        {
            DefaultTypeMap.MatchNamesWithUnderscores = true;
            if (container == null) throw new ArgumentNullException(nameof(container));
            container.RegisterSingleton<ISystemClock, SystemClock>();
            container.Register(typeof(IValidator<>), Assemblies.All, Lifestyle.Singleton);
            container.RegisterConditional(typeof(IValidator<>), typeof(ComponentModelValidator<>), Lifestyle.Singleton,
                context => !context.Handled);

            RegisterMappers(container);
            RegisterHandlers(container);
            RegisterQueries(container, configuration);
            container.Register<IEventBus, InMemoryEventBus>(Lifestyle.Scoped);

            // https://simpleinjector.readthedocs.io/en/4.0/using.html#collections
            // Warning: In contrast to the collection abstractions, array and List<T> are registered as Transient.
            // Array and List<T> are a mutable types; a consumer can change the contents of such collection.
            // Sharing it (by making it singleton) might cause unrelated parts of your applications to fail when changes
            // are made to it. Because an array and List<T> are concrete types, they can not function as a stream,
            // causing the elements in the array to get the lifetime of the consuming component. This could cause
            // lifestyle mismatches when the array was not registered as transient.
            container.Collection.Register(typeof(IConsumer<>), Assemblies.All);
            container.Collection.Append(typeof(IConsumer<>), typeof(EventLogger<>));
        }

        private static void RegisterQueries(Container container, IConfiguration configuration)
        {
            container.Register(typeof(IQuery<,>), Assemblies.All, Lifestyle.Scoped);
            container.Register<IConnectionFactory>(()
                => new ConnectionFactory<SQLiteConnection>(configuration.GetConnectionString("Nevo")), Lifestyle.Singleton);
            container.Register<IUnitOfWork, DapperUnitOfWork>(Lifestyle.Scoped);
            container.RegisterDecorator(typeof(IQuery<,>), typeof(IoValidationQueryDecorator<,>), Lifestyle.Scoped);
        }

        private static void RegisterMappers(Container container)
        {
            container.Register(typeof(IMapper<,>), Assemblies.All, Lifestyle.Scoped);
        }

        private static void RegisterHandlers(Container container)
        {
            container.Register(typeof(IHandler<,>), Assemblies.All, Lifestyle.Scoped);
            container.RegisterDecorator(typeof(IHandler<,>), typeof(IoValidationHandlerDecorator<,>), Lifestyle.Scoped);
            container.RegisterDecorator(typeof(IHandler<,>), typeof(FlushEventBusDecorator<,>), Lifestyle.Scoped);
            container.RegisterDecorator(typeof(IHandler<,>), typeof(UnitOfWorkScope<,>), Lifestyle.Scoped);
        }
    }
}