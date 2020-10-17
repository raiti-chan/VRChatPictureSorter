using System;
using System.Threading;
using System.Windows;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VRChatPictureSorter {
	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow : Window {

		/// <summary>
		/// ルートパス
		/// </summary>
		private string rootPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\VRChat";

		/// <summary>
		/// 日付変更時刻
		/// </summary>
		private int hour = Properties.Settings.Default.Hour;

		/// <summary>
		/// 日図家変更時刻(分)
		/// </summary>
		private int minute = Properties.Settings.Default.Minute;

		/// <summary>
		/// ファイルシステムのウォッチャー
		/// </summary>
		private FileSystemWatcher watcher = null;

		/// <summary>
		/// ファイル名の正規表現
		/// </summary>
		private const string FileRegex = "VRChat_........._(....-..-.._..-..)-.......png";

		/// <summary>
		/// 初期化
		/// </summary>
		public MainWindow() {
			this.InitializeComponent();
			this.pathTextBox.Text = this.rootPath;

			List<int> hourList = new List<int>();
			for (int i = 0; i < 24; i++) {
				hourList.Add(i);
			}
			this.hourComboBox.ItemsSource = hourList;
			this.hourComboBox.SelectedIndex = this.hour;

			List<int> minuteList = new List<int>();
			for (int i = 0; i < 60; i++) {
				minuteList.Add(i);
			}
			this.minuteComboBox.ItemsSource = minuteList;
			this.minuteComboBox.SelectedIndex = this.minute;
		}

		/// <summary>
		/// ウィンドウを閉じようとしたとき
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e) {
			e.Cancel = true;
			this.pathTextBox.Text = this.rootPath;
			this.hourComboBox.SelectedIndex = this.hour;
			this.minuteComboBox.SelectedIndex = this.minute;
			this.Hide();
		}

		/// <summary>
		/// Cancelボタンを押したとき
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonCancel(object sender, RoutedEventArgs e) {
			this.pathTextBox.Text = this.rootPath;
			this.hourComboBox.SelectedIndex = this.hour;
			this.minuteComboBox.SelectedIndex = this.minute;
			this.Hide();
		}

		/// <summary>
		/// Acceptボタンを押したとき
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonAccept(object sender, RoutedEventArgs e) {
			this.rootPath = this.pathTextBox.Text;
			this.hour = this.hourComboBox.SelectedIndex;
			this.minute = this.minuteComboBox.SelectedIndex;

			Properties.Settings.Default.Hour = this.hour;
			Properties.Settings.Default.Minute = this.minute;
			Properties.Settings.Default.Save();

			if (this.watcher != null) {
				this.watcher.EnableRaisingEvents = false;
				this.watcher.Dispose();
				this.watcher = null;
			}

			this.watcher = new FileSystemWatcher {
				Path = this.rootPath,
				Filter = "*.png",
				NotifyFilter = NotifyFilters.FileName,
				IncludeSubdirectories = false,
			};

			this.watcher.Created += this.WatcherCreated;
			this.watcher.EnableRaisingEvents = true;

			this.Hide();
		}

		/// <summary>
		/// 終了
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonExit(object sender, RoutedEventArgs e) {
			if (MessageBox.Show("アプリケーションを終了します。\n振り分け機能は停止します。\nよろしいですか?", "終了",
				MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.Cancel) {
				return;
			}

			Application.Current.Shutdown();
		}

		/// <summary>
		/// ファイルをすべて展開します。
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		async private void FileDeployment(object sender, RoutedEventArgs e) {
			if (MessageBox.Show("すべての写真をVRChatのフォルダ直下に展開します。\nよろしいですか?", "確認",
				MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.Cancel) {
				return;
			}

			this.IsEnabled = false;
			await Task.Run(() => {
				string[] directoris = Directory.GetDirectories(this.rootPath);

				foreach (string directory in directoris) {
					string[] files = Directory.GetFiles(directory);
					foreach (string file in files) {
						Match result = Regex.Match(file, FileRegex);
						if (!result.Success) {
							continue;
						}
						File.Move(file, $"{this.rootPath}\\{Path.GetFileName(file)}");
					}
					if (Directory.GetFiles(directory).Length == 0 && Directory.GetDirectories(directory).Length == 0) {
						Directory.Delete(directory);
					}
				}
			});

			this.IsEnabled = true;
		}

		/// <summary>
		/// ファイルを手動で整理します。
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		async private void ManualSorting(object sender, RoutedEventArgs e) {
			if (MessageBox.Show("VRChatフォルダ以下のファイルを日付ごとに分類します。\nよろしいですか?", "確認",
				MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.Cancel) {
				return;
			}
			this.rootPath = this.pathTextBox.Text;
			this.hour = this.hourComboBox.SelectedIndex;
			this.minute = this.minuteComboBox.SelectedIndex;

			Properties.Settings.Default.Hour = this.hour;
			Properties.Settings.Default.Minute = this.minute;
			Properties.Settings.Default.Save();

			this.IsEnabled = false;
			await Task.Run(() => {
				string[] files = Directory.GetFiles(this.rootPath);
				int failure = 0;
				foreach (string file in files) {
					Match result = Regex.Match(file, FileRegex);
					if (!result.Success) {
						continue;
					}

					DateTime date = DateTime.ParseExact(result.Groups[1].Value, "yyyy-MM-dd_HH-mm", null);

					if (this.hour > date.Hour || (this.hour == date.Hour && this.minute > date.Minute)) {
						date = date.AddDays(-1);
					}

					string directoryName = $"{this.rootPath}\\{date.ToString("yyyy-MM-dd")}";
					Directory.CreateDirectory(directoryName);
					try {
						File.Move(file, $"{directoryName}\\{Path.GetFileName(file)}");
					} catch (IOException) {
						failure++;
					}
				}
				if (failure != 0) {
					MessageBox.Show($"{failure}件のファイルの移動に失敗しました。\n再度実行してみてください。", "情報", MessageBoxButton.OK, MessageBoxImage.Information);
				}
			});

			this.IsEnabled = true;
		}

		/// <summary>
		/// ファイルのウォッチャーのコールバック関数
		/// </summary>
		/// <param name="source"></param>
		/// <param name="e"></param>
		private void WatcherCreated(object source, FileSystemEventArgs e) {
			Match result = Regex.Match(e.Name, FileRegex);
			if (!result.Success) {
				return;
			}

			DateTime date = DateTime.ParseExact(result.Groups[1].Value, "yyyy-MM-dd_HH-mm", null);

			if (this.hour > date.Hour || (this.hour == date.Hour && this.minute > date.Minute)) {
				date = date.AddDays(-1);
			}

			string directoryName = $"{this.rootPath}\\{date.ToString("yyyy-MM-dd")}";
			Directory.CreateDirectory(directoryName);

			bool flag = false;
			while (!flag) {
				try {
					File.Move(e.FullPath, $"{directoryName}\\{e.Name}");
					flag = true;
				} catch (IOException) {
					Thread.Sleep(500);
				}
			}


		}
	}
}
