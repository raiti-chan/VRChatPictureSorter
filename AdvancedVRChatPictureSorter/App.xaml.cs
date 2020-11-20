using System;
using System.IO;
using System.Linq;
using System.Windows;
using NLog;
using NLog.Config;
using Raitichan.AdvancedVRChatPictureSorter.Core.Module;
using Raitichan.AdvancedVRChatPictureSorter.Core.Window.FatalExceptionDialog;
using Raitichan.AdvancedVRChatPictureSorter.Core.Window.Logger;
using Raitichan.AdvancedVRChatPictureSorter.Library.Manager;

namespace Raitichan.AdvancedVRChatPictureSorter.Core {
	/// <summary>
	/// App.xaml の相互作用ロジック
	/// </summary>
	internal partial class App : Application {

		public static App CurrentApp => Current as App;

		/// <summary>
		/// Logger
		/// </summary>
		private static readonly Logger logger = LogManager.GetCurrentClassLogger();

		/// <summary>
		/// タスクトレイアイコン
		/// </summary>
		public NotifycationWrapper Notifycation { private set; get; } = null;


		/// <summary>
		/// プラグインマネージャー
		/// </summary>
		private readonly PluginManager pluginManager = new PluginManager(CoreModule.Instance);

		/// <summary>
		/// ログスタック
		/// </summary>
		public LogStack LogStack { private set; get; } = null;

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

			this.pluginManager.LoadPlugins(pluginRootDirectory);
			CoreModule.Instance.Initialize();
			this.pluginManager.PluginInit();
		}


		private void StartEvent(object sender, StartupEventArgs e) {
			if (e != null && e.Args.Select(arg => arg.Equals("--debug-console")).Count() > 0) {
				this.LogStack = new LogStack();

				LogWindow logWindow = new LogWindow();
				logWindow.Show();

				LoggingConfiguration conf = LogManager.Configuration;
				LogTarget consoleTarget = new LogTarget("consoleWrapper", this.LogStack);
				conf.AddRule(LogLevel.Trace, LogLevel.Fatal, consoleTarget);
				LogManager.Configuration = conf;

			}

			AppDomain.CurrentDomain.UnhandledException += this.UnhandledException;

			logger.Info("Start application.");

			this.ShutdownMode = ShutdownMode.OnExplicitShutdown;
			this.Notifycation = new NotifycationWrapper();
			this.Initialize();
		}

		private void ExitEvent(object sender, ExitEventArgs e) {
			logger.Info("Finalze.");
			this.pluginManager.Dispose();
			this.Notifycation.Dispose();
		}

		/// <summary>
		/// ハンドルされていない例外。
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void UnhandledException(object sender, UnhandledExceptionEventArgs e) {
			logger.Fatal("Fatal Exception!!\nException was not catched.\n{0}", e.ExceptionObject.ToString());
			new FatalExceptionDialog(e.ExceptionObject as Exception).ShowDialog();

		}

	}
}
