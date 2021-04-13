using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Athena.Data.Books;

namespace Athena.Data.PublishingHouses {
    public class PublishingHouseView : IDataErrorInfo
    {
        public Guid Id { get; set; }
        public string PublisherName { get; set; }
        public virtual ICollection<Book> Books { get; set; }
        public string Error => null;
        public string this[string columnName]
        {
            get
            {
                string result = string.Empty;
                if (columnName == "PublisherName")
                {
                    if (this.PublisherName == "")
                        result = "Nazwa wydawcy nie może być pusta.";
                }

                return result;
            }
        }

        public PublishingHouse ToPublishingHouse()
        {
            PublishingHouse publishinghouse = new PublishingHouse();
            publishinghouse.PublisherName = PublisherName;
            publishinghouse.Id = Id;
            return publishinghouse;
        }
    }
}
