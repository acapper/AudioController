using System;
using AudioController.Controllers;
using Chromely;
using Chromely.Core;
using Chromely.Core.Network;

namespace AudioController {
	class AudioControllerApp : ChromelyBasicApp {
		public override void Configure (IChromelyContainer container) {
			base.Configure (container);
			container.RegisterSingleton (typeof (ChromelyController), Guid.NewGuid ().ToString (), typeof (DemoController));
			container.RegisterSingleton (typeof (ChromelyController), Guid.NewGuid ().ToString (), typeof (AudioDevices));
		}
	}
}