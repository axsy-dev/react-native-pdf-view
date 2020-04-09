﻿using Microsoft.ReactNative;

namespace test
{
    sealed partial class App : ReactApplication
{
    public App()
    {
        MainComponentName = "test";

#if BUNDLE
        JavaScriptBundleFile = "index.windows";
        InstanceSettings.UseWebDebugger = false;
        InstanceSettings.UseFastRefresh = false;
#else
        JavaScriptMainModuleName = "index";
        InstanceSettings.UseWebDebugger = true;
        InstanceSettings.UseFastRefresh = true;
#endif

#if DEBUG
        InstanceSettings.EnableDeveloperMenu = true;
#else
        InstanceSettings.EnableDeveloperMenu = false;
#endif

        PackageProviders.Add(new Microsoft.ReactNative.Managed.ReactPackageProvider()); // Includes any modules in this project
        PackageProviders.Add(new RNPDFvnext.ReactPackageProvider());

        InitializeComponent();
    }
}
}