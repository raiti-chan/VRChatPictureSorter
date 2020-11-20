using System;
using System.Windows.Data;
using System.Windows.Input;

namespace Raitichan.AdvancedVRChatPictureSorter.Core.Window.Logger.Command {
	/// <summary>
	/// フィルター更新コマンド
	/// </summary>
	internal class FilterUpdateCommand : ICommand {

		/// <summary>
		/// フィルター
		/// </summary>
		private readonly Predicate<object> filter;

		/// <summary>
		/// フィルターを指定して更新コマンドを初期化
		/// </summary>
		/// <param name="filter">フィルター</param>
		public FilterUpdateCommand(Predicate<object> filter) {
			this.filter = filter;
		}

		/// <summary>
		/// 有効変更通知
		/// </summary>
		public event EventHandler CanExecuteChanged;

		/// <summary>
		/// コマンドが有効か否かを返します。
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>有効か否か</returns>
		public bool CanExecute(object parameter) {
			return true;
		}

		public void Execute(object parameter) {
			if (!(parameter is ListCollectionView view)) return;
			view.Filter = this.filter;
			view.Refresh();
			return;
		}
	}
}
