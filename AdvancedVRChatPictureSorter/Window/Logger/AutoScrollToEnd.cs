using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;

namespace Raitichan.AdvancedVRChatPictureSorter.Core.Window.Logger {
	/// <summary>
	/// DataGridに要素が追加されたとき自動で一番したにスクロールするか否か。
	/// </summary>
	internal static class AutoScrollToEnd {

		#region +Enable

		/// <summary>
		/// 自動スクロールの有効
		/// </summary>
		public static readonly DependencyProperty EnableProperty = DependencyProperty.RegisterAttached(
			"Enable",
			typeof(bool),
			typeof(AutoScrollToEnd),
			new PropertyMetadata(EnablePropertyChanged) );
		
		/// <summary>
		/// <see cref="EnableProperty"/> Set
		/// </summary>
		/// <param name="obj">DataGrid</param>
		/// <param name="value">Enable</param>
		public static void SetEnable(DataGrid obj, bool value) => obj.SetValue(EnableProperty, value);

		/// <summary>
		/// <see cref="EnableProperty"/> Get
		/// </summary>
		/// <param name="obj">DataGrid</param>
		/// <returns>Is Enbale</returns>
		public static bool GetEnable(DataGrid obj) => (bool)obj.GetValue(EnableProperty);

		#endregion

		#region -Handler

		/// <summary>
		/// 要素更新イベントハンドラ
		/// </summary>
		private static readonly DependencyProperty HandlerProperty = DependencyProperty.RegisterAttached(
			"Handler",
			typeof(CollectionUpdateHandler),
			typeof(AutoScrollToEnd));

		/// <summary>
		/// <see cref="HandlerProperty"/> Set
		/// </summary>
		/// <param name="obj">DataGrid</param>
		/// <param name="value">Handler</param>
		private static void SetHandler(DataGrid obj, CollectionUpdateHandler value) => obj.SetValue(HandlerProperty, value);

		/// <summary>
		/// <see cref="HandlerProperty"/> Get
		/// </summary>
		/// <param name="obj">DataGrid</param>
		/// <returns>Handler</returns>
		private static CollectionUpdateHandler GetHandler(DataGrid obj) => obj.GetValue(HandlerProperty) as CollectionUpdateHandler;

		#endregion

		private static void EnablePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
			if (!(d is DataGrid dataGrid)) return;
			bool enable = (bool)e.NewValue;

			CollectionUpdateHandler handler = GetHandler(dataGrid);

			if (handler == null) {
				handler = new CollectionUpdateHandler(dataGrid);
				SetHandler(dataGrid, handler);
			}

			handler.Enable = enable;
		}

		/// <summary>
		/// DataGridに登録されているItemSourceの内容が変更された場合に発火するイベントハンドラ管理クラス。
		/// </summary>
		private class CollectionUpdateHandler {

			/// <summary>
			/// ターゲットグリッド
			/// </summary>
			private readonly DataGrid target;

			/// <summary>
			/// <see cref="Enable"/>
			/// </summary>
			private bool enable = false;

			/// <summary>
			/// 更新の通知が有効か否か
			/// </summary>
			public bool Enable { 
				get => this.enable;
				set {
					// 値が同じ場合は変更しない。
					if (enable == value) return;
					this.enable = value;
					if (this.target.ItemsSource is INotifyCollectionChanged notifyCollection) {
						if (value) {
							notifyCollection.CollectionChanged += this.OnCollectionUpdate;
						} else {
							notifyCollection.CollectionChanged -= this.OnCollectionUpdate;
						}
					}
				}
			}

			/// <summary>
			/// DataGridを指定して初期化
			/// </summary>
			/// <param name="grid">ターゲットグリッド</param>
			public CollectionUpdateHandler(DataGrid grid) {
				this.target = grid;
			}

			/// <summary>
			/// リストが更新されたとき発火する。
			/// </summary>
			/// <param name="o">リスト</param>
			/// <param name="e">イベント</param>
			private void OnCollectionUpdate(object o, NotifyCollectionChangedEventArgs e) {
				// o がINotifyCollectionChangedを実装していないことはあり得ない。
				if (!(o is INotifyCollectionChanged notifyCollection)) return;
				
				if (notifyCollection != this.target.ItemsSource) {
					// gridのソースとoが違う場合はハンドラを削除
					notifyCollection.CollectionChanged -= this.OnCollectionUpdate;

					if (!(this.target.ItemsSource is INotifyCollectionChanged sourceCollection)) return;
					// 新しいgridのソースがINotifyCollectionChangedを実装していたらハンドラを登録
					sourceCollection.CollectionChanged += this.OnCollectionUpdate;
					return;
				}
				target.Dispatcher.Invoke(() => {
					// gridのソースとoが同じ場合はGridをスクロール
					int count = this.target.Items.Count;
					if (count <= 0) return;
					this.target.ScrollIntoView(this.target.Items.GetItemAt(count - 1));
				});
			}

		}

	}


}
