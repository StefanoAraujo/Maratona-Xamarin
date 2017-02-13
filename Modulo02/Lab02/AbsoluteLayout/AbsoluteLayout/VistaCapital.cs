using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AbsoluteLayout
{
    [Activity(Label ="VistaCapital")]
    public class VistaCapital : Activity
    {
        double defaultValue;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.VistaCapital);

            Button btnSair = FindViewById<Button>
                (Resource.Id.btnsair);
            EditText txtCapitalM = FindViewById<EditText>
                (Resource.Id.txtcapitalM);
            EditText txtCapitalB = FindViewById<EditText>
                (Resource.Id.txtcapitalB);
            ImageView imgBrasil = FindViewById<ImageView>
                (Resource.Id.imagenbra);
            ImageView imgMexico = FindViewById<ImageView>
                (Resource.Id.imagenmex);
            

            try
            {
                txtCapitalM.Text = Intent.GetDoubleExtra("CapitalM", defaultValue).ToString();
                txtCapitalB.Text = Intent.GetDoubleExtra("CapitalB", defaultValue).ToString();
                imgBrasil.SetImageResource(Resource.Drawable.Brasil);
                imgMexico.SetImageResource(Resource.Drawable.Mexico);

            }
            catch (Exception ex)
            {

                Toast.MakeText
                         (this, ex.Message,
                          ToastLength.Short).Show();
            }

            btnSair.Click += delegate
            {
                Process.KillProcess(Process.MyPid());
            };
        }
    }
}