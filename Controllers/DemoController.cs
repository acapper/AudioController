using System;
using System.Collections.Generic;
using Chromely.Core.Configuration;
using Chromely.Core.Network;

namespace AudioController.Controllers {
	public class DemoController : ChromelyController {
		private readonly IChromelyConfiguration _config;

		public DemoController (IChromelyConfiguration config) {
			_config = config;
		}

		[HttpGet (Route = "/sample/demo")]
		private ChromelyResponse GetData (ChromelyRequest request) {

			var data = new { SomeField = 1, SomeOtherField = "Two" };

			return new ChromelyResponse (request.Id) {
				Data = data
			};
		}

		[HttpPost (Route = "/sample/execute")]
		private ChromelyResponse Execute (ChromelyRequest request) {
			Console.WriteLine ("Post");
			return new ChromelyResponse (request.Id) {
				Data = new { msg = "I went to c#", request = request }
			};
		}

		[Command (Route = "/sample/exitprogram")]
		public void ExitProgram (IDictionary<string, string> queryParameters) {
			System.Environment.Exit (1);
		}
	}
}