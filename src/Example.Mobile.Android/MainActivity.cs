﻿
using System;
using System.Diagnostics;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Example.Mobile.Extensions;
using Hostly;
using Hostly.Extensions;

namespace Example.Mobile.Droid
{
    [Activity(Label = "Example.Mobile", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, IXamarinHostingPlatform
    {
        public event EventHandler OnStarted;
        public event EventHandler OnStopped;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            new XamarinHostBuilder().ConfigureExampleMobile()
                .UsePlatform(this)
                .Build()
                .RunExampleMobile();
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnStop()
        {
            base.OnStop();
            OnStopped(this, null);
        }

        protected override void OnStart()
        {
            base.OnStart();
            OnStarted(this, null);
        }

        void IXamarinHostingPlatform.LoadApplication(IXamarinApplication application)
        {
            if (typeof(global::Xamarin.Forms.Application).IsAssignableFrom(application.GetType()))
                base.LoadApplication((global::Xamarin.Forms.Application)application);
            else
                throw new ArgumentException("Application supplied is of incorrect type");
        }
    }
}
