using System.Windows.Media;

namespace GW2PAO.Views
{
    public class NotificationWindow : OverlayWindow
    {
        private readonly Brush background;

        public NotificationWindow()
        {
            this.background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
            {
                Opacity = 0,
            };
            this.Background = background;
        }

        protected override Brush GetBackgroundBrush()
        {
            return background;
        }
    }
}
