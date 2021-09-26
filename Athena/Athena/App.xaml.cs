using System.Globalization;
using System.Threading;
using System.Windows;

namespace Athena {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);
            ApplicationDbContext.Instance.Database.EnsureCreated();
            ApplicationDbContext.Instance.Seed();
            CultureInfo info = new CultureInfo("pl-PL");
            Thread.CurrentThread.CurrentCulture = info;
            Thread.CurrentThread.CurrentUICulture = info;
        }
    }
}