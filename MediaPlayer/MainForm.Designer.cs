namespace MediaPlayer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pbHighlights = new System.Windows.Forms.PictureBox();
            this.PlayerContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMediasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savePlayListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadPlayListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPlayListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setModeFullToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setModeMiniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrHighlights = new System.Windows.Forms.Timer(this.components);
            this.mPlayer = new MediaPlayer.MediaPlayerUI.Player();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pbHighlights)).BeginInit();
            this.PlayerContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbHighlights
            // 
            this.pbHighlights.BackColor = System.Drawing.Color.Black;
            this.pbHighlights.ContextMenuStrip = this.PlayerContextMenuStrip;
            this.pbHighlights.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbHighlights.Location = new System.Drawing.Point(0, 191);
            this.pbHighlights.Name = "pbHighlights";
            this.pbHighlights.Size = new System.Drawing.Size(284, 20);
            this.pbHighlights.TabIndex = 2;
            this.pbHighlights.TabStop = false;
            this.pbHighlights.Paint += new System.Windows.Forms.PaintEventHandler(this.pbHighlights_Paint);
            // 
            // PlayerContextMenuStrip
            // 
            this.PlayerContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.PlayerContextMenuStrip.Name = "PlayerContextMenuStrip";
            this.PlayerContextMenuStrip.Size = new System.Drawing.Size(153, 92);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMediasToolStripMenuItem,
            this.savePlayListToolStripMenuItem,
            this.loadPlayListToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.fileToolStripMenuItem_DropDownItemClicked);
            // 
            // openMediasToolStripMenuItem
            // 
            this.openMediasToolStripMenuItem.Name = "openMediasToolStripMenuItem";
            this.openMediasToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openMediasToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.openMediasToolStripMenuItem.Text = "Open Media(s)";
            // 
            // savePlayListToolStripMenuItem
            // 
            this.savePlayListToolStripMenuItem.Name = "savePlayListToolStripMenuItem";
            this.savePlayListToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.savePlayListToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.savePlayListToolStripMenuItem.Text = "Save PlayList";
            // 
            // loadPlayListToolStripMenuItem
            // 
            this.loadPlayListToolStripMenuItem.Name = "loadPlayListToolStripMenuItem";
            this.loadPlayListToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.loadPlayListToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.loadPlayListToolStripMenuItem.Text = "Load PlayList";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPlayListToolStripMenuItem,
            this.setModeFullToolStripMenuItem,
            this.setModeMiniToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.viewToolStripMenuItem.Text = "View";
            this.viewToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.viewToolStripMenuItem_DropDownItemClicked);
            // 
            // showPlayListToolStripMenuItem
            // 
            this.showPlayListToolStripMenuItem.Name = "showPlayListToolStripMenuItem";
            this.showPlayListToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.showPlayListToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.showPlayListToolStripMenuItem.Text = "Show PlayList";
            // 
            // setModeFullToolStripMenuItem
            // 
            this.setModeFullToolStripMenuItem.Name = "setModeFullToolStripMenuItem";
            this.setModeFullToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.F)));
            this.setModeFullToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.setModeFullToolStripMenuItem.Text = "Set Mode Full";
            // 
            // setModeMiniToolStripMenuItem
            // 
            this.setModeMiniToolStripMenuItem.Name = "setModeMiniToolStripMenuItem";
            this.setModeMiniToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.M)));
            this.setModeMiniToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.setModeMiniToolStripMenuItem.Text = "Set Mode Mini";
            // 
            // tmrHighlights
            // 
            this.tmrHighlights.Enabled = true;
            this.tmrHighlights.Interval = 200;
            this.tmrHighlights.Tick += new System.EventHandler(this.tmrHighlights_Tick);
            // 
            // mPlayer
            // 
            this.mPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mPlayer.BackColor = System.Drawing.Color.Transparent;
            this.mPlayer.ContextMenuStrip = this.PlayerContextMenuStrip;
            this.mPlayer.Location = new System.Drawing.Point(0, 0);
            this.mPlayer.MediaControlBackColor = System.Drawing.Color.White;
            this.mPlayer.MediaControlForeColor = System.Drawing.Color.Black;
            this.mPlayer.MediaPositionTrackingBarBorderColor = System.Drawing.Color.Black;
            this.mPlayer.Name = "mPlayer";
            this.mPlayer.ShowAudioModeUI = true;
            this.mPlayer.ShowToolTips = true;
            this.mPlayer.Size = new System.Drawing.Size(284, 190);
            this.mPlayer.TabIndex = 0;
            this.mPlayer.VolumeTrackingBarBorderColor = System.Drawing.Color.Black;
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.helpToolStripMenuItem_DropDownItemClicked);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 211);
            this.ContextMenuStrip = this.PlayerContextMenuStrip;
            this.Controls.Add(this.pbHighlights);
            this.Controls.Add(this.mPlayer);
            this.Name = "MainForm";
            this.Text = "Media Player";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbHighlights)).EndInit();
            this.PlayerContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MediaPlayerUI.Player mPlayer;
        private System.Windows.Forms.PictureBox pbHighlights;
        private System.Windows.Forms.Timer tmrHighlights;
        private System.Windows.Forms.ContextMenuStrip PlayerContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMediasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem savePlayListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadPlayListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPlayListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setModeFullToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setModeMiniToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}