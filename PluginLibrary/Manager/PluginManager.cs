using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using NLog;
using Raitichan.AdvancedVRChatPictureSorter.Library.Interface;

namespace Raitichan.AdvancedVRChatPictureSorter.Library.Manager {
	/// <summary>
	/// プラグインマネージャー
	/// </summary>
	public class PluginManager {

		/// <summary>
		/// Logger
		/// </summary>
		private static readonly Logger logger = LogManager.GetCurrentClassLogger();

		/// <summary>
		/// 読み込まれたプラグイン
		/// </summary>
		private readonly Dictionary<string, PluginEntry> plugins = new Dictionary<string, PluginEntry>();


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

			foreach (KeyValuePair<string, PluginEntry> pair in this.plugins) {
				pair.Value.PluginInterface.Initialize();
			}
		}

		/// <summary>
		/// 指定されたパスのプラグインを読み込む
		/// </summary>
		/// <param name="dllFile">読み込むDLL</param>
		public void LoadPlugin(FileInfo dllFile) {
			logger.Info("Load Plugin {0}", dllFile);
			
			IPlugin plugin = null;
			Assembly asm = Assembly.LoadFrom(dllFile.FullName);

			var types = from type in asm.GetTypes() where !(type.IsInterface || type.IsAbstract) select type;
			foreach (Type type in types) {
				logger.Debug("Find Type : {0}", type.FullName);
				if (typeof(IPlugin).IsAssignableFrom(type)) {
					logger.Info("Find Plugin Entrypoint {0}", type.Name);
					plugin = Activator.CreateInstance(type) as IPlugin;
					break;
				}
			}

			if (plugin == null) {
				logger.Warn("Not found PluginInterface.");
				return;
			}

			logger.Info("Loaded Plugin : {0}, {1}, {2}", plugin.PluginName, plugin.PluginVersion, plugin.PluginDesctiption);
			plugin.PreInitialize();
			PluginEntry pe = new PluginEntry(dllFile, plugin);
			this.plugins.Add(plugin.PluginName, pe);
		}

		/// <summary>
		/// プラグインマネージャを破棄します。
		/// </summary>
		public void Dispose() {
			foreach(KeyValuePair<string, PluginEntry> plugin in this.plugins) {
				plugin.Value.PluginInterface.Dispose();
			}

			this.plugins.Clear();
		}

	}
}
