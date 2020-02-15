using System;
using Chromely.Core;

namespace AudioController {
	class Program {
		[STAThread]
		static void Main (string[] args) {
			AppBuilder
				.Create ()
				.UseApp<AudioControllerApp> ()
				.Build ()
				.Run (args);
		}

	}
}