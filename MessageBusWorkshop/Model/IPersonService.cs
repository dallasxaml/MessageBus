using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MessageBusWorkshop.Model
{
    public interface IPersonService
    {
        Task<IEnumerable<Person>> LoadPeople();
        Task<Person> LoadPerson(int personId);
    }
}
