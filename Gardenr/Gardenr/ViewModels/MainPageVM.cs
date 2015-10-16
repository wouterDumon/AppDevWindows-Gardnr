using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gardenr.ViewModels
{
    //erven niet vergeten is verplicht!
    public class MainePageVM : ViewModelBase
    {
       /* private ICountryRepository repoCountries = SimpleIoc.Default.GetInstance<ICountryRepository>();

        public List<Country> Countries { get; set; }
        public Registration NewRegistration { get; set; }


        public void GoTNextPage()
        {
            GoToPageMessage message = new GoToPageMessage() { PageNumber = 1 };
            Messenger.Default.Send<GoToPageMessage>(message);
        }
        public ObservableCollection<Registration> Registrations { get; set; }
        */
        public MainePageVM()
        {
           /* NewRegistration = new Registration();
            SaveCommand = new RelayCommand(Save);
            Countries = repoCountries.GetCountries();
            Registrations = new ObservableCollection<Registration>();
            NextPageCommand = new RelayCommand(GoTNextPage);*/

        }
      /*  private void Save()
        {
            Registrations.Add(NewRegistration);

        }
        public RelayCommand SaveCommand
        {
            get; set;
        }
        public RelayCommand NextPageCommand { get; set; }
        */
    }
}
