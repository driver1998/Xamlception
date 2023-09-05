using MU = Microsoft.UI;
using MUX = Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Xamlception
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {        
        public App()
        {
            WinUIApp app = new();
        }
    }
}
