using NLog;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Windows.Threading;

namespace Raitichan.AdvancedVRChatPictureSorter.Core.Window.Logger {
	/// <summary>
	/// ログ管理
	/// </summary>
	internal class LogStack {

		/// <summary>
		/// ログ保存リスト
		/// </summary>
		private readonly ObservableCollection<LogElement> logElements;

		/// <summary>
		/// ログ保存リストの初期化
		/// </summary>
		public LogStack() {
			this.logElements = new ObservableCollection<LogElement>();
		}

		/// <summary>
		/// ログの書き込み。
		/// </summary>
		/// <param name="info">ログinfo</param>
		public void WriteLog(LogEventInfo info) {
			this.logElements.Add(new LogElement(info));
		}


		/// <summary>
		/// 読み取り専用でログリストを取得する。
		/// </summary>
		public ReadOnlyObservableCollection<LogElement> ObservableLogElements {
			get {
				ReadOnlyObservableCollection<LogElement> elements = new ReadOnlyObservableCollection<LogElement>(logElements);
				BindingOperations.EnableCollectionSynchronization(elements, new object());
				return elements;
			}
		}

	}
}
