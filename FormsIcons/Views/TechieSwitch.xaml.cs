using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormsIcons.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TechieSwitch
    {

        public TechieSwitch()
        {
            InitializeComponent();
        }

        private async void ClickGestureRecognizer_OnClicked(object sender, EventArgs e)
        {
            var position = new Rectangle
            {
                Left = 20,
                Top = 2,
                Width = 16,
                Height = 16
            };

            await Thumb.LayoutTo(position, 300, Easing.SinIn);
        }
    }
}