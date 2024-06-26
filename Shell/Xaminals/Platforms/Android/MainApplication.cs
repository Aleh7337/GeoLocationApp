﻿using Android.App;
using Android.Runtime;
using Android;

[assembly: UsesPermission(Manifest.Permission.AccessCoarseLocation)]
[assembly: UsesPermission(Manifest.Permission.AccessFineLocation)]
[assembly: UsesFeature("android hardware. location", Required = false)]
[assembly: UsesFeature("android. hardware. location.gps", Required = false)]
[assembly: UsesFeature("android hardware. location.network", Required = false)]
//se si ha android successivo al 9
[assembly: UsesPermission(Manifest.Permission.AccessBackgroundLocation)]
namespace Xaminals;

[Application]
public class MainApplication : MauiApplication
{
	public MainApplication(IntPtr handle, JniHandleOwnership ownership)
		: base(handle, ownership)
	{
	}

	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}
