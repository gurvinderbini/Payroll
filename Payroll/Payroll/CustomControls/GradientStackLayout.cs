using Xamarin.Forms;

namespace Payroll.CustomControls
{
    public class GradientStackLayout:StackLayout
    {
        public static readonly BindableProperty StartColorProperty =
            BindableProperty.Create(nameof(StartColor),
                typeof(Color),
                typeof(GradientStackLayout),
                Color.Accent);

        public static readonly BindableProperty EndColorProperty =
            BindableProperty.Create(nameof(EndColor),
                typeof(Color),
                typeof(GradientStackLayout),
                Color.Accent);

        public Color StartColor
        {
            get => (Color)GetValue(StartColorProperty);
            set => SetValue(StartColorProperty, value);
        }

        public Color EndColor
        {
            get => (Color)GetValue(EndColorProperty);
            set => SetValue(EndColorProperty, value);
        }
    }
}
