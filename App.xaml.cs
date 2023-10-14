using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using Dashboard.ViewModels;
using System;

namespace Dashboard;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    [STAThread]
    public static void Main(string[] args)
    {
        // IHost is used to manage the application lifetime, logging, configuration, and dependency injection.
        using IHost host = CreateHostBuilder(args).Build();
        host.Start();
        
        App app = new();
        app.InitializeComponent();
        app.MainWindow = host.Services.GetRequiredService<MainWindow>();
        app.MainWindow.Visibility = Visibility.Visible;
        app.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) => 
        Host.CreateDefaultBuilder(args)
        .ConfigureAppConfiguration((HostBuilderContext, configurationsBuilder) =>
            configurationsBuilder.AddUserSecrets(typeof(App).Assembly))
        .ConfigureServices((hostContext, services) =>
        {
            // Below are are adding Views and ViewModels into the DI container
            // TODO: do we need to add the Views into the DI container?

            // AddSingleton - Only one instance is ever created and returned.
            // AddTransient - A new instance is created and returned every time.
            
            
            services.AddSingleton<ViewModelLocater>();
            services.AddSingleton<MainWindow>();


            services.AddSingleton<HousingMarketFactorsViewModel>();



            services.AddSingleton<WeakReferenceMessenger>();
            services.AddSingleton<IMessenger, WeakReferenceMessenger>(provider => provider.GetRequiredService<WeakReferenceMessenger>());

            //services.AddSingleton(_ => Current.Dispatcher);            

            //services.AddTransient<ISnackbarMessageQueue>(provider =>
            //{
            //    Dispatcher dispatcher = provider.GetRequiredService<Dispatcher>();
            //    return new SnackbarMessageQueue(TimeSpan.FromSeconds(2.0), dispatcher);
            //});

        });       
}
