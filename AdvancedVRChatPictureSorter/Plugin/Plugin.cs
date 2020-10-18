using AdvancedVRChatPictureSorter.Lib;
using System.IO;

namespace AdvancedVRChatPictureSorter.Plugin {
	/// <summary>
	/// プラグイン管理用
	/// </summary>
	internal class Plugin {

		/// <summary>
		/// プラグイン
		/// </summary>
		public IPluginInterface PluginInterface { get; private set; }

		/// <summary>
		/// プラグインDLLへのパス
		/// </summary>
		public FileInfo PluginPath { get; private set; }

		/// <summary>
		/// プラグインオブジェクトの初期化
		/// </summary>
		/// <param name="context">プラグインのエントリーポイント</param>
		/// <param name="path">プラグインパス</param>
		public Plugin(FileInfo path ,IPluginInterface context) {
			this.PluginInterface = context;
			this.PluginPath = path;
		}

		/// <summary>
		/// プラグインを開放します。
		/// </summary>
		public void Dispose() {
			this.PluginInterface.Exit();
		}

	}
}
