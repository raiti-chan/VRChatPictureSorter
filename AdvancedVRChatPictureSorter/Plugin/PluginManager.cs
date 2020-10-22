using AdvancedVRChatPictureSorter.Lib;
using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using NLog;

namespace AdvancedVRChatPictureSorter.Plugin {
	/// <summary>
	/// プラグインマネージャー
	/// </summary>
	internal class PluginManager {

		/// <summary>
		/// Logger
		/// </summary>
		private static readonly Logger logger = LogManager.GetCurrentClassLogger();

		/// <summary>
		/// 読み込まれたプラグイン
		/// </summary>
		private readonly Dictionary<string, Plugin> plugins = new Dictionary<string, Plugin>();


		/// <summary>
		/// 指定されたディレクトリからプラグインを読み込む
		/// </summary>
		/// <param name="rootDirectory">ルートディレクトリ</param>
		public void LoadPlugins(DirectoryInfo rootDirectory) {
			logger.Info("Load plugins.");
			foreach (FileInfo dll in rootDirectory.GetFiles("*.dll")) {
				logger.Info("Find Dll {0}", dll.FullName);
				this.LoadPlugin(dll);
			}
		}

		/// <summary>
		/// 指定されたパスのプラグインを読み込む
		/// </summary>
		/// <param name="dllFile">読み込むDLL</param>
		public void LoadPlugin(FileInfo dllFile) {
			logger.Info("Load Plugin {0}", dllFile);
			
			IPluginInterface plugin = null;
			Assembly asm = Assembly.LoadFrom(dllFile.FullName);

			var types = from type in asm.GetTypes() where !(type.IsInterface || type.IsAbstract) select type;
			foreach (Type type in types) {
				if (type.IsAssignableFrom(typeof(IPluginInterface))) {
					logger.Info("Find Plugin Entrypoint {0}", type.Name);
					plugin = Activator.CreateInstance(type) as IPluginInterface;
					break;
				}
			}

			if (plugin == null) {
				logger.Warn("Not found PluginInterface.");
				return;
			}

			Plugin pm = new Plugin(dllFile, plugin);
			this.plugins.Add(plugin.PluginName, pm);
		}

		/// <summary>
		/// プラグインマネージャを破棄します。
		/// </summary>
		public void Dispose() {
			foreach(KeyValuePair<string, Plugin> plugin in this.plugins) {
				plugin.Value.Dispose();
			}

			this.plugins.Clear();
		}

	}
}
