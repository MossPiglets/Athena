using Athena.Data;

namespace Athena.EventManagers.EventArgs {
    public class StoragePlaceAddedEventArgs : System.EventArgs {
        public StoragePlace StoragePlace { get; set; }
    }
}