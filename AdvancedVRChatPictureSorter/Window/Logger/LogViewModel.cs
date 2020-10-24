using NLog;
using Raitichan.AdvancedVRChatPictureSorter.Library.Util.NLog;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using System.Windows.Media;

namespace Raitichan.AdvancedVRChatPictureSorter.Core.Window.Logger {
	/// <summary>
	/// ログウィンドウのビューモデル
	/// </summary>
	internal class LogViewModel : INotifyPropertyChanged {

		/// <summary>
		/// ログ情報
		/// </summary>
		public LogStack LogStack { get; } = App.CurrentApp?.LogStack;

		/// <summary>
		/// ログリスト
		/// </summary>
		public ReadOnlyObservableCollection<LogElement> LogElements {
			get {
				if (LogStack == null) return null;
				return this.LogStack.ObservableLogElements;
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

	internal class LogElementRowColorConverter : IValueConverter {

		/// <summary>
		/// 標準色
		/// </summary>
		public Brush DefaultBrush { get; set; }

		/// <summary>
		/// トレース色
		/// </summary>
		public Brush TraceBrush { get; set; }


		/// <summary>
		/// デバッグ色
		/// </summary>
		public Brush DebugBrush { get; set; }

		/// <summary>
		/// 情報色
		/// </summary>
		public Brush InfoBrush { get; set; }

		/// <summary>
		/// 警告色
		/// </summary>
		public Brush WarnBrush { get; set; }

		/// <summary>
		/// エラー色
		/// </summary>
		public Brush ErrorBrush { get; set; }

		/// <summary>
		/// 致命的なエラー色
		/// </summary>
		public Brush FatalBrush { get; set; }


		public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
			LogLevel level = value as LogLevel;
			if (level == null) return this.DefaultBrush;
			switch (level.ToEnum()) {
				case LogLevelEnum.Trace:
					return this.TraceBrush;
				case LogLevelEnum.Debug:
					return this.DebugBrush;
				case LogLevelEnum.Info:
					return this.InfoBrush;
				case LogLevelEnum.Warn:
					return this.WarnBrush;
				case LogLevelEnum.Error:
					return this.ErrorBrush;
				case LogLevelEnum.Fatal:
					return this.FatalBrush;
				case LogLevelEnum.Off:
					return this.DefaultBrush;
				default:
					return this.DefaultBrush;
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
			throw new NotImplementedException();
		}
	}
}
