
using LaGranAppPlugin;
using System.Collections.Generic;

namespace LaGranApp.ViewModel.Loader
{
    public interface IviewmodelLoader
    {
        List<IPlugin> Items { get; set; }
        IPlugin sItem { get; set; }
    }
}