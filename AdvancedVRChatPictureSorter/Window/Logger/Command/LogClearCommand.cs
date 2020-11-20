using System;
using System.Windows.Input;

namespace Raitichan.AdvancedVRChatPictureSorter.Core.Window.Logger.Command {
	/// <summary>
	/// ログを削除するコマンド
	/// </summary>
	internal class LogClearCommand : ICommand {

		/// <summary>
		/// 実行可能か変更された際に通知する。
		/// </summary>
		public event EventHandler CanExecuteChanged;

		/// <summary>
		/// 実行可能か否か。常に実行可能なのでtrue。
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>true</returns>
		public bool CanExecute(object parameter) {
			return true;
		}

		/// <summary>
		/// 実行。ログを削除します。
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		public void Execute(object parameter) {
			App.CurrentApp.LogStack.Clear();
		}
	}
}
