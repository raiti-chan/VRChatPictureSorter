using NLog;
using System;
using System.Collections.Generic;

namespace Raitichan.AdvancedVRChatPictureSorter.Core.Window.Logger {
	/// <summary>
	/// ログの最小単位オブジェクト
	/// </summary>
	internal class LogElement {

		/// <summary>
		/// ログID
		/// </summary>
		public int Id { get; private set; }

		/// <summary>
		/// ログレベル
		/// </summary>
		public LogLevel Level { get; private set; }

		/// <summary>
		/// ログの時刻
		/// </summary>
		public DateTime Time { get; private set; }

		/// <summary>
		/// ロガー名
		/// </summary>
		public string LoggerName { get; private set; }

		/// <summary>
		/// ログメッセージ
		/// </summary>
		public string Message { get; private set; }

		/// <summary>
		/// ログプロパティ、空の場合null
		/// </summary>
		public IDictionary<object, object> Properties { get; private set; } = null;

		/// <summary>
		/// パラメータ
		/// </summary>
		public object[] Parameters { get; private set; } = null;

		/// <summary>
		/// LogEventInfoからLogElementの生成
		/// </summary>
		/// <param name="info">LogEventInfo</param>
		public LogElement (LogEventInfo info) {
			this.Id = info.SequenceID;
			this.Level = info.Level;
			this.Time = info.TimeStamp;
			this.LoggerName = info.LoggerName;
			this.Message = info.FormattedMessage;
			this.Parameters = info.Parameters;

			if (info.Properties.Count > 0) {
				this.Properties = info.Properties;
			}
		}

	}
}
