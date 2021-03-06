﻿using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Prism;
using Prism.Ioc;
using Prism.Modularity;
using StockAlerts.App.Constants;
using StockAlerts.App.Services.Accounts;
using StockAlerts.App.Services.AlertDefinitions;
using StockAlerts.App.Services.Logging;
using StockAlerts.App.Services.RequestProvider;
using StockAlerts.App.Services.Settings;
using StockAlerts.App.Services.Stocks;
using StockAlerts.App.Services.UserPreferences;
using StockAlerts.App.Utility;
using StockAlerts.App.Views;
using StockAlerts.App.Views.AlertDefinitions;

namespace StockAlerts.App
{
    public partial class App
    {
        public App()
            : this(null)
        {

        }

        public App(IPlatformInitializer initializer)
            : this(initializer, true)
        {

        }

        public App(IPlatformInitializer initializer, bool setFormsDependencyResolver)
            : base(initializer, setFormsDependencyResolver)
        {

        }


        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync(nameof(MainPage));
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<LoginPage>();
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterForNavigation<SettingsPage>();
            containerRegistry.RegisterForNavigation<AlertsPage>();
            containerRegistry.RegisterForNavigation<AlertHistoryPage>();
            containerRegistry.RegisterForNavigation<EditAlertDefinitionPage>();
            containerRegistry.RegisterForNavigation<StockSearchPage>();

            containerRegistry.Register<ISettingsService, SettingsService>();
            containerRegistry.Register<IAccountService, AccountService>();
            containerRegistry.Register<IAlertDefinitionsService, AlertDefinitionsService>();
            containerRegistry.Register<IUserPreferencesService, UserPreferencesService>();
            containerRegistry.Register<IStocksService, StocksService>();
            containerRegistry.Register<IRequestProvider, RequestProvider>();
            containerRegistry.Register<ILogger, ConsoleLogger>();

            IHttpClientFactory httpClientFactory = new HttpClientFactory();
            httpClientFactory.AddHttpClient(
                MiscConstants.StockAlertsApi, 
                c =>
                {
                    c.BaseAddress = new Uri(MiscConstants.StockAlertsApiBaseUri);
                    c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                });
            containerRegistry.RegisterInstance(httpClientFactory);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
