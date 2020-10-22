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


		string IPlugin.PluginName { get; } = "TestPlugin";

		string IPlugin.PluginDesctiption { get; } = "Test!!";

		Version IPlugin.PluginVersion { get; } = new Version(1, 0, 0);

		void IPlugin.Dispose() {
			logger.Info("Test Plugin Dispose");
		}

		void IPlugin.Initialize() {
			logger.Info("Test Plugin Initialize");
		}
	}
}
