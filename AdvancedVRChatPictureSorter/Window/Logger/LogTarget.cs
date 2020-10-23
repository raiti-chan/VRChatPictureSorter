using NLog;
using NLog.Common;
using NLog.Targets;
using System;

namespace Raitichan.AdvancedVRChatPictureSorter.Core.Window.Logger {
	/// <summary>
	/// コンソールウィンドウへ出力するターゲット
	/// </summary>
	[Target("ConsoleWrapper")]
	internal class LogTarget : TargetWithLayout {

		private readonly LogStack stack;

		/// <summary>
		/// 初期化
		/// </summary>
		/// <param name="name">ターゲット名</param>
		public LogTarget(string name, LogStack stack) {
			this.Name = name;
			this.stack = stack;
		}


		protected override void Write(LogEventInfo logEvent) {
			this.stack.WriteLog(logEvent);
		}

	}
}
