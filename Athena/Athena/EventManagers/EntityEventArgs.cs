using System;

namespace Athena.EventManagers {
    public class EntityEventArgs<T> : EventArgs {
        public T Entity { get; set; }
    }
}