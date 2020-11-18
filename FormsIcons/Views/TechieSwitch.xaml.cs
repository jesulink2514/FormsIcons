using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormsIcons.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TechieSwitch : ITechiesSwitchController
    {
        public static BindableProperty IsOnProperty = BindableProperty.Create(nameof(IsOn), typeof(bool),
            typeof(TechieSwitch), false, BindingMode.TwoWay, propertyChanged: OnPropertyChanged);

        public static BindableProperty ThumbBrushProperty = BindableProperty.Create(nameof(ThumbBrush), typeof(Brush),
            typeof(TechieSwitch), SolidColorBrush.Blue, BindingMode.TwoWay, propertyChanged: OnBrushPropertyChanged);

        public static BindableProperty BorderBrushProperty = BindableProperty.Create(nameof(BorderBrush), typeof(Brush),
            typeof(TechieSwitch), SolidColorBrush.Blue, BindingMode.TwoWay, propertyChanged: OnBrushPropertyChanged);


        public TechieSwitch()
        {
            InitializeComponent();
            SizeChanged += TechieSwitch_SizeChanged;
        }

        private void TechieSwitch_SizeChanged(object sender, EventArgs e)
        {
            (this as ITechiesSwitchController).SetUITo(IsOn);
        }

        public bool IsOn
        {
            get => (bool)GetValue(IsOnProperty);
            set => SetValue(IsOnProperty, value);
        }

        public Brush ThumbBrush
        {
            get => GetValue(ThumbBrushProperty) as Brush;
            set => SetValue(ThumbBrushProperty, value);
        }

        public Brush BorderBrush
        {
            get => GetValue(BorderBrushProperty) as Brush;
            set => SetValue(BorderBrushProperty,value);
        }

        private void ClickGestureRecognizer_OnClicked(object sender, EventArgs e)
        {
            IsOn = !IsOn;
        }

        private static void OnPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            (bindable as ITechiesSwitchController).SetUITo((bool)newvalue);
        }
        private static void OnBrushPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var switchControl = bindable as TechieSwitch;
            (bindable as ITechiesSwitchController).SetUITo(switchControl.IsOn);
        }
        private void RaisePropertyChanged(string propertyName)
        {
            this.OnPropertyChanged(propertyName);
        }

        async void ITechiesSwitchController.SetUITo(bool valueToShow)
        {
            var position = new Rectangle
            {
                Left = 20,
                Top = 2,
                Width = 16,
                Height = 16
            };

            var uncheckedPosition = new Rectangle
            {
                Left = 2,
                Top = 2,
                Width = 16,
                Height = 16
            };

            await Thumb.LayoutTo(valueToShow ? position : uncheckedPosition, 300, Easing.SinIn);

            Thumb.Fill = ThumbBrush;
            Border.Fill = BorderBrush;
        }
    }

    internal interface ITechiesSwitchController
    {
        void SetUITo(bool valueToShow);
    }
}