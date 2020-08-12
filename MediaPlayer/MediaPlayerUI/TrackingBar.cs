using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MediaPlayer.MediaPlayerUI
{
    public partial class TrackingBar : UserControl
    {
        //events-------------
        public event EventHandler TrackBarScroll = null;
        //private--------------
        private bool mouseisdown = false;
        private DateTime mousedowntime = DateTime.MinValue;

        private int GetTrackPosition(int cur_x_pos)
        {
            int total = this.pbTrackBar.Width;
            return (int)(((cur_x_pos * 100) / total));
        }

        private void SetValue(int clickpos)
        {
            var val = this.GetTrackPosition(clickpos);
            if (val >= this.pbTrackBar.Minimum && val <= this.pbTrackBar.Maximum)
            {
                this.Value = val;
            }
            this.TrackBarScroll?.Invoke(this, new EventArgs());
        }
        private void UpdateValue(int clickpos, int change)
        {
            int clkperc = this.GetTrackPosition(clickpos);
            if (clkperc != this.Value)
            {
                var val = clkperc > this.Value ? (this.Value + change) : (this.Value - change); ;
                if (val >= this.pbTrackBar.Minimum && val <= this.pbTrackBar.Maximum)
                {
                    this.Value = val;
                }
            }
            this.TrackBarScroll?.Invoke(this, new EventArgs());
        }
        private void UpdateValue(int change)
        {
            this.UpdateValue(this.pbTrackBar.PointToClient(Cursor.Position).X, change);
        }
        public TrackingBar()
        {
            InitializeComponent();
        }
        
        public int SmallChange { get; set; } = 2;
        public int LargeChange { get; set; } = 10;
        
        public int Value { get { return this.pbTrackBar.Value; } set { this.pbTrackBar.Value = value; } }

        public int BorderWidth { get; set; } = 2;
        public Color BorderColor { get; set; } = Color.Black;
        private void SetupUI()
        {
            this.pbTrackBar.Size = this.Size;
            this.pbTrackBar.Location = new Point(this.BorderWidth, this.BorderWidth);
            this.pbTrackBar.Size = new Size((this.pbTrackBar.Size.Width - (this.BorderWidth * 2)), (this.pbTrackBar.Size.Height - (this.BorderWidth * 2)));
            this.pbTrackBar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.BackColor = this.BorderColor;
        }
        private void customTrackBar_Load(object sender, EventArgs e)
        {
            this.SetupUI();
        }

        private void pbTrackBar_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                this.mouseisdown = true;
                this.mousedowntime = DateTime.Now;
                
                this.UpdateValue(e.X, e.Clicks > 1 ? this.LargeChange : this.SmallChange);
            }
        }

        private void pbTrackBar_MouseUp(object sender, MouseEventArgs e)
        {
            this.mouseisdown = false;
            double mdt = (DateTime.Now - this.mousedowntime).TotalMilliseconds;
            if (mdt < 100)
            {
                this.SetValue(e.X);
            }
        }
        private void pbTrackBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                this.UpdateValue(e.X, this.LargeChange);
            }

        }
        private void tmrClickRemain_Tick(object sender, EventArgs e)
        {
            if(mouseisdown)
            {
                this.UpdateValue(this.SmallChange);
            }
            
        }

        

        
    }
}
