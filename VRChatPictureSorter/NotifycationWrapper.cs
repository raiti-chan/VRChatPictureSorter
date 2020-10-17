using System;
using System.ComponentModel;


namespace VRChatPictureSorter {
	/// <summary>
	/// 駐在アイコン
	/// </summary>
	public partial class NotifycationWrapper : Component {
		public NotifycationWrapper() {
			this.InitializeComponent();

			this.Icon.Icon = System.Drawing.SystemIcons.Application;

			this.item_Open.Click += this.Setting;
			this.item_Exit.Click += this.Exit;
		}

		public void Setting(object sender, EventArgs e) => System.Windows.Application.Current.MainWindow.Show();

		public void Exit(object sender, EventArgs e) => System.Windows.Application.Current.Shutdown();

		public NotifycationWrapper(IContainer container) {
			container.Add(this);

			this.InitializeComponent();
		}
	}
}
