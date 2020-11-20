using Raitichan.AdvancedVRChatPictureSorter.Library.Module;
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
		/// 全てのプラグインが読み込まれる前に呼ばれるイニシャライズ
		/// </summary>
		void PreInitialize();

		/// <summary>
		/// 全てのプラグインが読み込まれた後に呼ばれるイニシャライズ
		/// </summary>
		/// <param name="module">コアモジュール</param>
		void Initialize(ICoreModule module);


		/// <summary>
		/// プラグインのアンロード処理
		/// </summary>
		void Dispose();

	}
}
