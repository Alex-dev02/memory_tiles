using MemoryTiles.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MemoryTiles
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            SetEnvironmentVariables();
            CreateUserView signInView = new CreateUserView();
            signInView.Show();
        }
        public void SetEnvironmentVariables()
        {
            Environment.SetEnvironmentVariable("cachePath", Environment.CurrentDirectory + @"\..\..\Cache");
            Environment.SetEnvironmentVariable("sourcePath", Environment.CurrentDirectory + @"\..\..");
        }
    }
}
