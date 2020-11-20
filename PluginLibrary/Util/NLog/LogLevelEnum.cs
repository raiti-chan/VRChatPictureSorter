

using NLog;

namespace Raitichan.AdvancedVRChatPictureSorter.Library.Util.NLog {
	/// <summary>
	/// ログレベル列挙体
	/// </summary>
	public enum LogLevelEnum {
		/// <summary>
		/// トレース
		/// </summary>
		Trace,
		/// <summary>
		/// デバッグ
		/// </summary>
		Debug,
		/// <summary>
		/// 情報
		/// </summary>
		Info,
		/// <summary>
		/// 警告
		/// </summary>
		Warn,
		/// <summary>
		/// 例外
		/// </summary>
		Error,
		/// <summary>
		/// 致命的エラー
		/// </summary>
		Fatal,
		/// <summary>
		/// オフ
		/// </summary>
		Off,
	}

	/// <summary>
	/// LogLevel用関数
	/// </summary>
	public static class LogLevelUtil {

		/// <summary>
		/// NLogの<see cref="LogLevel"/>から<see cref="LogLevelEnum"/>を取得します。
		/// </summary>
		/// <param name="level">ログレベル</param>
		/// <returns><see cref="LogLevelEnum"/></returns>
		public static LogLevelEnum ToEnum(this LogLevel level) {
			if (level == LogLevel.Trace) return LogLevelEnum.Trace;
			if (level == LogLevel.Debug) return LogLevelEnum.Debug;
			if (level == LogLevel.Info) return LogLevelEnum.Info;
			if (level == LogLevel.Warn) return LogLevelEnum.Warn;
			if (level == LogLevel.Error) return LogLevelEnum.Error;
			if (level == LogLevel.Fatal) return LogLevelEnum.Fatal;
			return LogLevelEnum.Off;
		}

		/// <summary>
		/// <see cref="LogLevelEnum"/>からNLogの<see cref="LogLevel"/>を取得します。。
		/// </summary>
		/// <param name="level">ログレベル</param>
		/// <returns><see cref="LogLevel"/></returns>
		public static LogLevel ToOriginal(this LogLevelEnum level) {
			if (level == LogLevelEnum.Trace) return LogLevel.Trace;
			if (level == LogLevelEnum.Debug) return LogLevel.Debug;
			if (level == LogLevelEnum.Info) return LogLevel.Info;
			if (level == LogLevelEnum.Warn) return LogLevel.Warn;
			if (level == LogLevelEnum.Error) return LogLevel.Error;
			if (level == LogLevelEnum.Fatal) return LogLevel.Fatal;
			return LogLevel.Off;
		}

	}
}
