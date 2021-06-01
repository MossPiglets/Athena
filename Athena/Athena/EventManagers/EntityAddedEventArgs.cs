using System;

namespace Athena.EventManagers {
    public class EntityAddedEventArgs<T> : EventArgs {
        public T Entity { get; set; }
    }
}