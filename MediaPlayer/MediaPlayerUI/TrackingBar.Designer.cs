namespace MediaPlayer.MediaPlayerUI
{
    partial class TrackingBar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pbTrackBar = new System.Windows.Forms.ProgressBar();
            this.tmrClickRemain = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // pbTrackBar
            // 
            this.pbTrackBar.BackColor = System.Drawing.Color.Red;
            this.pbTrackBar.ForeColor = System.Drawing.Color.Red;
            this.pbTrackBar.Location = new System.Drawing.Point(0, 0);
            this.pbTrackBar.Name = "pbTrackBar";
            this.pbTrackBar.Size = new System.Drawing.Size(50, 20);
            this.pbTrackBar.TabIndex = 0;
            this.pbTrackBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbTrackBar_MouseDown);
            this.pbTrackBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbTrackBar_MouseMove);
            this.pbTrackBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbTrackBar_MouseUp);
            // 
            // tmrClickRemain
            // 
            this.tmrClickRemain.Enabled = true;
            this.tmrClickRemain.Tick += new System.EventHandler(this.tmrClickRemain_Tick);
            // 
            // customTrackBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbTrackBar);
            this.Name = "customTrackBar";
            this.Size = new System.Drawing.Size(100, 20);
            this.Load += new System.EventHandler(this.customTrackBar_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbTrackBar;
        private System.Windows.Forms.Timer tmrClickRemain;
    }
}
