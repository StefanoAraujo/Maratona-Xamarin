using System;
using Xamarin.Forms;

namespace Greetings
{
    public class GreetingsPage : ContentPage
    {
        public GreetingsPage()
        {
            var MyLabel = new Label();
            MyLabel.Text = "Greetings, Xamarin.Forms";
            this.Content = MyLabel;

            //solução 1
            //Padding = new Thickness(0, 20, 0, 0);

            //solução 2
            Padding = Device.OnPlatform<Thickness>(
                new Thickness(0, 20, 0, 0),
                new Thickness(0),
                new Thickness(0));

            MyLabel.HorizontalOptions = LayoutOptions.Center;
            MyLabel.VerticalOptions = LayoutOptions.Center;

            MyLabel.HorizontalTextAlignment = TextAlignment.Center;
            MyLabel.VerticalTextAlignment = TextAlignment.Center;
        }
    }
}
