using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormsIcons
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Sharpnado.Tabs.Initializer.Initialize(loggerEnable:false,debugLogEnable:true);
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
