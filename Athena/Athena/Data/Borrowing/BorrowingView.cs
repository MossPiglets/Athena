using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Athena.Annotations;

namespace Athena.Data.Borrowing {
    public class BorrowingView : IDataErrorInfo, INotifyPropertyChanged {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Error => null;

        public string this[string columnName] {
            get {
                if (columnName == "FirstName") {
                    if (string.IsNullOrEmpty(FirstName)) {
                        return"Imię nie może być puste";
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

        public Borrowing ToBorrowing() {
            return new Borrowing {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                BorrowDate = BorrowDate,
                ReturnDate = ReturnDate
            };
        }
    }
}