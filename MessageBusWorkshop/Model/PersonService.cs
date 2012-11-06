using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace MessageBusWorkshop.Model
{
    public class PersonService : IPersonService
    {
        private List<Person> _personTable;

        public PersonService()
        {
            _personTable = new List<Person>
            {
                new Person
                {
                    Id = 1,
                    FirstName = "Richard",
                    LastName = "Castle",
                    Phone = "555-2312",
                    Email = "Rick@Castle.com"
                },
                new Person
                {
                    Id = 2,
                    FirstName = "Kate",
                    LastName = "Becket",
                    Phone = "555-2981",
                    Email = "Kate.Becket@nypd.gov"
                },
                new Person
                {
                    Id = 3,
                    FirstName = "Javier",
                    LastName = "Esposito",
                    Phone = "555-2198",
                    Email = "Javier.Esposito@nypd.gov"
                },
                new Person
                {
                    Id = 4,
                    FirstName = "Kevin",
                    LastName = "Ryan",
                    Phone = "555-1987",
                    Email = "Kevin.Ryan@nypd.gov"
                },
            };
        }

        public void LoadPeople(Action<IEnumerable<Person>> callback)
        {
            ThreadPool.QueueUserWorkItem(delegate
            {
                Thread.Sleep(2000);
                callback(_personTable);
            });
        }

        public void LoadPerson(int personId, Action<Person> callback)
        {
            ThreadPool.QueueUserWorkItem(delegate
            {
                Thread.Sleep(1000);
                callback(_personTable.FirstOrDefault(p => p.Id == personId));
            });
        }
    }
}
