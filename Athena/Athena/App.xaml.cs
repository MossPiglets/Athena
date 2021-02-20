using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using Athena.Data;
using Microsoft.EntityFrameworkCore;

namespace Athena {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);
            using var context = new ApplicationDbContext();
            context.Database.EnsureCreated();
        }
    }
}