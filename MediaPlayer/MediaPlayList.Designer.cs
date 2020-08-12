namespace MediaPlayer
{
    partial class MediaPlayList
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
            this.lstPlayList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btClose = new System.Windows.Forms.Button();
            this.tmrUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.btRemove = new System.Windows.Forms.Button();
            this.btClear = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.btLoadPlayList = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstPlayList
            // 
            this.lstPlayList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstPlayList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lstPlayList.FullRowSelect = true;
            this.lstPlayList.GridLines = true;
            this.lstPlayList.Location = new System.Drawing.Point(5, 5);
            this.lstPlayList.MultiSelect = false;
            this.lstPlayList.Name = "lstPlayList";
            this.lstPlayList.Size = new System.Drawing.Size(300, 300);
            this.lstPlayList.TabIndex = 0;
            this.lstPlayList.UseCompatibleStateImageBehavior = false;
            this.lstPlayList.View = System.Windows.Forms.View.Details;
            this.lstPlayList.DoubleClick += new System.EventHandler(this.lstPlayList_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "#";
            this.columnHeader1.Width = 35;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Title";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Duration";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Artist";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Album";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Composer";
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.Location = new System.Drawing.Point(255, 311);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(50, 23);
            this.btClose.TabIndex = 1;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // tmrUpdateTimer
            // 
            this.tmrUpdateTimer.Enabled = true;
            this.tmrUpdateTimer.Tick += new System.EventHandler(this.tmrUpdateTimer_Tick);
            // 
            // btRemove
            // 
            this.btRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btRemove.Location = new System.Drawing.Point(5, 311);
            this.btRemove.Name = "btRemove";
            this.btRemove.Size = new System.Drawing.Size(55, 23);
            this.btRemove.TabIndex = 2;
            this.btRemove.Text = "Remove";
            this.btRemove.UseVisualStyleBackColor = true;
            this.btRemove.Click += new System.EventHandler(this.btRemove_Click);
            // 
            // btClear
            // 
            this.btClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClear.Location = new System.Drawing.Point(66, 311);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(50, 23);
            this.btClear.TabIndex = 3;
            this.btClear.Text = "Clear";
            this.btClear.UseVisualStyleBackColor = true;
            this.btClear.Click += new System.EventHandler(this.btClear_Click);
            // 
            // btAdd
            // 
            this.btAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btAdd.Location = new System.Drawing.Point(122, 311);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(50, 23);
            this.btAdd.TabIndex = 4;
            this.btAdd.Text = "Add";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btLoadPlayList
            // 
            this.btLoadPlayList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btLoadPlayList.Location = new System.Drawing.Point(178, 311);
            this.btLoadPlayList.Name = "btLoadPlayList";
            this.btLoadPlayList.Size = new System.Drawing.Size(71, 23);
            this.btLoadPlayList.TabIndex = 5;
            this.btLoadPlayList.Text = "Load PL";
            this.btLoadPlayList.UseVisualStyleBackColor = true;
            this.btLoadPlayList.Click += new System.EventHandler(this.btLoadPlayList_Click);
            // 
            // MediaPlayList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 342);
            this.Controls.Add(this.btLoadPlayList);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.btClear);
            this.Controls.Add(this.btRemove);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.lstPlayList);
            this.Name = "MediaPlayList";
            this.Text = "Media play list";
            this.Load += new System.EventHandler(this.MediaPlayList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstPlayList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Timer tmrUpdateTimer;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Button btRemove;
        private System.Windows.Forms.Button btClear;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Button btLoadPlayList;
    }
}