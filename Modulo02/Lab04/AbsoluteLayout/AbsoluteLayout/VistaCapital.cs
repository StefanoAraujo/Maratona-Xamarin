using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

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

                var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                path = Path.Combine(path, "Base.db3");

                var conn = new SQLiteConnection(path);

                var elementos = from s in conn.Table<Informacao>()
                                select s;

                foreach (var fila in elementos)
                {
                    Toast.MakeText(this, $"Entradas x Saidas Mexico: {fila.EntradasMexico} x {fila.SaidasMexico}", ToastLength.Short).Show();
                    Toast.MakeText(this, $"Entradas x Saidas Brasil: {fila.EntradasBrasil} x {fila.SaidasBrasil}", ToastLength.Short).Show();
                }

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