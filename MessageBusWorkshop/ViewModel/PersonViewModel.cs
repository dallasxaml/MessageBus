﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using MessageBusWorkshop.Messages;
using MessageBusWorkshop.Model;

namespace MessageBusWorkshop.ViewModel
{
    public class PersonViewModel : ViewModelBase
    {
        private readonly IPersonService _personService;

        public PersonViewModel(IPersonService personService)
        {
            _personService = personService;

            MessengerInstance.Register<PersonSelected>(this, delegate (PersonSelected message)
            {
                _personService.LoadPerson(message.PersonId, person =>
                {
                    FirstName = person.FirstName;
                    LastName = person.LastName;
                    Email = person.Email;
                    Phone = person.Phone;
                });
            });
        }

        /// <summary>
        /// The <see cref="FirstName" /> property's name.
        /// </summary>
        public const string FirstNamePropertyName = "FirstName";

        private string _firstName = String.Empty;

        /// <summary>
        /// Sets and gets the FirstName property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string FirstName
        {
            get
            {
                return _firstName;
            }

            set
            {
                if (_firstName == value)
                {
                    return;
                }

                RaisePropertyChanging(FirstNamePropertyName);
                _firstName = value;
                RaisePropertyChanged(FirstNamePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="LastName" /> property's name.
        /// </summary>
        public const string LastNamePropertyName = "LastName";

        private string _lastName = String.Empty;

        /// <summary>
        /// Sets and gets the LastName property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string LastName
        {
            get
            {
                return _lastName;
            }

            set
            {
                if (_lastName == value)
                {
                    return;
                }

                RaisePropertyChanging(LastNamePropertyName);
                _lastName = value;
                RaisePropertyChanged(LastNamePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Email" /> property's name.
        /// </summary>
        public const string EmailPropertyName = "Email";

        private string _email = String.Empty;

        /// <summary>
        /// Sets and gets the Email property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                if (_email == value)
                {
                    return;
                }

                RaisePropertyChanging(EmailPropertyName);
                _email = value;
                RaisePropertyChanged(EmailPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Phone" /> property's name.
        /// </summary>
        public const string PhonePropertyName = "Phone";

        private string _phone = String.Empty;

        /// <summary>
        /// Sets and gets the Phone property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Phone
        {
            get
            {
                return _phone;
            }

            set
            {
                if (_phone == value)
                {
                    return;
                }

                RaisePropertyChanging(PhonePropertyName);
                _phone = value;
                RaisePropertyChanged(PhonePropertyName);
            }
        }
    }
}