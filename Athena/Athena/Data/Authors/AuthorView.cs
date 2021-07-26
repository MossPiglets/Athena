using System;
using System.ComponentModel;

namespace Athena.Data {
    class AuthorView : IDataErrorInfo {
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string Error => null;

        public string this[string columnName] {
            get {
                string result = string.Empty;
                if (columnName == nameof(LastName)) {
                    if (this.LastName == "")
                        result = "Musisz podać nazwisko.";
                }

                return result;
            }
        }

        public Author ToAuthor() {
            Author authors = new Author();
            authors.LastName = LastName;
            authors.Id = Id;
            return authors;
        }
    }
}