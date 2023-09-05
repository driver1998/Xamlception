using Microsoft.UI.Dispatching;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Hosting;
using Microsoft.UI.Xaml.Markup;
using Microsoft.UI.Xaml.XamlTypeInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamlception
{
    public class WinUIApp : Microsoft.UI.Xaml.Application, IXamlMetadataProvider
    {
        private DispatcherQueueController _dispatcherQueueController;
        private WindowsXamlManager _windowsXamlManager;
        private List<IXamlMetadataProvider> _providers;

        public WinUIApp()
        {
            _providers = new List<IXamlMetadataProvider>
            {
                new XamlControlsXamlMetaDataProvider(),
                new Xamlception.WinUI.Xamlception_WinUI_XamlTypeInfo.XamlMetaDataProvider()
            };

            _dispatcherQueueController = DispatcherQueueController.CreateOnCurrentThread();
            _windowsXamlManager = WindowsXamlManager.InitializeForCurrentThread();
        }

        public IXamlType? GetXamlType(Type type)
        {
            foreach (var provider in _providers)
            {
                var result = provider.GetXamlType(type);
                if (result != null) return result;
            }
            return null;
        }

        public IXamlType? GetXamlType(string fullName)
        {
            foreach (var provider in _providers)
            {
                var result = provider.GetXamlType(fullName);
                if (result != null) return result;
            }
            return null;
        }

        public XmlnsDefinition[] GetXmlnsDefinitions()
        {
            return _providers.SelectMany(p => p.GetXmlnsDefinitions()).ToArray();
        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            Resources.MergedDictionaries.Add(new XamlControlsResources());
        }
    }
}
