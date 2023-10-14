using Microsoft.Extensions.DependencyInjection;
using System;

namespace Dashboard.ViewModels;

public class ViewModelLocater
{
    private IServiceProvider _serviceProvider { get; }

    public ViewModelLocater(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    // Add properties for each ViewModel here
    public HousingMarketFactorsViewModel HousingMarketFactorsViewModel => _serviceProvider.GetRequiredService<HousingMarketFactorsViewModel>();

}