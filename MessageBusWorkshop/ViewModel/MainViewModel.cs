using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Threading;
using MessageBusWorkshop.Model;
using MessageBusWorkshop.Messages;
using System.Linq;

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
                            Id = person.Id,
                            FullName = String.Format("{0}, {1}",
                                person.LastName,
                                person.FirstName)
                        });
                });
            });

            MessengerInstance.Register<PersonNameChanged>(this, message =>
            {
                var person = _people.FirstOrDefault(p => p.Id == message.PersonId);
                if (person != null)
                    person.FullName = String.Format("{0}, {1}", message.LastName, message.FirstName);
            });
        }

        public IEnumerable<PersonHeaderViewModel> People
        {
            get { return _people; }
        }

        /// <summary>
        /// The <see cref="SelectedPerson" /> property's name.
        /// </summary>
        public const string SelectedPersonPropertyName = "SelectedPerson";

        private PersonHeaderViewModel _selectedPerson = null;

        /// <summary>
        /// Sets and gets the SelectedPerson property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public PersonHeaderViewModel SelectedPerson
        {
            get
            {
                return _selectedPerson;
            }

            set
            {
                if (_selectedPerson == value)
                {
                    return;
                }

                RaisePropertyChanging(SelectedPersonPropertyName);
                _selectedPerson = value;
                RaisePropertyChanged(SelectedPersonPropertyName);

                MessengerInstance.Send(new PersonSelected
                {
                    PersonId = value.Id
                });
            }
        }
    }
}