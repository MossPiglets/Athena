using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Athena.Annotations;
using Athena.Data.Books;

namespace Athena.Data.Borrowings {
    public class BorrowingView : IDataErrorInfo, INotifyPropertyChanged {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public Book Book { get; set; }
        public string Error => null;

        public string this[string columnName] {
            get {
                if (columnName == "FirstName") {
                    if (this.FirstName == "") { 
                        return "Imię nie może być puste";
                    }
                }

                return null;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}