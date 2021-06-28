using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Athena.EventManagers
{
    public static class EventBus
    {
        static EventBus()
        {
            Instance = MediatorBuilder.Build();
        }

        public static IMediator Instance { get; }
    }
}
