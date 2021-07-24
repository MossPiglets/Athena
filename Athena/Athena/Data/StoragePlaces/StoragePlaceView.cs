using System;
using System.ComponentModel;


namespace Athena.Data.StoragePlaces {
    class StoragePlaceView : IDataErrorInfo {
        public Guid Id { get; set; }
        public string StoragePlaceName { get; set; }
        public string Error => null;

        public string this[string columnName] {
            get {
                string result = string.Empty;
                if (columnName == nameof(StoragePlaceName)) {
                    if (this.StoragePlaceName == "")
                        result = "Nazwa nie może być pusta.";
                }

                return result;
            }
        }

        public StoragePlace ToStoragePlace() {
            StoragePlace storageplaces = new StoragePlace();
            storageplaces.StoragePlaceName = StoragePlaceName;
            storageplaces.Id = Id;
            return storageplaces;
        }
    }
}