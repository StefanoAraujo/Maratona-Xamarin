using Android.App;
using Android.Widget;
using Android.OS;
using System;

namespace AbsoluteLayout
{
    [Activity(Label = "Conversor", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstance)
        {
            base.OnCreate(savedInstance);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            Button btnConverter = FindViewById<Button>(Resource.Id.btnConverter);
            EditText txtDolares = FindViewById<EditText>(Resource.Id.txtdolares);
            EditText txtReais = FindViewById<EditText>(Resource.Id.txtreais);

            double reais, dolares;

            btnConverter.Click += delegate
            {
                try
                {
                    dolares = double.Parse(txtDolares.Text);
                    reais = dolares * 3.12;
                    txtReais.Text = reais.ToString();
                    if(Convert.ToDouble(txtReais.Text) > 500)
                        Toast.MakeText(this, "Esse dolar tá muito caro!", ToastLength.Short).Show();
                }
                catch (System.Exception ex)
                {
                    Toast.MakeText
                    (this, ex.Message, ToastLength.Short).Show();
                }
            };
        }
    }
}

