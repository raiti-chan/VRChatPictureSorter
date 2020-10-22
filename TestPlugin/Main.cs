using NLog;
using Raitichan.AdvancedVRChatPictureSorter.Library.Interface;
using System;

namespace Raitichan.AdvancedVRChatPictureSorter.Plugins.TestPlugin {

	/// <summary>
	/// テストプラグイン
	/// </summary>
	public class Main : IPlugin {

		/// <summary>
		/// Logger
		/// </summary>
		private static readonly Logger logger = LogManager.GetCurrentClassLogger();


		public string PluginName { get; } = "TestPlugin";

		public string PluginDesctiption { get; } = "Test!!";

		public Version PluginVersion { get; } = new Version(1, 0, 0);

		public void Dispose() {
			logger.Info("Test Plugin Dispose");
		}

		public void Initialize() {
			logger.Info("Test Plugin Initialize");
		}

		public void PreInitialize() {
			logger.Info("Test Plugin PreInitialize");
		}
	}
}
