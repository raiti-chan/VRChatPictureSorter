﻿using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AdvancedVRChatPictureSorter {
	public partial class NotifycationWrapper : Component {
		public NotifycationWrapper() {
			this.InitializeComponent();

			this.Icon.Icon = System.Drawing.SystemIcons.Application;

			this.itemExit.Click += this.OnClickExit;
		}

		public NotifycationWrapper(IContainer container) {
			container.Add(this);

			this.InitializeComponent();
		}

		private void OnClickExit(object sender, EventArgs e) {
			System.Windows.Application.Current.Shutdown();
		}

		/// <summary>
		/// コンテキストメニューを追加
		/// </summary>
		public void AddMenuItem(string menuName ,EventHandler e) {
			ToolStripMenuItem item = new ToolStripMenuItem();

			this.Menu.SuspendLayout();
			this.Menu.Items.Insert(0,item);
			item.Name = menuName;
			item.Text = menuName;
			item.Click += e;

			this.Menu.ResumeLayout(false);
		}

		/// <summary>
		/// メニューのセパレーターを追加します。
		/// </summary>
		public void AddMenuSeparator() {
			ToolStripSeparator separator = new ToolStripSeparator();

			this.Menu.SuspendLayout();
			this.Menu.Items.Insert(0, separator);

			this.Menu.ResumeLayout(false);
		}
	}
}
