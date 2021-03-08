using Athena.Data.Books;

namespace Athena.Windows
{
    public partial class BorrowedBooksListWindow
    {
        public BorrowedBooksListWindow()
        {
            InitializeComponent();
        }

        private void OpenReturnBookWindow_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Book book = (Book)BorrowedBookList.SelectedItem;
            ReturnWindow returnWindow = new ReturnWindow(book);
            returnWindow.Show();
        }
    }
}
