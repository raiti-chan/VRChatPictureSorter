using NLog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raitichan.AdvancedVRChatPictureSorter.Core.Window.Logger {
	/// <summary>
	/// ログ管理
	/// </summary>
	internal class LogStack {

		/// <summary>
		/// ログ保存リスト
		/// </summary>
		private readonly List<LogElement> logElements;

		/// <summary>
		/// ログ保存リストの初期化
		/// </summary>
		public LogStack() {
			this.logElements = new List<LogElement>(1000);
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
		public ReadOnlyCollection<LogElement> LogElements {
			get {
				return this.logElements.AsReadOnly();
			}
		}

	}
}
