using System.IO;
using System.Threading.Tasks;
using MediatR.Pipeline;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;
using global::Autofac;
using MediatR.Extensions.Autofac.DependencyInjection;

namespace Athena.EventManagers
{
    class MediatorBuilder
    {
        public static IMediator Build()
        {
            var builder = new ContainerBuilder();
            // this will add all your Request- and Notificationhandler
            // that are located in the same project as your program-class
            builder.RegisterMediatR(typeof(EventBus).Assembly);

            var container = builder.Build();

            var mediator = container.Resolve<IMediator>();

            return mediator;
        }
    }
}
