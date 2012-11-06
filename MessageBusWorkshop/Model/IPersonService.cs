using System;
using System.Collections.Generic;

namespace MessageBusWorkshop.Model
{
    public interface IPersonService
    {
        void LoadPeople(Action<IEnumerable<Person>> callback);
        void LoadPerson(int personId, Action<Person> callback);
    }
}
