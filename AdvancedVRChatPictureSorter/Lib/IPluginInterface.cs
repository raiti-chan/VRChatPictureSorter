using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedVRChatPictureSorter.Lib {
	/// <summary>
	/// プラグインを実装する際のインターフェイス
	/// </summary>
	public interface IPluginInterface {


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
		/// 終了処理
		/// </summary>
		void Exit();

	}
}
