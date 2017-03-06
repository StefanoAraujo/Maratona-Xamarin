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

namespace ListViewDemo
{
    public class Employee
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string position;

        public string Position
        {
            get { return position; }
            set { position = value; }
        }
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public Employee(string name, string position, string email)
        {
            Name = name;
            Position = position;
            Email = email;
        }

        public override string ToString()
        {
            return name;
        }
    }

    public class EmployeeList
    {
        public Employee[] GetEmployees(int number)
        {
            Employee[] employees = new Employee[number];
            String[] nomes = { "Daniel", "Cibely", "Vander", "Helenice", "Daniela", "Jordan", "Expedito", "Antusia", "Dayse", "Antusia", "Moacir", "Monica", "Elaine", "Angelo" };
            String[] positions = { "Supervisor", "Operador", "Gerente", "Diretor" };
            var rdn = new Random();

            for (int i = 0; i < number; i++)
            {
                var name = nomes[rdn.Next(0, 13)];

                var newEmployee = new Employee(
                    name,
                    positions[rdn.Next(0, 3)],
                    $"{name}@myapp.com"
                    );
                employees[i] = newEmployee;
            }
            return employees;
        }
    }

}   