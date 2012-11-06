using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Threading;
using MessageBusWorkshop.Model;
using Microsoft.Practices.ServiceLocation;

namespace MessageBusWorkshop.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            DispatcherHelper.Initialize();
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<IPersonService, PersonService>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<PersonViewModel>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public PersonViewModel Person
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PersonViewModel>();
            }
        }
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}