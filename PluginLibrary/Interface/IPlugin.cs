using System;

namespace Raitichan.AdvancedVRChatPictureSorter.Library.Interface {
	public interface IPlugin {

		/// <summary>
		/// プラグイン名
		/// </summary>
		string PluginName { get; }

		/// <summary>
		/// プラグイン詳細
		/// </summary>
		string PluginDesctiption { get; }

		/// <summary>
		/// プラグインバージョン
		/// </summary>
		Version PluginVersion { get; }

		/// <summary>
		/// 初期化処理
		/// </summary>
		void Initialize();


		/// <summary>
		/// プラグインのアンロード処理
		/// </summary>
		void Dispose();

	}
}
