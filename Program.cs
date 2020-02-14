using System;
using Chromely.Core;
using Chromely.Core.Configuration;

namespace My_Chromely_App
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			//IChromelyConfiguration config = DefaultConfiguration.CreateForRuntimePlatform();

			AppBuilder
			.Create()
			.UseApp<DemoChromelyApp>()
			.Build()
			.Run(args);
		}

	}
}