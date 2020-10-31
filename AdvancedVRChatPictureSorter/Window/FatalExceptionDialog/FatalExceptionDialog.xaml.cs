using System;

namespace Raitichan.AdvancedVRChatPictureSorter.Core.Window.FatalExceptionDialog {
	/// <summary>
	/// FatalExceptionDialog.xaml の相互作用ロジック
	/// </summary>
	internal partial class FatalExceptionDialog : System.Windows.Window {
		public FatalExceptionDialog(Exception e) {
			InitializeComponent();
			if (this.DataContext is ExceptionViewModel viewModel) {
				viewModel.Exception = e;
			}
		}
	}
}
