using NLog;
using Raitichan.AdvancedVRChatPictureSorter.Library.Module;
using System;

namespace Raitichan.AdvancedVRChatPictureSorter.Core.Module {
	/// <summary>
	/// アプリケーションコアモジュール
	/// </summary>
	internal class CoreModule : ICoreModule {

		/// <summary>
		/// Logger
		/// </summary>
		private static readonly Logger logger = LogManager.GetCurrentClassLogger();


		/// <summary>
		/// コアモジュールインスタンス
		/// </summary>
		public static CoreModule Instance { get; } = new CoreModule();

		public void Initialize() {
			logger.Info("Init CoreModule.");
		}

		/// <summary>
		/// タスクトレイアイコンにメニューを追加します。
		/// </summary>
		/// <param name="name">項目名</param>
		/// <param name="e">押下時イベントハンドラ</param>
		public void AddNotifycationMenu(string name, EventHandler e) {
			App.CurrentApp.Notifycation.AddMenuItem(name, e);
		}

	}
}
