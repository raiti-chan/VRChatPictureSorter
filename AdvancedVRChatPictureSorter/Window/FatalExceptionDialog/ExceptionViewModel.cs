using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Raitichan.AdvancedVRChatPictureSorter.Core.Window.FatalExceptionDialog {
	/// <summary>
	/// 致命的な例外ウィンドウのビューモデル
	/// </summary>
	internal class ExceptionViewModel : INotifyPropertyChanged {

		/// <summary>
		/// <see cref="Exception"/>
		/// </summary>
		private Exception exception;

		/// <summary>
		/// 発生例外
		/// </summary>
		public Exception Exception {
			get => this.exception;
			set {
				this.exception = value;
				this.ExceptionClassName = null;
				this.ExceptionMessage = null;
			}
		}

		/// <summary>
		/// クラス名を取得します。
		/// </summary>
		public string ExceptionClassName {
			private set => RaisePropertyChanged();
			get => this.Exception?.GetType().FullName;
		}

		/// <summary>
		/// 例外メッセージ
		/// </summary>
		public string ExceptionMessage {
			private set => RaisePropertyChanged();
			get {
				StringBuilder builder = new StringBuilder();
				Exception targetException = this.Exception;
				while (targetException != null) {
					builder.Append("Exception : ");
					builder.AppendLine(targetException.GetType().FullName);
					builder.Append("Message : ");
					builder.AppendLine(targetException.Message);
					builder.Append("Source : ");
					builder.AppendLine(targetException?.Source);
					builder.Append("Method : ");
					builder.AppendLine(targetException.TargetSite?.Name);
					if (targetException.InnerException != null) {
						builder.Append("Inner : ");
						builder.AppendLine(targetException.InnerException?.GetType().FullName);
					}
					builder.AppendLine(
						"\n" +
						"--------------------------------------------------------------Data--------------------------------------------------------------\n");
					foreach(object dataKey in targetException.Data) {
						builder.Append(dataKey.ToString());
						builder.Append(" : ");
						builder.AppendLine(targetException.Data[dataKey]?.ToString());
					}
					builder.AppendLine(
						"\n" +
						"--------------------------------------------------------------DataEnd--------------------------------------------------------------\n");
					builder.AppendLine(
						"\n" +
						"--------------------------------------------------------------StackTrace--------------------------------------------------------------\n");
					builder.AppendLine(targetException.StackTrace);
					builder.AppendLine(
						"\n" +
						"--------------------------------------------------------------EndStackTrace--------------------------------------------------------------\n");
					targetException = targetException.InnerException;
					if (targetException != null) {
						builder.AppendLine(
							"\n\n\n" +
							"--------------------------------------------------------------Next--------------------------------------------------------------\n");
					}
				}
				return builder.ToString();
			}
		}


		/// <summary>
		/// プロパティ変更通知イベント
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// プロパティの変更の通知
		/// </summary>
		/// <param name="propertyName">プロパティ名</param>
		private void RaisePropertyChanged([CallerMemberName] string propertyName = null) {
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

	}
}
