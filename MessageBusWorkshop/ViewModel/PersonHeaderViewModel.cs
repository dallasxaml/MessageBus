using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;

namespace MessageBusWorkshop.ViewModel
{
    public class PersonHeaderViewModel : ViewModelBase
    {
        /// <summary>
        /// The <see cref="FullName" /> property's name.
        /// </summary>
        public const string FullNamePropertyName = "FullName";

        private string _fullName = String.Empty;

        /// <summary>
        /// Sets and gets the FullName property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string FullName
        {
            get
            {
                return _fullName;
            }

            set
            {
                if (_fullName == value)
                {
                    return;
                }

                RaisePropertyChanging(FullNamePropertyName);
                _fullName = value;
                RaisePropertyChanged(FullNamePropertyName);
            }
        }
    }
}
