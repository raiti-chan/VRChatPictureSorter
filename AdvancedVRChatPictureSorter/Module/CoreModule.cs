using Raitichan.AdvancedVRChatPictureSorter.Library.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raitichan.AdvancedVRChatPictureSorter.Core.Module {
	/// <summary>
	/// アプリケーションコアモジュール
	/// </summary>
	internal class CoreModule : ICoreModule {

		/// <summary>
		/// コアモジュールインスタンス
		/// </summary>
		public static CoreModule Instance { get; } = new CoreModule();

	}
}
