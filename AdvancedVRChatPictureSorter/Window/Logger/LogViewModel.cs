using NLog;
using Raitichan.AdvancedVRChatPictureSorter.Core.Window.Logger.Command;
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
				if (this.LogStack == null) return null;
				ReadOnlyObservableCollection<LogElement> elements = this.LogStack.ObservableLogElements;
				return elements;
			}
		}

		/// <summary>
		/// <see cref="FilterUpdateCommand"/>
		/// </summary>
		private FilterUpdateCommand filterUpdateCommand;

		/// <summary>
		/// フィルター更新コマンド
		/// </summary>
		public FilterUpdateCommand FilterUpdateCommand {
			get {
				if (this.filterUpdateCommand == null) {
					this.filterUpdateCommand = new FilterUpdateCommand(this.LogFilterFunction);
				}

				return this.filterUpdateCommand;
			}
		}

		/// <summary>
		/// <
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private bool LogFilterFunction(object element) {
			if (!(element is LogElement logElement)) {
				return false;
			}

			switch(logElement.Level.ToEnum()) {
				case LogLevelEnum.Trace:
					return !this.IsFiltedTrace;
				case LogLevelEnum.Debug:
					return !this.IsFiltedDebug;
				case LogLevelEnum.Info:
					return !this.IsFiltedInfo;
				case LogLevelEnum.Warn:
					return !this.IsFiltedWarn;
				case LogLevelEnum.Error:
					return !this.IsFiltedError;
				case LogLevelEnum.Fatal:
					return !this.IsFiltedFatal;
				default:
					return true;
			}
		}

		/// <summary>
		/// ログ削除コマンド
		/// </summary>
		public LogClearCommand LogClearCommand { get; } = new LogClearCommand();

		/// <summary>
		/// <see cref="IsFiltedTrace"/>
		/// </summary>
		private bool isFiltedTrace = false;
		/// <summary>
		/// リストのTraceのフィルタ状態
		/// </summary>
		public bool IsFiltedTrace { 
			get => this.isFiltedTrace;
			set {
				this.isFiltedTrace = value;
				this.RaisePropertyChanged();
			} 
		}

		/// <summary>
		/// <see cref="IsFiltedDebug"/>
		/// </summary>
		private bool isFiltedDebug = false;
		/// <summary>
		/// リストのDebugのフィルタ状態
		/// </summary>
		public bool IsFiltedDebug {
			get => this.isFiltedDebug;
			set {
				this.isFiltedDebug = value;
				this.RaisePropertyChanged();
			}
		}

		/// <summary>
		/// <see cref="IsFiltedInfo"/>
		/// </summary>
		private bool isFiltedInfo = false;
		/// <summary>
		/// リストのInfoのフィルタ状態
		/// </summary>
		public bool IsFiltedInfo {
			get => this.isFiltedInfo;
			set {
				this.isFiltedInfo = value;
				this.RaisePropertyChanged();
			}
		}

		/// <summary>
		/// <see cref="IsFiltedWarn"/>
		/// </summary>
		private bool isFiltedWarn = false;
		/// <summary>
		/// リストのWarnのフィルタ状態
		/// </summary>
		public bool IsFiltedWarn {
			get => this.isFiltedWarn;
			set {
				this.isFiltedWarn = value;
				this.RaisePropertyChanged();
			}
		}

		/// <summary>
		/// <see cref="IsFiltedError"/>
		/// </summary>
		private bool isFiltedError = false;
		/// <summary>
		/// リストのErrorのフィルタ状態
		/// </summary>
		public bool IsFiltedError {
			get => this.isFiltedError;
			set {
				this.isFiltedError = value;
				this.RaisePropertyChanged();
			}
		}

		/// <summary>
		/// <see cref="IsFiltedFatal/>
		/// </summary>
		private bool isFiltedFatal = false;
		/// <summary>
		/// リストのFatalのフィルタ状態
		/// </summary>
		public bool IsFiltedFatal {
			get => this.isFiltedFatal;
			set {
				this.isFiltedFatal = value;
				this.RaisePropertyChanged();
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
