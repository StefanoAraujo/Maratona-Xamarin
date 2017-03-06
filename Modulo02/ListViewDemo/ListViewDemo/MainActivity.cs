using Android.App;
using Android.Widget;
using Android.OS;

namespace ListViewDemo
{
    [Activity(Label = "ListViewDemo", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            var employeeList = new EmployeeList();
            var employees = employeeList.GetEmployees(20);

            ListView lvEmployees = FindViewById<ListView>
                (Resource.Id.lvEmployee);

            //Forma de exibir as informações com o adapter padrão 
            //var adapter = new ArrayAdapter<Employee>(this, Android.Resource.Layout.SimpleListItem1, employees);
            //lvEmployees.Adapter = adapter;

            //Forma de exibir as informações com o adapter personalizado. 
            EmployeeAdapter adapter = new EmployeeAdapter(employees);
            lvEmployees.Adapter = adapter;


        }
    }
}

