using NLog;
using System;

namespace Raitichan.AdvancedVRChatPictureSorter.Core.Window.Logger {
	/// <summary>
	/// ログの最小単位オブジェクト
	/// </summary>
	internal class LogElement {

		/// <summary>
		/// ログレベル
		/// </summary>
		public LogLevel Level { get; private set; }

		/// <summary>
		/// ログの時刻
		/// </summary>
		public DateTime Time { get; private set; }

		/// <summary>
		/// ログメッセージ
		/// </summary>
		public string Message { get; private set; }

		/// <summary>
		/// LogEventInfoからLogElementの生成
		/// </summary>
		/// <param name="info">LogEventInfo</param>
		public LogElement (LogEventInfo info) {
			this.Level = info.Level;
			this.Message = info.Message;
			this.Time = info.TimeStamp;
		}

	}
}
