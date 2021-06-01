using System;
using Athena.Data;

namespace Athena.EventManagers.EventsArguments {
    public class AuthorAddedEventArgs : EventArgs {
        public Author Author { get; set; }
    }
}