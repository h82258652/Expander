using Windows.UI.Xaml;

namespace Demo
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Expander.ExpandDirection = Expander.ExpandDirection == ExpandDirection.Down ? ExpandDirection.Up : ExpandDirection.Down;
        }
    }
}