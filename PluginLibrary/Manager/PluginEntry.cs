using Raitichan.AdvancedVRChatPictureSorter.Library.Interface;
using System.IO;

namespace Raitichan.AdvancedVRChatPictureSorter.Library.Manager {
	/// <summary>
	/// プラグイン管理用
	/// </summary>
	internal class PluginEntry {

		/// <summary>
		/// プラグイン
		/// </summary>
		public IPlugin PluginInterface { get; private set; }

		/// <summary>
		/// プラグインDLLへのパス
		/// </summary>
		public FileInfo PluginPath { get; private set; }

		/// <summary>
		/// プラグインオブジェクトの初期化
		/// </summary>
		/// <param name="context">プラグインのエントリーポイント</param>
		/// <param name="path">プラグインパス</param>
		public PluginEntry(FileInfo path ,IPlugin context) {
			this.PluginInterface = context;
			this.PluginPath = path;
		}
	}
}
