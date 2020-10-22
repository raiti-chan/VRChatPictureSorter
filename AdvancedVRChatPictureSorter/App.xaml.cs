﻿using System.IO;
using System.Windows;
using NLog;

namespace Raitichan.AdvancedVRChatPictureSorter.Core {
	/// <summary>
	/// App.xaml の相互作用ロジック
	/// </summary>
	public partial class App : Application {
		/// <summary>
		/// Logger
		/// </summary>
		private static readonly Logger logger = LogManager.GetCurrentClassLogger();

		/// <summary>
		/// タスクトレイアイコン
		/// </summary>
		private NotifycationWrapper notify = null;

		/// <summary>
		/// 初期化処理
		/// </summary>
		private void Initialize() {
			logger.Info("Initialize application.");


			DirectoryInfo pluginRootDirectory = new DirectoryInfo("./plugins");
			if (!pluginRootDirectory.Exists) {
				pluginRootDirectory.Create();
			}
			logger.Info("Plugin Root Path : {0}", pluginRootDirectory.FullName);
		}


		private void StartEvent(object sender, StartupEventArgs e) {
			logger.Info("Start application.");

			this.ShutdownMode = ShutdownMode.OnExplicitShutdown;
			this.notify = new NotifycationWrapper();
			this.Initialize();
		}

		private void ExitEvent(object sender, ExitEventArgs e) {
			logger.Info("Finalze.");
			this.notify.Dispose();
		}

	}
}
