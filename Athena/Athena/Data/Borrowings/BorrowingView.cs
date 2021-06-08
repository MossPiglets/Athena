using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Athena.Annotations;
using Athena.Data.Books;

namespace Athena.Data.Borrowings {
    public class BorrowingView : IDataErrorInfo, INotifyPropertyChanged
    {
        private Guid id;
        private string firstName;
        private string lastName;
        private DateTime borrowDate;
        private DateTime? returnDate;
        private Book book;
        public Guid Id
        {
            get => id; set
            {
                id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        public string FirstName {
            get => firstName; set
            {
                firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }
        public string LastName {
            get => lastName; set
            {
                lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }
        public DateTime BorrowDate {
            get => borrowDate; set
            {
                borrowDate = value;
                OnPropertyChanged(nameof(BorrowDate));
            }
        }
        public DateTime? ReturnDate {
            get => returnDate; set
            {
                returnDate = value;
                OnPropertyChanged(nameof(ReturnDate));
            }
        }
        public Book Book {
            get => book; set
            {
                book = value;
                OnPropertyChanged(nameof(Book));
            }
        }
        public string Error => null;

        public string this[string columnName]
        {
            get
            {
                if (columnName == nameof(FirstName))
                {
                    if (this.FirstName == "")
                    {
                        return "Imię nie może być puste";
                    }
                }

                return null;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}