namespace VRChatPictureSorter {
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
			this.item_Open = new System.Windows.Forms.ToolStripMenuItem();
			this.item_Exit = new System.Windows.Forms.ToolStripMenuItem();
			this.Menu.SuspendLayout();
			// 
			// Icon
			// 
			this.Icon.ContextMenuStrip = this.Menu;
			this.Icon.Text = "VRChatPictureSorter v1.1";
			this.Icon.Visible = true;
			// 
			// Menu
			// 
			this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.item_Open,
            this.item_Exit});
			this.Menu.Name = "Menu";
			this.Menu.Size = new System.Drawing.Size(112, 48);
			// 
			// item_Open
			// 
			this.item_Open.Name = "item_Open";
			this.item_Open.Size = new System.Drawing.Size(111, 22);
			this.item_Open.Text = "Setting";
			// 
			// item_Exit
			// 
			this.item_Exit.Name = "item_Exit";
			this.item_Exit.Size = new System.Drawing.Size(111, 22);
			this.item_Exit.Text = "Exit";
			this.Menu.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.NotifyIcon Icon;
		private System.Windows.Forms.ContextMenuStrip Menu;
		private System.Windows.Forms.ToolStripMenuItem item_Open;
		private System.Windows.Forms.ToolStripMenuItem item_Exit;
	}
}
