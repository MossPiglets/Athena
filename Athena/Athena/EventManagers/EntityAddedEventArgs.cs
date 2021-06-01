using System;
using System.Collections.Generic;
using System.Text;

namespace Athena.EventManagers {
    public class EntityAddedEventArgs<T> : EventArgs {
        public T t { get; set; }
    }
}