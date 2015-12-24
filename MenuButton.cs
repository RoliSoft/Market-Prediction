namespace MarketPrediction
{
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Provides a modified button with a menu on the right.
    /// Originally from http://stackoverflow.com/a/24087828/156626
    /// </summary>
    public class MenuButton : Button
    {
        /// <summary>
        /// Gets or sets the menu.
        /// </summary>
        /// <value>The menu.</value>
        [DefaultValue(null)]
        public ContextMenuStrip Menu { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to show menu under cursor.
        /// </summary>
        /// <value><c>true</c> if show menu under cursor; otherwise, <c>false</c>.</value>
        [DefaultValue(false)]
        public bool ShowMenuUnderCursor { get; set; }

        /// <summary>
        /// Raises the <see cref="M:System.Windows.Forms.Control.OnMouseDown(System.Windows.Forms.MouseEventArgs)" /> event.
        /// </summary>
        /// <param name="mevent">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            if (Menu != null && mevent.Button == MouseButtons.Right)
            {
                Menu.Show(this, ShowMenuUnderCursor ? mevent.Location : new Point(0, Height));
            }
            else
            {
                base.OnMouseDown(mevent);
            }
        }

        /// <summary>
        /// Raises the <see cref="M:System.Windows.Forms.ButtonBase.OnPaint(System.Windows.Forms.PaintEventArgs)" /> event.
        /// </summary>
        /// <param name="pevent">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            if (Menu != null)
            {
                var arrowX = ClientRectangle.Width - 14;
                var arrowY = ClientRectangle.Height / 2 - 1;

                var brush  = Enabled ? SystemBrushes.ControlText : SystemBrushes.ButtonShadow;
                var arrows = new[] { new Point(arrowX, arrowY), new Point(arrowX + 7, arrowY), new Point(arrowX + 3, arrowY + 4) };

                pevent.Graphics.FillPolygon(brush, arrows);
            }
        }
    }
}
