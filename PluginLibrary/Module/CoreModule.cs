
using System;

namespace Raitichan.AdvancedVRChatPictureSorter.Library.Module {
	public interface ICoreModule {

		/// <summary>
		/// タスクトレイアイコンにメニューを追加します。
		/// </summary>
		/// <param name="name">項目名</param>
		/// <param name="e">押下時イベントハンドラ</param>
		void AddNotifycationMenu(string name, EventHandler e);

	}
}
