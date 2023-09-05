using System.Windows;
using System.Windows.Forms.Integration;

using MU = Microsoft.UI;
using MUX = Microsoft.UI.Xaml;

namespace Xamlception
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MUX.Hosting.DesktopWindowXamlSource? _desktopWindowXamlSource = null;

        public MainWindow()
        {
            InitializeComponent();

            btn.Click += (s, e) =>
            {
                MessageBox.Show("WPF button clicked");
            };
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var winformsHost = new WindowsFormsHost();
            var panel = new System.Windows.Forms.Panel();
            winformsHost.Child = panel;
            wrapperGrid.Children.Add(winformsHost);

            _desktopWindowXamlSource = new();
            var windowId = MU.Win32Interop.GetWindowIdFromWindow(winformsHost.Handle);
            _desktopWindowXamlSource.Initialize(windowId);
            _desktopWindowXamlSource.Content = new Xamlception.WinUI.RootUserControl();
            _desktopWindowXamlSource.SiteBridge.ResizePolicy = MU.Content.ContentSizePolicy.ResizeContentToParentWindow;
            _desktopWindowXamlSource.SiteBridge.Show();
        }
    }
}
