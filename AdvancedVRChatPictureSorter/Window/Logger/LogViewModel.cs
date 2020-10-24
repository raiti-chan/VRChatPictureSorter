using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Raitichan.AdvancedVRChatPictureSorter.Core.Window.Logger {
	/// <summary>
	/// ログウィンドウのビューモデル
	/// </summary>
	internal class LogViewModel : INotifyPropertyChanged {

		/// <summary>
		/// ログ情報
		/// </summary>
		public LogStack LogStack { get; } = App.CurrentApp.LogStack;

		/// <summary>
		/// ログリスト
		/// </summary>
		public IList<LogElement> LogElements {
			get {
				if (LogStack == null) return null;
				return this.LogStack.LogElements;
			}
		}


		/// <summary>
		/// プロパティ変更通知イベント
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// プロパティの変更の通知
		/// </summary>
		/// <param name="propertyName">プロパティ名</param>
		private void RaisePropertyChanged([CallerMemberName]string propertyName = null) {
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
