using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Content;

namespace AbsoluteLayout
{
    [Activity(Label = "Conversor", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        double EntradasM, EntradasB, SaidasB, SaidasM, CapitalM, CapitalB;
        protected override void OnCreate(Bundle savedInstance)
        {
            base.OnCreate(savedInstance);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            Button btnCalcular = FindViewById<Button>
                 (Resource.Id.btnCalcular);
            EditText txtEntradasM = FindViewById<EditText>
                (Resource.Id.txtentradasM);
            EditText txtSaidasM = FindViewById<EditText>
                (Resource.Id.txtsaidasM);
            EditText txtEntradasB = FindViewById<EditText>
                (Resource.Id.txtentradasB);
            EditText txtSaidasB = FindViewById<EditText>
                (Resource.Id.txtsaidasB);

            btnCalcular.Click += delegate
            {
                try
                {
                    EntradasM = double.Parse(txtEntradasM.Text);
                    EntradasB = double.Parse(txtEntradasB.Text);
                    SaidasM = double.Parse(txtSaidasM.Text);
                    SaidasB = double.Parse(txtSaidasB.Text);
                    CapitalB = EntradasB - SaidasB;
                    CapitalM = EntradasM - SaidasM;

                    Carregar();

                }
                catch (Exception ex)
                {
                    Toast.MakeText
                        (this, ex.Message,
                         ToastLength.Short).Show();
                }
            };
        }

        private void Carregar()
        {
            Intent objIntent = new Intent(this, typeof(VistaCapital));
            objIntent.PutExtra("CapitalM", CapitalM);
            objIntent.PutExtra("CapitalB", CapitalB);
            StartActivity(objIntent);
        }
    }
}

