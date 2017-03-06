using Cats.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Cats.ViewModels
{
    public class CatsViewModel : INotifyPropertyChanged
    {

        private bool Busy;

        public bool IsBusy
        {
            get { return Busy; }
            set
            {
                Busy = value;
                OnPropertyChange();
                GetCatsCommand.ChangeCanExecute();
            }
        }

        public Command GetCatsCommand { get; set; }

        public ObservableCollection<Cat> Cats { get; set; }

        public CatsViewModel()
        {
            Cats = new ObservableCollection<Cat>();
            GetCatsCommand = new Command(
                async () => await GetCats(),
                      () => !IsBusy);
        }

        private async Task GetCats()
        {
            if (!IsBusy)
            {
                Exception error = null;
                try
                {
                    IsBusy = true;
                    var repositorio = new Repository();
                    var itens = await repositorio.GetCats();

                    Cats.Clear();
                    foreach (var cat in itens)
                    {
                        Cats.Add(cat);
                    }
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Erro!", error.Message, "Ok");
                    error = ex;
                }
                finally
                {
                    IsBusy = false;
                }
            }

            return;
        }

        private void OnPropertyChange([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
