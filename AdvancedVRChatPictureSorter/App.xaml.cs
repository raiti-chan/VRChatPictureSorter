using System.Windows;
using AdvancedVRChatPictureSorter.Plugin;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace AdvancedVRChatPictureSorter {
	/// <summary>
	/// App.xaml の相互作用ロジック
	/// </summary>
	public partial class App : Application {
		/// <summary>
		/// Logger
		/// </summary>
		private static readonly Logger logger = LogManager.GetCurrentClassLogger();

		/// <summary>
		/// プラグインマネージャー
		/// </summary>
		private readonly PluginManager pluginManager = new PluginManager(); 

		/// <summary>
		/// タスクトレイアイコン
		/// </summary>
		private NotifycationWrapper notify = null;

		/// <summary>
		/// 初期化処理
		/// </summary>
		private void Initialize() {
			logger.Info("Initialize application.");
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
