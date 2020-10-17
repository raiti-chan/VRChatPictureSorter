using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace VRChatPictureSorter {
	/// <summary>
	/// App.xaml の相互作用ロジック
	/// </summary>
	public partial class App : Application {

		private NotifycationWrapper notify;

		private MainWindow window;

		protected override void OnStartup(StartupEventArgs e) {
			base.OnStartup(e);
			this.ShutdownMode = ShutdownMode.OnExplicitShutdown;
			this.notify = new NotifycationWrapper();
			this.window = new MainWindow();
			this.window.Show();
			this.MainWindow = this.window;
		}

		protected override void OnExit(ExitEventArgs e) {
			base.OnExit(e);
			this.notify.Dispose();
		}

	}
}
