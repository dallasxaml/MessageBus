using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Threading;
using MessageBusWorkshop.Model;

namespace MessageBusWorkshop.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IPersonService _personService;

        private ObservableCollection<PersonHeaderViewModel> _people;

        public MainViewModel(IPersonService personService)
        {
            _personService = personService;

            _people = new ObservableCollection<PersonHeaderViewModel>();
            _personService.LoadPeople(people =>
            {
                DispatcherHelper.CheckBeginInvokeOnUI(delegate
                {
                    foreach (var person in people)
                        _people.Add(new PersonHeaderViewModel
                        {
                            FullName = String.Format("{0}, {1}", person.LastName, person.FirstName)
                        });
                });
            });
        }

        public IEnumerable<PersonHeaderViewModel> People
        {
            get { return _people; }
        }
    }
}