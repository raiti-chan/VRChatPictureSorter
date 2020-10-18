namespace AdvancedVRChatPictureSorter {
	partial class NotifycationWrapper {
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region コンポーネント デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			this.Icon = new System.Windows.Forms.NotifyIcon(this.components);
			this.Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.itemExit = new System.Windows.Forms.ToolStripMenuItem();
			this.Menu.SuspendLayout();
			// 
			// Icon
			// 
			this.Icon.ContextMenuStrip = this.Menu;
			this.Icon.Visible = true;
			// 
			// Menu
			// 
			this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemExit});
			this.Menu.Name = "menu";
			this.Menu.Size = new System.Drawing.Size(180, 70);
			// 
			// itemExit
			// 
			this.itemExit.Name = "itemExit";
			this.itemExit.Size = new System.Drawing.Size(93, 22);
			this.itemExit.Text = "Exit";
			this.Menu.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.NotifyIcon Icon;
		private System.Windows.Forms.ContextMenuStrip Menu;
		private System.Windows.Forms.ToolStripMenuItem itemExit;
	}
}
