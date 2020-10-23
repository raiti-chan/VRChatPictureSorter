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

		/// <summary>
		/// 初期化
		/// </summary>
		/// <param name="name">ターゲット名</param>
		public LogTarget(string name) {
			this.Name = name;
		}


		protected override void Write(LogEventInfo logEvent) {
			// TODO: ログコンソールへ出力
		}

	}
}
