using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AdvancedVRChatPictureSorter {
	/// <summary>
	/// App.xaml の相互作用ロジック
	/// </summary>
	public partial class App : Application {

		private NotifycationWrapper notify = null;

		private void StartEvent(object sender, StartupEventArgs e) {
			this.ShutdownMode = ShutdownMode.OnExplicitShutdown;
			this.notify = new NotifycationWrapper();
		}

		private void ExitEvent(object sender, ExitEventArgs e) {
			this.notify.Dispose();
		}

	}
}
